using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RpgDbManager
{
    static class Base
    {
        private static string m_path;
        private static string m_dbPw = "";
        private static string m_dbFile = "rpg_db.mdb";
        private static string m_cnnStr;

        private static string m_exportFilePath = string.Empty;

        static Base()
        {
            m_path = Environment.CurrentDirectory;

            string sepChar = Path.DirectorySeparatorChar.ToString();
            if (!m_path.EndsWith(sepChar))
                m_path += sepChar;

            m_dbFile = string.Concat(m_path, m_dbFile);
            m_cnnStr = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Jet OLEDB:Database Password={1};", m_dbFile, m_dbPw);
        }

        public static string CnnStr
        {
            get
            {
                return m_cnnStr;
            }
        }

        public static string ExportFilePath
        {
            get
            {
                return m_exportFilePath;
            }
            set
            {
                m_exportFilePath = value;
            }
        }
    }
}
