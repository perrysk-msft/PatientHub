
# coding: utf-8

# In[ ]:

import argparse
import os
import pickle
import re
import subprocess
import urllib

import numpy as np
import pandas as pd
from sqlalchemy import create_engine
from azureml.core.model import Model
import pyodbc

import os

commands = [
    "apt-get update && apt-get install curl apt-transport-https -y",
    "curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add -",
    "curl https://packages.microsoft.com/config/ubuntu/16.04/prod.list > /etc/apt/sources.list.d/mssql-release.list",
    "apt-get update",
    "ACCEPT_EULA=Y apt-get install msodbcsql17 -y",
    "ACCEPT_EULA=Y apt-get install mssql-tools -y",
    "echo 'export PATH=\"$PATH:/opt/mssql-tools/bin\"' >> ~/.bash_profile",
    "echo 'export PATH=\"$PATH:/opt/mssql-tools/bin\"' >> ~/.bashrc",
    "source ~/.bashrc",
    "apt-get install unixodbc-dev -y",

]

for cmd in commands:
    print(cmd)
    os.system(cmd)


parser = argparse.ArgumentParser(
    description="Start Batch Scoring")
parser.add_argument('--model_name', dest="model_name", required=True)
parser.add_argument('--input_csv', dest="input_csv", required=True)


args = parser.parse_args()
server = 'ace-demo-server.database.windows.net'
database = 'PatientHub'
username = 'demo'
password = 'YourPassword1!'
driver = '{ODBC Driver 17 for SQL Server}'
connection_string = 'DRIVER='+driver+';SERVER='+server + \
    ';PORT=1433;DATABASE='+database+';UID='+username+';PWD=' + password
cnxn = pyodbc.connect(connection_string)
command = "SELECT * FROM dbo.Patient"
train = pd.read_sql(command, cnxn, index_col='Id')
train.drop(['FirstName', 'LastName', 'patient_nbr'], axis=1, inplace=True)

train['discharge_disposition_id'] = train['discharge_disposition_id'].astype(
    'object')
train['admission_type_id'] = train['admission_type_id'].astype('object')
train['admission_source_id'] = train['admission_source_id'].astype('object')


# In[ ]:


def bin_less_common_levels(train, col_name, in_list):
    """ Places less common categorical levels into an 'Other' bin.

    :param train: Training set.
    :param test: Test set.
    :param col_name: Name of column in which to create 'Other' bin.
    :param in_list: List of levels NOT to be binned.

    """

    # if the level is not in in_list, set it to 'Other'
    train.loc[~train[col_name].isin(in_list), col_name] = 'Other'

    # print summary of changes
    # print('Train levels after binning:\n', train[col_name].value_counts())


# In[ ]:


# first 14 levels contain reasonable amount of info
in_list = list(train['discharge_disposition_id'].value_counts()[:14].index)
# set all other levels to 'Other'
bin_less_common_levels(train, 'discharge_disposition_id', in_list)

# first 10 levels contain reasonable amount of info
in_list = list(train['medical_specialty'].value_counts()[:10].index)
# set all other levels to 'Other'
bin_less_common_levels(train, 'medical_specialty', in_list)

# first 20 levels contain reasonable amount of info
in_list = list(train['diag_1'].value_counts()[:20].index)
# set all other levels to 'Other'
bin_less_common_levels(train, 'diag_1', in_list)
# first 20 levels contain reasonable amount of info
in_list = list(train['diag_2'].value_counts()[:20].index)
# set all other levels to 'Other'
bin_less_common_levels(train, 'diag_2', in_list)
# first 20 levels contain reasonable amount of info
in_list = list(train['diag_3'].value_counts()[:20].index)
# set all other levels to 'Other'
bin_less_common_levels(train, 'diag_3', in_list)


# In[ ]:


# constant column
constants = ['acetohexamide', 'examide', 'citoglipton', 'citoglipton',
             'glimepiride-pioglitazone', 'metformin-rosiglitazone', 'metformin-pioglitazone']

y = 'readmitted'  # modeling prediction target

