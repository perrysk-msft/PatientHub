using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PatientHubData;
using model = PatientHubData.Model;
using System.Threading;

namespace AdminUI
{
    public partial class NewModel : Form
    {
        private Process p = new Process();
        private ProcessCaller processCaller;
        private string LoginRegisterDeployScript = Application.StartupPath + @"\scripts\" + "RegisterNewModel.py";
        private string scriptOutput;
        private string RTEndpointMrker = "[RT-Endpoint]:";


        public List<model> models;
        private ImageList il = new ImageList();
        public int modelId;
        Model selectedModel;

        string modelName;
        string modelFile;
        string scoreFile;
        string ymlFile;
        string subscriptionId;
        string resourceGroup;
        string workspace;
        string region;
        string aksClusterName;
        string description;
        string workingDirectory;
        string realTimeEndpoint;
        //string batchEndpoint;



        public NewModel()
        {
            InitializeComponent();
            link.Visible = false;
            models = Model.GetAll();
        }

        private void Model_Load(object sender, EventArgs e)
        {
            txtSubscriptionId.Text = Configuration.SubscriptionId;
            txtResourceGroup.Text = Configuration.ResourceGroup;
            txtWorkspace.Text = Configuration.WorkspaceName;
            txtRegion.Text = Configuration.Region;
            txtAKSCluster.Text = Configuration.AKSClusterName;

            // If this is EDIT
            if (modelId != -1)
            {
                
                selectedModel = models.Where(x => x.Id == modelId).ToList()[0];
                lblTitle.Text = "Edit Model: " + selectedModel.Name;

                txtModelName.Text = selectedModel.Name;
                txtModelFile.Text = selectedModel.ModelFile;
                txtScoreFile.Text = selectedModel.ScoreFile;
                txtYamlFile.Text = selectedModel.YamlFile;
                txtDescription.Text = selectedModel.Description;

                modelName = txtModelName.Text.Trim();
                modelFile = txtModelFile.Text.Trim();
                scoreFile = txtScoreFile.Text.Trim();
                ymlFile = txtYamlFile.Text.Trim();
                subscriptionId = txtSubscriptionId.Text.Trim();
                resourceGroup = txtResourceGroup.Text.Trim();
                workspace = txtWorkspace.Text.Trim();
                region = txtRegion.Text.Trim();
                aksClusterName = txtAKSCluster.Text.Trim();
                description = txtDescription.Text.Trim();
            }

        }

        private void bRegisterModel_Click(object sender, EventArgs e)
        {
            modelName = txtModelName.Text.Trim();
            modelFile = txtModelFile.Text.Trim();
            scoreFile = txtScoreFile.Text.Trim();
            ymlFile = txtYamlFile.Text.Trim();
            subscriptionId = txtSubscriptionId.Text.Trim();
            resourceGroup = txtResourceGroup.Text.Trim();
            workspace = txtWorkspace.Text.Trim();
            region = txtRegion.Text.Trim();
            aksClusterName = txtAKSCluster.Text.Trim();
            description = txtDescription.Text.Trim();


            if (!CheckInput())
            {
                return;
            }            

            progressBar1.Visible = true;
            this.Cursor = Cursors.AppStarting;
            this.bRegisterModel.Enabled = false;

            string args = String.Format(@"{0} --script_file_name=""{1}"" --model_path=""{2}"" --conda_env_file_name=""{3}"" --default_subscription_id=""{4}"" --default_resource_group=""{5}"" --default_workspace_name=""{6}"" --default_workspace_region=""{7}"" --model_name=""{8}"" --model_description=""{9}"" --aks_cluster_name=""{10}""", LoginRegisterDeployScript, scoreFile, modelFile, ymlFile, subscriptionId, resourceGroup, workspace, region, modelName, description, aksClusterName);

            processCaller = new ProcessCaller(this);
            processCaller.FileName = Configuration.pyhtonPath;
            processCaller.WorkingDirectory = workingDirectory;
            processCaller.Arguments = args;// @"Login_register_deploy_perry.py --script_file_name=""score.py"" --model_path=""sklearn_regression_model.pkl"" --conda_env_file_name=""myenv.yml"" --default_subscription_id=""a6c2a7cc-d67e-4a1a-b765-983f08c0423a"" --default_resource_group=""xiaoyzhu-mlworkspace"" --default_workspace_name=""xiaoyzhu-MLworkspace"" --default_workspace_region=""eastus2"" --model_name=""phdeploymodel"" --model_description=""Ridge regression model to predict diabetes"" --aks_cluster_name=""ace-patienthub""";

            processCaller.StdErrReceived += new DataReceivedHandler(writeStreamInfo);
            processCaller.StdOutReceived += new DataReceivedHandler(writeStreamInfo);
            processCaller.Completed += new EventHandler(processCompletedOrCanceled);
            processCaller.Cancelled += new EventHandler(processCompletedOrCanceled);

            this.txtOutput.Text = string.Format("[{0}] {1}", DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString(), "Started the execution of the model registration and deployment script.") + Environment.NewLine;

            processCaller.Start();

        }

