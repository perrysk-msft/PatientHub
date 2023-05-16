using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PatientHubData;
using medicationHistory = PatientHubData.MedicationHistory;

namespace AdminUI
{
    public partial class Auditor : Form
    {

        private List<MedicationHistory> medicationsHistory;

        public Auditor()
        {
            InitializeComponent();
        }

        private void DataScientistMain_Load(object sender, EventArgs e)
        {
        }

        private void bLedgerVerification_Click(object sender, EventArgs e)
        {
             lblLedgerVerify.Text = Ledger.Verify();
            if (lblLedgerVerify.Text == "Ledger verification succeeded.")
            {
                lblLedgerVerify.BackColor = Color.LightGreen;
            }
            else
                lblLedgerVerify.BackColor = Color.Tomato;
        }

        private void bMedication_Click(object sender, EventArgs e)
        {
            medicationsHistory = medicationHistory.GetAll();
            dgMedicationsHistory.DataSource = null;

            if (medicationsHistory.Count > 0)
            {
                dgMedicationsHistory.AutoGenerateColumns = true;
                dgMedicationsHistory.DataSource = medicationsHistory;
                dgMedicationsHistory.Rows[0].Selected = false;

            }

            dgMedicationsHistory.Refresh();
        }

        private void bLogout_Click(object sender, EventArgs e)
        {
            Login.Show(this);
        }
    }
}
