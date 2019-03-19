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
        private List<ModelParams> positiveModelParams;
        private List<ModelParams> negativeModelParams;

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

            //patients[0].firstName + ", " + patients[0].lastName;

        }
        private void Init()
        {
            try
            {

                lbPatientNbr.Text = patient.patientNbr.ToString();
                lbFullName.Text = patient.firstName + ", " + patient.lastName;

                lbAge.Text = patient.age;
                lbRace.Text = patient.race;
                lbGender.Text = patient.gender;


                UpdateChart(selectedScore);

                lbPatientInfo.Text = selectedLastName + ", " + selectedFirstName;

                // Positive Values
                positiveModelParams = DMPRW30Days_SingleInference.GetParameters(selectedPatientId, true);

                PositiveL1.Text = positiveModelParams[0].paramName + ":";
                PositiveText1.Text = positiveModelParams[0].paramValue;

                PositiveL2.Text = positiveModelParams[1].paramName + ":";
                PositiveText2.Text = positiveModelParams[1].paramValue;

                PositiveL3.Text = positiveModelParams[2].paramName + ":";
                PositiveText3.Text = positiveModelParams[2].paramValue;

                PositiveL4.Text = positiveModelParams[3].paramName + ":";
                PositiveText4.Text = positiveModelParams[3].paramValue;

                PositiveL5.Text = positiveModelParams[4].paramName + ":";
                PositiveText5.Text = positiveModelParams[4].paramValue;

                // Negative Values
                negativeModelParams = DMPRW30Days_SingleInference.GetParameters(selectedPatientId, false);

                NegativeL1.Text = negativeModelParams[0].paramName + ":";
                NegativeText1.Text = negativeModelParams[0].paramValue;

                NegativeL2.Text = negativeModelParams[1].paramName + ":";
                NegativeText2.Text = negativeModelParams[1].paramValue;

                NegativeL3.Text = negativeModelParams[2].paramName + ":";
                NegativeText3.Text = negativeModelParams[2].paramValue;

                NegativeL4.Text = negativeModelParams[3].paramName + ":";
                NegativeText4.Text = negativeModelParams[3].paramValue;

                NegativeL5.Text = negativeModelParams[4].paramName + ":";
                NegativeText5.Text = negativeModelParams[4].paramValue;

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
