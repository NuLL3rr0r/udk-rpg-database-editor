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
    public partial class InteractiveDialogInputForm2 : Form
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

        public string title
        {
            set
            {
                this.Text = value;
            }
        }

        private string _table;
        public string table
        {
            set
            {
                this._table = value;
            }
        }

        private int _group;
        public int group
        {
            set
            {
                this._group = value;
            }
        }

        private string _charID;
        public string charID
        {
            set
            {
                this._charID = value;
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

        public string dialogText
        {
            get
            {
                return txtDialogText.Text;
            }
        }

        int m_lastInsertedRowID = 0;
        int _dialogID = -1;
        public int dialogID
        {
            get
            {
                return m_lastInsertedRowID;
            }
            set
            {
                _dialogID = value;
            }
        }

        private int _zIndex = -1;
        public int zIndex
        {
            get
            {
                return this._zIndex;
            }
            set
            {
                this._zIndex = value;
            }
        }

        #endregion


        public InteractiveDialogInputForm2()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string tbl = _table;
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

                    dr["GroupID"] = _group;
                    dr["CharacterID"] = _charID;
                    dr["DialogText"] = txtDialogText.Text;
                    dr["Condition"] = cmbCondition.Text;
                    dr["ConditionType"] = cmbConditionType.Text;
                    dr["Comment"] = txtComment.Text;
                    dr["zIndex"] = _zIndex;
                    dt.Rows.Add(dr);

                    oda.InsertCommand = ocb.GetInsertCommand();

                    oda.RowUpdated += new OleDbRowUpdatedEventHandler(OnTableRowUpdated);

                    if (oda.Update(ds, tbl) == 1)
                    {
                        ds.AcceptChanges();
                        _isOK = true;
                        this.Close();
                    }
                    else
                    {
                        ds.RejectChanges();
                        MessageBox.Show("عدم ثبت دیالوگ", "درج دیالوگ", MessageBoxButtons.OK,
                            MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                        txtDialogText.Focus();
                    }
                }
                else
                {
                    bool found = false;

                    OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                    OleDbDataReader drr = cmd.ExecuteReader();

                    while (drr.Read())
                    {
                        if ((int)drr["RowID"] == _dialogID)
                        {
                            found = true;
                            break;
                        }
                    }

                    if (found)
                    {
                        for (int i = 0; i < dt.Rows.Count; ++i)
                        {
                            dr = dt.Rows[i];
                            if ((int)dr["RowID"] == _dialogID)
                            {
                                dr.BeginEdit();

                                dr["DialogText"] = txtDialogText.Text;
                                dr["Condition"] = cmbCondition.Text;
                                dr["ConditionType"] = cmbConditionType.Text;
                                dr["Comment"] = txtComment.Text;

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
                                    MessageBox.Show("عدم ثبت تغییرات", "ویرایش دیالوگ", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                                    txtDialogText.Focus();
                                }
                            }
                        }
                    }

                    drr.Close();
                    drr.Dispose();
                    drr = null;
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

        private void OnTableRowUpdated(object sender, OleDbRowUpdatedEventArgs e)
        {
            if (e.StatementType == StatementType.Insert)
            {
                OleDbCommand cmd = new OleDbCommand("SELECT @@IDENTITY", e.Command.Connection, e.Command.Transaction);

                m_lastInsertedRowID = (int)cmd.ExecuteScalar();
                e.Row["RowID"] = m_lastInsertedRowID;
                e.Row.AcceptChanges();

                cmd.Dispose();
                cmd = null;
            }
        }

        private void InteractiveDialogInputForm2_Load(object sender, EventArgs e)
        {
            try
            {
                string sqlStr = string.Concat("SELECT * FROM ", _table);

                OleDbConnection cnn = new OleDbConnection(Base.CnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);

                cnn.Open();

                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                OleDbDataReader drr = cmd.ExecuteReader();

                while (drr.Read())
                {
                    if ((int)drr["RowID"] == _dialogID)
                    {
                        txtDialogText.Text = drr["DialogText"].ToString();
                        cmbCondition.Text = drr["Condition"].ToString();
                        cmbConditionType.Text = drr["ConditionType"].ToString();
                        txtComment.Text = drr["Comment"].ToString();
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
    }
}
