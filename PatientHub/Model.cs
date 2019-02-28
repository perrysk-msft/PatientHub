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

            for (int i = 0; i < models.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.ImageIndex = i;
                listView1.Items.Add(lvi);

                if (models[i].isSelected)
                {
                    listView1.Items[i].Checked = true;
                }
            }
        }

        private void bCreate_Click(object sender, EventArgs e)
        {
            CreateModel cm = new CreateModel();
            cm.ShowDialog();
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

            }
            else
                panel3.Visible = false;

        }

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // TODO: Enable all models when they are deployed
            if (e.Index != 0) e.NewValue = e.CurrentValue;

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
