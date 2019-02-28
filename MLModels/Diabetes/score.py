import pickle
import json
import numpy
import azureml.train.automl
from sklearn.externals import joblib
from azureml.core.model import Model
import pandas as pd
import numpy as np


def init():
    global model
    model_path = Model.get_model_path(model_name = 'AutoML64cb64a1a8') # this name is model.id of model that we want to deploy
    # deserialize the model file back into a sklearn model
    model = joblib.load(model_path)

def run(rawdata):
    try:
        data = json.loads(rawdata)['data']
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

        spec_counts_raw = {"specs": ['InternalMedicine', 'Emergency/Trauma', 'Family/GeneralPractice',
               'Cardiology', 'Surgery-General'], "num patients": [14635,  7565,  7440,  5352,  3099]}
        df_raw['medical_specialty'] = df_raw['medical_specialty'].replace(np.nan, "NaNSpec")
        spec_counts = pd.DataFrame(data = spec_counts_raw)
        spec_thresh = 5
        for (index, row) in spec_counts.head(spec_thresh).iterrows():
            spec = row['specs']
            new_col = 'spec_' + str(spec)
            df_raw[new_col] = (df_raw.medical_specialty == spec)


        diag_counts_raw = {"icd9value": ['428', '250', '276', '414', '401', '427', '599', '496', '403', '486'], 'num patients w diag': [18101., 17861., 13816., 12895., 12371., 11757.,  6824.,  5990.,
                5693.,  5455.]}

        diag_counts = pd.DataFrame(diag_counts_raw, columns = [ 'icd9value', 'num patients w diag'])
        df_raw['diag_1'] = df_raw['diag_1'].replace(np.nan, "NaNSpec")
        df_raw['diag_2'] = df_raw['diag_2'].replace(np.nan, "NaNSpec")
        df_raw['diag_3'] = df_raw['diag_3'].replace(np.nan, "NaNSpec")
        diag_thresh = 10
        for (index, row) in diag_counts.head(diag_thresh).iterrows():
            icd9 = row['icd9value']
            new_col = 'diag_' + str(icd9)
            df_raw[new_col] = (df_raw.diag_1 == icd9)|(df_raw.diag_2 == icd9)|(df_raw.diag_3 == icd9)

        df_raw2 = pd.DataFrame(df_raw, copy=True) #preserve df_raw so I can rerun this step
        df_raw2['age'] = df_raw2.age.str.extract('(\d+)-\d+')

        to_drop = ['acetohexamide', 'troglitazone', 'examide', 'citoglipton',
            'glipizide-metformin', 'glimepiride-pioglitazone',
            'metformin-pioglitazone', 'weight', 'medical_specialty', 'diag_2',
            'diag_1', 'diag_3', 'patient_nbr', 'encounter_id']
        df_raw2.drop(to_drop, axis=1, inplace=True,errors = 'ignore')

        #break out categorical variables into binaries
        cat_cols = ['gender', 'tolbutamide', 'acarbose', 'miglitol', 'tolazamide',
            'metformin-rosiglitazone', 'change', 'diabetesMed',
            'glyburide-metformin', 'max_glu_serum', 'A1Cresult',
            'metformin', 'repaglinide', 'nateglinide', 'chlorpropamide',
            'glimepiride', 'glipizide', 'glyburide', 'pioglitazone',
            'rosiglitazone', 'insulin', 'race', 'admission_type_id',
            'admission_source_id', 'payer_code', 'discharge_disposition_id']
        target_cols = ['age', 'time_in_hospital', 'num_lab_procedures', 'num_procedures', 'num_medications', 'number_outpatient', 'number_emergency', 'number_inpatient', 'number_diagnoses', 'spec_num patients', 'diag_num patients w diag', 'gender_Female', 'gender_Male', 'gender_Unknown/Invalid', 'tolbutamide_No', 'tolbutamide_Steady', 'acarbose_Down', 'acarbose_No', 'acarbose_Steady', 'acarbose_Up', 'miglitol_Down', 'miglitol_No', 'miglitol_Steady', 'miglitol_Up', 'tolazamide_No', 'tolazamide_Steady', 'tolazamide_Up', 'metformin-rosiglitazone_No', 'metformin-rosiglitazone_Steady', 'change_Ch', 'change_No', 'diabetesMed_No', 'diabetesMed_Yes', 'glyburide-metformin_Down', 'glyburide-metformin_No', 'glyburide-metformin_Steady', 'glyburide-metformin_Up', 'max_glu_serum_>200', 'max_glu_serum_>300', 'max_glu_serum_None', 'max_glu_serum_Norm', 'A1Cresult_>7', 'A1Cresult_>8', 'A1Cresult_None', 'A1Cresult_Norm', 'metformin_Down', 'metformin_No', 'metformin_Steady', 'metformin_Up', 'repaglinide_Down', 'repaglinide_No', 'repaglinide_Steady', 'repaglinide_Up', 'nateglinide_Down', 'nateglinide_No', 'nateglinide_Steady', 'nateglinide_Up', 'chlorpropamide_Down', 'chlorpropamide_No', 'chlorpropamide_Steady', 'chlorpropamide_Up', 'glimepiride_Down', 'glimepiride_No', 'glimepiride_Steady', 'glimepiride_Up', 'glipizide_Down', 'glipizide_No', 'glipizide_Steady', 'glipizide_Up', 'glyburide_Down', 'glyburide_No', 'glyburide_Steady', 'glyburide_Up', 'pioglitazone_Down', 'pioglitazone_No', 'pioglitazone_Steady', 'pioglitazone_Up', 'rosiglitazone_Down', 'rosiglitazone_No', 'rosiglitazone_Steady', 'rosiglitazone_Up', 'insulin_Down', 'insulin_No', 'insulin_Steady', 'insulin_Up', 'race_AfricanAmerican', 'race_Asian', 'race_Caucasian', 'race_Hispanic', 'race_Other', 'admission_type_id_1', 'admission_type_id_2', 'admission_type_id_3', 'admission_type_id_4', 'admission_type_id_5', 'admission_type_id_6', 'admission_type_id_7', 'admission_type_id_8', 'admission_source_id_1', 'admission_source_id_2', 'admission_source_id_3', 'admission_source_id_4', 'admission_source_id_5', 'admission_source_id_6', 'admission_source_id_7', 'admission_source_id_8', 'admission_source_id_9', 'admission_source_id_10', 'admission_source_id_11', 'admission_source_id_13', 'admission_source_id_14', 'admission_source_id_17', 'admission_source_id_20', 'admission_source_id_22', 'admission_source_id_25', 'payer_code_BC', 'payer_code_CH', 'payer_code_CM', 'payer_code_CP', 'payer_code_DM', 'payer_code_FR', 'payer_code_HM', 'payer_code_MC', 'payer_code_MD', 'payer_code_MP', 'payer_code_OG', 'payer_code_OT', 'payer_code_PO', 'payer_code_SI', 'payer_code_SP', 'payer_code_UN', 'payer_code_WC', 'discharge_disposition_id_1', 'discharge_disposition_id_2', 'discharge_disposition_id_3', 'discharge_disposition_id_4', 'discharge_disposition_id_5', 'discharge_disposition_id_6', 'discharge_disposition_id_7', 'discharge_disposition_id_8', 'discharge_disposition_id_9', 'discharge_disposition_id_10', 'discharge_disposition_id_11', 'discharge_disposition_id_12', 'discharge_disposition_id_13', 'discharge_disposition_id_14', 'discharge_disposition_id_15', 'discharge_disposition_id_16', 'discharge_disposition_id_17', 'discharge_disposition_id_18', 'discharge_disposition_id_19', 'discharge_disposition_id_20', 'discharge_disposition_id_22', 'discharge_disposition_id_23', 'discharge_disposition_id_24', 'discharge_disposition_id_25', 'discharge_disposition_id_27', 'discharge_disposition_id_28', 'is_readmitted']
        df_raw2 = pd.get_dummies(df_raw2, columns=cat_cols)
        nonexisted_cols = list(set(target_cols) - set(df_raw2.columns))
        # print("nonexisted_cols",nonexisted_cols, len(nonexisted_cols))
        for col in nonexisted_cols:
            df_raw2.insert(0, col, 0)
        #dropping these leaves up with one binary variable, ideal for simplicity
        df_raw2.drop(['readmitted_<30','readmitted_>30'], axis=1, inplace=True, errors = 'ignore')

        df_raw2.drop('readmitted_NO', axis=1, inplace=True,errors = 'ignore')


        print("df_raw2 is", df_raw2)
        result = model.predict_proba(df_raw2) 
    except Exception as e:
        result = str(e)
        return json.dumps({"error": result})
    return json.dumps({"result":result.tolist()})
