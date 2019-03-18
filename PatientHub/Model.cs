using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using model = PatientHubData.Model;
using Configuration = PatientHubData.Configuration;
using PatientHubData;

namespace PatientHubUI
{
    public partial class Model : Form
    {
        public List<model> models;
        private ImageList il = new ImageList();

        public Model()
        {
            InitializeComponent();            
        }
        private void Model_Load(object sender, EventArgs e)
        {
            il.ImageSize = new Size(244, 81);

            foreach (model model in models)
            {
                il.Images.Add(model.Name, Image.FromFile(model.ImagePath));
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
                

                if (model.isSelected)
                {
                    listView1.Items[i].Checked = true;
                }
                i++;
            }           
        }
        private void bApply_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                models[item.ImageIndex].isSelected = item.Checked;
            }

            this.Close();                        
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {            
            if (e.Item.Checked)
            {

                panel3.Visible = true;
                txtModelDetails.Text =  "Single Inderence API: " + Configuration.DMPRW30Days_singleInference_URL + System.Environment.NewLine +
                                        "Batch Inference API: " + Configuration.DMPRW30Days_batchInference_URL;

            }
            else
                panel3.Visible = false;

        }

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                var checkedCount = listView1.CheckedItems.Count;
                for (var i = 0; i < checkedCount; i++)
                {
                    listView1.CheckedItems[i].Checked = false;
                }
            }

        }
    }
}
