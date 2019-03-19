using System;
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
    public partial class Login : Form
    {
        private Form form;
        public Login()
        {
            InitializeComponent();
            cbView.SelectedIndex = 0;
        }

        private void Authenticate()
        {
            if (txtUsername.Text == "demo" && txtPassword.Text == "demo")
            {
                if (cbView.SelectedIndex == 0) // Doctor
                {
                    form = new DoctorMain();
                }
                else // Patient
                {
                    form = new PatientMain();                    
                }
                
                this.Hide();
                form.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Credentials. Please try again.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public static void Show(Form currentForm)
        {
            Form form = new Login();
            currentForm.Hide();
            form.ShowDialog();
            currentForm.Close();
        }
        private void bLogin_Click(object sender, EventArgs e)
        {
            Authenticate();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) Authenticate();
        }

        private void cbView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) Authenticate();
        }
    }
}
