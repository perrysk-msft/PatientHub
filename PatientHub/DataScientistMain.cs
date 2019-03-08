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
    public partial class DataScientistMain : Form
    {
        public List<model> models;
        private ImageList il = new ImageList();


        public DataScientistMain()
        {
            InitializeComponent();
            models = model.GetAll();
        }

        private void DataScientistMain_Load(object sender, EventArgs e)
        {
            il.ImageSize = new Size(244, 81);

            foreach (model model in models)
            {
                il.Images.Add(model.Id.ToString(), Image.FromFile(model.ImagePath));
            }

            listView1.View = View.LargeIcon;
            listView1.CheckBoxes = true;
            listView1.LargeImageList = il;
            int i = 0;

            foreach (model model in models)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.ImageIndex = i;
                lvi.Tag = model.Id;
                listView1.Items.Add(lvi);
                i++;
            } 
            
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Checked)
            {
                bEdit.Enabled = true;
                bEdit.Refresh();

                // TODO: Replace with details from SQL
                panel3.Visible = true;
                txtModelDetails.Text = "Single Inderence API: " + Configuration.DMPRW30Days_singleInference_URL + System.Environment.NewLine +
                                        "Batch Inference API: " + Configuration.DMPRW30Days_batchInference_URL;

            }
            else
            {
                bEdit.Enabled = false;
                panel3.Visible = false;
            }

        }

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // TODO: Enable all models when they are deployed
            //if (e.Index != 0) e.NewValue = e.CurrentValue;

            if (e.NewValue == CheckState.Checked)
            {
                var checkedCount = listView1.CheckedItems.Count;
                for (var i = 0; i < checkedCount; i++)
                {
                    listView1.CheckedItems[i].Checked = false;
                }
            }
        }

            private void Search()
        {
            //List<Patient> filter = null;
            //if (txtSearch.Text != "")
            //{
            //    try
            //    {
            //        if (txtSearch.Text.ToLower().Contains("id="))
            //        {
            //            filter = patients.Where(x => x.Id == long.Parse(txtSearch.Text.Split('=')[1].Trim())).ToList();
            //        }
            //        if (txtSearch.Text.ToLower() == "order by id desc")
            //        {
            //            filter = patients.OrderByDescending(s => s.Id).ToList();
            //        }
            //        if (txtSearch.Text.ToLower() == "order by first name desc")
            //        {
            //            filter = patients.OrderByDescending(s => s.firstName).ToList();
            //        }
            //        if (txtSearch.Text.ToLower() == "order by last name desc")
            //        {
            //            filter = patients.OrderByDescending(s => s.lastName).ToList();
            //        }
            //        if (txtSearch.Text == "order by DMPRW30Days score desc")
            //        {
            //            filter = patients.OrderByDescending(s => s.DMPRW30Days_Score).ToList();
            //        }

            //        dgPatients.DataSource = filter;
            //    }
            //    catch (Exception ex) { MessageBox.Show("Invalied search input." + "\n" + "Detailed Exception:" + ex.Message, "Invalid format", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            //}
            //else
            //    dgPatients.DataSource = patients.OrderByDescending(s => s.DMPRW30Days_Score).ToList();
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

        private void bNewModel_Click(object sender, EventArgs e)
        {
            NewModel cm = new NewModel();
            cm.modelId = -1;
            cm.ShowDialog();
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            NewModel cm = new NewModel();
            cm.modelId = int.Parse(listView1.CheckedItems[0].Tag.ToString());
            cm.ShowDialog();
        }
    }
}
