import pickle
import json
import numpy
import azureml.train.automl
from sklearn.externals import joblib
from azureml.core.model import Model
import pandas as pd


def init():
    global model
    model_path = Model.get_model_path(model_name = 'AutoMLfa0c1e2ddbest') # this name is model.id of model that we want to deploy
    # deserialize the model file back into a sklearn model
    model = joblib.load(model_path)

def run(rawdata):
    try:
        data = json.loads(rawdata)['data']
        data = numpy.array(data)
        data_df = pd.DataFrame(data, columns=['age', 'time_in_hospital', 'num_lab_procedures', 'num_procedures',
       'num_medications', 'number_outpatient', 'number_emergency',
       'number_inpatient', 'number_diagnoses', 'spec_InternalMedicine',
       'spec_Family/GeneralPractice', 'spec_Emergency/Trauma',
       'spec_Cardiology', 'spec_Surgery-General', 'diag_428', 'diag_250',
       'diag_276', 'diag_414', 'diag_427', 'diag_401', 'diag_599',
       'diag_496', 'diag_786', 'diag_403', 'gender_Female', 'gender_Male',
       'gender_Unknown/Invalid', 'tolbutamide_No', 'tolbutamide_Steady',
       'acarbose_No', 'acarbose_Steady', 'acarbose_Up', 'miglitol_Down',
       'miglitol_No', 'miglitol_Steady', 'tolazamide_No',
       'tolazamide_Steady', 'metformin-rosiglitazone_No', 'change_Ch',
       'change_No', 'diabetesMed_No', 'diabetesMed_Yes',
       'glyburide-metformin_No', 'glyburide-metformin_Steady',
       'max_glu_serum_>200', 'max_glu_serum_>300', 'max_glu_serum_None',
       'max_glu_serum_Norm', 'A1Cresult_>7', 'A1Cresult_>8',
       'A1Cresult_None', 'A1Cresult_Norm', 'metformin_Down',
       'metformin_No', 'metformin_Steady', 'metformin_Up',
       'repaglinide_Down', 'repaglinide_No', 'repaglinide_Steady',
       'repaglinide_Up', 'nateglinide_No', 'nateglinide_Steady',
       'nateglinide_Up', 'chlorpropamide_No', 'chlorpropamide_Steady',
       'chlorpropamide_Up', 'glimepiride_Down', 'glimepiride_No',
       'glimepiride_Steady', 'glimepiride_Up', 'glipizide_Down',
       'glipizide_No', 'glipizide_Steady', 'glipizide_Up',
       'glyburide_Down', 'glyburide_No', 'glyburide_Steady',
       'glyburide_Up', 'pioglitazone_Down', 'pioglitazone_No',
       'pioglitazone_Steady', 'pioglitazone_Up', 'rosiglitazone_Down',
       'rosiglitazone_No', 'rosiglitazone_Steady', 'rosiglitazone_Up',
       'insulin_Down', 'insulin_No', 'insulin_Steady', 'insulin_Up',
       'race_AfricanAmerican', 'race_Asian', 'race_Caucasian',
       'race_Hispanic', 'race_Other', 'admission_type_id_1',
       'admission_type_id_2', 'admission_type_id_3',
       'admission_type_id_4', 'admission_type_id_5',
       'admission_type_id_6', 'admission_type_id_7',
       'admission_type_id_8', 'admission_source_id_1',
       'admission_source_id_2', 'admission_source_id_3',
       'admission_source_id_4', 'admission_source_id_5',
       'admission_source_id_6', 'admission_source_id_7',
       'admission_source_id_8', 'admission_source_id_9',
       'admission_source_id_14', 'admission_source_id_17',
       'admission_source_id_20', 'admission_source_id_22',
       'payer_code_BC', 'payer_code_CH', 'payer_code_CM', 'payer_code_CP',
       'payer_code_DM', 'payer_code_FR', 'payer_code_HM', 'payer_code_MC',
       'payer_code_MD', 'payer_code_MP', 'payer_code_OG', 'payer_code_OT',
       'payer_code_PO', 'payer_code_SI', 'payer_code_SP', 'payer_code_UN',
       'payer_code_WC', 'discharge_disposition_id_1',
       'discharge_disposition_id_2', 'discharge_disposition_id_3',
       'discharge_disposition_id_4', 'discharge_disposition_id_5',
       'discharge_disposition_id_6', 'discharge_disposition_id_7',
       'discharge_disposition_id_8', 'discharge_disposition_id_9',
       'discharge_disposition_id_10', 'discharge_disposition_id_11',
       'discharge_disposition_id_13', 'discharge_disposition_id_14',
       'discharge_disposition_id_15', 'discharge_disposition_id_16',
       'discharge_disposition_id_17', 'discharge_disposition_id_18',
       'discharge_disposition_id_22', 'discharge_disposition_id_23',
       'discharge_disposition_id_24', 'discharge_disposition_id_25',
       'discharge_disposition_id_27', 'discharge_disposition_id_28'])
        print(dir(model))
        result = model.predict_proba(data_df) 
    except Exception as e:
        result = str(e)
        return json.dumps({"error": result})
    return json.dumps({"result":result.tolist()})
