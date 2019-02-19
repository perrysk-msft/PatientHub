﻿using System;
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
            il.ImageSize = new Size(224, 138);
            il.Images.Add("test1", Image.FromFile(@"images\DM.png"));
            
            listView1.View = View.LargeIcon;
            listView1.CheckBoxes = true;
            listView1.ShowItemToolTips = true;
            listView1.LargeImageList = il;
            
            for (int i = 0; i < il.Images.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.ImageIndex = i;
                lvi.ToolTipText = "This is the detailed description...This is the detailed description...This is the detailed description...This is the detailed description...This is the detailed description...This is the detailed description...";

                listView1.Items.Add(lvi);



            }
        }

        private void Inference_Load(object sender, EventArgs e)
        {

        }
    }
}
