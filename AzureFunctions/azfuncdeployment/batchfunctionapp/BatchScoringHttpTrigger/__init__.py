import logging

import azure.functions as func
from azureml.core.authentication import ServicePrincipalAuthentication
import requests


def main(req: func.HttpRequest) -> func.HttpResponse:
    logging.info('Python HTTP trigger function processed a batch scoring request.')

#TODO: add auth for function later, for now get a 'name param PatientHub'
    name = req.params.get('name')
    if not name:
        try:
            req_body = req.get_json()
        except ValueError:
            pass
        else:
            name = req_body.get('name')

    if name:
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

        logging.info('Found workspace and experiments')
        #logging.info(ws.name,ws.location,ws.experiments["patienthub_batch_scoring"])
        aad_token = svc_pr.get_authentication_header()
        rest_endpoint = "https://westus2.aether.ms/api/v1.0/subscriptions/a6c2a7cc-d67e-4a1a-b765-983f08c0423a/resourceGroups/xiaoyzhu-mlworkspace/providers/Microsoft.MachineLearningServices/workspaces/xiaoyzhu-MLworkspace/PipelineRuns/PipelineSubmit/565c32df-250c-461c-b9b7-2283cbaf55ab"
        
        # specify batch size when running the pipeline
        response = requests.post(rest_endpoint,
                                 headers=aad_token,
                                 json={"ExperimentName": "patienthub_batch_scoring",
                                       "ParameterAssignments": {"param_batch_size": 50}})
        run_id = response.json()["Id"]
        logging.info(run_id)
        #TODO: check if the response from above needs to be sent to func caller.
        return func.HttpResponse(f"Completed batch scoring {name}!")
    else:
        return func.HttpResponse(
             "Please pass a name on the query string or in the request body",
             status_code=400
        )
