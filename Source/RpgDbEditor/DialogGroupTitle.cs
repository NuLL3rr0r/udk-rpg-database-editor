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
    public partial class DialogGroupTitle : Form
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

        private int _id = -1;
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        private string _tbl = string.Empty;
        public string tbl
        {
            get
            {
                return this._tbl;
            }
            set
            {
                this._tbl = value;
            }
        }

        private string _title = string.Empty;
        public string title
        {
            get
            {
                return this._title;
            }
        }

        #endregion

        public DialogGroupTitle()
        {
            InitializeComponent();
        }

        private void InteractiveDialogGroupTitle_Load(object sender, EventArgs e)
        {
            try
            {
                string sqlStr = string.Concat("SELECT * FROM ", tbl);

                OleDbConnection cnn = new OleDbConnection(Base.CnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);

                cnn.Open();

                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                OleDbDataReader drr = cmd.ExecuteReader();

                while (drr.Read())
                {
                    if ((int)drr["RowID"] == id)
                    {
                        txtTitle.Text = drr["Title"].ToString();
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

            txtTitle.Focus();
            txtTitle.SelectAll();
        }

        private void txtTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                _title = txtTitle.Text.Trim();

                if (_title != string.Empty)
                {
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
                            if ((int)dr["RowID"] == _id)
                            {
                                dr.BeginEdit();

                                dr["Title"] = _title;

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
                                    MessageBox.Show("عدم ثبت تغییرات", "ویرایش عنوان", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                                    txtTitle.Focus();
                                    txtTitle.SelectAll();
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
                else
                {
                    MessageBox.Show("لطفا نام معتبري وارد نمائيد", "نام غير معتبر", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    txtTitle.Focus();
                    txtTitle.SelectAll();
                }
            }
            else if ((Keys)e.KeyChar == Keys.Escape)
            {
                _title = string.Empty;
                this.Close();
            }
        }
    }
}
