namespace RpgDbManager
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
            this.components = new System.ComponentModel.Container();
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tbpCharacters = new System.Windows.Forms.TabPage();
            this.tblCharacters = new System.Windows.Forms.TableLayoutPanel();
            this.dgvCharacters = new System.Windows.Forms.DataGridView();
            this.ctxCharactersMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCharactersEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCharactersErase = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlCharactersForm = new System.Windows.Forms.Panel();
            this.txtCharactersSearch = new System.Windows.Forms.TextBox();
            this.txtCharactersID = new System.Windows.Forms.TextBox();
            this.lblCharactersSearchWarning = new System.Windows.Forms.Label();
            this.lblCharactersSearch = new System.Windows.Forms.Label();
            this.btnCharactersCancel = new System.Windows.Forms.Button();
            this.btnCharactersAddEdit = new System.Windows.Forms.Button();
            this.lblCharctersID = new System.Windows.Forms.Label();
            this.tbpInteractiveDialogs = new System.Windows.Forms.TabPage();
            this.trvInterActiveDialog = new System.Windows.Forms.TreeView();
            this.ctxInteractiveDialogs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuInteractiveDialogsAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInteractiveDialogsEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInteractiveDialogsErase = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInteractiveDialogsSeparator01 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuInteractiveDialogsMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInteractiveDialogsMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInteractiveDialogsSeparator02 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuInteractiveDialogsGroupTitle = new System.Windows.Forms.ToolStripMenuItem();
            this.tbpQuest = new System.Windows.Forms.TabPage();
            this.pnlQuests = new System.Windows.Forms.Panel();
            this.btnSideQuest18 = new System.Windows.Forms.Button();
            this.ctxQuestButtons = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuQuestButtonsQuestTitle = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSideQuest17 = new System.Windows.Forms.Button();
            this.btnSideQuest16 = new System.Windows.Forms.Button();
            this.btnSideQuest15 = new System.Windows.Forms.Button();
            this.btnSideQuest14 = new System.Windows.Forms.Button();
            this.btnSideQuest13 = new System.Windows.Forms.Button();
            this.btnSideQuest12 = new System.Windows.Forms.Button();
            this.btnSideQuest11 = new System.Windows.Forms.Button();
            this.btnSideQuest10 = new System.Windows.Forms.Button();
            this.btnSideQuest09 = new System.Windows.Forms.Button();
            this.btnSideQuest08 = new System.Windows.Forms.Button();
            this.btnSideQuest07 = new System.Windows.Forms.Button();
            this.btnSideQuest06 = new System.Windows.Forms.Button();
            this.btnSideQuest05 = new System.Windows.Forms.Button();
            this.btnSideQuest04 = new System.Windows.Forms.Button();
            this.btnSideQuest03 = new System.Windows.Forms.Button();
            this.btnSideQuest02 = new System.Windows.Forms.Button();
            this.btnSideQuest01 = new System.Windows.Forms.Button();
            this.btnMainQuest06 = new System.Windows.Forms.Button();
            this.btnMainQuest05 = new System.Windows.Forms.Button();
            this.btnMainQuest04 = new System.Windows.Forms.Button();
            this.btnMainQuest03 = new System.Windows.Forms.Button();
            this.btnMainQuest02 = new System.Windows.Forms.Button();
            this.btnMainQuest01 = new System.Windows.Forms.Button();
            this.tbpExport = new System.Windows.Forms.TabPage();
            this.pnlExportMain = new System.Windows.Forms.Panel();
            this.txtExportPath = new System.Windows.Forms.TextBox();
            this.btnSetExportPath = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.fbdExport = new System.Windows.Forms.FolderBrowserDialog();
            this.mnuCharactersSeparator01 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCharactersInteractiveDialogs = new System.Windows.Forms.ToolStripMenuItem();
            this.tbcMain.SuspendLayout();
            this.tbpCharacters.SuspendLayout();
            this.tblCharacters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCharacters)).BeginInit();
            this.ctxCharactersMenu.SuspendLayout();
            this.pnlCharactersForm.SuspendLayout();
            this.tbpInteractiveDialogs.SuspendLayout();
            this.ctxInteractiveDialogs.SuspendLayout();
            this.tbpQuest.SuspendLayout();
            this.pnlQuests.SuspendLayout();
            this.ctxQuestButtons.SuspendLayout();
            this.tbpExport.SuspendLayout();
            this.pnlExportMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcMain
            // 
            this.tbcMain.Controls.Add(this.tbpCharacters);
            this.tbcMain.Controls.Add(this.tbpInteractiveDialogs);
            this.tbcMain.Controls.Add(this.tbpQuest);
            this.tbcMain.Controls.Add(this.tbpExport);
            this.tbcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcMain.Location = new System.Drawing.Point(0, 0);
            this.tbcMain.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbcMain.RightToLeftLayout = true;
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(982, 693);
            this.tbcMain.TabIndex = 0;
            this.tbcMain.SelectedIndexChanged += new System.EventHandler(this.tbcMain_SelectedIndexChanged);
            // 
            // tbpCharacters
            // 
            this.tbpCharacters.Controls.Add(this.tblCharacters);
            this.tbpCharacters.Location = new System.Drawing.Point(4, 25);
            this.tbpCharacters.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tbpCharacters.Name = "tbpCharacters";
            this.tbpCharacters.Padding = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tbpCharacters.Size = new System.Drawing.Size(974, 664);
            this.tbpCharacters.TabIndex = 0;
            this.tbpCharacters.Text = "کاراکتر";
            this.tbpCharacters.UseVisualStyleBackColor = true;
            // 
            // tblCharacters
            // 
            this.tblCharacters.ColumnCount = 1;
            this.tblCharacters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblCharacters.Controls.Add(this.dgvCharacters, 0, 2);
            this.tblCharacters.Controls.Add(this.pnlCharactersForm, 0, 1);
            this.tblCharacters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblCharacters.Location = new System.Drawing.Point(3, 1);
            this.tblCharacters.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tblCharacters.Name = "tblCharacters";
            this.tblCharacters.RowCount = 3;
            this.tblCharacters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblCharacters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tblCharacters.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblCharacters.Size = new System.Drawing.Size(968, 662);
            this.tblCharacters.TabIndex = 1;
            // 
            // dgvCharacters
            // 
            this.dgvCharacters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCharacters.ContextMenuStrip = this.ctxCharactersMenu;
            this.dgvCharacters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCharacters.Location = new System.Drawing.Point(3, 56);
            this.dgvCharacters.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.dgvCharacters.Name = "dgvCharacters";
            this.dgvCharacters.Size = new System.Drawing.Size(962, 605);
            this.dgvCharacters.TabIndex = 6;
            // 
            // ctxCharactersMenu
            // 
            this.ctxCharactersMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCharactersEdit,
            this.mnuCharactersErase,
            this.mnuCharactersSeparator01,
            this.mnuCharactersInteractiveDialogs});
            this.ctxCharactersMenu.Name = "ctxCharactersMenu";
            this.ctxCharactersMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctxCharactersMenu.Size = new System.Drawing.Size(202, 98);
            // 
            // mnuCharactersEdit
            // 
            this.mnuCharactersEdit.Name = "mnuCharactersEdit";
            this.mnuCharactersEdit.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.mnuCharactersEdit.Size = new System.Drawing.Size(201, 22);
            this.mnuCharactersEdit.Text = "ویرایش";
            this.mnuCharactersEdit.Click += new System.EventHandler(this.mnuCharactersEdit_Click);
            // 
            // mnuCharactersErase
            // 
            this.mnuCharactersErase.Name = "mnuCharactersErase";
            this.mnuCharactersErase.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.mnuCharactersErase.Size = new System.Drawing.Size(201, 22);
            this.mnuCharactersErase.Text = "حذف";
            this.mnuCharactersErase.Click += new System.EventHandler(this.mnuCharactersErase_Click);
            // 
            // pnlCharactersForm
            // 
            this.pnlCharactersForm.Controls.Add(this.txtCharactersSearch);
            this.pnlCharactersForm.Controls.Add(this.txtCharactersID);
            this.pnlCharactersForm.Controls.Add(this.lblCharactersSearchWarning);
            this.pnlCharactersForm.Controls.Add(this.lblCharactersSearch);
            this.pnlCharactersForm.Controls.Add(this.btnCharactersCancel);
            this.pnlCharactersForm.Controls.Add(this.btnCharactersAddEdit);
            this.pnlCharactersForm.Controls.Add(this.lblCharctersID);
            this.pnlCharactersForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCharactersForm.Location = new System.Drawing.Point(3, 21);
            this.pnlCharactersForm.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.pnlCharactersForm.Name = "pnlCharactersForm";
            this.pnlCharactersForm.Size = new System.Drawing.Size(962, 33);
            this.pnlCharactersForm.TabIndex = 4;
            // 
            // txtCharactersSearch
            // 
            this.txtCharactersSearch.Location = new System.Drawing.Point(-1, 6);
            this.txtCharactersSearch.Name = "txtCharactersSearch";
            this.txtCharactersSearch.Size = new System.Drawing.Size(149, 23);
            this.txtCharactersSearch.TabIndex = 5;
            this.txtCharactersSearch.TextChanged += new System.EventHandler(this.txtCharactersSearch_TextChanged);
            // 
            // txtCharactersID
            // 
            this.txtCharactersID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCharactersID.Location = new System.Drawing.Point(678, 6);
            this.txtCharactersID.Name = "txtCharactersID";
            this.txtCharactersID.Size = new System.Drawing.Size(182, 23);
            this.txtCharactersID.TabIndex = 2;
            this.txtCharactersID.TextChanged += new System.EventHandler(this.txtCharactersID_TextChanged);
            // 
            // lblCharactersSearchWarning
            // 
            this.lblCharactersSearchWarning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCharactersSearchWarning.AutoSize = true;
            this.lblCharactersSearchWarning.ForeColor = System.Drawing.Color.DarkRed;
            this.lblCharactersSearchWarning.Location = new System.Drawing.Point(205, 10);
            this.lblCharactersSearchWarning.Name = "lblCharactersSearchWarning";
            this.lblCharactersSearchWarning.Size = new System.Drawing.Size(310, 16);
            this.lblCharactersSearchWarning.TabIndex = 6;
            this.lblCharactersSearchWarning.Text = "داده های جدول براساس جستجو فیلتر شده است";
            // 
            // lblCharactersSearch
            // 
            this.lblCharactersSearch.AutoSize = true;
            this.lblCharactersSearch.Location = new System.Drawing.Point(154, 9);
            this.lblCharactersSearch.Name = "lblCharactersSearch";
            this.lblCharactersSearch.Size = new System.Drawing.Size(55, 16);
            this.lblCharactersSearch.TabIndex = 4;
            this.lblCharactersSearch.Text = "جستجو";
            // 
            // btnCharactersCancel
            // 
            this.btnCharactersCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCharactersCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCharactersCancel.Location = new System.Drawing.Point(516, 7);
            this.btnCharactersCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCharactersCancel.Name = "btnCharactersCancel";
            this.btnCharactersCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCharactersCancel.TabIndex = 3;
            this.btnCharactersCancel.Text = "لغو";
            this.btnCharactersCancel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCharactersCancel.UseVisualStyleBackColor = true;
            this.btnCharactersCancel.Click += new System.EventHandler(this.btnCharactersCancel_Click);
            // 
            // btnCharactersAddEdit
            // 
            this.btnCharactersAddEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCharactersAddEdit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCharactersAddEdit.Location = new System.Drawing.Point(597, 7);
            this.btnCharactersAddEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCharactersAddEdit.Name = "btnCharactersAddEdit";
            this.btnCharactersAddEdit.Size = new System.Drawing.Size(75, 23);
            this.btnCharactersAddEdit.TabIndex = 3;
            this.btnCharactersAddEdit.Text = "درج";
            this.btnCharactersAddEdit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCharactersAddEdit.UseVisualStyleBackColor = true;
            this.btnCharactersAddEdit.Click += new System.EventHandler(this.btnCharactersAddEdit_Click);
            // 
            // lblCharctersID
            // 
            this.lblCharctersID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCharctersID.AutoSize = true;
            this.lblCharctersID.Location = new System.Drawing.Point(866, 9);
            this.lblCharctersID.Name = "lblCharctersID";
            this.lblCharctersID.Size = new System.Drawing.Size(98, 16);
            this.lblCharctersID.TabIndex = 1;
            this.lblCharctersID.Text = "شناسه کاراکتر";
            // 
            // tbpInteractiveDialogs
            // 
            this.tbpInteractiveDialogs.Controls.Add(this.trvInterActiveDialog);
            this.tbpInteractiveDialogs.Location = new System.Drawing.Point(4, 25);
            this.tbpInteractiveDialogs.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tbpInteractiveDialogs.Name = "tbpInteractiveDialogs";
            this.tbpInteractiveDialogs.Padding = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tbpInteractiveDialogs.Size = new System.Drawing.Size(974, 664);
            this.tbpInteractiveDialogs.TabIndex = 1;
            this.tbpInteractiveDialogs.Text = "دیالوگ های تعاملی";
            this.tbpInteractiveDialogs.UseVisualStyleBackColor = true;
            // 
            // trvInterActiveDialog
            // 
            this.trvInterActiveDialog.ContextMenuStrip = this.ctxInteractiveDialogs;
            this.trvInterActiveDialog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvInterActiveDialog.Location = new System.Drawing.Point(3, 1);
            this.trvInterActiveDialog.Name = "trvInterActiveDialog";
            this.trvInterActiveDialog.RightToLeftLayout = true;
            this.trvInterActiveDialog.Size = new System.Drawing.Size(968, 662);
            this.trvInterActiveDialog.TabIndex = 0;
            this.trvInterActiveDialog.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvInterActiveDialog_AfterSelect);
            // 
            // ctxInteractiveDialogs
            // 
            this.ctxInteractiveDialogs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInteractiveDialogsAdd,
            this.mnuInteractiveDialogsEdit,
            this.mnuInteractiveDialogsErase,
            this.mnuInteractiveDialogsSeparator01,
            this.mnuInteractiveDialogsMoveUp,
            this.mnuInteractiveDialogsMoveDown,
            this.mnuInteractiveDialogsSeparator02,
            this.mnuInteractiveDialogsGroupTitle});
            this.ctxInteractiveDialogs.Name = "ctxInteractiveDialogs";
            this.ctxInteractiveDialogs.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctxInteractiveDialogs.Size = new System.Drawing.Size(168, 148);
            this.ctxInteractiveDialogs.Opening += new System.ComponentModel.CancelEventHandler(this.ctxInteractiveDialogs_Opening);
            // 
            // mnuInteractiveDialogsAdd
            // 
            this.mnuInteractiveDialogsAdd.Name = "mnuInteractiveDialogsAdd";
            this.mnuInteractiveDialogsAdd.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.mnuInteractiveDialogsAdd.Size = new System.Drawing.Size(167, 22);
            this.mnuInteractiveDialogsAdd.Text = "درج";
            this.mnuInteractiveDialogsAdd.Click += new System.EventHandler(this.mnuInteractiveDialogsAdd_Click);
            // 
            // mnuInteractiveDialogsEdit
            // 
            this.mnuInteractiveDialogsEdit.Name = "mnuInteractiveDialogsEdit";
            this.mnuInteractiveDialogsEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Insert)));
            this.mnuInteractiveDialogsEdit.Size = new System.Drawing.Size(167, 22);
            this.mnuInteractiveDialogsEdit.Text = "ویرایش";
            this.mnuInteractiveDialogsEdit.Click += new System.EventHandler(this.mnuInteractiveDialogsEdit_Click);
            // 
            // mnuInteractiveDialogsErase
            // 
            this.mnuInteractiveDialogsErase.Name = "mnuInteractiveDialogsErase";
            this.mnuInteractiveDialogsErase.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.mnuInteractiveDialogsErase.Size = new System.Drawing.Size(167, 22);
            this.mnuInteractiveDialogsErase.Text = "حذف";
            this.mnuInteractiveDialogsErase.Click += new System.EventHandler(this.mnuInteractiveDialogsErase_Click);
            // 
            // mnuInteractiveDialogsSeparator01
            // 
            this.mnuInteractiveDialogsSeparator01.Name = "mnuInteractiveDialogsSeparator01";
            this.mnuInteractiveDialogsSeparator01.Size = new System.Drawing.Size(164, 6);
            // 
            // mnuInteractiveDialogsMoveUp
            // 
            this.mnuInteractiveDialogsMoveUp.Name = "mnuInteractiveDialogsMoveUp";
            this.mnuInteractiveDialogsMoveUp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
            this.mnuInteractiveDialogsMoveUp.Size = new System.Drawing.Size(167, 22);
            this.mnuInteractiveDialogsMoveUp.Text = "▲";
            this.mnuInteractiveDialogsMoveUp.Click += new System.EventHandler(this.mnuInteractiveDialogsMoveUp_Click);
            // 
            // mnuInteractiveDialogsMoveDown
            // 
            this.mnuInteractiveDialogsMoveDown.Name = "mnuInteractiveDialogsMoveDown";
            this.mnuInteractiveDialogsMoveDown.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.mnuInteractiveDialogsMoveDown.Size = new System.Drawing.Size(167, 22);
            this.mnuInteractiveDialogsMoveDown.Text = "▼";
            this.mnuInteractiveDialogsMoveDown.Click += new System.EventHandler(this.mnuInteractiveDialogsMoveDown_Click);
            // 
            // mnuInteractiveDialogsSeparator02
            // 
            this.mnuInteractiveDialogsSeparator02.Name = "mnuInteractiveDialogsSeparator02";
            this.mnuInteractiveDialogsSeparator02.Size = new System.Drawing.Size(164, 6);
            // 
            // mnuInteractiveDialogsGroupTitle
            // 
            this.mnuInteractiveDialogsGroupTitle.Name = "mnuInteractiveDialogsGroupTitle";
            this.mnuInteractiveDialogsGroupTitle.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.mnuInteractiveDialogsGroupTitle.Size = new System.Drawing.Size(167, 22);
            this.mnuInteractiveDialogsGroupTitle.Text = "عنوان گروه";
            this.mnuInteractiveDialogsGroupTitle.Click += new System.EventHandler(this.mnuInteractiveDialogsGroupTitle_Click);
            // 
            // tbpQuest
            // 
            this.tbpQuest.Controls.Add(this.pnlQuests);
            this.tbpQuest.Location = new System.Drawing.Point(4, 25);
            this.tbpQuest.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tbpQuest.Name = "tbpQuest";
            this.tbpQuest.Size = new System.Drawing.Size(974, 664);
            this.tbpQuest.TabIndex = 2;
            this.tbpQuest.Text = "ماموریت";
            this.tbpQuest.UseVisualStyleBackColor = true;
            // 
            // pnlQuests
            // 
            this.pnlQuests.Controls.Add(this.btnSideQuest18);
            this.pnlQuests.Controls.Add(this.btnSideQuest17);
            this.pnlQuests.Controls.Add(this.btnSideQuest16);
            this.pnlQuests.Controls.Add(this.btnSideQuest15);
            this.pnlQuests.Controls.Add(this.btnSideQuest14);
            this.pnlQuests.Controls.Add(this.btnSideQuest13);
            this.pnlQuests.Controls.Add(this.btnSideQuest12);
            this.pnlQuests.Controls.Add(this.btnSideQuest11);
            this.pnlQuests.Controls.Add(this.btnSideQuest10);
            this.pnlQuests.Controls.Add(this.btnSideQuest09);
            this.pnlQuests.Controls.Add(this.btnSideQuest08);
            this.pnlQuests.Controls.Add(this.btnSideQuest07);
            this.pnlQuests.Controls.Add(this.btnSideQuest06);
            this.pnlQuests.Controls.Add(this.btnSideQuest05);
            this.pnlQuests.Controls.Add(this.btnSideQuest04);
            this.pnlQuests.Controls.Add(this.btnSideQuest03);
            this.pnlQuests.Controls.Add(this.btnSideQuest02);
            this.pnlQuests.Controls.Add(this.btnSideQuest01);
            this.pnlQuests.Controls.Add(this.btnMainQuest06);
            this.pnlQuests.Controls.Add(this.btnMainQuest05);
            this.pnlQuests.Controls.Add(this.btnMainQuest04);
            this.pnlQuests.Controls.Add(this.btnMainQuest03);
            this.pnlQuests.Controls.Add(this.btnMainQuest02);
            this.pnlQuests.Controls.Add(this.btnMainQuest01);
            this.pnlQuests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQuests.Location = new System.Drawing.Point(0, 0);
            this.pnlQuests.Name = "pnlQuests";
            this.pnlQuests.Size = new System.Drawing.Size(974, 664);
            this.pnlQuests.TabIndex = 25;
            // 
            // btnSideQuest18
            // 
            this.btnSideQuest18.ContextMenuStrip = this.ctxQuestButtons;
            this.btnSideQuest18.Location = new System.Drawing.Point(758, 492);
            this.btnSideQuest18.Name = "btnSideQuest18";
            this.btnSideQuest18.Size = new System.Drawing.Size(128, 124);
            this.btnSideQuest18.TabIndex = 48;
            this.btnSideQuest18.Tag = "QUEST00024";
            this.btnSideQuest18.Text = "QUEST00024";
            this.btnSideQuest18.UseVisualStyleBackColor = true;
            this.btnSideQuest18.Click += new System.EventHandler(this.btnMainQuest01_Click);
            // 
            // ctxQuestButtons
            // 
            this.ctxQuestButtons.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuQuestButtonsQuestTitle});
            this.ctxQuestButtons.Name = "ctxQuestButtons";
            this.ctxQuestButtons.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctxQuestButtons.Size = new System.Drawing.Size(163, 26);
            // 
            // mnuQuestButtonsQuestTitle
            // 
            this.mnuQuestButtonsQuestTitle.Name = "mnuQuestButtonsQuestTitle";
            this.mnuQuestButtonsQuestTitle.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.mnuQuestButtonsQuestTitle.Size = new System.Drawing.Size(162, 22);
            this.mnuQuestButtonsQuestTitle.Text = "عنوان ماموریت";
            this.mnuQuestButtonsQuestTitle.Click += new System.EventHandler(this.mnuQuestButtonsQuestTitle_Click);
            // 
            // btnSideQuest17
            // 
            this.btnSideQuest17.ContextMenuStrip = this.ctxQuestButtons;
            this.btnSideQuest17.Location = new System.Drawing.Point(624, 492);
            this.btnSideQuest17.Name = "btnSideQuest17";
            this.btnSideQuest17.Size = new System.Drawing.Size(128, 124);
            this.btnSideQuest17.TabIndex = 47;
            this.btnSideQuest17.Tag = "QUEST00023";
            this.btnSideQuest17.Text = "QUEST00023";
            this.btnSideQuest17.UseVisualStyleBackColor = true;
            this.btnSideQuest17.Click += new System.EventHandler(this.btnMainQuest01_Click);
            // 
            // btnSideQuest16
            // 
            this.btnSideQuest16.ContextMenuStrip = this.ctxQuestButtons;
            this.btnSideQuest16.Location = new System.Drawing.Point(490, 492);
            this.btnSideQuest16.Name = "btnSideQuest16";
            this.btnSideQuest16.Size = new System.Drawing.Size(128, 124);
            this.btnSideQuest16.TabIndex = 46;
            this.btnSideQuest16.Tag = "QUEST00022";
            this.btnSideQuest16.Text = "QUEST00022";
            this.btnSideQuest16.UseVisualStyleBackColor = true;
            this.btnSideQuest16.Click += new System.EventHandler(this.btnMainQuest01_Click);
            // 
            // btnSideQuest15
            // 
            this.btnSideQuest15.ContextMenuStrip = this.ctxQuestButtons;
            this.btnSideQuest15.Location = new System.Drawing.Point(356, 492);
            this.btnSideQuest15.Name = "btnSideQuest15";
            this.btnSideQuest15.Size = new System.Drawing.Size(128, 124);
            this.btnSideQuest15.TabIndex = 45;
            this.btnSideQuest15.Tag = "QUEST00021";
            this.btnSideQuest15.Text = "QUEST00021";
            this.btnSideQuest15.UseVisualStyleBackColor = true;
            this.btnSideQuest15.Click += new System.EventHandler(this.btnMainQuest01_Click);
            // 
            // btnSideQuest14
            // 
            this.btnSideQuest14.ContextMenuStrip = this.ctxQuestButtons;
            this.btnSideQuest14.Location = new System.Drawing.Point(222, 492);
            this.btnSideQuest14.Name = "btnSideQuest14";
            this.btnSideQuest14.Size = new System.Drawing.Size(128, 124);
            this.btnSideQuest14.TabIndex = 44;
            this.btnSideQuest14.Tag = "QUEST00020";
            this.btnSideQuest14.Text = "QUEST00020";
            this.btnSideQuest14.UseVisualStyleBackColor = true;
            this.btnSideQuest14.Click += new System.EventHandler(this.btnMainQuest01_Click);
            // 
            // btnSideQuest13
            // 
            this.btnSideQuest13.ContextMenuStrip = this.ctxQuestButtons;
            this.btnSideQuest13.Location = new System.Drawing.Point(88, 492);
            this.btnSideQuest13.Name = "btnSideQuest13";
            this.btnSideQuest13.Size = new System.Drawing.Size(128, 124);
            this.btnSideQuest13.TabIndex = 43;
            this.btnSideQuest13.Tag = "QUEST00019";
            this.btnSideQuest13.Text = "QUEST00019";
            this.btnSideQuest13.UseVisualStyleBackColor = true;
            this.btnSideQuest13.Click += new System.EventHandler(this.btnMainQuest01_Click);
            // 
            // btnSideQuest12
            // 
            this.btnSideQuest12.ContextMenuStrip = this.ctxQuestButtons;
            this.btnSideQuest12.Location = new System.Drawing.Point(758, 362);
            this.btnSideQuest12.Name = "btnSideQuest12";
            this.btnSideQuest12.Size = new System.Drawing.Size(128, 124);
            this.btnSideQuest12.TabIndex = 42;
            this.btnSideQuest12.Tag = "QUEST00018";
            this.btnSideQuest12.Text = "QUEST00018";
            this.btnSideQuest12.UseVisualStyleBackColor = true;
            this.btnSideQuest12.Click += new System.EventHandler(this.btnMainQuest01_Click);
            // 
            // btnSideQuest11
            // 
            this.btnSideQuest11.ContextMenuStrip = this.ctxQuestButtons;
            this.btnSideQuest11.Location = new System.Drawing.Point(624, 362);
            this.btnSideQuest11.Name = "btnSideQuest11";
            this.btnSideQuest11.Size = new System.Drawing.Size(128, 124);
            this.btnSideQuest11.TabIndex = 41;
            this.btnSideQuest11.Tag = "QUEST00017";
            this.btnSideQuest11.Text = "QUEST00017";
            this.btnSideQuest11.UseVisualStyleBackColor = true;
            this.btnSideQuest11.Click += new System.EventHandler(this.btnMainQuest01_Click);
            // 
            // btnSideQuest10
            // 
            this.btnSideQuest10.ContextMenuStrip = this.ctxQuestButtons;
            this.btnSideQuest10.Location = new System.Drawing.Point(490, 362);
            this.btnSideQuest10.Name = "btnSideQuest10";
            this.btnSideQuest10.Size = new System.Drawing.Size(128, 124);
            this.btnSideQuest10.TabIndex = 40;
            this.btnSideQuest10.Tag = "QUEST00016";
            this.btnSideQuest10.Text = "QUEST00016";
            this.btnSideQuest10.UseVisualStyleBackColor = true;
            this.btnSideQuest10.Click += new System.EventHandler(this.btnMainQuest01_Click);
            // 
            // btnSideQuest09
            // 
            this.btnSideQuest09.ContextMenuStrip = this.ctxQuestButtons;
            this.btnSideQuest09.Location = new System.Drawing.Point(356, 362);
            this.btnSideQuest09.Name = "btnSideQuest09";
            this.btnSideQuest09.Size = new System.Drawing.Size(128, 124);
            this.btnSideQuest09.TabIndex = 39;
            this.btnSideQuest09.Tag = "QUEST00015";
            this.btnSideQuest09.Text = "QUEST00015";
            this.btnSideQuest09.UseVisualStyleBackColor = true;
            this.btnSideQuest09.Click += new System.EventHandler(this.btnMainQuest01_Click);
            // 
            // btnSideQuest08
            // 
            this.btnSideQuest08.ContextMenuStrip = this.ctxQuestButtons;
            this.btnSideQuest08.Location = new System.Drawing.Point(222, 362);
            this.btnSideQuest08.Name = "btnSideQuest08";
            this.btnSideQuest08.Size = new System.Drawing.Size(128, 124);
            this.btnSideQuest08.TabIndex = 38;
            this.btnSideQuest08.Tag = "QUEST00014";
            this.btnSideQuest08.Text = "QUEST00014";
            this.btnSideQuest08.UseVisualStyleBackColor = true;
            this.btnSideQuest08.Click += new System.EventHandler(this.btnMainQuest01_Click);
            // 
            // btnSideQuest07
            // 
            this.btnSideQuest07.ContextMenuStrip = this.ctxQuestButtons;
            this.btnSideQuest07.Location = new System.Drawing.Point(88, 362);
            this.btnSideQuest07.Name = "btnSideQuest07";
            this.btnSideQuest07.Size = new System.Drawing.Size(128, 124);
            this.btnSideQuest07.TabIndex = 37;
            this.btnSideQuest07.Tag = "QUEST00013";
            this.btnSideQuest07.Text = "QUEST00013";
            this.btnSideQuest07.UseVisualStyleBackColor = true;
            this.btnSideQuest07.Click += new System.EventHandler(this.btnMainQuest01_Click);
            // 
            // btnSideQuest06
            // 
            this.btnSideQuest06.ContextMenuStrip = this.ctxQuestButtons;
            this.btnSideQuest06.Location = new System.Drawing.Point(758, 232);
            this.btnSideQuest06.Name = "btnSideQuest06";
            this.btnSideQuest06.Size = new System.Drawing.Size(128, 124);
            this.btnSideQuest06.TabIndex = 36;
            this.btnSideQuest06.Tag = "QUEST00012";
            this.btnSideQuest06.Text = "QUEST00012";
            this.btnSideQuest06.UseVisualStyleBackColor = true;
            this.btnSideQuest06.Click += new System.EventHandler(this.btnMainQuest01_Click);
            // 
            // btnSideQuest05
            // 
            this.btnSideQuest05.ContextMenuStrip = this.ctxQuestButtons;
            this.btnSideQuest05.Location = new System.Drawing.Point(624, 232);
            this.btnSideQuest05.Name = "btnSideQuest05";
            this.btnSideQuest05.Size = new System.Drawing.Size(128, 124);
            this.btnSideQuest05.TabIndex = 35;
            this.btnSideQuest05.Tag = "QUEST00011";
            this.btnSideQuest05.Text = "QUEST00011";
            this.btnSideQuest05.UseVisualStyleBackColor = true;
            this.btnSideQuest05.Click += new System.EventHandler(this.btnMainQuest01_Click);
            // 
            // btnSideQuest04
            // 
            this.btnSideQuest04.ContextMenuStrip = this.ctxQuestButtons;
            this.btnSideQuest04.Location = new System.Drawing.Point(490, 232);
            this.btnSideQuest04.Name = "btnSideQuest04";
            this.btnSideQuest04.Size = new System.Drawing.Size(128, 124);
            this.btnSideQuest04.TabIndex = 34;
            this.btnSideQuest04.Tag = "QUEST00010";
            this.btnSideQuest04.Text = "QUEST00010";
            this.btnSideQuest04.UseVisualStyleBackColor = true;
            this.btnSideQuest04.Click += new System.EventHandler(this.btnMainQuest01_Click);
            // 
            // btnSideQuest03
            // 
            this.btnSideQuest03.ContextMenuStrip = this.ctxQuestButtons;
            this.btnSideQuest03.Location = new System.Drawing.Point(356, 232);
            this.btnSideQuest03.Name = "btnSideQuest03";
            this.btnSideQuest03.Size = new System.Drawing.Size(128, 124);
            this.btnSideQuest03.TabIndex = 33;
            this.btnSideQuest03.Tag = "QUEST00009";
            this.btnSideQuest03.Text = "QUEST00009";
            this.btnSideQuest03.UseVisualStyleBackColor = true;
            this.btnSideQuest03.Click += new System.EventHandler(this.btnMainQuest01_Click);
            // 
            // btnSideQuest02
            // 
            this.btnSideQuest02.ContextMenuStrip = this.ctxQuestButtons;
            this.btnSideQuest02.Location = new System.Drawing.Point(222, 232);
            this.btnSideQuest02.Name = "btnSideQuest02";
            this.btnSideQuest02.Size = new System.Drawing.Size(128, 124);
            this.btnSideQuest02.TabIndex = 32;
            this.btnSideQuest02.Tag = "QUEST00008";
            this.btnSideQuest02.Text = "QUEST00008";
            this.btnSideQuest02.UseVisualStyleBackColor = true;
            this.btnSideQuest02.Click += new System.EventHandler(this.btnMainQuest01_Click);
            // 
            // btnSideQuest01
            // 
            this.btnSideQuest01.ContextMenuStrip = this.ctxQuestButtons;
            this.btnSideQuest01.Location = new System.Drawing.Point(88, 232);
            this.btnSideQuest01.Name = "btnSideQuest01";
            this.btnSideQuest01.Size = new System.Drawing.Size(128, 124);
            this.btnSideQuest01.TabIndex = 31;
            this.btnSideQuest01.Tag = "QUEST00007";
            this.btnSideQuest01.Text = "QUEST00007";
            this.btnSideQuest01.UseVisualStyleBackColor = true;
            this.btnSideQuest01.Click += new System.EventHandler(this.btnMainQuest01_Click);
            // 
            // btnMainQuest06
            // 
            this.btnMainQuest06.ContextMenuStrip = this.ctxQuestButtons;
            this.btnMainQuest06.Location = new System.Drawing.Point(758, 57);
            this.btnMainQuest06.Name = "btnMainQuest06";
            this.btnMainQuest06.Size = new System.Drawing.Size(128, 124);
            this.btnMainQuest06.TabIndex = 30;
            this.btnMainQuest06.Tag = "QUEST00006";
            this.btnMainQuest06.Text = "QUEST00006";
            this.btnMainQuest06.UseVisualStyleBackColor = true;
            this.btnMainQuest06.Click += new System.EventHandler(this.btnMainQuest01_Click);
            // 
            // btnMainQuest05
            // 
            this.btnMainQuest05.ContextMenuStrip = this.ctxQuestButtons;
            this.btnMainQuest05.Location = new System.Drawing.Point(624, 57);
            this.btnMainQuest05.Name = "btnMainQuest05";
            this.btnMainQuest05.Size = new System.Drawing.Size(128, 124);
            this.btnMainQuest05.TabIndex = 29;
            this.btnMainQuest05.Tag = "QUEST00005";
            this.btnMainQuest05.Text = "QUEST00005";
            this.btnMainQuest05.UseVisualStyleBackColor = true;
            this.btnMainQuest05.Click += new System.EventHandler(this.btnMainQuest01_Click);
            // 
            // btnMainQuest04
            // 
            this.btnMainQuest04.ContextMenuStrip = this.ctxQuestButtons;
            this.btnMainQuest04.Location = new System.Drawing.Point(490, 57);
            this.btnMainQuest04.Name = "btnMainQuest04";
            this.btnMainQuest04.Size = new System.Drawing.Size(128, 124);
            this.btnMainQuest04.TabIndex = 28;
            this.btnMainQuest04.Tag = "QUEST00004";
            this.btnMainQuest04.Text = "QUEST00004";
            this.btnMainQuest04.UseVisualStyleBackColor = true;
            this.btnMainQuest04.Click += new System.EventHandler(this.btnMainQuest01_Click);
            // 
            // btnMainQuest03
            // 
            this.btnMainQuest03.ContextMenuStrip = this.ctxQuestButtons;
            this.btnMainQuest03.Location = new System.Drawing.Point(356, 57);
            this.btnMainQuest03.Name = "btnMainQuest03";
            this.btnMainQuest03.Size = new System.Drawing.Size(128, 124);
            this.btnMainQuest03.TabIndex = 27;
            this.btnMainQuest03.Tag = "QUEST00003";
            this.btnMainQuest03.Text = "QUEST00003";
            this.btnMainQuest03.UseVisualStyleBackColor = true;
            this.btnMainQuest03.Click += new System.EventHandler(this.btnMainQuest01_Click);
            // 
            // btnMainQuest02
            // 
            this.btnMainQuest02.ContextMenuStrip = this.ctxQuestButtons;
            this.btnMainQuest02.Location = new System.Drawing.Point(222, 57);
            this.btnMainQuest02.Name = "btnMainQuest02";
            this.btnMainQuest02.Size = new System.Drawing.Size(128, 124);
            this.btnMainQuest02.TabIndex = 26;
            this.btnMainQuest02.Tag = "QUEST00002";
            this.btnMainQuest02.Text = "QUEST00002";
            this.btnMainQuest02.UseVisualStyleBackColor = true;
            this.btnMainQuest02.Click += new System.EventHandler(this.btnMainQuest01_Click);
            // 
            // btnMainQuest01
            // 
            this.btnMainQuest01.ContextMenuStrip = this.ctxQuestButtons;
            this.btnMainQuest01.Location = new System.Drawing.Point(88, 57);
            this.btnMainQuest01.Name = "btnMainQuest01";
            this.btnMainQuest01.Size = new System.Drawing.Size(128, 124);
            this.btnMainQuest01.TabIndex = 25;
            this.btnMainQuest01.Tag = "QUEST00001";
            this.btnMainQuest01.Text = "QUEST00001";
            this.btnMainQuest01.UseVisualStyleBackColor = true;
            this.btnMainQuest01.Click += new System.EventHandler(this.btnMainQuest01_Click);
            // 
            // tbpExport
            // 
            this.tbpExport.Controls.Add(this.pnlExportMain);
            this.tbpExport.Location = new System.Drawing.Point(4, 25);
            this.tbpExport.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tbpExport.Name = "tbpExport";
            this.tbpExport.Size = new System.Drawing.Size(974, 664);
            this.tbpExport.TabIndex = 3;
            this.tbpExport.Text = "تولید خروجی";
            this.tbpExport.UseVisualStyleBackColor = true;
            // 
            // pnlExportMain
            // 
            this.pnlExportMain.Controls.Add(this.txtExportPath);
            this.pnlExportMain.Controls.Add(this.btnSetExportPath);
            this.pnlExportMain.Controls.Add(this.btnExport);
            this.pnlExportMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlExportMain.Location = new System.Drawing.Point(0, 0);
            this.pnlExportMain.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.pnlExportMain.Name = "pnlExportMain";
            this.pnlExportMain.Size = new System.Drawing.Size(974, 664);
            this.pnlExportMain.TabIndex = 1;
            // 
            // txtExportPath
            // 
            this.txtExportPath.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtExportPath.Location = new System.Drawing.Point(180, 165);
            this.txtExportPath.Name = "txtExportPath";
            this.txtExportPath.ReadOnly = true;
            this.txtExportPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtExportPath.Size = new System.Drawing.Size(613, 23);
            this.txtExportPath.TabIndex = 10;
            // 
            // btnSetExportPath
            // 
            this.btnSetExportPath.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSetExportPath.Location = new System.Drawing.Point(409, 194);
            this.btnSetExportPath.Name = "btnSetExportPath";
            this.btnSetExportPath.Size = new System.Drawing.Size(156, 35);
            this.btnSetExportPath.TabIndex = 7;
            this.btnSetExportPath.Text = "مسیر ذخیره سازی";
            this.btnSetExportPath.UseVisualStyleBackColor = true;
            this.btnSetExportPath.Click += new System.EventHandler(this.btnSetExportPath_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(364, 304);
            this.btnExport.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(247, 57);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "تولید خروجی XML";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // fbdExport
            // 
            this.fbdExport.ShowNewFolderButton = false;
            // 
            // mnuCharactersSeparator01
            // 
            this.mnuCharactersSeparator01.Name = "mnuCharactersSeparator01";
            this.mnuCharactersSeparator01.Size = new System.Drawing.Size(198, 6);
            // 
            // mnuCharactersInteractiveDialogs
            // 
            this.mnuCharactersInteractiveDialogs.Name = "mnuCharactersInteractiveDialogs";
            this.mnuCharactersInteractiveDialogs.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuCharactersInteractiveDialogs.Size = new System.Drawing.Size(201, 22);
            this.mnuCharactersInteractiveDialogs.Text = "دیالوگ های تعاملی";
            this.mnuCharactersInteractiveDialogs.Click += new System.EventHandler(this.mnuCharactersInteractiveDialogs_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 693);
            this.Controls.Add(this.tbcMain);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(990, 720);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مدیریت پایگاه داده عصر پهلوانان 2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.tbcMain.ResumeLayout(false);
            this.tbpCharacters.ResumeLayout(false);
            this.tblCharacters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCharacters)).EndInit();
            this.ctxCharactersMenu.ResumeLayout(false);
            this.pnlCharactersForm.ResumeLayout(false);
            this.pnlCharactersForm.PerformLayout();
            this.tbpInteractiveDialogs.ResumeLayout(false);
            this.ctxInteractiveDialogs.ResumeLayout(false);
            this.tbpQuest.ResumeLayout(false);
            this.pnlQuests.ResumeLayout(false);
            this.ctxQuestButtons.ResumeLayout(false);
            this.tbpExport.ResumeLayout(false);
            this.pnlExportMain.ResumeLayout(false);
            this.pnlExportMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tbpCharacters;
        private System.Windows.Forms.TabPage tbpInteractiveDialogs;
        private System.Windows.Forms.TabPage tbpQuest;
        private System.Windows.Forms.TabPage tbpExport;
        private System.Windows.Forms.Panel pnlExportMain;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.FolderBrowserDialog fbdExport;
        private System.Windows.Forms.TableLayoutPanel tblCharacters;
        private System.Windows.Forms.DataGridView dgvCharacters;
        private System.Windows.Forms.Panel pnlCharactersForm;
        private System.Windows.Forms.Label lblCharctersID;
        private System.Windows.Forms.Label lblCharactersSearch;
        private System.Windows.Forms.Button btnCharactersAddEdit;
        private System.Windows.Forms.TextBox txtCharactersSearch;
        private System.Windows.Forms.TextBox txtCharactersID;
        private System.Windows.Forms.ContextMenuStrip ctxCharactersMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuCharactersEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuCharactersErase;
        private System.Windows.Forms.Button btnCharactersCancel;
        private System.Windows.Forms.Label lblCharactersSearchWarning;
        private System.Windows.Forms.TreeView trvInterActiveDialog;
        private System.Windows.Forms.ContextMenuStrip ctxInteractiveDialogs;
        private System.Windows.Forms.ToolStripMenuItem mnuInteractiveDialogsAdd;
        private System.Windows.Forms.ToolStripMenuItem mnuInteractiveDialogsEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuInteractiveDialogsErase;
        private System.Windows.Forms.Panel pnlQuests;
        private System.Windows.Forms.Button btnSideQuest18;
        private System.Windows.Forms.Button btnSideQuest17;
        private System.Windows.Forms.Button btnSideQuest16;
        private System.Windows.Forms.Button btnSideQuest15;
        private System.Windows.Forms.Button btnSideQuest14;
        private System.Windows.Forms.Button btnSideQuest13;
        private System.Windows.Forms.Button btnSideQuest12;
        private System.Windows.Forms.Button btnSideQuest11;
        private System.Windows.Forms.Button btnSideQuest10;
        private System.Windows.Forms.Button btnSideQuest09;
        private System.Windows.Forms.Button btnSideQuest08;
        private System.Windows.Forms.Button btnSideQuest07;
        private System.Windows.Forms.Button btnSideQuest06;
        private System.Windows.Forms.Button btnSideQuest05;
        private System.Windows.Forms.Button btnSideQuest04;
        private System.Windows.Forms.Button btnSideQuest03;
        private System.Windows.Forms.Button btnSideQuest02;
        private System.Windows.Forms.Button btnSideQuest01;
        private System.Windows.Forms.Button btnMainQuest06;
        private System.Windows.Forms.Button btnMainQuest05;
        private System.Windows.Forms.Button btnMainQuest04;
        private System.Windows.Forms.Button btnMainQuest03;
        private System.Windows.Forms.Button btnMainQuest02;
        private System.Windows.Forms.Button btnMainQuest01;
        private System.Windows.Forms.Button btnSetExportPath;
        private System.Windows.Forms.TextBox txtExportPath;
        private System.Windows.Forms.ContextMenuStrip ctxQuestButtons;
        private System.Windows.Forms.ToolStripMenuItem mnuQuestButtonsQuestTitle;
        private System.Windows.Forms.ToolStripSeparator mnuInteractiveDialogsSeparator01;
        private System.Windows.Forms.ToolStripMenuItem mnuInteractiveDialogsMoveUp;
        private System.Windows.Forms.ToolStripMenuItem mnuInteractiveDialogsMoveDown;
        private System.Windows.Forms.ToolStripSeparator mnuInteractiveDialogsSeparator02;
        private System.Windows.Forms.ToolStripMenuItem mnuInteractiveDialogsGroupTitle;
        private System.Windows.Forms.ToolStripSeparator mnuCharactersSeparator01;
        private System.Windows.Forms.ToolStripMenuItem mnuCharactersInteractiveDialogs;
    }
}