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
using model = PatientHubData.Model;

namespace PatientHubUI
{
    public partial class PatientMain : Form
    {        
        public List<model> models;
        private Patient patient;
        private List<ModelParams> ModelParams;

        private long selectedPatientId = Configuration.demoPatientId;
        private string selectedFirstName;
        private string selectedLastName;
        private decimal selectedScore;
        private ToolTip tt = new ToolTip();

        public PatientMain()
        {
            InitializeComponent();

            tt.InitialDelay = 0;
            tt.ShowAlways = true;

            models = model.GetAll().Where(x => x.isActive).ToList(); ;
            patient = Patient.GetPatient(selectedPatientId);

            selectedFirstName = patient.firstName;
            selectedLastName = patient.lastName;
            selectedScore = patient.DMPRW30Days_Score;
            label6.Text = DateTime.Now.AddDays(1).ToLongDateString() + " at 8:00 AM";

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

                // Positive Values
                ModelParams = DMPRW30Days_SingleInference.GetParameters(selectedPatientId);

                L1.Text = ModelParams[0].paramName + ":";
                Text1.Text = ModelParams[0].paramValue;

                L2.Text = ModelParams[1].paramName + ":";
                Text2.Text = ModelParams[1].paramValue;

                L3.Text = ModelParams[2].paramName + ":";
                Text3.Text = ModelParams[2].paramValue;

                L4.Text = ModelParams[3].paramName + ":";
                Text4.Text = ModelParams[3].paramValue;

                L5.Text = ModelParams[4].paramName + ":";
                Text5.Text = ModelParams[4].paramValue;

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
