namespace RpgDbManager
{
    partial class Quest
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
            this.trv = new System.Windows.Forms.TreeView();
            this.ctx = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuErase = new System.Windows.Forms.ToolStripMenuItem();
            this.ctx.SuspendLayout();
            this.SuspendLayout();
            // 
            // trv
            // 
            this.trv.ContextMenuStrip = this.ctx;
            this.trv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trv.Location = new System.Drawing.Point(0, 0);
            this.trv.Name = "trv";
            this.trv.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.trv.RightToLeftLayout = true;
            this.trv.Size = new System.Drawing.Size(712, 446);
            this.trv.TabIndex = 0;
            this.trv.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trv_AfterSelect);
            // 
            // ctx
            // 
            this.ctx.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAdd,
            this.mnuEdit,
            this.mnuErase});
            this.ctx.Name = "ctx";
            this.ctx.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctx.Size = new System.Drawing.Size(155, 70);
            this.ctx.Opening += new System.ComponentModel.CancelEventHandler(this.ctx_Opening);
            // 
            // mnuAdd
            // 
            this.mnuAdd.Name = "mnuAdd";
            this.mnuAdd.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.mnuAdd.Size = new System.Drawing.Size(154, 22);
            this.mnuAdd.Text = "درج";
            this.mnuAdd.Click += new System.EventHandler(this.mnuAdd_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Insert)));
            this.mnuEdit.Size = new System.Drawing.Size(154, 22);
            this.mnuEdit.Text = "ویرایش";
            this.mnuEdit.Click += new System.EventHandler(this.mnuEdit_Click);
            // 
            // mnuErase
            // 
            this.mnuErase.Name = "mnuErase";
            this.mnuErase.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.mnuErase.Size = new System.Drawing.Size(154, 22);
            this.mnuErase.Text = "حذف";
            this.mnuErase.Click += new System.EventHandler(this.mnuErase_Click);
            // 
            // Quest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 446);
            this.Controls.Add(this.trv);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(728, 484);
            this.Name = "Quest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ماموریت";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Quest_Load);
            this.Shown += new System.EventHandler(this.Quest_Shown);
            this.ctx.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView trv;
        private System.Windows.Forms.ContextMenuStrip ctx;
        private System.Windows.Forms.ToolStripMenuItem mnuAdd;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuErase;
    }
}