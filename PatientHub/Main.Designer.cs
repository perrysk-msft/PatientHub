namespace PatientHubUI
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.TopToolStrip = new System.Windows.Forms.ToolStrip();
            this.BottomToolStrip = new System.Windows.Forms.ToolStrip();
            this.bPredict = new System.Windows.Forms.Button();
            this.dgPatients = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patient_nbr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Race = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bSingleInferenceTest = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TopToolStrip
            // 
            this.TopToolStrip.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TopToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.TopToolStrip.Location = new System.Drawing.Point(0, 0);
            this.TopToolStrip.Name = "TopToolStrip";
            this.TopToolStrip.Size = new System.Drawing.Size(1237, 25);
            this.TopToolStrip.TabIndex = 0;
            this.TopToolStrip.Text = "toolStrip1";
            // 
            // BottomToolStrip
            // 
            this.BottomToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.BottomToolStrip.Location = new System.Drawing.Point(0, 686);
            this.BottomToolStrip.Name = "BottomToolStrip";
            this.BottomToolStrip.Size = new System.Drawing.Size(1237, 25);
            this.BottomToolStrip.TabIndex = 1;
            this.BottomToolStrip.Text = "toolStrip1";
            // 
            // bPredict
            // 
            this.bPredict.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bPredict.Location = new System.Drawing.Point(8, 13);
            this.bPredict.Name = "bPredict";
            this.bPredict.Size = new System.Drawing.Size(129, 53);
            this.bPredict.TabIndex = 3;
            this.bPredict.Text = "Predict";
            this.bPredict.UseVisualStyleBackColor = true;
            this.bPredict.Click += new System.EventHandler(this.bPredict_Click);
            // 
            // dgPatients
            // 
            this.dgPatients.AllowUserToAddRows = false;
            this.dgPatients.AllowUserToDeleteRows = false;
            this.dgPatients.AllowUserToOrderColumns = true;
            this.dgPatients.BackgroundColor = System.Drawing.Color.White;
            this.dgPatients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgPatients.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPatients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgPatients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.patient_nbr,
            this.FirstName,
            this.LastName,
            this.Race,
            this.Gender,
            this.Age,
            this.Weight});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgPatients.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgPatients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPatients.GridColor = System.Drawing.Color.Gainsboro;
            this.dgPatients.Location = new System.Drawing.Point(0, 0);
            this.dgPatients.MultiSelect = false;
            this.dgPatients.Name = "dgPatients";
            this.dgPatients.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPatients.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgPatients.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Gray;
            this.dgPatients.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgPatients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPatients.Size = new System.Drawing.Size(1232, 228);
            this.dgPatients.TabIndex = 2;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // patient_nbr
            // 
            this.patient_nbr.DataPropertyName = "patientNbr";
            this.patient_nbr.HeaderText = "Patient NBR";
            this.patient_nbr.Name = "patient_nbr";
            this.patient_nbr.ReadOnly = true;
            // 
            // FirstName
            // 
            this.FirstName.DataPropertyName = "FirstName";
            this.FirstName.HeaderText = "First Name";
            this.FirstName.Name = "FirstName";
            this.FirstName.ReadOnly = true;
            // 
            // LastName
            // 
            this.LastName.DataPropertyName = "LastName";
            this.LastName.HeaderText = "Last Name";
            this.LastName.Name = "LastName";
            this.LastName.ReadOnly = true;
            // 
            // Race
            // 
            this.Race.DataPropertyName = "race";
            this.Race.HeaderText = "Race";
            this.Race.Name = "Race";
            this.Race.ReadOnly = true;
            // 
            // Gender
            // 
            this.Gender.DataPropertyName = "gender";
            this.Gender.HeaderText = "Gender";
            this.Gender.Name = "Gender";
            this.Gender.ReadOnly = true;
            // 
            // Age
            // 
            this.Age.DataPropertyName = "age";
            this.Age.HeaderText = "Age";
            this.Age.Name = "Age";
            this.Age.ReadOnly = true;
            // 
            // Weight
            // 
            this.Weight.DataPropertyName = "weight";
            this.Weight.HeaderText = "Weight";
            this.Weight.Name = "Weight";
            this.Weight.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Column2";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // bSingleInferenceTest
            // 
            this.bSingleInferenceTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSingleInferenceTest.Location = new System.Drawing.Point(143, 13);
            this.bSingleInferenceTest.Name = "bSingleInferenceTest";
            this.bSingleInferenceTest.Size = new System.Drawing.Size(159, 53);
            this.bSingleInferenceTest.TabIndex = 4;
            this.bSingleInferenceTest.Text = "SingleInference REST API Call";
            this.bSingleInferenceTest.UseVisualStyleBackColor = true;
            this.bSingleInferenceTest.Click += new System.EventHandler(this.bSingleInferenceTest_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgPatients);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.bSingleInferenceTest);
            this.splitContainer1.Panel2.Controls.Add(this.bPredict);
            this.splitContainer1.Size = new System.Drawing.Size(1234, 567);
            this.splitContainer1.SplitterDistance = 230;
            this.splitContainer1.TabIndex = 5;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 25);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 661);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 25);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainer2.Panel1MinSize = 90;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(1234, 661);
            this.splitContainer2.SplitterDistance = 90;
            this.splitContainer2.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PatientHub.Properties.Resources.logo;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(297, 86);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1237, 711);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.BottomToolStrip);
            this.Controls.Add(this.TopToolStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Main";
            this.Text = "ACE Patient Hub E2E";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPatients)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip TopToolStrip;
        private System.Windows.Forms.ToolStrip BottomToolStrip;
        private System.Windows.Forms.DataGridView dgPatients;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button bPredict;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Button bSingleInferenceTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn patient_nbr;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Race;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

