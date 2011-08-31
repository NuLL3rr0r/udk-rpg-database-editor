using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RpgDbManager
{
    public partial class Quest : Form
    {
        #region Global Variables & Properties

        private string _quest = string.Empty;
        public string quest
        {
            set
            {
                this._quest = value;
            }
        }

        private TreeNode rootQuestNode;

        #endregion

        #region Typedefs

        enum QuestLevel
        {
            None,
            Level0,
            Level1,
            Level2
        }

        #endregion

        public Quest()
        {
            InitializeComponent();
        }

        private void Quest_Load(object sender, EventArgs e)
        {
            rootQuestNode = new TreeNode(_quest);
            rootQuestNode.Tag = QuestLevel.Level0;
            trv.Nodes.Add(rootQuestNode);
        }

        private void SetCtxStatus()
        {
            if (trv.Nodes.Count == 0 || trv.SelectedNode == null)
            {
                mnuAdd.Enabled = false;
                mnuEdit.Enabled = false;
                mnuErase.Enabled = false;
                return;
            }

            switch((QuestLevel)trv.SelectedNode.Tag)
            {
                case QuestLevel.Level0:
                    mnuAdd.Enabled = true;
                    mnuEdit.Enabled = true;
                    mnuErase.Enabled = false;
                    break;
                case QuestLevel.Level1:
                    mnuAdd.Enabled = true;
                    mnuEdit.Enabled = true;
                    mnuErase.Enabled = true;
                    break;
                case QuestLevel.Level2:
                    mnuAdd.Enabled = false;
                    mnuEdit.Enabled = true;
                    mnuErase.Enabled = true;
                    break;
                default:
                    break;
            }
        }

        private void ctx_Opening(object sender, CancelEventArgs e)
        {
            SetCtxStatus();
        }

        private void trv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SetCtxStatus();
        }

        private void mnuAdd_Click(object sender, EventArgs e)
        {
            using (QuestDialogInputForm frm = new QuestDialogInputForm())
            {
                QuestLevel newNodeTag = QuestLevel.None;
                switch ((QuestLevel)trv.SelectedNode.Tag)
                {
                    case QuestLevel.Level0:
                        newNodeTag = QuestLevel.Level1;
                        break;
                    case QuestLevel.Level1:
                        newNodeTag = QuestLevel.Level2;
                        break;
                    case QuestLevel.Level2:
                        break;
                    default:
                        break;
                }
                frm.parentNode = trv.SelectedNode.Text;
                frm.ShowDialog();

                if (frm.isOK)
                {
                    TreeNode n = new TreeNode(frm.quest);
                    n.Tag = newNodeTag;
                    trv.SelectedNode.Nodes.Add(n);
                    trv.SelectedNode.ExpandAll();
                }
            }
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            using (QuestDialogInputForm frm = new QuestDialogInputForm())
            {
                frm.isEditMode = true;
                switch ((QuestLevel)trv.SelectedNode.Tag)
                {
                    case QuestLevel.Level0:
                        break;
                    case QuestLevel.Level1:
                        break;
                    case QuestLevel.Level2:
                        break;
                    default:
                        break;
                }
                frm.title = trv.SelectedNode.Text;
                frm.quest = trv.SelectedNode.Text;
                frm.ShowDialog();

                if (frm.isOK)
                {
                }
            }
        }

        private void EraseQuest(TreeNode node)
        {
            string tbl = "Quests";
            string sqlStr = string.Concat("SELECT * FROM ", tbl);

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.CnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);

                cnn.Open();

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataRow dr;

                ocb.QuotePrefix = "[";
                ocb.QuoteSuffix = "]";
                oda.Fill(ds, tbl);

                dt = ds.Tables[tbl];
                for (int i = 0; i < dt.Rows.Count; ++i)
                {
                    dr = dt.Rows[i];
                    if (dr["ID"].ToString().Trim() == node.Text)
                    {
                        dr.Delete();
                        break;
                    }
                }

                oda.DeleteCommand = ocb.GetDeleteCommand();

                if (oda.Update(ds, tbl) == 1)
                {
                    ds.AcceptChanges();
                    node.Remove();
                }
                else
                {
                    ds.RejectChanges();
                }

                cnn.Close();

                dt.Dispose();
                ds.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();

                dt = null;
                ds = null;
                ocb = null;
                oda = null;
                cnn = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n\t" + ex.Message);
            }
            finally
            {
            }
        }

        private void mnuErase_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = MessageBox.Show("آيا مايل به حذف ماموریت مورد نظر مي باشيد؟", "حذف ماموریت",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (dlgResult != DialogResult.OK)
            {
                return;
            }

            switch ((QuestLevel)trv.SelectedNode.Tag)
            {
                case QuestLevel.Level0:
                    break;
                case QuestLevel.Level1:
                    foreach (TreeNode n in trv.SelectedNode.Nodes)
                    {
                        EraseQuest(n);
                    }
                    EraseQuest(trv.SelectedNode);
                    break;
                case QuestLevel.Level2:
                    EraseQuest(trv.SelectedNode);
                    break;
                default:
                    break;
            }
        }

        private void AddLevel2Quests(TreeNode node)
        {
            string tbl = "Quests";
            string sqlStr = string.Concat("SELECT * FROM ", tbl);

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.CnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);

                cnn.Open();

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataRow dr;

                oda.Fill(ds, tbl);

                dt = ds.Tables[tbl];
                dt.DefaultView.Sort = "[ID] asc";
                for (int i = 0; i < dt.Rows.Count; ++i)
                {
                    dr = dt.Rows[i];
                    string q = dr["ID"].ToString().Trim();

                    if (dr["Parent"].ToString().Trim() == node.Text)
                    {
                        TreeNode n = new TreeNode(q);
                        n.Tag = QuestLevel.Level2;
                        node.Nodes.Add(n);
                    }
                }

                cnn.Close();

                dt.Dispose();
                ds.Dispose();
                oda.Dispose();
                cnn.Dispose();

                dt = null;
                ds = null;
                oda = null;
                cnn = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n\t" + ex.Message);
            }
            finally
            {
            }
        }

        private void Quest_Shown(object sender, EventArgs e)
        {
            string tbl = "Quests";
            string sqlStr = string.Concat("SELECT * FROM ", tbl);

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.CnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);

                cnn.Open();

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataRow dr;

                oda.Fill(ds, tbl);

                dt = ds.Tables[tbl];
                dt.DefaultView.Sort = "[ID] asc";
                for (int i = 0; i < dt.Rows.Count; ++i)
                {
                    dr = dt.Rows[i];
                    string q = dr["ID"].ToString().Trim();

                    if (dr["Parent"].ToString().Trim() == rootQuestNode.Text)
                    {
                        TreeNode n = new TreeNode(q);
                        n.Tag = QuestLevel.Level1;
                        AddLevel2Quests(n);
                        rootQuestNode.Nodes.Add(n);
                    }
                }

                cnn.Close();

                dt.Dispose();
                ds.Dispose();
                oda.Dispose();
                cnn.Dispose();

                dt = null;
                ds = null;
                oda = null;
                cnn = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n\t" + ex.Message);
            }
            finally
            {
            }

            rootQuestNode.ExpandAll();
        }
    }
}
