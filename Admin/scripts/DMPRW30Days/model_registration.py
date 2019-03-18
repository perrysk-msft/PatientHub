from azureml.core.model import Model
import azureml.core
import os
from azureml.core import Workspace
import argparse

parser = argparse.ArgumentParser(
    description="model registration")

parser.add_argument('--model_name', dest="model_name", required=True)
parser.add_argument('--model_path', dest="model_path", required=True)
args = parser.parse_args()



subscription_id = os.getenv("SUBSCRIPTION_ID", default="a6c2a7cc-d67e-4a1a-b765-983f08c0423a")
resource_group = os.getenv("RESOURCE_GROUP", default="xiaoyzhu-mlworkspace")
workspace_name = os.getenv("WORKSPACE_NAME", default="xiaoyzhu-MLworkspace")
workspace_region = os.getenv("WORKSPACE_REGION", default="eastus2")


try:
    ws = Workspace(subscription_id = subscription_id, resource_group = resource_group, workspace_name = workspace_name)
    # write the details of the workspace to a configuration file to the notebook library
    ws.write_config(file_name="xiaoyzhuconfig.json")
    print("Workspace configuration succeeded. Skip the workspace creation steps below")
except:
    print("Workspace not accessible. Change your parameters or create a new workspace below")
model = Model.register(model_path = args.model_path,
                       model_name = args.model_name,
                       tags = {"key": "0.1"},
                       description = "test",
                       workspace = ws)
print("model registered. model list: ", model.list(workspace = ws, name = args.model_name))