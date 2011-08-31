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
    public partial class QuestDialogInputForm : Form
    {
        #region Global Variables & Properties

        private bool _isEditMode = false;
        public bool isEditMode
        {
            set
            {
                _isEditMode = value;
            }
        }

        private bool _isOK = false;
        public bool isOK
        {
            get
            {
                return _isOK;
            }
        }

        public string title
        {
            set
            {
                this.Text = value;
            }
        }

        private string _parentNode;
        public string parentNode
        {
            set
            {
                _parentNode = value;
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

        #endregion

        public QuestDialogInputForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QuestDialogInputForm_Load(object sender, EventArgs e)
        {
            if (_isEditMode)
            {
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
                            txtID.Text = _quest;
                            txtDescription.Text = drr["Description"].ToString();
                            cmbConditionType.Text = drr["Conditions"].ToString();
                            cmbCondition.Text = drr["ConditionsType"].ToString();
                            cmbDoneConditionType.Text = drr["DoneConditions"].ToString();
                            cmbDoneCondition.Text = drr["DoneConditionsType"].ToString();
                            cmbActionType.Text = drr["Actions"].ToString();
                            cmbAction.Text = drr["ActionsType"].ToString();
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
            else
            {
                try
                {
                    string tbl = "QuestsCount";
                    string sqlStr = string.Concat("SELECT * FROM ", tbl);

                    OleDbConnection cnn = new OleDbConnection(Base.CnnStr);
                    OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);

                    cnn.Open();

                    OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                    OleDbDataReader drr = cmd.ExecuteReader();

                    while (drr.Read())
                    {
                        string count = ((int)drr["Count"] + 1).ToString();
                        int zero = 5 - count.Length;
                        string z = string.Empty;
                        for (int i = 0; i < zero; ++i)
                            z += "0";
                        _quest = "QUEST" + z + count;
                        txtID.Text = _quest;
                        break;
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

                if (!_isEditMode)
                {
                    dr = dt.NewRow();

                    dr["ID"] = _quest;
                    dr["Parent"] = _parentNode;
                    dr["Description"] = txtDescription.Text;
                    dr["Conditions"] = cmbCondition.Text;
                    dr["ConditionsType"] = cmbConditionType.Text;
                    dr["DoneConditions"] = cmbDoneCondition.Text;
                    dr["DoneConditionsType"] = cmbDoneConditionType.Text;
                    dr["Actions"] = cmbAction.Text;
                    dr["ActionsType"] = cmbActionType.Text;
                    dt.Rows.Add(dr);

                    oda.InsertCommand = ocb.GetInsertCommand();

                    if (oda.Update(ds, tbl) == 1)
                    {
                        ds.AcceptChanges();
                        IncreamentQuestsCount();
                        _isOK = true;
                        this.Close();
                    }
                    else
                    {
                        ds.RejectChanges();
                        MessageBox.Show("عدم ثبت ماموریت", "درج ماموریت", MessageBoxButtons.OK,
                            MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                        txtDescription.Focus();
                        txtDescription.SelectAll();
                    }
                }
                else
                {
                    for (int i = 0; i < dt.Rows.Count; ++i)
                    {
                        dr = dt.Rows[i];
                        if (dr["ID"].ToString() == _quest)
                        {
                            dr.BeginEdit();

                            dr["Description"] = txtDescription.Text;
                            dr["Conditions"] = cmbCondition.Text;
                            dr["ConditionsType"] = cmbConditionType.Text;
                            dr["DoneConditions"] = cmbDoneCondition.Text;
                            dr["DoneConditionsType"] = cmbDoneConditionType.Text;
                            dr["Actions"] = cmbAction.Text;
                            dr["ActionsType"] = cmbActionType.Text;

                            dr.EndEdit();

                            oda.UpdateCommand = ocb.GetUpdateCommand();

                            if (oda.Update(ds, tbl) == 1)
                            {
                                ds.AcceptChanges();
                                _isOK = true;
                                this.Close();
                            }
                            else
                            {
                                ds.RejectChanges();
                                MessageBox.Show("عدم ثبت تغییرات", "ویرایش ماموریت", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                                txtDescription.Focus();
                                txtDescription.SelectAll();
                            }

                            break;
                        }
                    }
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
        }

        private void IncreamentQuestsCount()
        {
            string tbl = "QuestsCount";
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
                    
                    int newCount = (int)dr["Count"] + 1;

                    dr.BeginEdit();
                    dr["Count"] = newCount;
                    dr.EndEdit();

                    break;
                }

                oda.UpdateCommand = ocb.GetUpdateCommand();

                if (oda.Update(ds, tbl) == 1)
                {
                    ds.AcceptChanges();
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

        private void QuestDialogInputForm_Shown(object sender, EventArgs e)
        {
            txtDescription.Focus();
            txtDescription.SelectAll();
        }
    }
}
