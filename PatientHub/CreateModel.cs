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

            string fileName = @"D:\AI\PatientHub\PatientHub\scripts\test.py";

            Process p = new Process();
            p.StartInfo = new ProcessStartInfo(@"E:\Anaconda\pkgs\python-3.7.1-h8c8aaf0_6\python.exe", fileName)
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
