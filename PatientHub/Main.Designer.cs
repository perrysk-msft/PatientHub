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
            this.TopToolStrip = new System.Windows.Forms.ToolStrip();
            this.BottomToolStrip = new System.Windows.Forms.ToolStrip();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.bPredict = new System.Windows.Forms.Button();
            this.dgPatients = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bSingleInferenceTest = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatients)).BeginInit();
            this.SuspendLayout();
            // 
            // TopToolStrip
            // 
            this.TopToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.TopToolStrip.Location = new System.Drawing.Point(0, 0);
            this.TopToolStrip.Name = "TopToolStrip";
            this.TopToolStrip.Size = new System.Drawing.Size(1060, 25);
            this.TopToolStrip.TabIndex = 0;
            this.TopToolStrip.Text = "toolStrip1";
            // 
            // BottomToolStrip
            // 
            this.BottomToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.BottomToolStrip.Location = new System.Drawing.Point(0, 518);
            this.BottomToolStrip.Name = "BottomToolStrip";
            this.BottomToolStrip.Size = new System.Drawing.Size(1060, 25);
            this.BottomToolStrip.TabIndex = 1;
            this.BottomToolStrip.Text = "toolStrip1";
            // 
            // bPredict
            // 
            this.bPredict.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bPredict.Location = new System.Drawing.Point(12, 230);
            this.bPredict.Name = "bPredict";
            this.bPredict.Size = new System.Drawing.Size(99, 35);
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
            this.dgPatients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id});
            this.dgPatients.Location = new System.Drawing.Point(12, 41);
            this.dgPatients.MultiSelect = false;
            this.dgPatients.Name = "dgPatients";
            this.dgPatients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPatients.Size = new System.Drawing.Size(970, 177);
            this.dgPatients.TabIndex = 2;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
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
            this.bSingleInferenceTest.Location = new System.Drawing.Point(822, 242);
            this.bSingleInferenceTest.Name = "bSingleInferenceTest";
            this.bSingleInferenceTest.Size = new System.Drawing.Size(146, 69);
            this.bSingleInferenceTest.TabIndex = 4;
            this.bSingleInferenceTest.Text = "bSingleInferenceTest";
            this.bSingleInferenceTest.UseVisualStyleBackColor = true;
            this.bSingleInferenceTest.Click += new System.EventHandler(this.bSingleInferenceTest_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1060, 543);
            this.Controls.Add(this.bSingleInferenceTest);
            this.Controls.Add(this.bPredict);
            this.Controls.Add(this.dgPatients);
            this.Controls.Add(this.BottomToolStrip);
            this.Controls.Add(this.TopToolStrip);
            this.Name = "Main";
            this.Text = "Patient Hub Demo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPatients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip TopToolStrip;
        private System.Windows.Forms.ToolStrip BottomToolStrip;
        private System.Windows.Forms.DataGridView dgPatients;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button bPredict;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.Button bSingleInferenceTest;
    }
}

