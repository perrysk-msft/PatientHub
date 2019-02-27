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

namespace PatientHubUI
{
    public partial class CreateModel : Form
    {
        public CreateModel()
        {
            InitializeComponent();
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

            textBox1.Text = output;            
        }

        private void bEnable_Click(object sender, EventArgs e)
        {
            run_cmd();           
        }
    }
}
