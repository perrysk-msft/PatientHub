namespace AdminUI
{
    partial class NewModel
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BUpdate = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.bRegisterModel = new System.Windows.Forms.Button();
            this.txtModelName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtScoreFile = new System.Windows.Forms.TextBox();
            this.txtSubscriptionId = new System.Windows.Forms.TextBox();
            this.txtModelFile = new System.Windows.Forms.TextBox();
            this.bBrowseScoreFile = new System.Windows.Forms.Button();
            this.lblModelName = new System.Windows.Forms.Label();
            this.bBrowseModelFile = new System.Windows.Forms.Button();
            this.lblScoreFile = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblModelFile = new System.Windows.Forms.Label();
            this.lblSubscriptionId = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.link = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAKSCluster = new System.Windows.Forms.TextBox();
            this.lblRegion = new System.Windows.Forms.Label();
            this.txtRegion = new System.Windows.Forms.TextBox();
            this.lblResourceGroup = new System.Windows.Forms.Label();
            this.lblWorkspace = new System.Windows.Forms.Label();
            this.txtResourceGroup = new System.Windows.Forms.TextBox();
            this.txtWorkspace = new System.Windows.Forms.TextBox();
            this.bBrowseYamlFile = new System.Windows.Forms.Button();
            this.txtYamlFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(11, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(376, 30);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Register and deploy new model in AML";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Silver;
            this.panel4.Location = new System.Drawing.Point(0, 51);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(4000, 1);
            this.panel4.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BUpdate);
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.lblTitle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1142, 72);
            this.panel2.TabIndex = 5;
            // 
            // BUpdate
            // 
            this.BUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BUpdate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BUpdate.Location = new System.Drawing.Point(1005, 12);
            this.BUpdate.Name = "BUpdate";
            this.BUpdate.Size = new System.Drawing.Size(125, 31);
            this.BUpdate.TabIndex = 26;
            this.BUpdate.Text = "Update Details";
            this.BUpdate.UseVisualStyleBackColor = true;
            this.BUpdate.Visible = false;
            this.BUpdate.Click += new System.EventHandler(this.BUpdate_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.White;
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1142, 5);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 1;
            this.progressBar1.Visible = false;
            // 
            // bRegisterModel
            // 
            this.bRegisterModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bRegisterModel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bRegisterModel.Location = new System.Drawing.Point(510, 235);
            this.bRegisterModel.Name = "bRegisterModel";
            this.bRegisterModel.Size = new System.Drawing.Size(165, 55);
            this.bRegisterModel.TabIndex = 7;
            this.bRegisterModel.Text = "Register and Deploy";
            this.bRegisterModel.UseVisualStyleBackColor = true;
            this.bRegisterModel.Click += new System.EventHandler(this.bRegisterModel_Click);
            // 
            // txtModelName
            // 
            this.txtModelName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelName.Location = new System.Drawing.Point(137, 26);
            this.txtModelName.Name = "txtModelName";
            this.txtModelName.Size = new System.Drawing.Size(538, 25);
            this.txtModelName.TabIndex = 0;
            this.txtModelName.Text = "diabetes-risk";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(137, 158);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(538, 71);
            this.txtDescription.TabIndex = 6;
            this.txtDescription.Text = "Sample model description...";
            // 
            // txtScoreFile
            // 
            this.txtScoreFile.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScoreFile.Location = new System.Drawing.Point(137, 92);
            this.txtScoreFile.Name = "txtScoreFile";
            this.txtScoreFile.Size = new System.Drawing.Size(457, 25);
            this.txtScoreFile.TabIndex = 4;
            // 
            // txtSubscriptionId
            // 
            this.txtSubscriptionId.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSubscriptionId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubscriptionId.Location = new System.Drawing.Point(106, 19);
            this.txtSubscriptionId.Name = "txtSubscriptionId";
            this.txtSubscriptionId.Size = new System.Drawing.Size(235, 23);
            this.txtSubscriptionId.TabIndex = 1;
            // 
            // txtModelFile
            // 
            this.txtModelFile.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelFile.Location = new System.Drawing.Point(137, 59);
            this.txtModelFile.Name = "txtModelFile";
            this.txtModelFile.Size = new System.Drawing.Size(457, 25);
            this.txtModelFile.TabIndex = 2;
            // 
            // bBrowseScoreFile
            // 
            this.bBrowseScoreFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bBrowseScoreFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBrowseScoreFile.Location = new System.Drawing.Point(600, 92);
            this.bBrowseScoreFile.Name = "bBrowseScoreFile";
            this.bBrowseScoreFile.Size = new System.Drawing.Size(75, 27);
            this.bBrowseScoreFile.TabIndex = 5;
            this.bBrowseScoreFile.Text = "Browse...";
            this.bBrowseScoreFile.UseVisualStyleBackColor = true;
            this.bBrowseScoreFile.Click += new System.EventHandler(this.bBrowseScoreFile_Click);
            // 
            // lblModelName
            // 
            this.lblModelName.AutoSize = true;
            this.lblModelName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelName.Location = new System.Drawing.Point(47, 29);
            this.lblModelName.Name = "lblModelName";
            this.lblModelName.Size = new System.Drawing.Size(88, 17);
            this.lblModelName.TabIndex = 6;
            this.lblModelName.Text = "Model Name:";
            // 
            // bBrowseModelFile
            // 
            this.bBrowseModelFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bBrowseModelFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBrowseModelFile.Location = new System.Drawing.Point(600, 59);
            this.bBrowseModelFile.Name = "bBrowseModelFile";
            this.bBrowseModelFile.Size = new System.Drawing.Size(75, 27);
            this.bBrowseModelFile.TabIndex = 3;
            this.bBrowseModelFile.Text = "Browse...";
            this.bBrowseModelFile.UseVisualStyleBackColor = true;
            this.bBrowseModelFile.Click += new System.EventHandler(this.bBrowseModelFile_Click);
            // 
            // lblScoreFile
            // 
            this.lblScoreFile.AutoSize = true;
            this.lblScoreFile.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScoreFile.Location = new System.Drawing.Point(68, 93);
            this.lblScoreFile.Name = "lblScoreFile";
            this.lblScoreFile.Size = new System.Drawing.Size(67, 17);
            this.lblScoreFile.TabIndex = 14;
            this.lblScoreFile.Text = "Score File:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(58, 157);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(77, 17);
            this.lblDescription.TabIndex = 8;
            this.lblDescription.Text = "Description:";
            // 
            // lblModelFile
            // 
            this.lblModelFile.AutoSize = true;
            this.lblModelFile.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelFile.Location = new System.Drawing.Point(63, 61);
            this.lblModelFile.Name = "lblModelFile";
            this.lblModelFile.Size = new System.Drawing.Size(72, 17);
            this.lblModelFile.TabIndex = 12;
            this.lblModelFile.Text = "Model File:";
            // 
            // lblSubscriptionId
            // 
            this.lblSubscriptionId.AutoSize = true;
            this.lblSubscriptionId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubscriptionId.Location = new System.Drawing.Point(9, 21);
            this.lblSubscriptionId.Name = "lblSubscriptionId";
            this.lblSubscriptionId.Size = new System.Drawing.Size(89, 15);
            this.lblSubscriptionId.TabIndex = 10;
            this.lblSubscriptionId.Text = "Subscription Id:";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 72);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.link);
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            this.splitContainer2.Panel1.Controls.Add(this.bBrowseYamlFile);
            this.splitContainer2.Panel1.Controls.Add(this.txtYamlFile);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.bRegisterModel);
            this.splitContainer2.Panel1.Controls.Add(this.txtModelName);
            this.splitContainer2.Panel1.Controls.Add(this.lblModelName);
            this.splitContainer2.Panel1.Controls.Add(this.txtDescription);
            this.splitContainer2.Panel1.Controls.Add(this.txtScoreFile);
            this.splitContainer2.Panel1.Controls.Add(this.lblModelFile);
            this.splitContainer2.Panel1.Controls.Add(this.lblDescription);
            this.splitContainer2.Panel1.Controls.Add(this.txtModelFile);
            this.splitContainer2.Panel1.Controls.Add(this.lblScoreFile);
            this.splitContainer2.Panel1.Controls.Add(this.bBrowseScoreFile);
            this.splitContainer2.Panel1.Controls.Add(this.bBrowseModelFile);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.txtOutput);
            this.splitContainer2.Size = new System.Drawing.Size(1142, 602);
            this.splitContainer2.SplitterDistance = 341;
            this.splitContainer2.TabIndex = 19;
            // 
            // link
            // 
            this.link.AutoSize = true;
            this.link.Location = new System.Drawing.Point(136, 235);
            this.link.Name = "link";
            this.link.Size = new System.Drawing.Size(74, 13);
            this.link.TabIndex = 25;
            this.link.TabStop = true;
            this.link.Text = "Python script";
            this.link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtAKSCluster);
            this.panel1.Controls.Add(this.txtSubscriptionId);
            this.panel1.Controls.Add(this.lblRegion);
            this.panel1.Controls.Add(this.lblSubscriptionId);
            this.panel1.Controls.Add(this.txtRegion);
            this.panel1.Controls.Add(this.lblResourceGroup);
            this.panel1.Controls.Add(this.lblWorkspace);
            this.panel1.Controls.Add(this.txtResourceGroup);
            this.panel1.Controls.Add(this.txtWorkspace);
            this.panel1.Location = new System.Drawing.Point(690, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(359, 185);
            this.panel1.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 25;
            this.label2.Text = "AKS Cluster:";
            // 
            // txtAKSCluster
            // 
            this.txtAKSCluster.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtAKSCluster.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAKSCluster.Location = new System.Drawing.Point(106, 136);
            this.txtAKSCluster.Name = "txtAKSCluster";
            this.txtAKSCluster.Size = new System.Drawing.Size(235, 23);
            this.txtAKSCluster.TabIndex = 24;
            // 
            // lblRegion
            // 
            this.lblRegion.AutoSize = true;
            this.lblRegion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegion.Location = new System.Drawing.Point(9, 111);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(47, 15);
            this.lblRegion.TabIndex = 23;
            this.lblRegion.Text = "Region:";
            // 
            // txtRegion
            // 
            this.txtRegion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtRegion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegion.Location = new System.Drawing.Point(106, 106);
            this.txtRegion.Name = "txtRegion";
            this.txtRegion.Size = new System.Drawing.Size(235, 23);
            this.txtRegion.TabIndex = 22;
            // 
            // lblResourceGroup
            // 
            this.lblResourceGroup.AutoSize = true;
            this.lblResourceGroup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResourceGroup.Location = new System.Drawing.Point(9, 51);
            this.lblResourceGroup.Name = "lblResourceGroup";
            this.lblResourceGroup.Size = new System.Drawing.Size(94, 15);
            this.lblResourceGroup.TabIndex = 19;
            this.lblResourceGroup.Text = "Resource Group:";
            // 
            // lblWorkspace
            // 
            this.lblWorkspace.AutoSize = true;
            this.lblWorkspace.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkspace.Location = new System.Drawing.Point(9, 81);
            this.lblWorkspace.Name = "lblWorkspace";
            this.lblWorkspace.Size = new System.Drawing.Size(68, 15);
            this.lblWorkspace.TabIndex = 21;
            this.lblWorkspace.Text = "Workspace:";
            // 
            // txtResourceGroup
            // 
            this.txtResourceGroup.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtResourceGroup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResourceGroup.Location = new System.Drawing.Point(106, 48);
            this.txtResourceGroup.Name = "txtResourceGroup";
            this.txtResourceGroup.Size = new System.Drawing.Size(235, 23);
            this.txtResourceGroup.TabIndex = 18;
            // 
            // txtWorkspace
            // 
            this.txtWorkspace.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtWorkspace.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWorkspace.Location = new System.Drawing.Point(106, 77);
            this.txtWorkspace.Name = "txtWorkspace";
            this.txtWorkspace.Size = new System.Drawing.Size(235, 23);
            this.txtWorkspace.TabIndex = 20;
            // 
            // bBrowseYamlFile
            // 
            this.bBrowseYamlFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bBrowseYamlFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBrowseYamlFile.Location = new System.Drawing.Point(600, 125);
            this.bBrowseYamlFile.Name = "bBrowseYamlFile";
            this.bBrowseYamlFile.Size = new System.Drawing.Size(75, 27);
            this.bBrowseYamlFile.TabIndex = 17;
            this.bBrowseYamlFile.Text = "Browse...";
            this.bBrowseYamlFile.UseVisualStyleBackColor = true;
            this.bBrowseYamlFile.Click += new System.EventHandler(this.bBrowseYamlFile_Click);
            // 
            // txtYamlFile
            // 
            this.txtYamlFile.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYamlFile.Location = new System.Drawing.Point(137, 125);
            this.txtYamlFile.Name = "txtYamlFile";
            this.txtYamlFile.Size = new System.Drawing.Size(457, 25);
            this.txtYamlFile.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Compose file (.yml):";
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.Location = new System.Drawing.Point(0, 0);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(1142, 257);
            this.txtOutput.TabIndex = 1;
            this.txtOutput.Text = "";
            // 
            // NewModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1142, 674);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "NewModel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Models";
            this.Load += new System.EventHandler(this.Model_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button bRegisterModel;
        private System.Windows.Forms.TextBox txtModelName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtScoreFile;
        private System.Windows.Forms.TextBox txtSubscriptionId;
        private System.Windows.Forms.TextBox txtModelFile;
        private System.Windows.Forms.Button bBrowseScoreFile;
        private System.Windows.Forms.Label lblModelName;
        private System.Windows.Forms.Button bBrowseModelFile;
        private System.Windows.Forms.Label lblScoreFile;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblModelFile;
        private System.Windows.Forms.Label lblSubscriptionId;
        private System.Windows.Forms.Button bBrowseYamlFile;
        private System.Windows.Forms.TextBox txtYamlFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblWorkspace;
        private System.Windows.Forms.TextBox txtWorkspace;
        private System.Windows.Forms.Label lblResourceGroup;
        private System.Windows.Forms.TextBox txtResourceGroup;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblRegion;
        private System.Windows.Forms.TextBox txtRegion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAKSCluster;
        private System.Windows.Forms.LinkLabel link;
        private System.Windows.Forms.Button BUpdate;
    }
}