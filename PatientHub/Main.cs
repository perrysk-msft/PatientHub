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
        private List<ModelParams> positiveModelParams;
        private List<ModelParams> negativeModelParams;

        private long selectedPatientId;
        private string selectedFirstName;
        private string selectedLastName;
        private decimal selectedScore; //TODO: Capture this dynamically
        private ToolTip tt = new ToolTip();

        public Main()
        {
            InitializeComponent();

            tt.InitialDelay = 0;
            tt.ShowAlways = true;


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

        }

        private void bPredict_Click(object sender, EventArgs e)
        {
            Model f = new Model();
            f.ShowDialog();

            // Get the Model Name and add colum to the Grid
            if (!dgPatients.Columns.Contains("DMPRW30Days_Score"))
            {
                AddBarGraphColumn("DMPRW30Days_Score"); // TODO: Do this dynamically...
            }
            

            // Order by the column
            var sortedList = patients.OrderByDescending(s => s.DMPRW30Days_Score).ToList();
            dgPatients.DataSource = sortedList;

            CellClick(0);

            tabControl1.Visible = true;

        }

        private void Main_Load(object sender, EventArgs e)
        {
            InitDataGrid();
        }

        private void bSingleInferenceTest_Click(object sender, EventArgs e)
        {
            // Build dynamic sql parameters:
            string[] sqlparams = new string[10];

            sqlparams[0] = positiveModelParams[0].sqlColumnName + ',' + PositiveText1.Text.Trim();
            sqlparams[1] = positiveModelParams[1].sqlColumnName + ',' + PositiveText2.Text.Trim();
            sqlparams[2] = positiveModelParams[2].sqlColumnName + ',' + PositiveText3.Text.Trim();
            sqlparams[3] = positiveModelParams[3].sqlColumnName + ',' + PositiveText4.Text.Trim();
            sqlparams[4] = positiveModelParams[4].sqlColumnName + ',' + PositiveText5.Text.Trim();

            sqlparams[5] = negativeModelParams[0].sqlColumnName + ',' + PositiveText1.Text.Trim();
            sqlparams[6] = negativeModelParams[1].sqlColumnName + ',' + PositiveText2.Text.Trim();
            sqlparams[7] = negativeModelParams[2].sqlColumnName + ',' + PositiveText3.Text.Trim();
            sqlparams[8] = negativeModelParams[3].sqlColumnName + ',' + PositiveText4.Text.Trim();
            sqlparams[9] = negativeModelParams[4].sqlColumnName + ',' + PositiveText5.Text.Trim();

            string[,] payloadData = DMPRW30Days_SingleInference.GetSingleInference(selectedPatientId, sqlparams);

            //try
            //{
                string response = DMPRW30Days_SingleInference.GetScore(payloadData);
                string input = "Input:";
                decimal newScore = decimal.Parse(response.Split(',')[1].Substring(0, 7)) * 100;
                UpdateChart(newScore);
                lbAPIResponse.Text = response;

                for (int i = 0; i < payloadData.Length; i++)
                {
                    input += payloadData[0,i];
                }
                lbAPIParams.Text = input;

            //}
            //catch (Exception ex) { lbAPIException.Text = ex.Message.ToString(); }            
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

                    lbPatientInfo.Text = selectedLastName + ", " + selectedFirstName;

                    //Reset DropDown Items
                    PositiveText1.Items.Clear();
                    PositiveText2.Items.Clear();
                    PositiveText3.Items.Clear();
                    PositiveText4.Items.Clear();
                    PositiveText5.Items.Clear();
                    NegativeText1.Items.Clear();
                    NegativeText2.Items.Clear();
                    NegativeText3.Items.Clear();
                    NegativeText4.Items.Clear();
                    NegativeText5.Items.Clear();


                    // Positive Values
                    positiveModelParams = DMPRW30Days_SingleInference.GetParameters(selectedPatientId, true);

                    PositiveL1.Text = positiveModelParams[0].paramName + ":";
                    PositiveText1.Text = positiveModelParams[0].paramValue;
                    tt.SetToolTip(PositiveL1, "Score: " + positiveModelParams[0].score.ToString());

                    PositiveText1.Items.AddRange(positiveModelParams[0].distinctValues.Split(',').ToArray());

                    PositiveL2.Text = positiveModelParams[1].paramName + ":";
                    PositiveText2.Text = positiveModelParams[1].paramValue;
                    tt.SetToolTip(PositiveL2, "Score: " + positiveModelParams[1].score.ToString());

                    PositiveText2.Items.AddRange(positiveModelParams[1].distinctValues.Split(',').ToArray());
         
                    PositiveL3.Text = positiveModelParams[2].paramName + ":";
                    PositiveText3.Text = positiveModelParams[2].paramValue;
                    tt.SetToolTip(PositiveL3, "Score: " + positiveModelParams[2].score.ToString());

                    PositiveText3.Items.AddRange(positiveModelParams[2].distinctValues.Split(',').ToArray());
                   
                    PositiveL4.Text = positiveModelParams[3].paramName + ":";
                    PositiveText4.Text = positiveModelParams[3].paramValue;
                    tt.SetToolTip(PositiveL4, "Score: " + positiveModelParams[3].score.ToString());

                    PositiveText4.Items.AddRange(positiveModelParams[3].distinctValues.Split(',').ToArray());
                   
                    PositiveL5.Text = positiveModelParams[4].paramName + ":";
                    PositiveText5.Text = positiveModelParams[4].paramValue;
                    tt.SetToolTip(PositiveL5, "Score: " + positiveModelParams[4].score.ToString());

                    PositiveText5.Items.AddRange(positiveModelParams[4].distinctValues.Split(',').ToArray());
                   
                    // Negative Values
                    negativeModelParams = DMPRW30Days_SingleInference.GetParameters(selectedPatientId, false);

                    NegativeL1.Text = negativeModelParams[0].paramName + ":";
                    NegativeText1.Text = negativeModelParams[0].paramValue;
                    tt.SetToolTip(NegativeL1, "Score: " + negativeModelParams[0].score.ToString());

                    NegativeText1.Items.AddRange(negativeModelParams[0].distinctValues.Split(',').ToArray());

                    NegativeL2.Text = negativeModelParams[1].paramName + ":";
                    NegativeText2.Text = negativeModelParams[1].paramValue;
                    tt.SetToolTip(NegativeL2, "Score: " + negativeModelParams[1].score.ToString());

                    NegativeText2.Items.AddRange(negativeModelParams[1].distinctValues.Split(',').ToArray());

                    NegativeL3.Text = negativeModelParams[2].paramName + ":";
                    NegativeText3.Text = negativeModelParams[2].paramValue;
                    tt.SetToolTip(NegativeL3, "Score: " + negativeModelParams[2].score.ToString());

                    NegativeText3.Items.AddRange(negativeModelParams[2].distinctValues.Split(',').ToArray());

                    NegativeL4.Text = negativeModelParams[3].paramName + ":";
                    NegativeText4.Text = negativeModelParams[3].paramValue;
                    tt.SetToolTip(NegativeL4, "Score: " + negativeModelParams[3].score.ToString());

                    NegativeText4.Items.AddRange(negativeModelParams[3].distinctValues.Split(',').ToArray());

                    NegativeL5.Text = negativeModelParams[4].paramName + ":";
                    NegativeText5.Text = negativeModelParams[4].paramValue;
                    tt.SetToolTip(NegativeL5, "Score: " + negativeModelParams[4].score.ToString());

                    NegativeText5.Items.AddRange(negativeModelParams[4].distinctValues.Split(',').ToArray());

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
