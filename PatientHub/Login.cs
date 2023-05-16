using PatientHubData;
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

namespace PatientHubUI
{
    public partial class Login : Form
    {
        private Form form;
        public Login()
        {
            InitializeComponent();
            cbView.SelectedIndex = 1;
        }
        private bool CheckConnection(int orderMedId, int refills)
        {
            bool success = false;
            List<Medication> medications = new List<Medication>();
            SqlCommand cmd = new SqlCommand();
            try
            {
                using (SqlConnection connection = new SqlConnection(Configuration.connectionString))
                {
                    connection.Open();

                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Configuration.commandTimeout;
                    cmd.CommandText = Configuration.spUpdateMedications;

                    cmd.Parameters.Add(new SqlParameter("OrderMedID", orderMedId));
                    cmd.Parameters.Add(new SqlParameter("Refills", refills));

                    cmd.ExecuteScalar();

                    success = true;
                }
                return success;
            }
            catch (SqlException e) { throw e; }
            finally { }
        }

        private void Authenticate()
        {
            // <add name="Db" connectionString="data source=ledgermi.public.f4b451b7ec3a.database.windows.net,3342;Initial Catalog=PatientHub;User ID=AzureAdmin;Password=V3ry$ecureP@ssword01!;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"/>
            // Set the connection string
            string cs = PatientHubData.Configuration.connectionString = "data source=ledgermi.public.f4b451b7ec3a.database.windows.net,3342;Initial Catalog=PatientHub;User ID=" + txtUsername.Text + ";Password=" + txtPassword.Text + ";Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            try
            {
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    connection.Open();
                    if (cbView.SelectedIndex == 0) // Doctor
                    {
                        form = new DoctorMain();
                    }
                    else // Patient
                    {
                        form = new PatientMain();
                    }
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
