using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RpgDbManager
{
    public partial class Main : Form
    {
        private DataTable m_dtCharacters = new DataTable();
        private string m_id4EditCharacters = string.Empty;

        private int m_lastInsertedDialogGroupRowID = 0;

        private bool m_showAllInteractiveDialogs = true;

        enum ETypesInterActiveDialogNodes
        {
            NONE,
            CHARACTER,
            InitiationDIALOG,
            GreetingDIALOG,
            InfoDIALOG,
            QuestDIALOG,
            ShoppingDIALOG,
            ShoppingOpenDIALOG,
            ShoppingBuyDIALOG,
            ShoppingSellDIALOG,
            ShoppingDenyDIALOG,
            FarewellDIALOG,
            InitiationDIALOGGROUP,
            GreetingDIALOGGROUP,
            InfoDIALOGGROUP,
            QuestDIALOGGROUP,
            ShoppingOpenDIALOGGROUP,
            ShoppingBuyDIALOGGROUP,
            ShoppingSellDIALOGGROUP,
            ShoppingDenyDIALOGGROUP,
            FarewellDIALOGGROUP,
            DIALOG
        }

        enum ETypesInterActiveDialogs
        {
            NONE,
            Initiation,
            Greeting,
            Info,
            Quest,
            ShoppingOpen,
            ShoppingBuy,
            ShoppingSell,
            ShoppingDeny,
            Farewell
        }

        public Main()
        {
            InitializeComponent();

            dgvCharacters.ReadOnly = true;
            dgvCharacters.AllowUserToAddRows = false;
            btnCharactersAddEdit.Enabled = false;
            btnCharactersCancel.Visible = false;
            lblCharactersSearchWarning.Visible = false;

            ReadTables();
        }

        private void FillCharacterXML(RpgDatabaseParser.Data.Database xml)
        {
            string tbl = "Characters";
            string sqlStr = string.Concat("SELECT * FROM ", tbl);

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.CnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);

                cnn.Open();

                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                OleDbDataReader drr = cmd.ExecuteReader();

                while (drr.Read())
                {
                    RpgDatabaseParser.Data.CharacterSheet.CharacterDefinition charDef = new RpgDatabaseParser.Data.CharacterSheet.CharacterDefinition();
                    charDef.Id = drr["ID"].ToString().Trim();

                    xml.CharacterDefinitions.Add(charDef);
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

        private List<RpgDatabaseParser.Data.InteractiveDialog.InteractiveDialogLine> ReadDialogsLineFromGroup(
            int groupID, string characterID, string tbl)
        {
            List<RpgDatabaseParser.Data.InteractiveDialog.InteractiveDialogLine> res =
                new List<RpgDatabaseParser.Data.InteractiveDialog.InteractiveDialogLine>();

            try
            {
                string sqlStr = string.Empty;
                switch (tbl)
                {
                    case "InitiationDialog":
                    case "InfoDialog":
                    case "QuestDialog":
                        sqlStr = string.Concat("SELECT * FROM [", tbl, "] WHERE (CharacterID='", characterID, "'",
                            " AND GroupID=", groupID, ");");
                        break;
                    case "GreetingDialog":
                    case "ShoppingOpenDialog":
                    case "ShoppingBuyDialog":
                    case "ShoppingSellDialog":
                    case "ShoppingDenyDialog":
                    case "FarewellDialog":
                        sqlStr = string.Concat("SELECT * FROM [", tbl, "] WHERE (GroupID=", groupID, ");");
                        break;
                    default:
                        break;
                }

                OleDbConnection cnn = new OleDbConnection(Base.CnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);

                cnn.Open();

                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                OleDbDataReader drr = cmd.ExecuteReader();

                while (drr.Read())
                {
                    RpgDatabaseParser.Data.InteractiveDialog.InteractiveDialogLine dialogLine =
                        new RpgDatabaseParser.Data.InteractiveDialog.InteractiveDialogLine();

                    dialogLine.Text = drr["DialogText"].ToString().Trim();
                    dialogLine.Comments = drr["Comment"].ToString().Trim();
                    dialogLine.UpdateProperties(characterID, tbl, (int)drr["RowID"]);

                    dialogLine.Condition = new RpgDatabaseParser.Data.DataCondition();

                    dialogLine.Condition.ConditionType = GetConditionTypes(drr["ConditionType"].ToString().Trim());
                    int numArg = -1;
                    int.TryParse(drr["Condition"].ToString().Trim(), out numArg);
                    dialogLine.Condition.NumberArgument = numArg;

                    RpgDatabaseParser.Data.DataAction dataAction = new RpgDatabaseParser.Data.DataAction();
                    dataAction.ActionType = GetActionTypes(drr["ActionType"].ToString().Trim());
                    numArg = -1;
                    int.TryParse(drr["Action"].ToString().Trim(), out numArg);
                    dataAction.NumberArgument = numArg;

                    dialogLine.Actions = new List<RpgDatabaseParser.Data.DataAction>();
                    dialogLine.Actions.Add(dataAction);

                    res.Add(dialogLine);
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

            return res;
        }

        private List<List<RpgDatabaseParser.Data.InteractiveDialog.InteractiveDialogLine>> GetDialogBatches(string characterId, ETypesInterActiveDialogs dialogType)
        {
            List<List<RpgDatabaseParser.Data.InteractiveDialog.InteractiveDialogLine>> res =
                new List<List<RpgDatabaseParser.Data.InteractiveDialog.InteractiveDialogLine>>();

            string tbl = string.Empty;
            string tblLines = string.Empty;

            switch (dialogType)
            {
                case ETypesInterActiveDialogs.Initiation:
                    tbl = "InitiationDialogGroup";
                    tblLines = "InitiationDialog";
                    break;
                case ETypesInterActiveDialogs.Info:
                    tbl = "InfoDialogGroup";
                    tblLines = "InfoDialog";
                    break;
                case ETypesInterActiveDialogs.Quest:
                    tbl = "QuestDialogGroup";
                    tblLines = "QuestDialog";
                    break;
                default:
                    break;
            }

            string sqlStr = string.Concat("SELECT * FROM ", tbl);

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.CnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);

                cnn.Open();

                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                OleDbDataReader drr = cmd.ExecuteReader();

                while (drr.Read())
                {
                    if (drr["CharacterID"].ToString().Trim() != characterId)
                        continue;

                    res.Add(ReadDialogsLineFromGroup((int)drr["RowID"], drr["characterID"].ToString(), tblLines));
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

            return res;
        }

        private List<RpgDatabaseParser.Data.InteractiveDialog.InteractiveDialogLine> GetDialogOptions(string characterId, ETypesInterActiveDialogs dialogType)
        {
            List<RpgDatabaseParser.Data.InteractiveDialog.InteractiveDialogLine> res =
                new List<RpgDatabaseParser.Data.InteractiveDialog.InteractiveDialogLine>();

            string tbl = string.Empty;

            switch (dialogType)
            {
                case ETypesInterActiveDialogs.Greeting:
                    tbl = "GreetingDialog";
                    break;
                case ETypesInterActiveDialogs.ShoppingOpen:
                    tbl = "ShoppingOpenDialog";
                    break;
                case ETypesInterActiveDialogs.ShoppingBuy:
                    tbl = "ShoppingBuyDialog";
                    break;
                case ETypesInterActiveDialogs.ShoppingSell:
                    tbl = "ShoppingSellDialog";
                    break;
                case ETypesInterActiveDialogs.ShoppingDeny:
                    tbl = "ShoppingDenyDialog";
                    break;
                case ETypesInterActiveDialogs.Farewell:
                    tbl = "FarewellDialog";
                    break;
                default:
                    break;
            }

            string sqlStr = string.Concat("SELECT * FROM ", tbl);

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.CnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);

                cnn.Open();

                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                OleDbDataReader drr = cmd.ExecuteReader();

                while (drr.Read())
                {
                    /*if (drr["CharacterID"].ToString().Trim() != characterId)
                        continue;*/

                    RpgDatabaseParser.Data.InteractiveDialog.InteractiveDialogLine line =
                        new RpgDatabaseParser.Data.InteractiveDialog.InteractiveDialogLine();

                    line.Text = drr["DialogText"].ToString().Trim();
                    line.Comments = drr["Comment"].ToString().Trim();
                    line.UpdateProperties(characterId, tbl, (int)drr["RowID"]);

                    line.Condition = new RpgDatabaseParser.Data.DataCondition();

                    line.Condition.ConditionType = GetConditionTypes(drr["ConditionType"].ToString().Trim());
                    int numArg = -1;
                    int.TryParse(drr["Condition"].ToString().Trim(), out numArg);
                    line.Condition.NumberArgument = numArg;

                    res.Add(line);
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

            return res;
        }

        private RpgDatabaseParser.Data.InteractiveDialog.InteractiveDialogPackage GetCharacterDialogs(string characterId)
        {
            RpgDatabaseParser.Data.InteractiveDialog.InteractiveDialogPackage res =
                new RpgDatabaseParser.Data.InteractiveDialog.InteractiveDialogPackage();

            res.CharacterId = characterId;

            res.InitiationDialogBatches = GetDialogBatches(characterId, ETypesInterActiveDialogs.Initiation);
            res.GreetingDialogOptions = GetDialogOptions(characterId, ETypesInterActiveDialogs.Greeting);
            res.InfoDialogBatches = GetDialogBatches(characterId, ETypesInterActiveDialogs.Info);
            res.QuestDialogBatches = GetDialogBatches(characterId, ETypesInterActiveDialogs.Quest);
            res.ShoppingDialog.OpenShopDialogBatch = GetDialogOptions(characterId, ETypesInterActiveDialogs.ShoppingOpen);
            res.ShoppingDialog.BuyDialogOptions = GetDialogOptions(characterId, ETypesInterActiveDialogs.ShoppingBuy);
            res.ShoppingDialog.SellDialogOptions = GetDialogOptions(characterId, ETypesInterActiveDialogs.ShoppingSell);
            res.ShoppingDialog.DenyDialogOptions = GetDialogOptions(characterId, ETypesInterActiveDialogs.ShoppingDeny);
            res.FarewellDialogOptions = GetDialogOptions(characterId, ETypesInterActiveDialogs.Farewell);

            return res;
        }

        private void FillInteractiveDialogXML(RpgDatabaseParser.Data.Database xml)
        {
            string tbl = "Characters";
            string sqlStr = string.Concat("SELECT * FROM ", tbl);

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.CnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);

                cnn.Open();

                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                OleDbDataReader drr = cmd.ExecuteReader();

                while (drr.Read())
                {
                    xml.InteractiveDialogList.Add(GetCharacterDialogs(drr["ID"].ToString().Trim()));
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

        private List<int> GetQuestChildrenIds(string parentId)
        {
            List<int> res = new List<int>();

            string tbl = "Quests";
            string sqlStr = string.Concat("SELECT * FROM ", tbl);

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.CnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);

                cnn.Open();

                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                OleDbDataReader drr = cmd.ExecuteReader();

                while (drr.Read())
                {
                    if (drr["Parent"].ToString().Trim() == parentId)
                    {
                        int id = -1;
                        int.TryParse(drr["ID"].ToString().Trim().Replace("QUEST", string.Empty), out id);
                        res.Add(id);
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

            return res;
        }

        private RpgDatabaseParser.Data.DataAction.ActionTypes GetActionTypes(string condition)
        {
            RpgDatabaseParser.Data.DataAction.ActionTypes res;

            Enum.TryParse<RpgDatabaseParser.Data.DataAction.ActionTypes>(condition, out res);

            return res;
        }

        private RpgDatabaseParser.Data.DataCondition.ConditionTypes GetConditionTypes(string condition)
        {
            RpgDatabaseParser.Data.DataCondition.ConditionTypes res;

            Enum.TryParse<RpgDatabaseParser.Data.DataCondition.ConditionTypes>(condition, out res);

            return res;
        }

        private void FillQuestXML(RpgDatabaseParser.Data.Database xml)
        {
            string tbl = "Quests";
            string sqlStr = string.Concat("SELECT * FROM ", tbl);

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.CnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);

                cnn.Open();

                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                OleDbDataReader drr = cmd.ExecuteReader();

                while (drr.Read())
                {
                    RpgDatabaseParser.Data.Quest.QuestDefinition questDef = new RpgDatabaseParser.Data.Quest.QuestDefinition();
                    
                    int id = -1;
                    int.TryParse(drr["ID"].ToString().Trim().Replace("QUEST", string.Empty), out id);
                    questDef.Id = id;
                    questDef.Description = drr["Description"].ToString().Trim();

                    questDef.Children = GetQuestChildrenIds(drr["ID"].ToString().Trim());

                    switch (id)
                    {
                        case 1:
                            questDef.SlotIndex = 0;
                            questDef.Category = RpgDatabaseParser.Data.Quest.QuestCategories.Main;
                            break;
                        case 2:
                            questDef.SlotIndex = 1;
                            questDef.Category = RpgDatabaseParser.Data.Quest.QuestCategories.Main;
                            break;
                        case 3:
                            questDef.SlotIndex = 2;
                            questDef.Category = RpgDatabaseParser.Data.Quest.QuestCategories.Main;
                            break;
                        case 4:
                            questDef.SlotIndex = 3;
                            questDef.Category = RpgDatabaseParser.Data.Quest.QuestCategories.Main;
                            break;
                        case 5:
                            questDef.SlotIndex = 4;
                            questDef.Category = RpgDatabaseParser.Data.Quest.QuestCategories.Main;
                            break;
                        case 6:
                            questDef.SlotIndex = 5;
                            questDef.Category = RpgDatabaseParser.Data.Quest.QuestCategories.Main;
                            break;
                        case 7:
                            questDef.SlotIndex = 0;
                            questDef.Category = RpgDatabaseParser.Data.Quest.QuestCategories.Side;
                            break;
                        case 8:
                            questDef.SlotIndex = 1;
                            questDef.Category = RpgDatabaseParser.Data.Quest.QuestCategories.Side;
                            break;
                        case 9:
                            questDef.SlotIndex = 2;
                            questDef.Category = RpgDatabaseParser.Data.Quest.QuestCategories.Side;
                            break;
                        case 10:
                            questDef.SlotIndex = 3;
                            questDef.Category = RpgDatabaseParser.Data.Quest.QuestCategories.Side;
                            break;
                        case 11:
                            questDef.SlotIndex = 4;
                            questDef.Category = RpgDatabaseParser.Data.Quest.QuestCategories.Side;
                            break;
                        case 12:
                            questDef.SlotIndex = 5;
                            questDef.Category = RpgDatabaseParser.Data.Quest.QuestCategories.Side;
                            break;
                        case 13:
                            questDef.SlotIndex = 6;
                            questDef.Category = RpgDatabaseParser.Data.Quest.QuestCategories.Side;
                            break;
                        case 14:
                            questDef.SlotIndex = 7;
                            questDef.Category = RpgDatabaseParser.Data.Quest.QuestCategories.Side;
                            break;
                        case 15:
                            questDef.SlotIndex = 8;
                            questDef.Category = RpgDatabaseParser.Data.Quest.QuestCategories.Side;
                            break;
                        case 16:
                            questDef.SlotIndex = 9;
                            questDef.Category = RpgDatabaseParser.Data.Quest.QuestCategories.Side;
                            break;
                        case 17:
                            questDef.SlotIndex = 10;
                            questDef.Category = RpgDatabaseParser.Data.Quest.QuestCategories.Side;
                            break;
                        case 18:
                            questDef.SlotIndex = 11;
                            questDef.Category = RpgDatabaseParser.Data.Quest.QuestCategories.Side;
                            break;
                        case 19:
                            questDef.SlotIndex = 12;
                            questDef.Category = RpgDatabaseParser.Data.Quest.QuestCategories.Side;
                            break;
                        case 20:
                            questDef.SlotIndex = 13;
                            questDef.Category = RpgDatabaseParser.Data.Quest.QuestCategories.Side;
                            break;
                        case 21:
                            questDef.SlotIndex = 14;
                            questDef.Category = RpgDatabaseParser.Data.Quest.QuestCategories.Side;
                            break;
                        case 22:
                            questDef.SlotIndex = 15;
                            questDef.Category = RpgDatabaseParser.Data.Quest.QuestCategories.Side;
                            break;
                        case 23:
                            questDef.SlotIndex = 16;
                            questDef.Category = RpgDatabaseParser.Data.Quest.QuestCategories.Side;
                            break;
                        case 24:
                            questDef.SlotIndex = 17;
                            questDef.Category = RpgDatabaseParser.Data.Quest.QuestCategories.Side;
                            break;
                        default:
                            questDef.Category = RpgDatabaseParser.Data.Quest.QuestCategories.Sub;
                            break;
                    }
                    
                    RpgDatabaseParser.Data.DataCondition dataCondition = new RpgDatabaseParser.Data.DataCondition();
                    dataCondition.ConditionType = GetConditionTypes(drr["ConditionsType"].ToString().Trim());
                    int numArg = -1;
                    int.TryParse(drr["Conditions"].ToString().Trim(), out numArg);
                    dataCondition.NumberArgument = numArg;

                    List<RpgDatabaseParser.Data.DataCondition> conditions = new List<RpgDatabaseParser.Data.DataCondition>();
                    conditions.Add(dataCondition);

                    questDef.Conditions = conditions;


                    dataCondition = new RpgDatabaseParser.Data.DataCondition();
                    dataCondition.ConditionType = GetConditionTypes(drr["DoneConditionsType"].ToString().Trim());
                    numArg = -1;
                    int.TryParse(drr["DoneConditions"].ToString().Trim(), out numArg);
                    dataCondition.NumberArgument = numArg;

                    List<RpgDatabaseParser.Data.DataCondition> doneConditions = new List<RpgDatabaseParser.Data.DataCondition>();
                    doneConditions.Add(dataCondition);

                    questDef.DoneConditions = doneConditions;


                    RpgDatabaseParser.Data.DataAction dataAction = new RpgDatabaseParser.Data.DataAction();
                    dataAction.ActionType = GetActionTypes(drr["ActionsType"].ToString().Trim());
                    numArg = -1;
                    int.TryParse(drr["Actions"].ToString().Trim(), out numArg);
                    dataAction.NumberArgument = numArg;

                    List<RpgDatabaseParser.Data.DataAction> actions = new List<RpgDatabaseParser.Data.DataAction>();
                    actions.Add(dataAction);

                    questDef.Actions = actions;

                    xml.QuestDefinitions.Add(questDef);
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

        private void txtExportPath_TextChanged(object sender, EventArgs e)
        {
            if (!btnExport.Enabled)
                btnExport.Enabled = true;
        }

        private void btnSetExportPath_Click(object sender, EventArgs e)
        {
            DialogResult result = fbdExport.ShowDialog(this);

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                string path = fbdExport.SelectedPath;
                if (!path.EndsWith(Path.DirectorySeparatorChar.ToString()))
                    path += Path.DirectorySeparatorChar.ToString();

                string file = path + "database.xml";

                Base.ExportFilePath = file;

                txtExportPath.Text = Base.ExportFilePath;

                string tbl = "Settings";
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

                        dr.BeginEdit();
                        dr["ExportPath"] = Base.ExportFilePath;
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
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            RpgDatabaseParser.Data.Database xml = new RpgDatabaseParser.Data.Database();

            FillCharacterXML(xml);
            FillInteractiveDialogXML(xml);
            FillQuestXML(xml);

            if (File.Exists(Base.ExportFilePath))
                File.Delete(Base.ExportFilePath);

            xml.SaveToFile(Base.ExportFilePath);

            MessageBox.Show(this, "فایل XML با موفقیت ذخیره شد.", "تولید خروجی", MessageBoxButtons.OK,
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
        }

        private DataTable ReadTable(string tbl)
        {
            DataTable dt = new DataTable();

            string sqlStr = string.Concat("SELECT * FROM ", tbl);

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.CnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);

                cnn.Open();

                DataSet ds = new DataSet();

                oda.Fill(ds, tbl);

                dt = ds.Tables[tbl];

                switch (tbl)
                {
                    case "Characters":
                        dt.Columns["ID"].ColumnName = "شناسه کاراکتر";
                        break;
                    default:
                        break;
                }

                cnn.Close();

                ds.Dispose();
                oda.Dispose();
                cnn.Dispose();

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

            return dt;
        }

        private void ReadTables()
        {
            txtCharactersSearch.Clear();
            m_dtCharacters = ReadTable("Characters");
            dgvCharacters.DataSource = m_dtCharacters;
            dgvCharacters.Columns[0].Width = 350;
            dgvCharacters.Sort(dgvCharacters.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
        }

        private void AddDialogGroup(string tbl)
        {
            string sqlStr = string.Concat("SELECT * FROM ", tbl);

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.CnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);

                cnn.Open();

                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                OleDbDataReader drr = cmd.ExecuteReader();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataRow dr;

                ocb.QuotePrefix = "[";
                ocb.QuoteSuffix = "]";
                oda.Fill(ds, tbl);

                dt = ds.Tables[tbl];
                dr = dt.NewRow();

                try
                {
                    dr["CharacterID"] = trvInterActiveDialog.SelectedNode.Parent.Parent.Text;
                }
                catch
                {
                    dr["CharacterID"] = trvInterActiveDialog.SelectedNode.Parent.Text;
                }

                dt.Rows.Add(dr);

                oda.InsertCommand = ocb.GetInsertCommand();

                oda.RowUpdated += new OleDbRowUpdatedEventHandler(OnDialogGroupTableRowUpdated);

                if (oda.Update(ds, tbl) == 1)
                {
                    ds.AcceptChanges();
                }
                else
                {
                    ds.RejectChanges();
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

        private void OnDialogGroupTableRowUpdated(object sender, OleDbRowUpdatedEventArgs e)
        {
            if (e.StatementType == StatementType.Insert)
            {
                OleDbCommand cmd = new OleDbCommand("SELECT @@IDENTITY", e.Command.Connection, e.Command.Transaction);

                m_lastInsertedDialogGroupRowID = (int)cmd.ExecuteScalar();
                e.Row["RowID"] = m_lastInsertedDialogGroupRowID;
                e.Row.AcceptChanges();

                cmd.Dispose();
                cmd = null;
            }
        }

        private void btnCharactersAddEdit_Click(object sender, EventArgs e)
        {
            if (txtCharactersID.Text.Trim() == string.Empty)
                return;

            string tbl = "Characters";
            string sqlStr = string.Concat("SELECT * FROM ", tbl);

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.CnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);

                cnn.Open();

                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                OleDbDataReader drr = cmd.ExecuteReader();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataRow dr;

                if (btnCharactersAddEdit.Text == "درج")
                {
                    bool duplicate = false;

                    while (drr.Read())
                    {
                        if (drr["ID"].ToString().Trim() == txtCharactersID.Text.Trim())
                        {
                            duplicate = true;
                            break;
                        }
                    }
                    if (!duplicate)
                    {
                        ocb.QuotePrefix = "[";
                        ocb.QuoteSuffix = "]";
                        oda.Fill(ds, tbl);

                        dt = ds.Tables[tbl];
                        dr = dt.NewRow();

                        dr["ID"] = txtCharactersID.Text.Trim();
                        dt.Rows.Add(dr);

                        oda.InsertCommand = ocb.GetInsertCommand();

                        if (oda.Update(ds, tbl) == 1)
                        {
                            ds.AcceptChanges();
                            /*MessageBox.Show("کاراکتر با موفقیت درج شد", "درج کاراکتر", MessageBoxButtons.OK,
                                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);*/
                            txtCharactersID.Clear();

                            txtCharactersSearch.Clear();
                            m_dtCharacters = dt;
                            dgvCharacters.DataSource = m_dtCharacters;
                            dgvCharacters.Columns[0].Width = 350;
                            dgvCharacters.Sort(dgvCharacters.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                        }
                        else
                        {
                            ds.RejectChanges();
                            MessageBox.Show("عدم ثبت کاراکتر", "درج کاراکتر", MessageBoxButtons.OK,
                                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                            txtCharactersID.SelectAll();
                        }
                    }
                    else
                    {
                        MessageBox.Show("کاراکتر مورد نظر قبلا ثبت شده است", "درج کاراکتر", MessageBoxButtons.OK,
                            MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                        txtCharactersID.SelectAll();
                    }
                }
                else
                {
                    ocb.QuotePrefix = "[";
                    ocb.QuoteSuffix = "]";
                    oda.Fill(ds, tbl);

                    bool found = false;

                    if (txtCharactersID.Text.Trim() != m_id4EditCharacters.Trim())
                        while (drr.Read())
                        {
                            if (drr["ID"].ToString().Trim() == txtCharactersID.Text.Trim())
                            {
                                found = true;
                                break;
                            }
                        }

                    if (!found)
                    {
                        dt = ds.Tables[tbl];
                        for (int i = 0; i < dt.Rows.Count; ++i)
                        {
                            dr = dt.Rows[i];
                            if (dr["ID"].ToString().Trim() == m_id4EditCharacters.Trim())
                            {
                                dr.BeginEdit();

                                dr["ID"] = txtCharactersID.Text.Trim();

                                dr.EndEdit();

                                oda.UpdateCommand = ocb.GetUpdateCommand();

                                if (oda.Update(ds, tbl) == 1)
                                {
                                    ds.AcceptChanges();
                                    /*MessageBox.Show("با موفقیت ویرایش شد", "ویرایش کاراکتر", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);*/

                                    txtCharactersSearch.Clear();
                                    m_dtCharacters = dt;
                                    dgvCharacters.DataSource = m_dtCharacters;
                                    dgvCharacters.Columns[0].Width = 350;
                                    dgvCharacters.Sort(dgvCharacters.Columns[0], System.ComponentModel.ListSortDirection.Ascending);

                                    btnCharactersCancel.Visible = false;
                                    btnCharactersAddEdit.Text = "درج";
                                    dgvCharacters.Enabled = true;
                                    txtCharactersSearch.Enabled = true;
                                    txtCharactersID.Clear();
                                }
                                else
                                {
                                    ds.RejectChanges();
                                    MessageBox.Show("عدم ثبت تغییرات", "ویرایش کاراکتر", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                                    txtCharactersID.SelectAll();
                                }

                                break;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("کاراکتر دیگری با این شناسه وجود دارد", "ویرایش کاراکتر", MessageBoxButtons.OK,
                            MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                        txtCharactersID.SelectAll();
                    }
                }

                txtCharactersID.Focus();

                drr.Close();
                cnn.Close();

                dt.Dispose();
                ds.Dispose();
                drr.Dispose();
                cmd.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();

                dt = null;
                ds = null;
                drr = null;
                cmd = null;
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

        private void txtCharactersSearch_TextChanged(object sender, EventArgs e)
        {
            string phrase = txtCharactersSearch.Text.Trim().ToLower();
            if (phrase != string.Empty)
            {
                DataTable dt = m_dtCharacters.Clone();
                for (int i = 0; i < m_dtCharacters.Rows.Count; ++i)
                {
                    if (m_dtCharacters.Rows[i][0].ToString().Trim().ToLower().Contains(phrase))
                    {
                        object[] row = m_dtCharacters.Rows[i].ItemArray;
                        dt.Rows.Add(row);
                    }
                }
                dgvCharacters.DataSource = dt;
                lblCharactersSearchWarning.Visible = true;
            }
            else
            {
                dgvCharacters.DataSource = m_dtCharacters;
                lblCharactersSearchWarning.Visible = false;
            }
        }

        private void mnuCharactersEdit_Click(object sender, EventArgs e)
        {
            m_id4EditCharacters = dgvCharacters.CurrentRow.Cells[0].Value.ToString().Trim();
            dgvCharacters.Enabled = false;
            txtCharactersSearch.Enabled = false;
            btnCharactersAddEdit.Text = "ویرایش";
            txtCharactersID.Text = m_id4EditCharacters;
            btnCharactersCancel.Visible = true;
            txtCharactersID.SelectAll();
            txtCharactersID.Focus();
        }

        private void mnuCharactersErase_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = MessageBox.Show("آيا مايل به حذف کاراکتر مورد نظر مي باشيد؟", "حذف کاراکتر",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (dlgResult != DialogResult.OK)
            {
                return;
            }
                        
            string tbl = "Characters";
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

                bool found = false;

                dt = ds.Tables[tbl];
                for (int i = 0; i < dt.Rows.Count; ++i)
                {
                    dr = dt.Rows[i];
                    if (dr["id"].ToString().Trim() == dgvCharacters.CurrentCell.Value.ToString().Trim())
                    {
                        found = true;

                        dr.Delete();

                        oda.DeleteCommand = ocb.GetDeleteCommand();

                        if (oda.Update(ds, tbl) == 1)
                        {
                            ds.AcceptChanges();
                            MessageBox.Show("با موفقیت پاک شد", "حذف کاراکتر", MessageBoxButtons.OK,
                                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

                            txtCharactersSearch.Clear();
                            m_dtCharacters = dt;
                            dgvCharacters.DataSource = m_dtCharacters;
                            dgvCharacters.Columns[0].Width = 350;
                            dgvCharacters.Sort(dgvCharacters.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                        }
                        else
                        {
                            ds.RejectChanges();
                            MessageBox.Show("عدم حذف", "حذف کاراکتر", MessageBoxButtons.OK,
                                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                        }

                        break;
                    }
                }

                if (!found)
                    MessageBox.Show("کاراکتر مورد نظر یافت نشد", "حذف کاراکتر", MessageBoxButtons.OK,
                                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                
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

        private void txtCharactersID_TextChanged(object sender, EventArgs e)
        {
            if (txtCharactersID.Text != string.Empty)
                btnCharactersAddEdit.Enabled = true;
            else
                btnCharactersAddEdit.Enabled = false;
        }

        private void btnCharactersCancel_Click(object sender, EventArgs e)
        {
            btnCharactersCancel.Visible = false;
            btnCharactersAddEdit.Text = "درج";
            dgvCharacters.Enabled = true;
            txtCharactersSearch.Enabled = true;
            txtCharactersID.Clear();
        }

        private void ReadDialogsFromGroup(TreeNode node, int groupID, string characterID, string tbl)
        {
            try
            {
                string sqlStr = string.Empty;
                switch (tbl)
                {
                    case "InitiationDialog":
                    case "InfoDialog":
                    case "QuestDialog":
                        sqlStr = string.Concat("SELECT * FROM [", tbl, "] WHERE (CharacterID='", characterID, "'",
                            " AND GroupID=", groupID, ") ORDER BY zIndex ASC;");
                        break;
                    case "GreetingDialog":
                    case "ShoppingOpenDialog":
                    case "ShoppingBuyDialog":
                    case "ShoppingSellDialog":
                    case "ShoppingDenyDialog":
                    case "FarewellDialog":
                        sqlStr = string.Concat("SELECT * FROM [", tbl, "] WHERE (GroupID=", groupID, ") ORDER BY zIndex ASC;");
                        break;
                    default:
                        break;
                }

                OleDbConnection cnn = new OleDbConnection(Base.CnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);

                cnn.Open();

                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                OleDbDataReader drr = cmd.ExecuteReader();

                while (drr.Read())
                {
                    Dictionary<ETypesInterActiveDialogNodes, int> tag = new Dictionary<ETypesInterActiveDialogNodes, int>();
                    tag.Add(ETypesInterActiveDialogNodes.DIALOG, (int)drr["RowID"]);

                    TreeNode n = new TreeNode(drr["DialogText"].ToString());
                    n.Tag = tag;
                    node.Nodes.Add(n);
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

        private void ReadDialogGroups(TreeNode node, string characterID, string tbl)
        {
            try
            {
                string sqlStr = string.Concat("SELECT * FROM [", tbl, "] WHERE CharacterID='", characterID,"';");

                OleDbConnection cnn = new OleDbConnection(Base.CnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);

                cnn.Open();

                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                OleDbDataReader drr = cmd.ExecuteReader();

                while (drr.Read())
                {
                    Dictionary<ETypesInterActiveDialogNodes, int> tag = new Dictionary<ETypesInterActiveDialogNodes, int>();
                    tag.Add(GetDialogGroupType((ETypesInterActiveDialogNodes)node.Tag), (int)drr["RowID"]);

                    TreeNode n = new TreeNode("******");

                    if (drr["Title"].ToString().Trim() != string.Empty)
                        n.Text = drr["Title"].ToString().Trim();

                    n.Tag = tag;

                    string table = string.Empty;
                    switch (tbl)
                    {
                        case "InitiationDialogGroup":
                            table = "InitiationDialog";
                            break;
                        case "GreetingDialogGroup":
                            table = "GreetingDialog";
                            break;
                        case "InfoDialogGroup":
                            table = "InfoDialog";
                            break;
                        case "QuestDialogGroup":
                            table = "QuestDialog";
                            break;
                        case "ShoppingOpenDialogGroup":
                            table = "ShoppingOpenDialog";
                            break;
                        case "ShoppingBuyDialogGroup":
                            table = "ShoppingBuyDialog";
                            break;
                        case "ShoppingSellDialogGroup":
                            table = "ShoppingSellDialog";
                            break;
                        case "ShoppingDenyDialogGroup":
                            table = "ShoppingDenyDialog";
                            break;
                        case "FarewellDialogGroup":
                            table = "FarewellDialog";
                            break;
                        default:
                            break;
                    }

                    ReadDialogsFromGroup(n, (int)drr["RowID"], drr["characterID"].ToString(), table);

                    node.Nodes.Add(n);
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

        private void ReadDialogsTree()
        {
            trvInterActiveDialog.Nodes.Clear();

            try
            {
                string tbl = "Characters";
                string sqlStr = string.Concat("SELECT * FROM ", tbl);

                OleDbConnection cnn = new OleDbConnection(Base.CnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);

                cnn.Open();

                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                OleDbDataReader drr = cmd.ExecuteReader();

                while (drr.Read())
                {
                    TreeNode node = new TreeNode(drr["ID"].ToString().Trim());
                    node.Tag = ETypesInterActiveDialogNodes.CHARACTER;

                    string[] nodes = { "Initiation", "Greeting", "Info",
                                         "Quest", "Shopping", "Farewell" };

                    string dialogGroupTable = string.Empty;

                    int i = -1;
                    foreach (string s in nodes)
                    {
                        TreeNode n = new TreeNode(s);
                        switch (++i)
                        {
                            case 0:
                                n.Tag = ETypesInterActiveDialogNodes.InitiationDIALOG;
                                ReadDialogGroups(n, drr["ID"].ToString().Trim(), "InitiationDialogGroup");
                                break;
                            case 1:
                                n.Tag = ETypesInterActiveDialogNodes.GreetingDIALOG;
                                ReadDialogGroups(n, drr["ID"].ToString().Trim(), "GreetingDialogGroup");
                                break;
                            case 2:
                                n.Tag = ETypesInterActiveDialogNodes.InfoDIALOG;
                                ReadDialogGroups(n, drr["ID"].ToString().Trim(), "InfoDialogGroup");
                                break;
                            case 3:
                                n.Tag = ETypesInterActiveDialogNodes.QuestDIALOG;
                                ReadDialogGroups(n, drr["ID"].ToString().Trim(), "QuestDialogGroup");
                                break;
                            case 4:
                                n.Tag = ETypesInterActiveDialogNodes.ShoppingDIALOG;

                                string[] jNodes = { "Open", "Buy", "Sell",
                                                     "Deny" };
                                int j = -1;
                                foreach (string js in jNodes)
                                {
                                    TreeNode jn = new TreeNode(js);
                                    switch (++j)
                                    {
                                        case 0:
                                            jn.Tag = ETypesInterActiveDialogNodes.ShoppingOpenDIALOG;
                                            ReadDialogGroups(jn, drr["ID"].ToString().Trim(), "ShoppingOpenDialogGroup");
                                            break;
                                        case 1:
                                            jn.Tag = ETypesInterActiveDialogNodes.ShoppingBuyDIALOG;
                                            ReadDialogGroups(jn, drr["ID"].ToString().Trim(), "ShoppingBuyDialogGroup");
                                            break;
                                        case 2:
                                            jn.Tag = ETypesInterActiveDialogNodes.ShoppingSellDIALOG;
                                            ReadDialogGroups(jn, drr["ID"].ToString().Trim(), "ShoppingSellDialogGroup");
                                            break;
                                        case 3:
                                            jn.Tag = ETypesInterActiveDialogNodes.ShoppingDenyDIALOG;
                                            ReadDialogGroups(jn, drr["ID"].ToString().Trim(), "ShoppingDenyDialogGroup");
                                            break;
                                        default:
                                            break;
                                    }
                                    n.Nodes.Add(jn);
                                }
                                break;
                            case 5:
                                n.Tag = ETypesInterActiveDialogNodes.FarewellDIALOG;
                                ReadDialogGroups(n, drr["ID"].ToString().Trim(), "FarewellDialogGroup");
                                break;
                            default:
                                break;
                        }
                        node.Nodes.Add(n);
                    }
                    trvInterActiveDialog.Nodes.Add(node);
                    //node.ExpandAll();
                }
                trvInterActiveDialog.ExpandAll();

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

        private void ReadDialogsTree(string character)
        {
            m_showAllInteractiveDialogs = true;

            trvInterActiveDialog.Nodes.Clear();

            try
            {
                string tbl = "Characters";
                string sqlStr = string.Concat("SELECT * FROM [", tbl, "] WHERE (ID='", character, "'",");");

                OleDbConnection cnn = new OleDbConnection(Base.CnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);

                cnn.Open();

                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                OleDbDataReader drr = cmd.ExecuteReader();

                while (drr.Read())
                {
                    TreeNode node = new TreeNode(drr["ID"].ToString().Trim());
                    node.Tag = ETypesInterActiveDialogNodes.CHARACTER;

                    string[] nodes = { "Initiation", "Greeting", "Info",
                                         "Quest", "Shopping", "Farewell" };

                    string dialogGroupTable = string.Empty;

                    int i = -1;
                    foreach (string s in nodes)
                    {
                        TreeNode n = new TreeNode(s);
                        switch (++i)
                        {
                            case 0:
                                n.Tag = ETypesInterActiveDialogNodes.InitiationDIALOG;
                                ReadDialogGroups(n, drr["ID"].ToString().Trim(), "InitiationDialogGroup");
                                break;
                            case 1:
                                n.Tag = ETypesInterActiveDialogNodes.GreetingDIALOG;
                                ReadDialogGroups(n, drr["ID"].ToString().Trim(), "GreetingDialogGroup");
                                break;
                            case 2:
                                n.Tag = ETypesInterActiveDialogNodes.InfoDIALOG;
                                ReadDialogGroups(n, drr["ID"].ToString().Trim(), "InfoDialogGroup");
                                break;
                            case 3:
                                n.Tag = ETypesInterActiveDialogNodes.QuestDIALOG;
                                ReadDialogGroups(n, drr["ID"].ToString().Trim(), "QuestDialogGroup");
                                break;
                            case 4:
                                n.Tag = ETypesInterActiveDialogNodes.ShoppingDIALOG;

                                string[] jNodes = { "Open", "Buy", "Sell",
                                                     "Deny" };
                                int j = -1;
                                foreach (string js in jNodes)
                                {
                                    TreeNode jn = new TreeNode(js);
                                    switch (++j)
                                    {
                                        case 0:
                                            jn.Tag = ETypesInterActiveDialogNodes.ShoppingOpenDIALOG;
                                            ReadDialogGroups(jn, drr["ID"].ToString().Trim(), "ShoppingOpenDialogGroup");
                                            break;
                                        case 1:
                                            jn.Tag = ETypesInterActiveDialogNodes.ShoppingBuyDIALOG;
                                            ReadDialogGroups(jn, drr["ID"].ToString().Trim(), "ShoppingBuyDialogGroup");
                                            break;
                                        case 2:
                                            jn.Tag = ETypesInterActiveDialogNodes.ShoppingSellDIALOG;
                                            ReadDialogGroups(jn, drr["ID"].ToString().Trim(), "ShoppingSellDialogGroup");
                                            break;
                                        case 3:
                                            jn.Tag = ETypesInterActiveDialogNodes.ShoppingDenyDIALOG;
                                            ReadDialogGroups(jn, drr["ID"].ToString().Trim(), "ShoppingDenyDialogGroup");
                                            break;
                                        default:
                                            break;
                                    }
                                    n.Nodes.Add(jn);
                                }
                                break;
                            case 5:
                                n.Tag = ETypesInterActiveDialogNodes.FarewellDIALOG;
                                ReadDialogGroups(n, drr["ID"].ToString().Trim(), "FarewellDialogGroup");
                                break;
                            default:
                                break;
                        }
                        node.Nodes.Add(n);
                    }
                    trvInterActiveDialog.Nodes.Add(node);
                    //node.ExpandAll();
                }
                trvInterActiveDialog.ExpandAll();

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

        private void tbcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tbcMain.SelectedTab.Name)
            {
                case "tbpInteractiveDialogs":
                    if (m_showAllInteractiveDialogs)
                        ReadDialogsTree();
                    else
                        ReadDialogsTree(dgvCharacters.CurrentRow.Cells[0].Value.ToString().Trim());
                    break;
                default:
                    break;
            }
        }

        private ETypesInterActiveDialogNodes GetDialogGroupType(ETypesInterActiveDialogNodes dialog)
        {
            switch (dialog)
            {
                case ETypesInterActiveDialogNodes.InitiationDIALOG:
                    return ETypesInterActiveDialogNodes.InitiationDIALOGGROUP;
                case ETypesInterActiveDialogNodes.GreetingDIALOG:
                    return ETypesInterActiveDialogNodes.GreetingDIALOGGROUP;
                case ETypesInterActiveDialogNodes.InfoDIALOG:
                    return ETypesInterActiveDialogNodes.InfoDIALOGGROUP;
                case ETypesInterActiveDialogNodes.QuestDIALOG:
                    return ETypesInterActiveDialogNodes.QuestDIALOGGROUP;
                case ETypesInterActiveDialogNodes.ShoppingOpenDIALOG:
                    return ETypesInterActiveDialogNodes.ShoppingOpenDIALOGGROUP;
                case ETypesInterActiveDialogNodes.ShoppingBuyDIALOG:
                    return ETypesInterActiveDialogNodes.ShoppingBuyDIALOGGROUP;
                case ETypesInterActiveDialogNodes.ShoppingSellDIALOG:
                    return ETypesInterActiveDialogNodes.ShoppingSellDIALOGGROUP;
                case ETypesInterActiveDialogNodes.ShoppingDenyDIALOG:
                    return ETypesInterActiveDialogNodes.ShoppingDenyDIALOGGROUP;
                case ETypesInterActiveDialogNodes.FarewellDIALOG:
                    return ETypesInterActiveDialogNodes.FarewellDIALOGGROUP;
                default:
                    return ETypesInterActiveDialogNodes.NONE;
            }
        }

        private string GetDialogGroupTable(ETypesInterActiveDialogNodes dialog)
        {
            switch (dialog)
            {
                case ETypesInterActiveDialogNodes.InitiationDIALOG:
                    return "InitiationDialogGroup";
                case ETypesInterActiveDialogNodes.GreetingDIALOG:
                    return "GreetingDialogGroup";
                case ETypesInterActiveDialogNodes.InfoDIALOG:
                    return "InfoDialogGroup";
                case ETypesInterActiveDialogNodes.QuestDIALOG:
                    return "QuestDialogGroup";
                case ETypesInterActiveDialogNodes.ShoppingOpenDIALOG:
                    return "ShoppingOpenDialogGroup";
                case ETypesInterActiveDialogNodes.ShoppingBuyDIALOG:
                    return "ShoppingBuyDialogGroup";
                case ETypesInterActiveDialogNodes.ShoppingSellDIALOG:
                    return "ShoppingSellDialogGroup";
                case ETypesInterActiveDialogNodes.ShoppingDenyDIALOG:
                    return "ShoppingDenyDialogGroup";
                case ETypesInterActiveDialogNodes.FarewellDIALOG:
                    return "FarewellDialogGroup";

                case ETypesInterActiveDialogNodes.InitiationDIALOGGROUP:
                    return "InitiationDialogGroup";
                case ETypesInterActiveDialogNodes.GreetingDIALOGGROUP:
                    return "GreetingDialogGroup";
                case ETypesInterActiveDialogNodes.InfoDIALOGGROUP:
                    return "InfoDialogGroup";
                case ETypesInterActiveDialogNodes.QuestDIALOGGROUP:
                    return "QuestDialogGroup";
                case ETypesInterActiveDialogNodes.ShoppingOpenDIALOGGROUP:
                    return "ShoppingOpenDialogGroup";
                case ETypesInterActiveDialogNodes.ShoppingBuyDIALOGGROUP:
                    return "ShoppingBuyDialogGroup";
                case ETypesInterActiveDialogNodes.ShoppingSellDIALOGGROUP:
                    return "ShoppingSellDialogGroup";
                case ETypesInterActiveDialogNodes.ShoppingDenyDIALOGGROUP:
                    return "ShoppingDenyDialogGroup";
                case ETypesInterActiveDialogNodes.FarewellDIALOGGROUP:
                    return "FarewellDialogGroup";

                default:
                    return "";
            }
        }

        private ETypesInterActiveDialogNodes GetInterActiveDialogNodeType(TreeNode node)
        {
            ETypesInterActiveDialogNodes nodeType = ETypesInterActiveDialogNodes.NONE;
            try
            {
                nodeType = (ETypesInterActiveDialogNodes)node.Tag;
            }
            catch
            {
                try
                {
                    Dictionary<ETypesInterActiveDialogNodes, int> dic;
                    dic = (Dictionary<ETypesInterActiveDialogNodes, int>)node.Tag;
                    foreach (ETypesInterActiveDialogNodes key in dic.Keys)
                    {
                        nodeType = key;
                        break;
                    }
                }
                catch
                {
                }
            }

            return nodeType;
        }

        private void mnuInteractiveDialogsAdd_Click(object sender, EventArgs e)
        {
            switch (GetInterActiveDialogNodeType(trvInterActiveDialog.SelectedNode))
            {
                case ETypesInterActiveDialogNodes.InitiationDIALOG:
                case ETypesInterActiveDialogNodes.GreetingDIALOG:
                case ETypesInterActiveDialogNodes.InfoDIALOG:
                case ETypesInterActiveDialogNodes.QuestDIALOG:
                case ETypesInterActiveDialogNodes.ShoppingOpenDIALOG:
                case ETypesInterActiveDialogNodes.ShoppingBuyDIALOG:
                case ETypesInterActiveDialogNodes.ShoppingSellDIALOG:
                case ETypesInterActiveDialogNodes.ShoppingDenyDIALOG:
                case ETypesInterActiveDialogNodes.FarewellDIALOG:
                    AddDialogGroup(GetDialogGroupTable((ETypesInterActiveDialogNodes)trvInterActiveDialog.SelectedNode.Tag));

                    Dictionary<ETypesInterActiveDialogNodes, int> tag = new Dictionary<ETypesInterActiveDialogNodes, int>();
                    tag.Add(GetDialogGroupType((ETypesInterActiveDialogNodes)trvInterActiveDialog.SelectedNode.Tag), m_lastInsertedDialogGroupRowID);

                    TreeNode node = new TreeNode("******");
                    node.Tag = tag;
                    trvInterActiveDialog.SelectedNode.Nodes.Add(node);
                    trvInterActiveDialog.SelectedNode.ExpandAll();
                    break;

                case ETypesInterActiveDialogNodes.InitiationDIALOGGROUP:
                case ETypesInterActiveDialogNodes.InfoDIALOGGROUP:
                case ETypesInterActiveDialogNodes.QuestDIALOGGROUP:
                case ETypesInterActiveDialogNodes.ShoppingOpenDIALOGGROUP:
                    using (InteractiveDialogInputForm1 frm = new InteractiveDialogInputForm1())
                    {
                        frm.title = "افزودن دیالوگ";
                        frm.zIndex = trvInterActiveDialog.SelectedNode.Nodes.Count;
                        try
                        {
                            Dictionary<ETypesInterActiveDialogNodes, int> dic;
                            dic = (Dictionary<ETypesInterActiveDialogNodes, int>)trvInterActiveDialog.SelectedNode.Tag;
                            foreach (ETypesInterActiveDialogNodes key in dic.Keys)
                            {
                                frm.group = dic[key];
                                break;
                            }
                        }
                        catch
                        {
                        }
                        try
                        {
                            frm.charID = trvInterActiveDialog.SelectedNode.Parent.Parent.Text;
                        }
                        catch
                        {
                        }
                        switch (GetInterActiveDialogNodeType(trvInterActiveDialog.SelectedNode))
                        {
                            case ETypesInterActiveDialogNodes.InitiationDIALOGGROUP:
                                frm.table = "InitiationDialog";
                                break;
                            case ETypesInterActiveDialogNodes.InfoDIALOGGROUP:
                                frm.table = "InfoDialog";
                                break;
                            case ETypesInterActiveDialogNodes.QuestDIALOGGROUP:
                                frm.table = "QuestDialog";
                                break;
                            case ETypesInterActiveDialogNodes.ShoppingOpenDIALOGGROUP:
                                frm.table = "ShoppingOpenDialog";
                                break;
                        }
                        try
                        {
                            frm.characters = new string[] { trvInterActiveDialog.SelectedNode.Parent.Parent.Parent.Text, "Player" };
                        }
                        catch
                        {
                            frm.characters = new string[] { trvInterActiveDialog.SelectedNode.Parent.Parent.Text, "Player" };
                        }
                        frm.ShowDialog(this);

                        if (frm.isOK)
                        {
                            Dictionary<ETypesInterActiveDialogNodes, int> t = new Dictionary<ETypesInterActiveDialogNodes, int>();
                            t.Add(ETypesInterActiveDialogNodes.DIALOG, frm.dialogID);

                            TreeNode n = new TreeNode(frm.dialogText);
                            n.Tag = t;
                            trvInterActiveDialog.SelectedNode.Nodes.Add(n);
                            trvInterActiveDialog.ExpandAll();
                        }
                    }
                    break;

                case ETypesInterActiveDialogNodes.GreetingDIALOGGROUP:
                case ETypesInterActiveDialogNodes.ShoppingBuyDIALOGGROUP:
                case ETypesInterActiveDialogNodes.ShoppingSellDIALOGGROUP:
                case ETypesInterActiveDialogNodes.ShoppingDenyDIALOGGROUP:
                case ETypesInterActiveDialogNodes.FarewellDIALOGGROUP:
                    using (InteractiveDialogInputForm2 frm = new InteractiveDialogInputForm2())
                    {
                        frm.title = "افزودن دیالوگ";
                        frm.zIndex = trvInterActiveDialog.SelectedNode.Nodes.Count;
                        try
                        {
                            Dictionary<ETypesInterActiveDialogNodes, int> dic;
                            dic = (Dictionary<ETypesInterActiveDialogNodes, int>)trvInterActiveDialog.SelectedNode.Tag;
                            foreach (ETypesInterActiveDialogNodes key in dic.Keys)
                            {
                                frm.group = dic[key];
                                break;
                            }
                        }
                        catch
                        {
                        }
                        try
                        {
                            frm.charID = trvInterActiveDialog.SelectedNode.Parent.Parent.Parent.Text;
                        }
                        catch
                        {
                        }
                        switch (GetInterActiveDialogNodeType(trvInterActiveDialog.SelectedNode))
                        {
                            case ETypesInterActiveDialogNodes.GreetingDIALOGGROUP:
                                frm.table = "GreetingDialog";
                                break;
                            case ETypesInterActiveDialogNodes.ShoppingBuyDIALOGGROUP:
                                frm.table = "ShoppingBuyDialog";
                                break;
                            case ETypesInterActiveDialogNodes.ShoppingSellDIALOGGROUP:
                                frm.table = "ShoppingSellDialog";
                                break;
                            case ETypesInterActiveDialogNodes.ShoppingDenyDIALOGGROUP:
                                frm.table = "ShoppingDenyDialog";
                                break;
                            case ETypesInterActiveDialogNodes.FarewellDIALOGGROUP:
                                frm.table = "FarewellDialog";
                                break;
                        }
                        frm.ShowDialog(this);

                        if (frm.isOK)
                        {
                            Dictionary<ETypesInterActiveDialogNodes, int> t = new Dictionary<ETypesInterActiveDialogNodes, int>();
                            t.Add(ETypesInterActiveDialogNodes.DIALOG, frm.dialogID);

                            TreeNode n = new TreeNode(frm.dialogText);
                            n.Tag = t;
                            trvInterActiveDialog.SelectedNode.Nodes.Add(n);
                            trvInterActiveDialog.ExpandAll();
                        }
                    }
                    break;

                default:
                    break;
            }
        }

        private void mnuInteractiveDialogsEdit_Click(object sender, EventArgs e)
        {
            switch (GetInterActiveDialogNodeType(trvInterActiveDialog.SelectedNode))
            {
                case ETypesInterActiveDialogNodes.DIALOG:
                    switch (GetInterActiveDialogNodeType(trvInterActiveDialog.SelectedNode.Parent))
                    {
                        case ETypesInterActiveDialogNodes.InitiationDIALOGGROUP:
                        case ETypesInterActiveDialogNodes.InfoDIALOGGROUP:
                        case ETypesInterActiveDialogNodes.QuestDIALOGGROUP:
                        case ETypesInterActiveDialogNodes.ShoppingOpenDIALOGGROUP:
                            using (InteractiveDialogInputForm1 frm = new InteractiveDialogInputForm1())
                            {
                                frm.isEditMode = true;
                                switch (GetInterActiveDialogNodeType(trvInterActiveDialog.SelectedNode.Parent))
                                {
                                    case ETypesInterActiveDialogNodes.InitiationDIALOGGROUP:
                                        frm.table = "InitiationDialog";
                                        break;
                                    case ETypesInterActiveDialogNodes.InfoDIALOGGROUP:
                                        frm.table = "InfoDialog";
                                        break;
                                    case ETypesInterActiveDialogNodes.QuestDIALOGGROUP:
                                        frm.table = "QuestDialog";
                                        break;
                                    case ETypesInterActiveDialogNodes.ShoppingOpenDIALOGGROUP:
                                        frm.table = "ShoppingOpenDialog";
                                        break;
                                }
                                Dictionary<ETypesInterActiveDialogNodes, int> dic;
                                dic = (Dictionary<ETypesInterActiveDialogNodes, int>)trvInterActiveDialog.SelectedNode.Tag;
                                foreach (ETypesInterActiveDialogNodes key in dic.Keys)
                                {
                                    frm.dialogID = dic[key];
                                    break;
                                }
                                try
                                {
                                    frm.characters = new string[] { trvInterActiveDialog.SelectedNode.Parent.Parent.Parent.Text, "Player" };
                                }
                                catch
                                {
                                    frm.characters = new string[] { trvInterActiveDialog.SelectedNode.Parent.Parent.Text, "Player" };
                                }

                                frm.ShowDialog(this);

                                if (frm.isOK)
                                {
                                    trvInterActiveDialog.SelectedNode.Text = frm.dialogText;
                                }
                            }
                            break;
                        case ETypesInterActiveDialogNodes.GreetingDIALOGGROUP:
                        case ETypesInterActiveDialogNodes.ShoppingBuyDIALOGGROUP:
                        case ETypesInterActiveDialogNodes.ShoppingSellDIALOGGROUP:
                        case ETypesInterActiveDialogNodes.ShoppingDenyDIALOGGROUP:
                        case ETypesInterActiveDialogNodes.FarewellDIALOGGROUP:
                            using (InteractiveDialogInputForm2 frm = new InteractiveDialogInputForm2())
                            {
                                frm.isEditMode = true;
                                switch (GetInterActiveDialogNodeType(trvInterActiveDialog.SelectedNode.Parent))
                                {
                                    case ETypesInterActiveDialogNodes.GreetingDIALOGGROUP:
                                        frm.table = "GreetingDialog";
                                        break;
                                    case ETypesInterActiveDialogNodes.ShoppingBuyDIALOGGROUP:
                                        frm.table = "ShoppingBuyDialog";
                                        break;
                                    case ETypesInterActiveDialogNodes.ShoppingSellDIALOGGROUP:
                                        frm.table = "ShoppingSellDialog";
                                        break;
                                    case ETypesInterActiveDialogNodes.ShoppingDenyDIALOGGROUP:
                                        frm.table = "ShoppingDenyDialog";
                                        break;
                                    case ETypesInterActiveDialogNodes.FarewellDIALOGGROUP:
                                        frm.table = "FarewellDialog";
                                        break;
                                }
                                Dictionary<ETypesInterActiveDialogNodes, int> dic;
                                dic = (Dictionary<ETypesInterActiveDialogNodes, int>)trvInterActiveDialog.SelectedNode.Tag;
                                foreach (ETypesInterActiveDialogNodes key in dic.Keys)
                                {
                                    frm.dialogID = dic[key];
                                    break;
                                }

                                frm.ShowDialog(this);

                                if (frm.isOK)
                                {
                                    trvInterActiveDialog.SelectedNode.Text = frm.dialogText;
                                }
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        private void EraseDialogGroup(string tbl)
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

                int rowId = -1;
                Dictionary<ETypesInterActiveDialogNodes, int> dic;
                dic = (Dictionary<ETypesInterActiveDialogNodes, int>)trvInterActiveDialog.SelectedNode.Tag;
                foreach (ETypesInterActiveDialogNodes key in dic.Keys)
                {
                    rowId = dic[key];
                    break;
                }

                dt = ds.Tables[tbl];
                for (int i = 0; i < dt.Rows.Count; ++i)
                {
                    dr = dt.Rows[i];
                    if ((int)dr["RowID"] == rowId)
                    {
                        dr.Delete();
                        break;
                    }
                }

                oda.DeleteCommand = ocb.GetDeleteCommand();

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

        private void CleanUpDialogGroup(string tbl)
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

                int rowId = -1;
                Dictionary<ETypesInterActiveDialogNodes, int> dic;
                dic = (Dictionary<ETypesInterActiveDialogNodes, int>)trvInterActiveDialog.SelectedNode.Tag;
                foreach (ETypesInterActiveDialogNodes key in dic.Keys)
                {
                    rowId = dic[key];
                    break;
                }

                dt = ds.Tables[tbl];
                for (int i = 0; i < dt.Rows.Count; ++i)
                {
                    dr = dt.Rows[i];
                    if ((int)dr["GroupID"] == rowId)
                    {
                        dr.Delete();
                    }
                }

                oda.DeleteCommand = ocb.GetDeleteCommand();

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

        private void EraseDialogMessage(string tbl)
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

                int rowId = -1;
                Dictionary<ETypesInterActiveDialogNodes, int> dic;
                dic = (Dictionary<ETypesInterActiveDialogNodes, int>)trvInterActiveDialog.SelectedNode.Tag;
                foreach (ETypesInterActiveDialogNodes key in dic.Keys)
                {
                    rowId = dic[key];
                    break;
                }

                dt = ds.Tables[tbl];
                for (int i = 0; i < dt.Rows.Count; ++i)
                {
                    dr = dt.Rows[i];
                    if ((int)dr["RowID"] == rowId)
                    {
                        dr.Delete();
                        break;
                    }
                }

                oda.DeleteCommand = ocb.GetDeleteCommand();

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

        private void mnuInteractiveDialogsErase_Click(object sender, EventArgs e)
        {
            switch (GetInterActiveDialogNodeType(trvInterActiveDialog.SelectedNode))
            {
                case ETypesInterActiveDialogNodes.InitiationDIALOGGROUP:
                case ETypesInterActiveDialogNodes.GreetingDIALOGGROUP:
                case ETypesInterActiveDialogNodes.InfoDIALOGGROUP:
                case ETypesInterActiveDialogNodes.QuestDIALOGGROUP:
                case ETypesInterActiveDialogNodes.ShoppingOpenDIALOGGROUP:
                case ETypesInterActiveDialogNodes.ShoppingBuyDIALOGGROUP:
                case ETypesInterActiveDialogNodes.ShoppingSellDIALOGGROUP:
                case ETypesInterActiveDialogNodes.ShoppingDenyDIALOGGROUP:
                case ETypesInterActiveDialogNodes.FarewellDIALOGGROUP:
                    DialogResult dlgResult = MessageBox.Show("آيا مايل به حذف گروه دیالوگ های مورد نظر مي باشيد؟", "حذف گروه دیالوگ",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                    if (dlgResult != DialogResult.OK)
                    {
                        return;
                    }

                    switch (GetInterActiveDialogNodeType(trvInterActiveDialog.SelectedNode))
                    {
                        case ETypesInterActiveDialogNodes.InitiationDIALOGGROUP:
                            CleanUpDialogGroup("InitiationDialog");
                            EraseDialogGroup("InitiationDialogGroup");
                            break;
                        case ETypesInterActiveDialogNodes.GreetingDIALOGGROUP:
                            CleanUpDialogGroup("GreetingDialog");
                            EraseDialogGroup("GreetingDialogGroup");
                            break;
                        case ETypesInterActiveDialogNodes.InfoDIALOGGROUP:
                            CleanUpDialogGroup("InfoDialog");
                            EraseDialogGroup("InfoDialogGroup");
                            break;
                        case ETypesInterActiveDialogNodes.QuestDIALOGGROUP:
                            CleanUpDialogGroup("QuestDialog");
                            EraseDialogGroup("QuestDialogGroup");
                            break;
                        case ETypesInterActiveDialogNodes.ShoppingOpenDIALOGGROUP:
                            CleanUpDialogGroup("ShoppingOpenDialog");
                            EraseDialogGroup("ShoppingOpenDialogGroup");
                            break;
                        case ETypesInterActiveDialogNodes.ShoppingBuyDIALOGGROUP:
                            CleanUpDialogGroup("ShoppingBuyDialog");
                            EraseDialogGroup("ShoppingBuyDialogGroup");
                            break;
                        case ETypesInterActiveDialogNodes.ShoppingSellDIALOGGROUP:
                            CleanUpDialogGroup("ShoppingSellDialog");
                            EraseDialogGroup("ShoppingSellDialogGroup");
                            break;
                        case ETypesInterActiveDialogNodes.ShoppingDenyDIALOGGROUP:
                            CleanUpDialogGroup("ShoppingDenyDialog");
                            EraseDialogGroup("ShoppingDenyDialogGroup");
                            break;
                        case ETypesInterActiveDialogNodes.FarewellDIALOGGROUP:
                            CleanUpDialogGroup("FarewellDialog");
                            EraseDialogGroup("FarewellDialogGroup");
                            break;
                        default:
                            break;
                    }
                    break;
                case ETypesInterActiveDialogNodes.DIALOG:
                    dlgResult = MessageBox.Show("آيا مايل به حذف دیالوگ مورد نظر مي باشيد؟", "حذف دیالوگ",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                    if (dlgResult != DialogResult.OK)
                    {
                        return;
                    }

                    string t = string.Empty;
                    switch (GetInterActiveDialogNodeType(trvInterActiveDialog.SelectedNode.Parent))
                    {
                        case ETypesInterActiveDialogNodes.InitiationDIALOGGROUP:
                           t = "InitiationDialog";
                            break;
                        case ETypesInterActiveDialogNodes.GreetingDIALOGGROUP:
                            t = "GreetingDialog";
                            break;
                        case ETypesInterActiveDialogNodes.InfoDIALOGGROUP:
                            t = "InfoDialog";
                            break;
                        case ETypesInterActiveDialogNodes.QuestDIALOGGROUP:
                            t = "QuestDialog";
                            break;
                        case ETypesInterActiveDialogNodes.ShoppingOpenDIALOGGROUP:
                            t = "ShoppingOpenDialog";
                            break;
                        case ETypesInterActiveDialogNodes.ShoppingBuyDIALOGGROUP:
                            t = "ShoppingBuyDialog";
                            break;
                        case ETypesInterActiveDialogNodes.ShoppingSellDIALOGGROUP:
                            t = "ShoppingSellDialog";
                            break;
                        case ETypesInterActiveDialogNodes.ShoppingDenyDIALOGGROUP:
                            t = "ShoppingDenyDialog";
                            break;
                        case ETypesInterActiveDialogNodes.FarewellDIALOGGROUP:
                            t = "FarewellDialog";
                            break;
                        default:
                            break;
                    }

                    EraseDialogMessage(t);
                    break;
                default:
                    break;
            }

            trvInterActiveDialog.SelectedNode.Remove();
        }

        private void SetInteractiveDialogsCtxStatus()
        {
            if (trvInterActiveDialog.Nodes.Count == 0 ||
                trvInterActiveDialog.SelectedNode == null)
            {
                mnuInteractiveDialogsAdd.Enabled = false;
                mnuInteractiveDialogsEdit.Enabled = false;
                mnuInteractiveDialogsErase.Enabled = false;
                mnuInteractiveDialogsGroupTitle.Visible = false;
                return;
            }

            switch (GetInterActiveDialogNodeType(trvInterActiveDialog.SelectedNode))
            {
                case ETypesInterActiveDialogNodes.CHARACTER:
                case ETypesInterActiveDialogNodes.ShoppingDIALOG:
                    mnuInteractiveDialogsAdd.Enabled = false;
                    mnuInteractiveDialogsEdit.Enabled = false;
                    mnuInteractiveDialogsErase.Enabled = false;
                    mnuInteractiveDialogsGroupTitle.Visible = false;
                    break;
                case ETypesInterActiveDialogNodes.InitiationDIALOG:
                case ETypesInterActiveDialogNodes.GreetingDIALOG:
                case ETypesInterActiveDialogNodes.InfoDIALOG:
                case ETypesInterActiveDialogNodes.QuestDIALOG:
                case ETypesInterActiveDialogNodes.ShoppingOpenDIALOG:
                case ETypesInterActiveDialogNodes.ShoppingBuyDIALOG:
                case ETypesInterActiveDialogNodes.ShoppingSellDIALOG:
                case ETypesInterActiveDialogNodes.ShoppingDenyDIALOG:
                case ETypesInterActiveDialogNodes.FarewellDIALOG:
                    mnuInteractiveDialogsAdd.Enabled = true;
                    mnuInteractiveDialogsEdit.Enabled = false;
                    mnuInteractiveDialogsErase.Enabled = false;
                    mnuInteractiveDialogsGroupTitle.Visible = false;
                    break;
                case ETypesInterActiveDialogNodes.InitiationDIALOGGROUP:
                case ETypesInterActiveDialogNodes.GreetingDIALOGGROUP:
                case ETypesInterActiveDialogNodes.InfoDIALOGGROUP:
                case ETypesInterActiveDialogNodes.QuestDIALOGGROUP:
                case ETypesInterActiveDialogNodes.ShoppingOpenDIALOGGROUP:
                case ETypesInterActiveDialogNodes.ShoppingBuyDIALOGGROUP:
                case ETypesInterActiveDialogNodes.ShoppingSellDIALOGGROUP:
                case ETypesInterActiveDialogNodes.ShoppingDenyDIALOGGROUP:
                case ETypesInterActiveDialogNodes.FarewellDIALOGGROUP:
                    mnuInteractiveDialogsAdd.Enabled = true;
                    mnuInteractiveDialogsEdit.Enabled = false;
                    mnuInteractiveDialogsErase.Enabled = true;
                    mnuInteractiveDialogsGroupTitle.Visible = true;
                    break;
                case ETypesInterActiveDialogNodes.DIALOG:
                    mnuInteractiveDialogsAdd.Enabled = false;
                    mnuInteractiveDialogsEdit.Enabled = true;
                    mnuInteractiveDialogsErase.Enabled = true;
                    mnuInteractiveDialogsGroupTitle.Visible = false;
                    break;
                default:
                    break;
            }
        }

        private void ctxInteractiveDialogs_Opening(object sender, CancelEventArgs e)
        {
            SetInteractiveDialogsCtxStatus();
        }

        private void trvInterActiveDialog_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SetInteractiveDialogsCtxStatus();
        }

        private void btnMainQuest01_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            using(Quest frm = new Quest())
            {
                frm.quest = (string)btn.Tag;
                frm.ShowDialog(this);
            }
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            string tbl = "Settings";
            string sqlStr = string.Concat("SELECT * FROM ", tbl);

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.CnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);

                cnn.Open();

                DataSet ds = new DataSet();

                ocb.QuotePrefix = "[";
                ocb.QuoteSuffix = "]";
                oda.Fill(ds, tbl);

                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                OleDbDataReader drr = cmd.ExecuteReader();

                while (drr.Read())
                {
                    Base.ExportFilePath = drr["ExportPath"].ToString().Trim();
                    txtExportPath.Text = Base.ExportFilePath;
                    if (Base.ExportFilePath != string.Empty)
                        btnExport.Enabled = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n\t" + ex.Message);
            }
        }

        private void mnuQuestButtonsQuestTitle_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem mnuItem = (ToolStripMenuItem)sender;
            ContextMenuStrip ctx = (ContextMenuStrip)mnuItem.Owner;
            Button btn = (Button)ctx.SourceControl;
            using (QuestTitleInputForm frm = new QuestTitleInputForm())
            {
                frm.quest = (string)btn.Tag;
                frm.ShowDialog(this);
                if (frm.isOK)
                {
                    btn.Text = string.Format("{0}\n{1}\n{2}",
                        (string)btn.Tag, frm.titleText, frm.titleLevel);
                }
            }
        }

        private bool SetDialogZIndex(TreeNode node, TreeNode otherNode, int newIndex, int oldIndex)
        {
            bool result = false;

            string tbl = string.Empty;

            switch (GetInterActiveDialogNodeType(node.Parent))
            {
                case ETypesInterActiveDialogNodes.InitiationDIALOGGROUP:
                    tbl = "InitiationDialog";
                    break;
                case ETypesInterActiveDialogNodes.GreetingDIALOGGROUP:
                    tbl = "GreetingDialog";
                    break;
                case ETypesInterActiveDialogNodes.InfoDIALOGGROUP:
                    tbl = "InfoDialog";
                    break;
                case ETypesInterActiveDialogNodes.QuestDIALOGGROUP:
                    tbl = "QuestDialog";
                    break;
                case ETypesInterActiveDialogNodes.ShoppingOpenDIALOGGROUP:
                    tbl = "ShoppingOpenDialog";
                    break;
                case ETypesInterActiveDialogNodes.ShoppingBuyDIALOGGROUP:
                    tbl = "ShoppingBuyDialog";
                    break;
                case ETypesInterActiveDialogNodes.ShoppingSellDIALOGGROUP:
                    tbl = "ShoppingSellDialog";
                    break;
                case ETypesInterActiveDialogNodes.ShoppingDenyDIALOGGROUP:
                    tbl = "ShoppingDenyDialog";
                    break;
                case ETypesInterActiveDialogNodes.FarewellDIALOGGROUP:
                    tbl = "FarewellDialog";
                    break;
            }

            string sqlStr = string.Concat("SELECT * FROM ", tbl);

            int id = -1;
            Dictionary<ETypesInterActiveDialogNodes, int> dic;
            dic = (Dictionary<ETypesInterActiveDialogNodes, int>)node.Tag;
            foreach (ETypesInterActiveDialogNodes key in dic.Keys)
            {
                id = dic[key];
                break;
            }

            int otherId = -1;
            dic = (Dictionary<ETypesInterActiveDialogNodes, int>)otherNode.Tag;
            foreach (ETypesInterActiveDialogNodes key in dic.Keys)
            {
                otherId = dic[key];
                break;
            }

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

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];

                    if ((int)dr["RowID"] == id)
                    {
                        dr.BeginEdit();
                        dr["zIndex"] = newIndex;
                        dr.EndEdit();

                        if (oda.Update(ds, tbl) == 1)
                        {
                            ds.AcceptChanges();
                        }
                        else
                        {
                            ds.RejectChanges();
                        }

                        continue;
                    }
                    if ((int)dr["RowID"] == otherId)
                    {
                        dr.BeginEdit();
                        dr["zIndex"] = oldIndex;
                        dr.EndEdit();

                        if (oda.Update(ds, tbl) == 1)
                        {
                            ds.AcceptChanges();
                            result = true;
                        }
                        else
                        {
                            ds.RejectChanges();
                        }

                        continue;
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

            return result;
        }

        private void mnuInteractiveDialogsMoveUp_Click(object sender, EventArgs e)
        {
            TreeNode node = trvInterActiveDialog.SelectedNode;
            TreeNode parent = node.Parent;
            int index = node.Index;
            if (index != 0)
            {
                TreeNode otherNode = parent.Nodes[node.Index - 1];
                if (SetDialogZIndex(node, otherNode, index - 1, index))
                {
                    parent.Nodes.Remove(node);
                    parent.Nodes.Insert(index - 1, node);
                    trvInterActiveDialog.SelectedNode = node;
                }
            }
        }

        private void mnuInteractiveDialogsMoveDown_Click(object sender, EventArgs e)
        {
            TreeNode node = trvInterActiveDialog.SelectedNode;
            TreeNode parent = node.Parent;
            int index = node.Index;
            if (index != parent.Nodes.Count - 1)
            {
                TreeNode otherNode = parent.Nodes[node.Index + 1];
                if (SetDialogZIndex(node, otherNode, index + 1, index))
                {
                    parent.Nodes.Remove(node);
                    parent.Nodes.Insert(index + 1, node);
                    trvInterActiveDialog.SelectedNode = node;
                }
            }
        }

        private void mnuInteractiveDialogsGroupTitle_Click(object sender, EventArgs e)
        {
            using (DialogGroupTitle frm = new DialogGroupTitle())
            {
                Dictionary<ETypesInterActiveDialogNodes, int> dic;
                dic = (Dictionary<ETypesInterActiveDialogNodes, int>)trvInterActiveDialog.SelectedNode.Tag;
                foreach (ETypesInterActiveDialogNodes key in dic.Keys)
                {
                    frm.id = dic[key];
                    frm.tbl = GetDialogGroupTable(key);
                    break;
                }
                frm.ShowDialog(this);
                if (frm.isOK)
                {
                    trvInterActiveDialog.SelectedNode.Text = frm.title;
                }
            }
        }

        private void mnuCharactersInteractiveDialogs_Click(object sender, EventArgs e)
        {
            m_showAllInteractiveDialogs = false;
            tbcMain.SelectedTab = tbpInteractiveDialogs;
        }
    }
}
