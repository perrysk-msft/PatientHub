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
using model = PatientHubData.Model;
using System.Threading;

namespace AdminUI
{
    public partial class NewModel : Form
    {
        private Process p = new Process();
        private ProcessCaller processCaller;
        
        public List<model> models;
        private ImageList il = new ImageList();
        public int modelId;        

        public NewModel()
        {
            InitializeComponent();

        }

        private void Model_Load(object sender, EventArgs e)
        {
        }

        private void run_cmd()
        {

            string fileName = @"scripts\DMPRW30Days\model_registration.py --model_name=peskount_test_packaged_python --model_path=scripts\DMPRW30Days\model.pkl";
            //string fileName = @"scripts\test.py";

            Process p = new Process();
            p.StartInfo = new ProcessStartInfo(@"D:\python\python.exe", fileName)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            p.Start();

            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            txtModelName.Text = output;
        }

        private void bEnable_Click(object sender, EventArgs e)
        {
            run_cmd();
        }


        private void bRegisterModel_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            this.bRegisterModel.Enabled = false;

            progressBar1.Visible = true;

            processCaller = new ProcessCaller(this);
            processCaller.FileName = @"D:\python\python.exe";
            processCaller.WorkingDirectory = @"D:\AI\PatientHub\Admin\scripts\Diabetes";
            processCaller.Arguments = @"D:\AI\PatientHub\Admin\scripts\Diabetes\Login_register_deploy_perry.py --script_file_name=""D:\AI\PatientHub\Admin\scripts\Diabetes\score.py"" --model_path=""D:\AI\PatientHub\Admin\scripts\Diabetes\model.pkl"" --conda_env_file_name=""D:\AI\PatientHub\Admin\scripts\Diabetes\myenv.yml"" --default_subscription_id=""a6c2a7cc-d67e-4a1a-b765-983f08c0423a"" --default_resource_group=""xiaoyzhu-mlworkspace"" --default_workspace_name=""xiaoyzhu-MLworkspace"" --default_workspace_region=""eastus2"" --model_name=""phdeploymodel"" --model_description=""Ridge regression model to predict diabetes"" --aks_cluster_name=""ace-patienthub""";

            processCaller.StdErrReceived += new DataReceivedHandler(errorStreamInfo);
            processCaller.StdOutReceived += new DataReceivedHandler(writeStreamInfo);
            processCaller.Completed += new EventHandler(processCompletedOrCanceled);
            processCaller.Cancelled += new EventHandler(processCompletedOrCanceled);
            
            this.txtOutput.Text = string.Format("[{0}] {1}", DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString(), "Started the execution of the model registration and deployment script.") + Environment.NewLine;

            processCaller.Start();
        }
        private void writeStreamInfo(object sender, DataReceivedEventArgs e)
        {
            string output = string.Format("[{0}] {1}", DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString(), e.Text.Trim());
            this.txtOutput.AppendText(output + Environment.NewLine);
        }
        private void errorStreamInfo(object sender, DataReceivedEventArgs e)
        {
            txtOutput.SelectionColor = Color.OrangeRed;
            string output = string.Format("[{0}] {1}", DateTime.Now.ToLongTimeString(), e.Text.Trim());
            this.txtOutput.AppendText(output + Environment.NewLine);
        }
        private void processCompletedOrCanceled(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            this.bRegisterModel.Enabled = true;

            progressBar1.Visible = false;
        }

        private void NewModel_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Update models");
        }
    }
}
