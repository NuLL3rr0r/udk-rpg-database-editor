namespace RpgDbManager
{
    partial class InteractiveDialogInputForm1
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
            this.txtComment = new System.Windows.Forms.TextBox();
            this.txtDialogText = new System.Windows.Forms.TextBox();
            this.cmbConditionType = new System.Windows.Forms.ComboBox();
            this.cmbCondition = new System.Windows.Forms.ComboBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.lblCondition = new System.Windows.Forms.Label();
            this.lblDialogText = new System.Windows.Forms.Label();
            this.lblAction = new System.Windows.Forms.Label();
            this.cmbAction = new System.Windows.Forms.ComboBox();
            this.cmbActionType = new System.Windows.Forms.ComboBox();
            this.cmbCharacterID = new System.Windows.Forms.ComboBox();
            this.lblCharacterID = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(12, 120);
            this.txtComment.Name = "txtComment";
            this.txtComment.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtComment.Size = new System.Drawing.Size(316, 21);
            this.txtComment.TabIndex = 7;
            // 
            // txtDialogText
            // 
            this.txtDialogText.Location = new System.Drawing.Point(12, 39);
            this.txtDialogText.Name = "txtDialogText";
            this.txtDialogText.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDialogText.Size = new System.Drawing.Size(316, 21);
            this.txtDialogText.TabIndex = 2;
            // 
            // cmbConditionType
            // 
            this.cmbConditionType.FormattingEnabled = true;
            this.cmbConditionType.Items.AddRange(new object[] {
            "HasItem",
            "HasMoney",
            "QuestNotOpended",
            "QuestOpened",
            "QuestClosed"});
            this.cmbConditionType.Location = new System.Drawing.Point(173, 66);
            this.cmbConditionType.Name = "cmbConditionType";
            this.cmbConditionType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbConditionType.Size = new System.Drawing.Size(155, 21);
            this.cmbConditionType.TabIndex = 3;
            // 
            // cmbCondition
            // 
            this.cmbCondition.FormattingEnabled = true;
            this.cmbCondition.Location = new System.Drawing.Point(12, 66);
            this.cmbCondition.Name = "cmbCondition";
            this.cmbCondition.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbCondition.Size = new System.Drawing.Size(155, 21);
            this.cmbCondition.TabIndex = 4;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(361, 123);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(47, 13);
            this.lblComment.TabIndex = 0;
            this.lblComment.Text = "توضیحات";
            // 
            // lblCondition
            // 
            this.lblCondition.AutoSize = true;
            this.lblCondition.Location = new System.Drawing.Point(375, 69);
            this.lblCondition.Name = "lblCondition";
            this.lblCondition.Size = new System.Drawing.Size(33, 13);
            this.lblCondition.TabIndex = 0;
            this.lblCondition.Text = " شرط";
            // 
            // lblDialogText
            // 
            this.lblDialogText.AutoSize = true;
            this.lblDialogText.Location = new System.Drawing.Point(351, 42);
            this.lblDialogText.Name = "lblDialogText";
            this.lblDialogText.Size = new System.Drawing.Size(57, 13);
            this.lblDialogText.TabIndex = 0;
            this.lblDialogText.Text = "متن دیالوگ";
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.Location = new System.Drawing.Point(373, 96);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(35, 13);
            this.lblAction.TabIndex = 0;
            this.lblAction.Text = "اکشن";
            // 
            // cmbAction
            // 
            this.cmbAction.FormattingEnabled = true;
            this.cmbAction.Location = new System.Drawing.Point(12, 93);
            this.cmbAction.Name = "cmbAction";
            this.cmbAction.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbAction.Size = new System.Drawing.Size(155, 21);
            this.cmbAction.TabIndex = 6;
            // 
            // cmbActionType
            // 
            this.cmbActionType.FormattingEnabled = true;
            this.cmbActionType.Items.AddRange(new object[] {
            "AddItem",
            "RemoveItem",
            "AddMoney",
            "RemoveMoney",
            "OpenQuest",
            "CloseQuest",
            "OpenShop",
            "AddXP",
            "RunKismet",
            "MakeEnemy"});
            this.cmbActionType.Location = new System.Drawing.Point(173, 93);
            this.cmbActionType.Name = "cmbActionType";
            this.cmbActionType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbActionType.Size = new System.Drawing.Size(155, 21);
            this.cmbActionType.TabIndex = 5;
            // 
            // cmbCharacterID
            // 
            this.cmbCharacterID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCharacterID.FormattingEnabled = true;
            this.cmbCharacterID.ItemHeight = 13;
            this.cmbCharacterID.Location = new System.Drawing.Point(12, 12);
            this.cmbCharacterID.Name = "cmbCharacterID";
            this.cmbCharacterID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbCharacterID.Size = new System.Drawing.Size(316, 21);
            this.cmbCharacterID.TabIndex = 1;
            // 
            // lblCharacterID
            // 
            this.lblCharacterID.AutoSize = true;
            this.lblCharacterID.Location = new System.Drawing.Point(334, 15);
            this.lblCharacterID.Name = "lblCharacterID";
            this.lblCharacterID.Size = new System.Drawing.Size(74, 13);
            this.lblCharacterID.TabIndex = 0;
            this.lblCharacterID.Text = "شناسه کاراکتر";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 147);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "لغو";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(93, 147);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "ذخیره";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // InteractiveDialogInputForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 184);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.txtDialogText);
            this.Controls.Add(this.cmbActionType);
            this.Controls.Add(this.cmbAction);
            this.Controls.Add(this.cmbConditionType);
            this.Controls.Add(this.cmbCondition);
            this.Controls.Add(this.cmbCharacterID);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.lblAction);
            this.Controls.Add(this.lblCondition);
            this.Controls.Add(this.lblDialogText);
            this.Controls.Add(this.lblCharacterID);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InteractiveDialogInputForm1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.InteractiveDialogInputForm1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.TextBox txtDialogText;
        private System.Windows.Forms.ComboBox cmbConditionType;
        private System.Windows.Forms.ComboBox cmbCondition;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Label lblCondition;
        private System.Windows.Forms.Label lblDialogText;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.ComboBox cmbAction;
        private System.Windows.Forms.ComboBox cmbActionType;
        private System.Windows.Forms.ComboBox cmbCharacterID;
        private System.Windows.Forms.Label lblCharacterID;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}