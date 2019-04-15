import pickle
import json
import numpy
from sklearn.externals import joblib

def init():
    global model
    # deserialize the model file back into a sklearn model
    model = joblib.load('sklearn_regression_model.pkl')

# note you can pass in multiple rows for scoring
def run(test_data):
    try:
        result = model.predict(test_data)
        # you can return any data type as long as it is JSON-serializable
        return result.tolist()
    except Exception as e:
        error = str(e)
        return error

# the data is from this dataset: https://www4.stat.ncsu.edu/~boos/var.select/diabetes.html
# in the format of AGE SEX BMI BP S1 S2 S3 S4 S5 S6 Y
        
test_data = [[ 0.03807591,  0.05068012,  0.06169621,  0.02187235, -0.0442235 ,
       -0.03482076, -0.04340085, -0.00259226,  0.01990842, -0.01764613]]
init()
print(run(test_data))