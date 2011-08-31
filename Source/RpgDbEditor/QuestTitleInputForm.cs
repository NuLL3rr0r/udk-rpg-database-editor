using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RpgDbManager
{
    public partial class QuestTitleInputForm : Form
    {
        #region Global Variables & Properties

        private bool _isOK = false;
        public bool isOK
        {
            get
            {
                return _isOK;
            }
        }

        private string _quest = string.Empty;
        public string quest
        {
            get
            {
                return this._quest;
            }
            set
            {
                this._quest = value;
            }
        }

        private string _titleText = string.Empty;
        public string titleText
        {
            get
            {
                return this._titleText;
            }
            set
            {
                this._titleText = value;
            }
        }

        private string _titleLevel = string.Empty;
        public string titleLevel
        {
            get
            {
                return this._titleLevel;
            }
            set
            {
                this._titleLevel = value;
            }
        }

        #endregion

        public QuestTitleInputForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QuestTitleInputForm_Load(object sender, EventArgs e)
        {
            switch (_quest)
            {
                case "QUEST00001":
                case "QUEST00002":
                case "QUEST00003":
                case "QUEST00004":
                case "QUEST00005":
                case "QUEST00006":
                    txtTitleLevel.Enabled = false;
                    break;
                default:
                    break;
            }

            try
            {
                string tbl = "Quests";
                string sqlStr = string.Concat("SELECT * FROM ", tbl);

                OleDbConnection cnn = new OleDbConnection(Base.CnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);

                cnn.Open();

                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                OleDbDataReader drr = cmd.ExecuteReader();

                while (drr.Read())
                {
                    if (drr["ID"].ToString() == _quest)
                    {
                        txtTitleText.Text = drr["BtnTitleText"].ToString();
                        txtTitleLevel.Text = drr["BtnTitleLevel"].ToString();
                    }
                }

                drr.Close();
                cnn.Close();

                drr.Dispose();
                cmd.Dispose();
                oda.Dispose();
                cnn.Dispose();

                drr = null;
                cmd = null;
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

        private void btnSave_Click(object sender, EventArgs e)
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
                    if (dr["ID"].ToString() == _quest)
                    {
                        dr.BeginEdit();

                        dr["BtnTitleText"] = txtTitleText.Text;
                        dr["BtnTitleLevel"] = txtTitleLevel.Text;

                        dr.EndEdit();

                        oda.UpdateCommand = ocb.GetUpdateCommand();

                        if (oda.Update(ds, tbl) == 1)
                        {
                            ds.AcceptChanges();
                            _titleText = txtTitleText.Text;
                            _titleLevel = txtTitleLevel.Text;
                            _isOK = true;
                            this.Close();
                        }
                        else
                        {
                            ds.RejectChanges();
                            MessageBox.Show("عدم ثبت تغییرات", "ویرایش عنوان", MessageBoxButtons.OK,
                                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                            txtTitleText.Focus();
                            txtTitleText.SelectAll();
                        }

                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n\t" + ex.Message);
            }
            finally
            {
            }
        }
    }
}
