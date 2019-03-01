x = ['LogisticRegression', 'ElasticNet', 'RandomForestClassifier', 'GradientBoostingRegressor', 'SGDRegressor', 'LassoLars', 'SVCWrapper', 'SVM', 'kNN regressor', 'KNeighborsClassifier', 'NBWrapper', 'LinearSVMWrapper', 'RandomForestRegressor', 'DecisionTreeClassifier', 'kNN', 'DecisionTreeRegressor', 'ExtraTreesClassifier', 'KNeighborsRegressor', 'SGDClassifierWrapper', 'LightGBMClassifier', 'ExtraTreesRegressor']
print(len(x))
import numpy as np
import json
import pandas as pd
item_to_score = ['Caucasian', 'Female', '[0-10)', '?', 6, 25, 1,
        1, '?', 'Pediatrics-Endocrinology', 41, 0, 1, 0, 0, 0, '250.83',
        '?', '?', 1, 'None', 'None', 'No', 'No', 'No', 'No', 'No', 'No',
        'No', 'No', 'No', 'No', 'No', 'No', 'No', 'No', 'No', 'No', 'No',
        'No', 'No', 'No', 'No', 'No', 'No', 'No', 'No']

item_to_score_string = [str(i) for i in item_to_score]
print(item_to_score_string)
# Two sets of data to score, so we get two results back
rawdata = {"data": 
            [
                item_to_score_string
            ]
        }
input_data = json.dumps(rawdata)
data = json.loads(input_data)['data']
print("data is", data, "len is", len(data))
df_raw = pd.DataFrame(data=data, columns=['race', 'gender', 'age', 'weight',
'admission_type_id', 'discharge_disposition_id', 'admission_source_id',
'time_in_hospital', 'payer_code', 'medical_specialty',
'num_lab_procedures', 'num_procedures', 'num_medications',
'number_outpatient', 'number_emergency', 'number_inpatient', 'diag_1',
'diag_2', 'diag_3', 'number_diagnoses', 'max_glu_serum', 'A1Cresult',
'metformin', 'repaglinide', 'nateglinide', 'chlorpropamide',
'glimepiride', 'acetohexamide', 'glipizide', 'glyburide', 'tolbutamide',
'pioglitazone', 'rosiglitazone', 'acarbose', 'miglitol', 'troglitazone',
'tolazamide', 'examide', 'citoglipton', 'insulin',
'glyburide-metformin', 'glipizide-metformin',
'glimepiride-pioglitazone', 'metformin-rosiglitazone',
'metformin-pioglitazone', 'change', 'diabetesMed'])
to_drop = ['acetohexamide', 'troglitazone', 'examide', 'citoglipton',
'glipizide-metformin', 'glimepiride-pioglitazone',
'metformin-pioglitazone', 'weight', 'patient_nbr', 'encounter_id']
df_raw.drop(to_drop, axis=1, inplace=True, errors = 'ignore')
df_raw = df_raw.replace('?', np.nan) 
spec_counts_raw = {"specs": ['InternalMedicine', 'Emergency/Trauma', 'Family/GeneralPractice',
    'Cardiology', 'Surgery-General'], "num patients": [14635,  7565,  7440,  5352,  3099]}

spec_counts = pd.DataFrame(spec_counts_raw, columns = ['specs', "num patients"]).set_index(["specs"])
spec_thresh = 5
for (spec, count) in spec_counts.head(spec_thresh).iteritems():
    new_col = 'spec_' + str(spec)
    df_raw[new_col] = (df_raw.medical_specialty == spec)
    print(df_raw[new_col])
# print("df_raw is", df_raw)