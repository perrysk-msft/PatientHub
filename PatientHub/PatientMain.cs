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

namespace PatientHubUI
{
    public partial class PatientMain : Form
    {        
        private Patient patient;

        private long selectedPatientId = Configuration.demoPatientId;
        private string selectedFirstName;
        private string selectedLastName;
        private decimal selectedScore;
        private ToolTip tt = new ToolTip();
        private List<Medication> medications;

        public PatientMain()
        {
            InitializeComponent();

            tt.InitialDelay = 0;
            tt.ShowAlways = true;

            patient = Patient.GetPatient(selectedPatientId);

            selectedFirstName = patient.firstName;
            selectedLastName = patient.lastName;
            selectedScore = patient.DMPRW30Days_Score;

        }
        private void Init()
        {
            try
            {

                lbPatientNbr.Text = patient.patientNbr.ToString();
                lbFullName.Text = patient.lastName + ", " + patient.firstName;

                lbAge.Text = patient.age;
                lbRace.Text = patient.race;
                lbGender.Text = patient.gender;

                UpdateChart(selectedScore);

                lbPatientInfo.Text = selectedLastName + ", " + selectedFirstName;


                medications = Medication.GetAll(selectedPatientId);
                dgMedications.DataSource = null;

                if (medications.Count > 0)
                {                    
                    dgMedications.AutoGenerateColumns = false;
                    dgMedications.DataSource = medications;
                    dgMedications.Rows[0].Selected = false;
                    tabControl1.TabPages[0].AutoScroll = true;

                    int i = 0;
                    foreach (DataGridViewRow r in dgMedications.Rows)
                    {
                        for (int j = 0; j < 14; j++)
                        {
                            if (j == 11)
                            {
                                this.dgMedications.Rows[i].Cells[j].ReadOnly = false;

                            }
                            else
                                this.dgMedications.Rows[i].Cells[j].ReadOnly = true;
                        }
                        i++;
                    }
                }

                dgMedications.Refresh();


            }
            catch (System.ArgumentException) { }



        }

        private void Main_Load(object sender, EventArgs e)
        {
            Init();
        }
        

        private void UpdateChart(decimal score)
        {            
            this.RiskChart.Series[0].Points[0].SetValueY(score);
            this.RiskChart.Series[0].Points[1].SetValueY(100-score);
            Color color;

            if (score < 20.00M)
            {
                color = Color.Green;
            }
            else if (score >= 20.00M && score <= 50.00M)
            {
                color = Color.Orange;
            }
            else if (score > 50.00M && score < 80.00M)
            {
                color = Color.OrangeRed;
            }
            else
            {
                color = Color.Red;
            }

            this.RiskChart.Series[0].Points[0].Color = color;

            this.RiskChart.Series[0].LegendText = score.ToString();

            this.RiskChart.Update();
        }


        private void Search()
        {

        }
        private void bLogout_Click(object sender, EventArgs e)
        {
            Login.Show(this);
        }

        private void bAppointment_Click(object sender, EventArgs e)
        {
            MessageBox.Show("coming soon...");
        }
    }
}
