using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminUI
{
    public partial class Login : Form
    {
        private static string default_cs = PatientHubData.Configuration.connectionString;
        private Form form;
        public Login()
        {
            InitializeComponent();
            //cbView.SelectedIndex = 0;
        }

        private void Authenticate()
        {
            string cs = default_cs;
            cs = cs.Replace("@v1", txtUsername.Text);
            cs = cs.Replace("@v2", txtPassword.Text);

            try
            {
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    connection.Open();
                    PatientHubData.Configuration.connectionString = cs;

                    form = new Auditor();

                    connection.Close();
                    this.Hide();
                    form.ShowDialog();
                    this.Close();

                }

            }
            catch (SqlException e) { MessageBox.Show("Invalid Credentials. Please try again.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            finally { }

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
