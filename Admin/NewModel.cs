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

namespace AdminUI
{
    public partial class NewModel : Form
    {
        private TabPage[] tps = new TabPage[3];
        public List<model> models;
        private ImageList il = new ImageList();
        public int modelId;

        public NewModel()
        {
            InitializeComponent();
            InitTabs();

            tps[0] = step1;
            tps[1] = step2;
            tps[2] = step3;
        }
        
        private void InitTabs()
        {
            //if(modelId != -1)
            //{
            //    var m = model.GetAll().Where(x => x.Id == modelId);
            //    model _model = ((model)m);

            //    lblTitle.Text = _model.Name;

            //}
        }
        private void Model_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tps[0]);
            tabControl1.TabPages.Remove(tps[1]);
            tabControl1.TabPages.Remove(tps[2]);
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(!tabControl1.TabPages.Contains(tps[0]))
                tabControl1.TabPages.Add(tps[0]);

            tabControl1.TabPages.Remove(tps[1]);
            tabControl1.TabPages.Remove(tps[2]);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!tabControl1.TabPages.Contains(tps[1]))
                tabControl1.TabPages.Add(tps[1]);

            tabControl1.TabPages.Remove(tps[0]);
            tabControl1.TabPages.Remove(tps[2]);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!tabControl1.TabPages.Contains(tps[2]))
                tabControl1.TabPages.Add(tps[2]);

            tabControl1.TabPages.Remove(tps[0]);
            tabControl1.TabPages.Remove(tps[1]);
        }
    }
}
