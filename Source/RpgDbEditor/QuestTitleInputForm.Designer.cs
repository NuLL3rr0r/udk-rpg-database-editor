namespace RpgDbManager
{
    partial class QuestTitleInputForm
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
            this.lblTitleText = new System.Windows.Forms.Label();
            this.txtTitleText = new System.Windows.Forms.TextBox();
            this.txtTitleLevel = new System.Windows.Forms.TextBox();
            this.lblTitleLevel = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitleText
            // 
            this.lblTitleText.AutoSize = true;
            this.lblTitleText.Location = new System.Drawing.Point(194, 17);
            this.lblTitleText.Name = "lblTitleText";
            this.lblTitleText.Size = new System.Drawing.Size(33, 13);
            this.lblTitleText.TabIndex = 0;
            this.lblTitleText.Text = "عنوان";
            // 
            // txtTitleText
            // 
            this.txtTitleText.Location = new System.Drawing.Point(12, 14);
            this.txtTitleText.Name = "txtTitleText";
            this.txtTitleText.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTitleText.Size = new System.Drawing.Size(175, 21);
            this.txtTitleText.TabIndex = 1;
            // 
            // txtTitleLevel
            // 
            this.txtTitleLevel.Location = new System.Drawing.Point(12, 41);
            this.txtTitleLevel.Name = "txtTitleLevel";
            this.txtTitleLevel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTitleLevel.Size = new System.Drawing.Size(175, 21);
            this.txtTitleLevel.TabIndex = 2;
            // 
            // lblTitleLevel
            // 
            this.lblTitleLevel.AutoSize = true;
            this.lblTitleLevel.Location = new System.Drawing.Point(193, 44);
            this.lblTitleLevel.Name = "lblTitleLevel";
            this.lblTitleLevel.Size = new System.Drawing.Size(34, 13);
            this.lblTitleLevel.TabIndex = 0;
            this.lblTitleLevel.Text = "سطح";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(93, 73);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "ذخیره";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 73);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "لغو";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // QuestTitleInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 108);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblTitleLevel);
            this.Controls.Add(this.lblTitleText);
            this.Controls.Add(this.txtTitleLevel);
            this.Controls.Add(this.txtTitleText);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuestTitleInputForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.QuestTitleInputForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitleText;
        private System.Windows.Forms.TextBox txtTitleText;
        private System.Windows.Forms.TextBox txtTitleLevel;
        private System.Windows.Forms.Label lblTitleLevel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}