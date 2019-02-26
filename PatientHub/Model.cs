using System;
using System.Collections.Generic;
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
        private List<model> models;

        public Model()
        {
            InitializeComponent();
            models = model.GetAll();
            
            ImageList il = new ImageList();
            il.ImageSize = new Size(244, 81);
            il.Images.Add("DMReadmission30Days", Image.FromFile(@"images\DMReadmission30Days.png"));
            il.Images.Add("Diabetes", Image.FromFile(@"images\Diabetes.png"));
            il.Images.Add("Asthma", Image.FromFile(@"images\Asthma.png"));



            listView1.View = View.LargeIcon;
            listView1.CheckBoxes = true;
            listView1.LargeImageList = il;
            
            for (int i = 0; i < il.Images.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.ImageIndex = i;
                listView1.Items.Add(lvi);
            }
        }

        private void bCreate_Click(object sender, EventArgs e)
        {
            CreateModel cm = new CreateModel();
            cm.ShowDialog();
        }

        private void bApply_Click(object sender, EventArgs e)
        {
            foreach (var item in listView1.Items)
            {

            }
            
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
