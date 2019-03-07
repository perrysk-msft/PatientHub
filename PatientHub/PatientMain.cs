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
        private List<Patient> patients;
        private List<ModelParams> positiveModelParams;
        private List<ModelParams> negativeModelParams;

        private long selectedPatientId = 10;
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
            patients = Patient.GetAll();
            patients = patients.Where(x => x.Id == selectedPatientId).ToList(); // Get real Patient ID

            foreach (model model in models)
            {
                if (!dgPatients.Columns.Contains(model.Name))
                    AddBarGraphColumn(model.Name);
            }
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
            tabControl1.TabPages[0].AutoScroll = true;

        }

        private void bPredict_Click(object sender, EventArgs e)
        {
            // TODO: DYnamic management of tabs based on Models...

            Model f = new Model();
            f.models = models;
            f.ShowDialog();

            foreach (model model in models)
            {
                // Show
                if(model.isSelected)
                {
                    if(!dgPatients.Columns.Contains(model.Name))
                        AddBarGraphColumn(model.Name);
                }

                // Hide
                else
                {
                    if (dgPatients.Columns.Contains(model.Name))
                        dgPatients.Columns.Remove(model.Name);
                }
            }
            
            // Order by the first column
            var sortedList = patients.OrderByDescending(s => s.DMPRW30Days_Score).ToList();
            dgPatients.DataSource = sortedList;

            CellClick(0);

            if (models.Where(x=>x.isSelected).Count() > 0)
                tabControl1.Visible = true;
            else
                tabControl1.Visible = false;

        }

        private void Main_Load(object sender, EventArgs e)
        {
            InitDataGrid();
        }

        private void SingleInference()
        {
            // Build dynamic sql parameters:
            string[] sqlparams = new string[10];

            sqlparams[0] = positiveModelParams[0].sqlColumnName + ',' + PositiveText1.Text.Trim();
            sqlparams[1] = positiveModelParams[1].sqlColumnName + ',' + PositiveText2.Text.Trim();
            sqlparams[2] = positiveModelParams[2].sqlColumnName + ',' + PositiveText3.Text.Trim();
            sqlparams[3] = positiveModelParams[3].sqlColumnName + ',' + PositiveText4.Text.Trim();
            sqlparams[4] = positiveModelParams[4].sqlColumnName + ',' + PositiveText5.Text.Trim();

            sqlparams[5] = negativeModelParams[0].sqlColumnName + ',' + NegativeText1.Text.Trim();
            sqlparams[6] = negativeModelParams[1].sqlColumnName + ',' + NegativeText2.Text.Trim();
            sqlparams[7] = negativeModelParams[2].sqlColumnName + ',' + NegativeText3.Text.Trim();
            sqlparams[8] = negativeModelParams[3].sqlColumnName + ',' + NegativeText4.Text.Trim();
            sqlparams[9] = negativeModelParams[4].sqlColumnName + ',' + NegativeText5.Text.Trim();

            string[,] payloadData = DMPRW30Days_SingleInference.GetSingleInference(selectedPatientId, sqlparams);
            string input = "[";
            string response = DMPRW30Days_SingleInference.GetScore(payloadData);

            try
            {                
                decimal newScore = decimal.Parse(response.Split(',')[1].Substring(0, 7)) * 100;
                UpdateChart(newScore);
            }
            catch (Exception ex)
            {

            }
        }
        private void bSingleInferenceTest_Click(object sender, EventArgs e)
        {
            SingleInference();
        }

        private void CellClick(int rowIndex)
        {
            if (rowIndex >= 0)
            {
                tabControl1.Visible = true;

                DataGridViewRow row = dgPatients.Rows[rowIndex];
                selectedPatientId = Int64.Parse(row.Cells["Id"].Value.ToString());
                selectedFirstName = row.Cells["FirstName"].Value.ToString();
                selectedLastName = row.Cells["LastName"].Value.ToString();

                try
                {
                    selectedScore = decimal.Parse(row.Cells["DMPRW30Days_Score"].Value.ToString());
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

        private void dgPatients_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up) || e.KeyCode.Equals(Keys.Down))
            {
                MoveUpDown(e.KeyCode == Keys.Up);
            }
            e.Handled = true;
        }
        private void MoveUpDown(bool goUp)
        {
            try
            {
                int currentRowindex = dgPatients.SelectedCells[0].OwningRow.Index;

                //Here I decide to change the row with the parameter
                //True -1 or False +1
                int newRowIndex = currentRowindex + (goUp ? -1 : 1);

                CellClick(newRowIndex);

                //Here it must be ensured that we remain within the index of the DGV
                if (newRowIndex > -1 && newRowIndex < dgPatients.Rows.Count)
                {
                    dgPatients.ClearSelection();
                    dgPatients.Rows[newRowIndex].Selected = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }

        }

        private void Search()
        {
            List<Patient> filter = null;
            if (txtSearch.Text != "")
            {
                try
                {
                    if (txtSearch.Text.ToLower().Contains("id="))
                    {
                        filter = patients.Where(x => x.Id == long.Parse(txtSearch.Text.Split('=')[1].Trim())).ToList();
                    }
                    if (txtSearch.Text.ToLower() == "order by id desc")
                    {
                        filter = patients.OrderByDescending(s => s.Id).ToList();
                    }
                    if (txtSearch.Text.ToLower() == "order by first name desc")
                    {
                        filter = patients.OrderByDescending(s => s.firstName).ToList();
                    }
                    if (txtSearch.Text.ToLower() == "order by last name desc")
                    {
                        filter = patients.OrderByDescending(s => s.lastName).ToList();
                    }
                    if (txtSearch.Text == "order by DMPRW30Days score desc")
                    {
                        filter = patients.OrderByDescending(s => s.DMPRW30Days_Score).ToList();
                    }

                    dgPatients.DataSource = filter;
                }
                catch (Exception ex) { MessageBox.Show("Invalied search input." + "\n" + "Detailed Exception:" + ex.Message, "Invalid format", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }
            else
                dgPatients.DataSource = patients.OrderByDescending(s => s.DMPRW30Days_Score).ToList();
        }
        private void bSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void txtSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) Search();
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
