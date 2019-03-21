#https://github.com/Azure/MachineLearningNotebooks/blob/master/how-to-use-azureml/manage-azureml-service/authentication-in-azureml/authentication-in-azure-ml.ipynb

from azureml.core.authentication import ServicePrincipalAuthentication
import requests

svc_pr_password="d/rkGA+z+XHqA/IrkNoRcQ4CsDDgho41BkabArVAeqY="

svc_pr = ServicePrincipalAuthentication(
    tenant_id="72f988bf-86f1-41af-91ab-2d7cd011db47",
    service_principal_id="3b783cdf-fd0a-4be5-b787-550383181f02",
    service_principal_password=svc_pr_password)


subscription_id="a6c2a7cc-d67e-4a1a-b765-983f08c0423a"
resource_group="xiaoyzhu-mlworkspace"
workspace_name="xiaoyzhu-MLworkspace"

#TODO: change to  using config.json and loading workspace from it
#my_workspace = Workspace.from_config()
#my_workspace.get_details()

from azureml.core.workspace import Workspace
ws = Workspace.get(workspace_name,
               svc_pr,
               subscription_id,
               resource_group)

print("Found workspace {} at location {}".format(ws.name, ws.location))
print("Found experiments for workspace {} experiment {}".format(ws.name, ws.experiments["patienthub_batch_scoring"]))

aad_token = svc_pr.get_authentication_header()
print(aad_token)

rest_endpoint = "https://westus2.aether.ms/api/v1.0/subscriptions/a6c2a7cc-d67e-4a1a-b765-983f08c0423a/resourceGroups/xiaoyzhu-mlworkspace/providers/Microsoft.MachineLearningServices/workspaces/xiaoyzhu-MLworkspace/PipelineRuns/PipelineSubmit/565c32df-250c-461c-b9b7-2283cbaf55ab"

# specify batch size when running the pipeline
response = requests.post(rest_endpoint,
                         headers=aad_token,
                         json={"ExperimentName": "patienthub_batch_scoring",
                               "ParameterAssignments": {"param_batch_size": 50}})
run_id = response.json()["Id"]
print(run_id)

from azureml.pipeline.core.run import PipelineRun
published_pipeline_run = PipelineRun(ws.experiments["patienthub_batch_scoring"], run_id)
print(published_pipeline_run)

#from azureml.widgets.RunDetails import RunDetails
#RunDetails(published_pipeline_run).show()