# python sets allow for subtraction, lists do not
# used here to find the categorical variables that should be dummy-encoded for modeling
# convert back to a list for later use
encodes = list(set(train.select_dtypes(
    include=['object']).columns) - set(constants + [y]))


# In[ ]:


# drop the original categorical variables
# then join the dummy-encoded versions of the same categorical variables back into the data

train = pd.concat([train.drop(encodes, axis=1),
                   pd.get_dummies(train[encodes])],
                  axis=1)


for name in train.columns:
    # use python replace function to replace common '_?' suffix
    # use regex to catch everything else
    train.rename(columns={name: name.replace('_?', '_q')}, inplace=True)
    train.rename(columns={name: re.sub(
        '[^0-9a-zA-Z]+', '_', name)}, inplace=True)

train.drop(['admission_source_id_11', 'admission_source_id_25',
            'payer_code_FR', 'admission_source_id_13'], axis=1, inplace=True)


# In[ ]:


# names of drops were changed in steps above, must redefine ('-' became '_')
constants = ['acetohexamide', 'examide', 'citoglipton', 'citoglipton', 'glimepiride_pioglitazone', 'metformin_rosiglitazone',
             'metformin_pioglitazone']

# everything that is not constant, an identifier, or the modeling target will be a modeling input
X = [name for name in train.columns if name not in [
    y] + constants + ['id', 'patient_nbr']]

# print summary
# print('y =', y)
# print('X =', X)


# In[ ]:


# xgboost treats all columns as numeric - no matter what
# any values that can't be converted easily will be NaN - XGBoost does handle NaN elegantly
train[X] = train[X].apply(pd.to_numeric, errors='coerce', axis=1)


# In[ ]:


# convert target to numeric value
# readmit = NO -> 0
# readmit = YES -> 1
train.loc[train[y] == 'NO', y] = '0'
train.loc[train[y] != '0', y] = '1'
train[y] = train[y].apply(pd.to_numeric)


def shap_localexplain_df(input_df):
    """ Summarize local Shapley information. 

    :param row: The row to explain from numpy array of Shapley values.

    """
    global args
    shap_values = np.loadtxt(args.input_csv, delimiter=',')  # load
    # print confirmation
    print('Pre-calculated Shapley values loaded from disk.')

    # this needs to read from AML later
    model_path = Model.get_model_path(args.model_name)
    model = pickle.load(
        open(model_path, 'rb'))

    # select shapley values for row
    # reshape into column vector
    # convert to pandas dataframe for easy plotting
    for index, row in enumerate(input_df.iterrows()):
        print(index)

        s_df = pd.DataFrame(shap_values[index, :][:-1],
                            columns=['Approximate Local Contributions'],
                            index=model.feature_names)  # must use feature_names for consistent results
        # print(shap_values)
        # sort dataframe by shapley values and print values
        s_df = s_df.sort_values(
            by='Approximate Local Contributions').T.reset_index()
        # print(s_df.at['index'])
        # drop additional column
        s_df.at[0, 'index'] = index
        s_df.set_index(['index'], inplace=True)
        #print(s_df, '\n')
        if index == 0:
            df_return = s_df
        else:
            df_return = pd.concat([df_return, s_df])
            # print(df_return)
    return df_return

    # plot top positive contributors for this row
    #_= s_df.iloc[-5:,:].plot(kind='bar', title='Approximate Local Contributions', legend=False)

    # manually calculate sum of shapley values for row
    #print('Shapley sum: ', s_df['Approximate Local Contributions'].sum() + shap_values[row.index[0], -1])

    # manually calculate actual model prediction before application of logit link function
    #p = row['predict'].values[0]
    # print('Model prediction: ', np.log(p/(1 - p))) # inverse logit


# In[ ]:


# row1 = train.iloc[[2]]
# print(row1.index[0])
localexp_df = shap_localexplain_df(train)
# localexp_df


# In[ ]:


params = urllib.parse.quote_plus(connection_string)
engine = create_engine("mssql+pyodbc:///?odbc_connect=%s" % params).connect()

localexp_df.to_sql('xiaoyongtest', con=engine, if_exists='replace',
                   index_label='index', index=True, schema='ml', chunksize=100)

print("Done!")
