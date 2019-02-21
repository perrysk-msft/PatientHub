using System;
using System.Collections.Generic;
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
    public partial class Main : Form
    {       
        private List<Patient> patients;
        private List<ModelParams> modelParams;
        private long selectedPatientId;
        private string selectedFirstName;
        private string selectedLastName;
        private decimal selectedScore; //TODO: Capture this dynamically

        public Main()
        {
            InitializeComponent();

            patients = Patient.GetAll();            
        }

        private void AddBarGraphColumn(string columnName)
        {
            DataGridViewBarGraphColumn col = new DataGridViewBarGraphColumn();
            col.Name = columnName;
            col.DataPropertyName = columnName;

            dgPatients.Columns.Add(col);
            
        }
        private void InitDataGrid()
        {
            dgPatients.AutoGenerateColumns = false;            
            dgPatients.DataSource = patients;
            dgPatients.Rows[0].Selected = false;            

            //TODO: Move to different method
            tabControl1.TabPages[0].AutoScroll = true;
            tabControl1.TabPages[1].AutoScroll = true;


            //TODO: MOve to a different Mathod
           



        }

        private void bPredict_Click(object sender, EventArgs e)
        {
            Model f = new Model();
            f.ShowDialog();

            // Get the Model Name and add colum to the Grid
            AddBarGraphColumn("DMPRW30Days_Score"); // TODO: Do this dynamically...

            // Order by the column
            var sortedList = patients.OrderByDescending(s => s.DMPRW30Days_Score).ToList();
            dgPatients.DataSource = sortedList;

            CellClick(0);

            tabControl1.Visible = true;

            // SingleInference



        }

        private void Main_Load(object sender, EventArgs e)
        {
            InitDataGrid();
        }

        private void bSingleInferenceTest_Click(object sender, EventArgs e)
        {

            /*
                ['age', 'time_in_hospital', 'num_lab_procedures', 'num_procedures',
               'num_medications', 'number_outpatient', 'number_emergency',
               'number_inpatient', 'number_diagnoses', 'spec_InternalMedicine',
               'spec_Family/GeneralPractice', 'spec_Emergency/Trauma',
               'spec_Cardiology', 'spec_Surgery-General', 'diag_250', 'diag_428',
               'diag_276', 'diag_414', 'diag_401', 'diag_427', 'diag_599',
               'diag_496', 'diag_403', 'diag_486', 'gender_Female', 'gender_Male',
               'tolbutamide_No', 'acarbose_No', 'acarbose_Steady', 'miglitol_No',
               'miglitol_Steady', 'tolazamide_No', 'tolazamide_Steady',
               'metformin-rosiglitazone_No', 'change_Ch', 'change_No',
               'diabetesMed_No', 'diabetesMed_Yes', 'glyburide-metformin_Down',
               'glyburide-metformin_No', 'glyburide-metformin_Steady',
               'max_glu_serum_>200', 'max_glu_serum_>300', 'max_glu_serum_None',
               'max_glu_serum_Norm', 'A1Cresult_>7', 'A1Cresult_>8',
               'A1Cresult_None', 'A1Cresult_Norm', 'metformin_Down',
               'metformin_No', 'metformin_Steady', 'metformin_Up',
               'repaglinide_Down', 'repaglinide_No', 'repaglinide_Steady',
               'repaglinide_Up', 'nateglinide_Down', 'nateglinide_No',
               'nateglinide_Steady', 'nateglinide_Up', 'chlorpropamide_No',
               'chlorpropamide_Steady', 'chlorpropamide_Up', 'glimepiride_Down',
               'glimepiride_No', 'glimepiride_Steady', 'glimepiride_Up',
               'glipizide_Down', 'glipizide_No', 'glipizide_Steady',
               'glipizide_Up', 'glyburide_Down', 'glyburide_No',
               'glyburide_Steady', 'glyburide_Up', 'pioglitazone_Down',
               'pioglitazone_No', 'pioglitazone_Steady', 'pioglitazone_Up',
               'rosiglitazone_Down', 'rosiglitazone_No', 'rosiglitazone_Steady',
               'rosiglitazone_Up', 'insulin_Down', 'insulin_No', 'insulin_Steady',
               'insulin_Up', 'race_AfricanAmerican', 'race_Asian',
               'race_Caucasian', 'race_Hispanic', 'race_Other',
               'admission_type_id_1', 'admission_type_id_2',
               'admission_type_id_3', 'admission_type_id_4',
               'admission_type_id_5', 'admission_type_id_6',
               'admission_type_id_7', 'admission_type_id_8',
               'admission_source_id_1', 'admission_source_id_2',
               'admission_source_id_3', 'admission_source_id_4',
               'admission_source_id_5', 'admission_source_id_6',
               'admission_source_id_7', 'admission_source_id_9',
               'admission_source_id_17', 'admission_source_id_20',
               'payer_code_BC', 'payer_code_CH', 'payer_code_CM', 'payer_code_CP',
               'payer_code_DM', 'payer_code_HM', 'payer_code_MC', 'payer_code_MD',
               'payer_code_MP', 'payer_code_OG', 'payer_code_OT', 'payer_code_PO',
               'payer_code_SI', 'payer_code_SP', 'payer_code_UN', 'payer_code_WC',
               'discharge_disposition_id_1', 'discharge_disposition_id_2',
               'discharge_disposition_id_3', 'discharge_disposition_id_4',
               'discharge_disposition_id_5', 'discharge_disposition_id_6',
               'discharge_disposition_id_7', 'discharge_disposition_id_8',
               'discharge_disposition_id_9', 'discharge_disposition_id_10',
               'discharge_disposition_id_11', 'discharge_disposition_id_13',
               'discharge_disposition_id_14', 'discharge_disposition_id_15',
               'discharge_disposition_id_17', 'discharge_disposition_id_18',
               'discharge_disposition_id_22', 'discharge_disposition_id_23',
               'discharge_disposition_id_24', 'discharge_disposition_id_25',
               'discharge_disposition_id_28']
             
             */
            string[,] payloadData = new string[,] {
                {                    
                    "80", "1", "15", "0", "12", "2", "0", "1", "6", "False", "False", "False", "False", "False", "False", "False", "False", "False", "False", "True", "False", "False", "False", "False", "1", "0", "0", "1", "0", "1", "0", "0", "0", "1", "0", "1", "0", "1", "0", "1", "0", "1", "1", "0", "0", "0", "0", "1", "0", "0", "1", "0", "0", "1", "0", "0", "0", "1", "0", "0", "1", "0", "0", "1", "0", "0", "0", "1", "0", "0", "0", "0", "1", "0", "0", "1", "0", "0", "0", "1", "0", "0", "0", "1", "0", "0", "0", "1", "0", "0", "1", "0", "0", "0", "0", "0", "0", "0", "0", "1", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "1", "0", "0", "0", "0", "0", "0", "0", "0", "0", "1", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "1", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0"
                }
            };

            string response = SingleInference.GetScore(payloadData);
            MessageBox.Show(response);
        }

        private void CellClick(int rowIndex)
        {
            if (rowIndex >= 0)
            { 
                DataGridViewRow row = dgPatients.Rows[rowIndex];
                selectedPatientId = Int64.Parse(row.Cells["Id"].Value.ToString());
                selectedFirstName = row.Cells["FirstName"].Value.ToString();
                selectedLastName = row.Cells["LastName"].Value.ToString();

                try
                {
                    selectedScore = decimal.Parse(row.Cells["DMPRW30Days_Score"].Value.ToString());
                    UpdateChart(selectedScore);

                    lbPatientInfo.Text = selectedLastName + ", " + selectedFirstName + " (id:" + selectedPatientId + ")";

                    modelParams = SingleInference.GetParameters(selectedPatientId);
                    HighL1.Text = modelParams[0].paramName + ": " + modelParams[0].paramValue;
                    HighL2.Text = modelParams[1].paramName + ": " + modelParams[1].paramValue;
                    HighL3.Text = modelParams[2].paramName + ": " + modelParams[2].paramValue;
                    HighL4.Text = modelParams[3].paramName + ": " + modelParams[3].paramValue;
                    HighL5.Text = modelParams[4].paramName + ": " + modelParams[4].paramValue;

                    LowL1.Text = modelParams[5].paramName + ": " + modelParams[5].paramValue;
                    LowL2.Text = modelParams[6].paramName + ": " + modelParams[6].paramValue;
                    LowL3.Text = modelParams[7].paramName + ": " + modelParams[7].paramValue;
                    LowL4.Text = modelParams[8].paramName + ": " + modelParams[8].paramValue;
                    LowL5.Text = modelParams[9].paramName + ": " + modelParams[9].paramValue;
                }
                catch (System.ArgumentException) { }
            
            }
        }
        private void dgPatients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CellClick(e.RowIndex);
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
    }
}