        private void writeStreamInfo(object sender, PatientHubData.DataReceivedEventArgs e)
        {
            string output = e.Text.Trim();
            scriptOutput = string.Format("[{0}] {1}", DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString(), output);
            // Get the Real-TIme Endpoint
            if (output.StartsWith(RTEndpointMrker))
            {
                realTimeEndpoint = output.Replace(RTEndpointMrker, "").Trim();
            }
            this.txtOutput.AppendText(scriptOutput + Environment.NewLine);
        }

        private void processCompletedOrCanceled(object sender, EventArgs e)
        {
            //this.txtOutput.Text.Last("[Deployment] AKS cluster deployed successfully. The end point is: ")
            //TODO: Update SQL Model table...and refresh model view

            try
            {
                model.Insert(modelName, description, workingDirectory, modelFile, scoreFile, ymlFile, realTimeEndpoint, "TBD", true);

                this.Cursor = Cursors.Default;
                this.bRegisterModel.Enabled = true;

                progressBar1.Visible = false;

                //this.Hide();
                //this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "New Model", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckInput()
        {
            link.Visible = false;
            string errorMessage;
            bool modelExists = false;

            foreach (Model m in models)
            {
                if (m.Name.ToLower() == modelName.ToLower())
                {
                    modelExists = true;
                    break;
                }
            }
            
            if (modelExists && modelId != -1)
            {
                errorMessage = "A Model with the same name exist. Please provide a unique name.";
            }
            
            else if (modelName == "")
            {
                errorMessage = "Model Name cannot be empty.";
            }
            else if (modelFile == "")
            {
                errorMessage = "Model File cannot be empty.";
            }
            else if (scoreFile == "")
            {
                errorMessage = "Scoring File cannot be empty.";
            }
            else if (ymlFile == "")
            {
                errorMessage = "Yaml File cannot be empty.";
            }
            else if (subscriptionId == "")
            {
                errorMessage = "Subscription Id cannot be empty.";
            }
            else if (resourceGroup == "")
            {
                errorMessage = "Resource Group cannot be empty.";
            }
            else if (workspace == "")
            {
                errorMessage = "Workspace name cannot be empty.";
            }
            else if (region == "")
            {
                errorMessage = "AKS Cluster region name cannot be empty.";
            }
            else if (aksClusterName == "")
            {
                errorMessage = "AKS Cluster name cannot be empty.";
            }

            else if (!(Path.GetDirectoryName(modelFile) == Path.GetDirectoryName(scoreFile) && Path.GetDirectoryName(scoreFile) == Path.GetDirectoryName(ymlFile)))
            {
                errorMessage = "The model file, scoring file,and Yaml file all need to be in the same directory.";
            }
            else if (!File.Exists(LoginRegisterDeployScript))
            {
                errorMessage = "Cannot find RegisterNewModel.py script.";
            }
            else
            {
                workingDirectory = Path.GetDirectoryName(modelFile);
                modelFile = Path.GetFileName(modelFile);
                scoreFile = Path.GetFileName(scoreFile);
                ymlFile = Path.GetFileName(ymlFile);
                link.Visible = true;

                return true;
            }

            MessageBox.Show(errorMessage, "New Model", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return false;
        }

        private void bBrowseModelFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog
            {
                Multiselect = false,
                Filter = "PKL files (*.pkl)|*.pkl",
                Title = "Select the model file"
            };
            fd.ShowDialog();
            if(fd.FileName != "")
            {
                txtModelFile.Text = fd.FileName;
            }
                
        }

        private void bBrowseScoreFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog
            {
                Multiselect = false,
                Filter = "Python files (*.py)|*.py",
                Title = "Select the model scoring file"
            };
            fd.ShowDialog();
            if (fd.FileName != "")
            {
                txtScoreFile.Text = fd.FileName;
            }
        }

        private void bBrowseYamlFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog
            {
                Multiselect = false,
                Filter = "YAML files (*.yml)|*.yml",
                Title = "Select the conda environment Yaml file"
            };
            fd.ShowDialog();
            if (fd.FileName != "")
            {
                txtYamlFile.Text = fd.FileName;
            }
        }

        private void link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string file = LoginRegisterDeployScript;
            if (File.Exists(file))
                Process.Start(file);
        }

        private void BUpdate_Click(object sender, EventArgs e)
        {
            CheckInput();
            Model.Update(selectedModel.Id, txtModelName.Text.Trim(), txtDescription.Text.Trim(), workingDirectory, txtModelFile.Text.Trim(), txtScoreFile.Text.Trim(), txtYamlFile.Text.Trim());
        }
    }
}
