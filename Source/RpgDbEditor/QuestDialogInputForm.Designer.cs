namespace RpgDbManager
{
    partial class QuestDialogInputForm
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
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.cmbCondition = new System.Windows.Forms.ComboBox();
            this.cmbConditionType = new System.Windows.Forms.ComboBox();
            this.cmbDoneCondition = new System.Windows.Forms.ComboBox();
            this.cmbDoneConditionType = new System.Windows.Forms.ComboBox();
            this.cmbAction = new System.Windows.Forms.ComboBox();
            this.cmbActionType = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblID = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(12, 12);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtID.Size = new System.Drawing.Size(316, 21);
            this.txtID.TabIndex = 1;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(12, 39);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDescription.Size = new System.Drawing.Size(316, 21);
            this.txtDescription.TabIndex = 2;
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
            // cmbDoneCondition
            // 
            this.cmbDoneCondition.FormattingEnabled = true;
            this.cmbDoneCondition.Location = new System.Drawing.Point(12, 93);
            this.cmbDoneCondition.Name = "cmbDoneCondition";
            this.cmbDoneCondition.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbDoneCondition.Size = new System.Drawing.Size(155, 21);
            this.cmbDoneCondition.TabIndex = 6;
            // 
            // cmbDoneConditionType
            // 
            this.cmbDoneConditionType.FormattingEnabled = true;
            this.cmbDoneConditionType.Items.AddRange(new object[] {
            "HasItem",
            "HasMoney",
            "QuestNotOpended",
            "QuestOpened",
            "QuestClosed"});
            this.cmbDoneConditionType.Location = new System.Drawing.Point(173, 93);
            this.cmbDoneConditionType.Name = "cmbDoneConditionType";
            this.cmbDoneConditionType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbDoneConditionType.Size = new System.Drawing.Size(155, 21);
            this.cmbDoneConditionType.TabIndex = 5;
            // 
            // cmbAction
            // 
            this.cmbAction.FormattingEnabled = true;
            this.cmbAction.Location = new System.Drawing.Point(12, 120);
            this.cmbAction.Name = "cmbAction";
            this.cmbAction.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbAction.Size = new System.Drawing.Size(155, 21);
            this.cmbAction.TabIndex = 8;
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
            this.cmbActionType.Location = new System.Drawing.Point(173, 120);
            this.cmbActionType.Name = "cmbActionType";
            this.cmbActionType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbActionType.Size = new System.Drawing.Size(155, 21);
            this.cmbActionType.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(93, 147);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "ذخیره";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 147);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "لغو";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(351, 15);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(42, 13);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "شناسه";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(346, 42);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(47, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "توضیحات";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(360, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = " شرط";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(334, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = " شرط اتمام";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(358, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "اکشن";
            // 
            // QuestDialogInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 183);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cmbActionType);
            this.Controls.Add(this.cmbDoneConditionType);
            this.Controls.Add(this.cmbConditionType);
            this.Controls.Add(this.cmbAction);
            this.Controls.Add(this.cmbDoneCondition);
            this.Controls.Add(this.cmbCondition);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtID);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuestDialogInputForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.QuestDialogInputForm_Load);
            this.Shown += new System.EventHandler(this.QuestDialogInputForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.ComboBox cmbCondition;
        private System.Windows.Forms.ComboBox cmbConditionType;
        private System.Windows.Forms.ComboBox cmbDoneCondition;
        private System.Windows.Forms.ComboBox cmbDoneConditionType;
        private System.Windows.Forms.ComboBox cmbAction;
        private System.Windows.Forms.ComboBox cmbActionType;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}