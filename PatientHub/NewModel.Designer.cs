namespace PatientHubUI
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
            this.txtModelName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblModelName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblTags = new System.Windows.Forms.Label();
            this.txtTags = new System.Windows.Forms.TextBox();
            this.lblModelFile = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblScoreFile = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.bBrowseModelFile = new System.Windows.Forms.Button();
            this.bBrowseScoreFile = new System.Windows.Forms.Button();
            this.bBack = new System.Windows.Forms.Button();
            this.bNext = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.step1 = new System.Windows.Forms.TabPage();
            this.step2 = new System.Windows.Forms.TabPage();
            this.step3 = new System.Windows.Forms.TabPage();
            this.bAMLImageStart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.step1.SuspendLayout();
            this.step2.SuspendLayout();
            this.step3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtModelName
            // 
            this.txtModelName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelName.Location = new System.Drawing.Point(112, 15);
            this.txtModelName.Name = "txtModelName";
            this.txtModelName.Size = new System.Drawing.Size(363, 27);
            this.txtModelName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Create new model";
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
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(987, 72);
            this.panel2.TabIndex = 5;
            // 
            // lblModelName
            // 
            this.lblModelName.AutoSize = true;
            this.lblModelName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelName.Location = new System.Drawing.Point(7, 18);
            this.lblModelName.Name = "lblModelName";
            this.lblModelName.Size = new System.Drawing.Size(99, 20);
            this.lblModelName.TabIndex = 6;
            this.lblModelName.Text = "Model Name:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(18, 150);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(88, 20);
            this.lblDescription.TabIndex = 8;
            this.lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(112, 147);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(832, 64);
            this.txtDescription.TabIndex = 7;
            // 
            // lblTags
            // 
            this.lblTags.AutoSize = true;
            this.lblTags.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTags.Location = new System.Drawing.Point(65, 51);
            this.lblTags.Name = "lblTags";
            this.lblTags.Size = new System.Drawing.Size(41, 20);
            this.lblTags.TabIndex = 10;
            this.lblTags.Text = "Tags:";
            // 
            // txtTags
            // 
            this.txtTags.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTags.Location = new System.Drawing.Point(112, 48);
            this.txtTags.Name = "txtTags";
            this.txtTags.Size = new System.Drawing.Size(363, 27);
            this.txtTags.TabIndex = 9;
            // 
            // lblModelFile
            // 
            this.lblModelFile.AutoSize = true;
            this.lblModelFile.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelFile.Location = new System.Drawing.Point(24, 84);
            this.lblModelFile.Name = "lblModelFile";
            this.lblModelFile.Size = new System.Drawing.Size(82, 20);
            this.lblModelFile.TabIndex = 12;
            this.lblModelFile.Text = "Model File:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(112, 81);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(363, 27);
            this.textBox1.TabIndex = 11;
            // 
            // lblScoreFile
            // 
            this.lblScoreFile.AutoSize = true;
            this.lblScoreFile.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScoreFile.Location = new System.Drawing.Point(30, 116);
            this.lblScoreFile.Name = "lblScoreFile";
            this.lblScoreFile.Size = new System.Drawing.Size(76, 20);
            this.lblScoreFile.TabIndex = 14;
            this.lblScoreFile.Text = "Score File:";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(112, 114);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(363, 27);
            this.textBox2.TabIndex = 13;
            // 
            // bBrowseModelFile
            // 
            this.bBrowseModelFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bBrowseModelFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBrowseModelFile.Location = new System.Drawing.Point(481, 81);
            this.bBrowseModelFile.Name = "bBrowseModelFile";
            this.bBrowseModelFile.Size = new System.Drawing.Size(75, 28);
            this.bBrowseModelFile.TabIndex = 15;
            this.bBrowseModelFile.Text = "Browse...";
            this.bBrowseModelFile.UseVisualStyleBackColor = true;
            // 
            // bBrowseScoreFile
            // 
            this.bBrowseScoreFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bBrowseScoreFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBrowseScoreFile.Location = new System.Drawing.Point(481, 113);
            this.bBrowseScoreFile.Name = "bBrowseScoreFile";
            this.bBrowseScoreFile.Size = new System.Drawing.Size(75, 28);
            this.bBrowseScoreFile.TabIndex = 16;
            this.bBrowseScoreFile.Text = "Browse...";
            this.bBrowseScoreFile.UseVisualStyleBackColor = true;
            // 
            // bBack
            // 
            this.bBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bBack.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBack.Location = new System.Drawing.Point(13, 329);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(75, 34);
            this.bBack.TabIndex = 2;
            this.bBack.Text = "Back";
            this.bBack.UseVisualStyleBackColor = true;
            // 
            // bNext
            // 
            this.bNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bNext.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bNext.Location = new System.Drawing.Point(94, 329);
            this.bNext.Name = "bNext";
            this.bNext.Size = new System.Drawing.Size(75, 34);
            this.bNext.TabIndex = 3;
            this.bNext.Text = "Next";
            this.bNext.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.step1);
            this.tabControl1.Controls.Add(this.step2);
            this.tabControl1.Controls.Add(this.step3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 72);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(987, 397);
            this.tabControl1.TabIndex = 17;
            // 
            // step1
            // 
            this.step1.Controls.Add(this.button8);
            this.step1.Controls.Add(this.bNext);
            this.step1.Controls.Add(this.txtModelName);
            this.step1.Controls.Add(this.bBack);
            this.step1.Controls.Add(this.bBrowseScoreFile);
            this.step1.Controls.Add(this.lblModelName);
            this.step1.Controls.Add(this.bBrowseModelFile);
            this.step1.Controls.Add(this.txtDescription);
            this.step1.Controls.Add(this.lblScoreFile);
            this.step1.Controls.Add(this.lblDescription);
            this.step1.Controls.Add(this.textBox2);
            this.step1.Controls.Add(this.txtTags);
            this.step1.Controls.Add(this.lblModelFile);
            this.step1.Controls.Add(this.lblTags);
            this.step1.Controls.Add(this.textBox1);
            this.step1.Location = new System.Drawing.Point(4, 22);
            this.step1.Name = "step1";
            this.step1.Padding = new System.Windows.Forms.Padding(3);
            this.step1.Size = new System.Drawing.Size(979, 371);
            this.step1.TabIndex = 0;
            this.step1.Text = "Step 1: Register Model in AML";
            this.step1.UseVisualStyleBackColor = true;
            // 
            // step2
            // 
            this.step2.Controls.Add(this.button4);
            this.step2.Controls.Add(this.button5);
            this.step2.Controls.Add(this.label3);
            this.step2.Controls.Add(this.button1);
            this.step2.Controls.Add(this.label2);
            this.step2.Controls.Add(this.bAMLImageStart);
            this.step2.Location = new System.Drawing.Point(4, 22);
            this.step2.Name = "step2";
            this.step2.Padding = new System.Windows.Forms.Padding(3);
            this.step2.Size = new System.Drawing.Size(979, 371);
            this.step2.TabIndex = 1;
            this.step2.Text = "Step 2: Real-time API endpoint deployment";
            this.step2.UseVisualStyleBackColor = true;
            // 
            // step3
            // 
            this.step3.Controls.Add(this.button6);
            this.step3.Controls.Add(this.button7);
            this.step3.Controls.Add(this.label4);
            this.step3.Controls.Add(this.button2);
            this.step3.Controls.Add(this.label5);
            this.step3.Controls.Add(this.button3);
            this.step3.Location = new System.Drawing.Point(4, 22);
            this.step3.Name = "step3";
            this.step3.Size = new System.Drawing.Size(979, 371);
            this.step3.TabIndex = 2;
            this.step3.Text = "Step 3: Batch API endpoint deployment";
            this.step3.UseVisualStyleBackColor = true;
            // 
            // bAMLImageStart
            // 
            this.bAMLImageStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAMLImageStart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAMLImageStart.Location = new System.Drawing.Point(414, 16);
            this.bAMLImageStart.Name = "bAMLImageStart";
            this.bAMLImageStart.Size = new System.Drawing.Size(91, 38);
            this.bAMLImageStart.TabIndex = 4;
            this.bAMLImageStart.Text = "Start";
            this.bAMLImageStart.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(386, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Create and Resister an image in AML that uses the model";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(250, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Deploy image to AML";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(414, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 38);
            this.button1.TabIndex = 6;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(220, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(292, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Publish teh AML pipeline as REST endpoint";
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(518, 71);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 38);
            this.button2.TabIndex = 10;
            this.button2.Text = "Start";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(492, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Create AMl Pipelines with the batch scoring ad model explanation scripts";
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(518, 17);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 38);
            this.button3.TabIndex = 8;
            this.button3.Text = "Start";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(94, 329);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 34);
            this.button4.TabIndex = 9;
            this.button4.Text = "Next";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(13, 329);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 34);
            this.button5.TabIndex = 8;
            this.button5.Text = "Back";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(94, 329);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 34);
            this.button6.TabIndex = 13;
            this.button6.Text = "Next";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(13, 329);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 34);
            this.button7.TabIndex = 12;
            this.button7.Text = "Back";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(853, 232);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(91, 38);
            this.button8.TabIndex = 17;
            this.button8.Text = "Start";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // NewModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(987, 469);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "NewModel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Models";
            this.Load += new System.EventHandler(this.Model_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.step1.ResumeLayout(false);
            this.step1.PerformLayout();
            this.step2.ResumeLayout(false);
            this.step2.PerformLayout();
            this.step3.ResumeLayout(false);
            this.step3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtModelName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblModelName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblTags;
        private System.Windows.Forms.TextBox txtTags;
        private System.Windows.Forms.Label lblModelFile;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblScoreFile;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button bBrowseModelFile;
        private System.Windows.Forms.Button bBrowseScoreFile;
        private System.Windows.Forms.Button bBack;
        private System.Windows.Forms.Button bNext;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage step1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TabPage step2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bAMLImageStart;
        private System.Windows.Forms.TabPage step3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
    }
}