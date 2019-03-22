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
    public partial class DoctorMain : Form
    {
        public TabPage tp;
        public List<model> models;
        private List<Patient> patients;
        private List<ModelParams> ModelParams;

        private long selectedPatientId;
        private string selectedFirstName;
        private string selectedLastName;
        private decimal selectedScore;
        private ToolTip tt = new ToolTip();

        public DoctorMain()
        {
            InitializeComponent();

            tt.InitialDelay = 0;
            tt.ShowAlways = true;

            models = model.GetAll();
            patients = Patient.GetAll();
            tp = tabPage2;
            tabControl1.TabPages.Remove(tp);
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
            f.models = models.Where(x=>x.isActive).ToList();
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

            if (models.Where(x => x.isSelected).Count() > 0)
            {
                if (!tabControl1.TabPages.Contains(tp))
                    tabControl1.TabPages.Add(tp);
            }
            else
            {
                if (tabControl1.TabPages.Contains(tp))
                    tabControl1.TabPages.Remove(tp);
            }

        }

        private void Main_Load(object sender, EventArgs e)
        {
            InitDataGrid();
        }

        private void SingleInference()
        {
            // Build dynamic sql parameters:
            string[] sqlparams = new string[5];

            sqlparams[0] = ModelParams[0].sqlColumnName + ',' + ParamText1.Text.Trim();
            sqlparams[1] = ModelParams[1].sqlColumnName + ',' + ParamText2.Text.Trim();
            sqlparams[2] = ModelParams[2].sqlColumnName + ',' + ParamText3.Text.Trim();
            sqlparams[3] = ModelParams[3].sqlColumnName + ',' + ParamText4.Text.Trim();
            sqlparams[4] = ModelParams[4].sqlColumnName + ',' + ParamText5.Text.Trim();

            string[,] payloadData = DMPRW30Days_SingleInference.GetSingleInference(selectedPatientId, sqlparams);
            string response = DMPRW30Days_SingleInference.GetScore(payloadData);

            try
            {
                string scoreStr = String.Format("{0:0.0000}", response.Split(',')[1].Substring(0, 7));
                decimal newScore = decimal.Parse(String.Format("{0:0.00}", decimal.Parse(scoreStr) * 100));
                UpdateChart(newScore);
            }
            catch (Exception ex)
            {

            }
        }
        private void bSingleInferenceTest_Click(object sender, EventArgs e)
        {
            //_TEST_Update_Scores();
            SingleInference();
        }

        private void _TEST_Update_Scores()
        {
            for (int i = 0; i <= 16220; i++)
            {
                try
                {
                    long PatientId = long.Parse(dgPatients.Rows[i].Cells[0].Value.ToString());

                    CellClick(i);
                    string[] sqlparams = new string[5];

                    sqlparams[0] = ModelParams[0].sqlColumnName + ',' + ParamText1.Text.Trim();
                    sqlparams[1] = ModelParams[1].sqlColumnName + ',' + ParamText2.Text.Trim();
                    sqlparams[2] = ModelParams[2].sqlColumnName + ',' + ParamText3.Text.Trim();
                    sqlparams[3] = ModelParams[3].sqlColumnName + ',' + ParamText4.Text.Trim();
                    sqlparams[4] = ModelParams[4].sqlColumnName + ',' + ParamText5.Text.Trim();

                    string[,] payloadData = DMPRW30Days_SingleInference.GetSingleInference(PatientId, sqlparams);
                    string response = DMPRW30Days_SingleInference.GetScore(payloadData);
                    decimal newScore = decimal.Parse(response.Split(',')[1].Substring(0, 7)) * 100;

                    DMPRW30Days_SingleInference._TEST_InsertScores(PatientId, newScore);
                }
                catch (Exception ex)
                {

                }

            }
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
                    ParamText1.Items.Clear();
                    ParamText2.Items.Clear();
                    ParamText3.Items.Clear();
                    ParamText4.Items.Clear();
                    ParamText5.Items.Clear();

                    // Positive Values
                    ModelParams = DMPRW30Days_SingleInference.GetParameters(selectedPatientId);

                    ParamL1.Text = ModelParams[0].paramName + ":";
                    ParamText1.Text = ModelParams[0].paramValue;
                    tt.SetToolTip(ParamL1, "Score: " + ModelParams[0].score.ToString());

                    ParamText1.Items.AddRange(ModelParams[0].distinctValues.Split(',').ToArray());

                    ParamL2.Text = ModelParams[1].paramName + ":";
                    ParamText2.Text = ModelParams[1].paramValue;
                    tt.SetToolTip(ParamL2, "Score: " + ModelParams[1].score.ToString());

                    ParamText2.Items.AddRange(ModelParams[1].distinctValues.Split(',').ToArray());
         
                    ParamL3.Text = ModelParams[2].paramName + ":";
                    ParamText3.Text = ModelParams[2].paramValue;
                    tt.SetToolTip(ParamL3, "Score: " + ModelParams[2].score.ToString());

                    ParamText3.Items.AddRange(ModelParams[2].distinctValues.Split(',').ToArray());
                   
                    ParamL4.Text = ModelParams[3].paramName + ":";
                    ParamText4.Text = ModelParams[3].paramValue;
                    tt.SetToolTip(ParamL4, "Score: " + ModelParams[3].score.ToString());

                    ParamText4.Items.AddRange(ModelParams[3].distinctValues.Split(',').ToArray());
                   
                    ParamL5.Text = ModelParams[4].paramName + ":";
                    ParamText5.Text = ModelParams[4].paramValue;
                    tt.SetToolTip(ParamL5, "Score: " + ModelParams[4].score.ToString());

                    ParamText5.Items.AddRange(ModelParams[4].distinctValues.Split(',').ToArray());

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
    }
}
