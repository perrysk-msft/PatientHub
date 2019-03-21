# python.exe f:/PatientHub/MLModels/Diabetes/login_register_deploy/Login_register_deploy_perry.py --script_file_name="./score.py" --model_path="./sklearn_regression_model.pkl" --conda_env_file_name="myenv.yml" --default_subscription_id="a6c2a7cc-d67e-4a1a-b765-983f08c0423a" --default_resource_group="xiaoyzhu-mlworkspace" --default_workspace_name="xiaoyzhu-MLworkspace" --default_workspace_region="eastus2" --model_name="phdeploymodel" --model_description="Ridge regression model to predict diabetes" --aks_cluster_name="ace-patienthub"
# coding: utf-8
# updated: 3/21/2019 12:59

import argparse
import os
from time import gmtime, strftime

import azureml.core
import numpy as np
from azureml.core import Workspace
from azureml.core.compute import AksCompute, ComputeTarget
from azureml.core.experiment import Experiment
from azureml.core.image import ContainerImage, Image
from azureml.core.model import Model
from azureml.core.webservice import AksWebservice, Webservice
from azureml.telemetry import set_diagnostics_collection

# import variables
parser = argparse.ArgumentParser(description='Process some integers.')
parser.add_argument('--script_file_name',
                    dest='script_file_name', required=True)
parser.add_argument('--conda_env_file_name',
                    dest='conda_env_file_name', required=True)
parser.add_argument('--default_subscription_id',
                    dest='default_subscription_id', required=True)
parser.add_argument('--default_resource_group',
                    dest='default_resource_group', required=True)
parser.add_argument('--default_workspace_name',
                    dest='default_workspace_name', required=True)
parser.add_argument('--default_workspace_region',
                    dest='default_workspace_region', required=True)
parser.add_argument('--model_path', dest='model_path', required=True)
parser.add_argument('--model_name', dest='model_name', required=True)
parser.add_argument('--model_description',
                    dest='model_description', required=True)
parser.add_argument('--aks_cluster_name',
                    dest='aks_cluster_name', required=True)
args = parser.parse_args()


script_file_name = os.path.normpath(args.script_file_name)
conda_env_file_name = os.path.normpath(args.conda_env_file_name)
default_subscription_id = args.default_subscription_id
default_resource_group = args.default_resource_group
default_workspace_name = args.default_workspace_name
default_workspace_region = args.default_workspace_region
model_path = os.path.normpath(args.model_path)  # ".\\model.pkl"
model_name = args.model_name  # note this must be less than 20 chars
# "Ridge regression model to predict diabetes"
model_description = args.model_description
aks_name = args.aks_cluster_name


# replace the model ID
with open(script_file_name, 'r') as cefr:
    content = cefr.read()

with open(script_file_name, 'w') as cefw:
    cefw.write(content.replace('global_model_name=',
                               "global_model_name=\"" + model_name + "\"#"))
# exit(0)

subscription_id = os.getenv("SUBSCRIPTION_ID", default=default_subscription_id)
resource_group = os.getenv("RESOURCE_GROUP", default=default_resource_group)
workspace_name = os.getenv("WORKSPACE_NAME", default=default_workspace_name)
workspace_region = os.getenv(
    "WORKSPACE_REGION", default=default_workspace_region)


try:
    ws = Workspace(subscription_id=subscription_id,
                   resource_group=resource_group, workspace_name=workspace_name)
    # write the details of the workspace to a configuration file to the notebook library
    ws.write_config(file_name="config.json")
    print("[Login] Workspace configuration succeeded.")
except:
    print("[ERROR] Workspace not accessible.")


# # Register the model for deployment

# In[3]:

print("[Register] Starting to register the model")

# Register the model

model = Model.register(model_path=model_path,  # this points to a local file
                       model_name=model_name,  # this is the name the model is registered as
                       tags={'area': "diabetes", 'type': "regression"},
                       description=model_description,
                       workspace=ws)

# print(model.name, model.description, model.version)
print("[Register] " + model.name + "registered successfully")


# # Create container image

print("[Image] Starting to create container image")
image_config = ContainerImage.image_configuration(runtime="python",
                                                  execution_script=script_file_name,
                                                  conda_file=conda_env_file_name,
                                                  tags={
                                                      'area': "digits", 'type': "automl_classification"},
                                                  description=model_description)

image = Image.create(name=model_name+"image",
                     # this is the model object
                     models=[model],
                     image_config=image_config,
                     workspace=ws)

image.wait_for_creation(show_output=True)

if image.creation_state == 'Failed':
    print("[ERROR] Image build log at: " + image.image_build_log_uri)
print("[Image] Container Image" + model_name+"image" + "created successfully")

# In[5]:


# Use the default configuration (can also provide parameters to customize)
prov_config = AksCompute.provisioning_configuration()

print("[Deployment] Starting to deploy model to AKS cluster")
# Create the cluster
aks_target = ComputeTarget.create(workspace=ws,
                                  name=aks_name,
                                  provisioning_configuration=prov_config)


# In[7]:


# Set the web service configuration (using default here)
aks_config = AksWebservice.deploy_configuration(
    collect_model_data=True, enable_app_insights=True)


# In[12]:


webservicelist = Webservice.list(workspace=ws)


# In[21]:


aks_service_name = model_name+strftime("%m%d%H%M", gmtime())

aks_service = Webservice.deploy_from_image(workspace=ws,
                                           name=aks_service_name,
                                           image=image,
                                           deployment_config=aks_config,
                                           deployment_target=aks_target)
aks_service.wait_for_deployment(show_output=True)

services = Webservice.list(ws)
print("[Deployment] AKS cluster deployed successfully. The end point is:")
print(services[0].scoring_uri)
