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

namespace PatientHub
{
    public partial class Main : Form
    {
        
        private Patient patient = new Patient();
        private List<Patient> patients;

        public Main()
        {
            InitializeComponent();

            this.dgPatients.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 11);
            this.dgPatients.DefaultCellStyle.Font = new Font("Tahoma", 10);

            patients = patient.GetAll();
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
        }

        private void bPredict_Click(object sender, EventArgs e)
        {
            Model f = new Model();
            f.ShowDialog();

            // Get the Model Name and add colum to the Grid
            AddBarGraphColumn("DMPRW30Days_Score");

            // Order by the column
            var sortedList = patients.OrderByDescending(s => s.DMPRW30Days_Score).ToList();
            dgPatients.DataSource = sortedList;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            InitDataGrid();
        }
    }
}
