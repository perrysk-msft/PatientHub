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
using System.Windows.Forms.DataVisualization.Charting;
using System.Reflection;
using System.Threading;

namespace PatientHubUI
{
    public partial class DoctorMain : Form
    {
        public TabPage tp;
        private List<Patient> patients;
        private List<Medication> medications;

        private long selectedPatientId;
        private string selectedFirstName;
        private string selectedLastName;
        private decimal selectedScore;
        private ToolTip tt = new ToolTip();
        private int newRefills;
        private int orderMedId;

        public DoctorMain()
        {
            InitializeComponent();

            tt.InitialDelay = 0;
            tt.ShowAlways = true;
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
            

        }

        private void Main_Load(object sender, EventArgs e)
        {
            InitDataGrid();
        }

        private void SingleInference()
        {
            // Build dynamic sql parameters:
            string[] sqlparams = new string[5];


            try
            {

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
                    medications = Medication.GetAll(selectedPatientId);
                    dgMedications.DataSource = null;

                    if (medications.Count > 0)
                    {
                        bUpdateMedications.Visible = true;
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

                    else
                    {
                        bUpdateMedications.Visible = false;
                    }
                    dgMedications.Refresh();

                    selectedScore = decimal.Parse(row.Cells["DMPRW30Days_Score"].Value.ToString());
                    UpdateChart(selectedScore);

                    lbPatientInfo.Text = selectedLastName + ", " + selectedFirstName;

                    //Reset DropDown Items
                    ParamText1.Items.Clear();
                    ParamText2.Items.Clear();
                    ParamText3.Items.Clear();
                    ParamText4.Items.Clear();
                    ParamText5.Items.Clear();


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

        private void button1_Click(object sender, EventArgs e)
        {

            //newRefills = int.Parse(dgMedications.Rows[1].Cells[11].Value.ToString());
            //orderMedId = int.Parse(dgMedications.Rows[1].Cells[0].Value.ToString());

            bool res = Medication.Update(orderMedId, newRefills);

            if (res)
            {
                lblUpdateMessage.Text = "Update was successful.";
                lblUpdateMessage.Refresh();
            }
            int milliseconds = 2000;
            Thread.Sleep(milliseconds);
            lblUpdateMessage.Text = "";
            lblUpdateMessage.Refresh();
            bUpdateMedications.Enabled = false;
        }

        private void dgMedications_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            bUpdateMedications.Enabled = true;
            //newRefills = int.Parse(dgMedications.Rows[e.RowIndex].Cells[11].Value.ToString());
            //orderMedId = int.Parse(dgMedications.Rows[e.RowIndex].Cells[0].Value.ToString());

        }

        private void dgMedications_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //bUpdateMedications.Enabled = true;
            //newRefills = int.Parse(dgMedications.Rows[e.RowIndex].Cells[11].Value.ToString());
            //orderMedId = int.Parse(dgMedications.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void dgMedications_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            newRefills = int.Parse(dgMedications.Rows[e.RowIndex].Cells[11].Value.ToString());
            orderMedId = int.Parse(dgMedications.Rows[e.RowIndex].Cells[0].Value.ToString());
        }
    }
}
