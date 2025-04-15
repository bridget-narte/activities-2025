namespace Narte_Activity1
{
    partial class Form1
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
            this.lblEnterInfo = new System.Windows.Forms.Label();
            this.lblSubmittedEntries = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.txtFamilyName = new System.Windows.Forms.TextBox();
            this.txtEmailAdd = new System.Windows.Forms.TextBox();
            this.txtCourse = new System.Windows.Forms.TextBox();
            this.bttnSubmit = new System.Windows.Forms.Button();
            this.comboBoxAge = new System.Windows.Forms.ComboBox();
            this.resultPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblEnterInfo
            // 
            this.lblEnterInfo.AutoSize = true;
            this.lblEnterInfo.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnterInfo.Location = new System.Drawing.Point(31, 22);
            this.lblEnterInfo.Name = "lblEnterInfo";
            this.lblEnterInfo.Size = new System.Drawing.Size(229, 25);
            this.lblEnterInfo.TabIndex = 0;
            this.lblEnterInfo.Text = "Enter Your Information";
            // 
            // lblSubmittedEntries
            // 
            this.lblSubmittedEntries.AutoSize = true;
            this.lblSubmittedEntries.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubmittedEntries.Location = new System.Drawing.Point(430, 21);
            this.lblSubmittedEntries.Name = "lblSubmittedEntries";
            this.lblSubmittedEntries.Size = new System.Drawing.Size(210, 25);
            this.lblSubmittedEntries.TabIndex = 1;
            this.lblSubmittedEntries.Text = "All Submitted Entries";
            // 
            // txtFirstName
            // 
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFirstName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new System.Drawing.Point(36, 62);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(379, 27);
            this.txtFirstName.TabIndex = 2;
            this.txtFirstName.UseWaitCursor = true;
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMiddleName.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtMiddleName.Location = new System.Drawing.Point(37, 107);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(379, 27);
            this.txtMiddleName.TabIndex = 3;
            // 
            // txtFamilyName
            // 
            this.txtFamilyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFamilyName.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtFamilyName.Location = new System.Drawing.Point(36, 152);
            this.txtFamilyName.Name = "txtFamilyName";
            this.txtFamilyName.Size = new System.Drawing.Size(379, 27);
            this.txtFamilyName.TabIndex = 4;
            // 
            // txtEmailAdd
            // 
            this.txtEmailAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmailAdd.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtEmailAdd.Location = new System.Drawing.Point(36, 246);
            this.txtEmailAdd.Multiline = true;
            this.txtEmailAdd.Name = "txtEmailAdd";
            this.txtEmailAdd.Size = new System.Drawing.Size(379, 32);
            this.txtEmailAdd.TabIndex = 6;
            // 
            // txtCourse
            // 
            this.txtCourse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCourse.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtCourse.Location = new System.Drawing.Point(36, 293);
            this.txtCourse.Multiline = true;
            this.txtCourse.Name = "txtCourse";
            this.txtCourse.Size = new System.Drawing.Size(379, 32);
            this.txtCourse.TabIndex = 7;
            // 
            // bttnSubmit
            // 
            this.bttnSubmit.BackColor = System.Drawing.Color.RoyalBlue;
            this.bttnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttnSubmit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnSubmit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bttnSubmit.Location = new System.Drawing.Point(35, 337);
            this.bttnSubmit.Name = "bttnSubmit";
            this.bttnSubmit.Size = new System.Drawing.Size(81, 40);
            this.bttnSubmit.TabIndex = 8;
            this.bttnSubmit.Text = "Submit";
            this.bttnSubmit.UseVisualStyleBackColor = false;
            this.bttnSubmit.Click += new System.EventHandler(this.bttnSubmit_Click);
            // 
            // comboBoxAge
            // 
            this.comboBoxAge.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.comboBoxAge.FormattingEnabled = true;
            this.comboBoxAge.Location = new System.Drawing.Point(37, 204);
            this.comboBoxAge.Name = "comboBoxAge";
            this.comboBoxAge.Size = new System.Drawing.Size(378, 28);
            this.comboBoxAge.TabIndex = 9;
            // 
            // resultPanel
            // 
            this.resultPanel.AutoScroll = true;
            this.resultPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.resultPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resultPanel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultPanel.Location = new System.Drawing.Point(435, 62);
            this.resultPanel.Name = "resultPanel";
            this.resultPanel.Padding = new System.Windows.Forms.Padding(20);
            this.resultPanel.Size = new System.Drawing.Size(305, 263);
            this.resultPanel.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.ForestGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(435, 337);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(516, 337);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(779, 406);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.resultPanel);
            this.Controls.Add(this.comboBoxAge);
            this.Controls.Add(this.bttnSubmit);
            this.Controls.Add(this.txtCourse);
            this.Controls.Add(this.txtEmailAdd);
            this.Controls.Add(this.txtFamilyName);
            this.Controls.Add(this.txtMiddleName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblSubmittedEntries);
            this.Controls.Add(this.lblEnterInfo);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEnterInfo;
        private System.Windows.Forms.Label lblSubmittedEntries;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.TextBox txtFamilyName;
        private System.Windows.Forms.TextBox txtEmailAdd;
        private System.Windows.Forms.TextBox txtCourse;
        private System.Windows.Forms.Button bttnSubmit;
        private System.Windows.Forms.ComboBox comboBoxAge;
        private System.Windows.Forms.FlowLayoutPanel resultPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

