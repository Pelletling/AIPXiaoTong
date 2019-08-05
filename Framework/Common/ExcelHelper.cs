using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Framework.Common
{
    public class ExcelHelper
    {
        private static FileType fileType = FileType.noset;

        //public static DataSet ImportExcel(string Path)
        //{
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        string strConn = "Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + Path + ";Extended Properties='Excel 12.0;HDR=yes;IMEX=1'";

        //        using (OleDbConnection conn = new OleDbConnection(strConn))
        //        {
        //            conn.Open();
        //            DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
        //            string sql = String.Format("select * from [{0}]", dt.Rows[dt.Rows.Count - 1][2].ToString().Trim());
        //            OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
        //            da.Fill(ds);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return ds;
        //}

        private enum FileType
        {
            noset,
            xls,
            xlsx,
            csv
        }

        public static DataSet ImportExcel(string Path, int StartRecord = 0, int maxRecords = 0, bool HDR = true, bool IMEX = true)
        {
            DataSet ds = new DataSet();
            try
            {
                string fileName = Path.Remove(0, Path.LastIndexOf("\\") + 1);
                string strConn = "";
                string hdr = HDR == true ? "yes" : "no";
                string imex = IMEX == true ? "1" : "0";

                //fileName.Split('.')[1].ToLower()
                switch (fileName.FileExt())
                {
                    case "xls":
                        strConn = " Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " + Path + " ;Extended Properties='Excel 8.0;HDR=" + hdr + ";IMEX=" + imex + "'";
                        fileType = FileType.xls;
                        break;
                    case "xlsx":
                        strConn = "Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + Path + ";Extended Properties='Excel 12.0;HDR=" + hdr + ";IMEX=" + imex + "'";
                        fileType = FileType.xlsx;
                        break;
                    case "csv":
                        strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Path.Remove(Path.LastIndexOf("\\") + 1) + ";Extended Properties='Text;FMT=Delimited;HDR=" + hdr + ";'";
                        fileType = FileType.csv;
                        break;
                }


                using (OleDbConnection conn = new OleDbConnection(strConn))
                {
                    conn.Open();
                    DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                    string tableName = fileType == FileType.csv ? fileName : dt.Rows[dt.Rows.Count - 1][2].ToString().Trim();

                    string sql = String.Format("select * from [{0}]", tableName);
                    OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);

                    if (StartRecord == 0 && maxRecords == 0)
                    {
                        da.Fill(ds, "table");
                    }
                    else
                    {
                        da.Fill(ds, StartRecord, maxRecords, "table");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="destFileName"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static int Export(System.Data.DataTable dt, string destFileName, string tableName)
        {
            if (File.Exists(destFileName))
            {
                File.Delete(destFileName);
            }
            //得到字段名  
            string szFields = "";
            string szValues = "";
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                szFields += "[" + dt.Columns[i] + "],";
            }
            szFields = szFields.TrimEnd(',');
            //定义数据连接  
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = GetConnectionString(destFileName);
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            //打开数据库连接  
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //创建数据库表  
            try
            {
                command.CommandText = GetCreateTableSql("[" + tableName + "]", szFields.Split(','));
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //如果允许覆盖则删除已有数据  
                throw ex;
            }
            try
            {
                //循环处理数据------------------------------------------  
                int recordCount = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    szValues = "";
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        szValues += "'" + dt.Rows[i][j] + "',";
                    }
                    szValues = szValues.TrimEnd(',');
                    //组合成SQL语句并执行  
                    string szSql = "INSERT INTO [" + tableName + "](" + szFields + ") VALUES(" + szValues + ")";
                    command.CommandText = szSql;
                    recordCount += command.ExecuteNonQuery();
                }
                connection.Close();
                return recordCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //得到连接字符串  
        private static String GetConnectionString(string fullPath)
        {
            string szConnection;
            //szConnection = "Provider=Microsoft.JET.OLEDB.4.0;Extended Properties=Excel 8.0;data source=" + fullPath;
            szConnection = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                    "Data Source=" + fullPath + ";" +
                    "Extended Properties='Excel 12.0 Xml;HDR=YES;'";


            return szConnection;
        }


        //得到创建表的SQL语句  
        private static string GetCreateTableSql(string tableName, string[] fields)
        {
            string szSql = "CREATE TABLE " + tableName + "(";
            for (int i = 0; i < fields.Length; i++)
            {
                szSql += fields[i] + " VARCHAR(200),";
            }
            szSql = szSql.TrimEnd(',') + ")";
            return szSql;
        }


        public static DataTable ImportCSV(string filePath, string splitString = ",", bool containHeader = true, string ReplaceString = "", Encoding encoding = null)
        {
            DataTable tb = new DataTable("Table");

            //定义表头
            using (StreamReader sr = new StreamReader(filePath, encoding == null ? Encoding.Default:encoding))
            {
                var s = Regex.Split(sr.ReadLine(), splitString, RegexOptions.IgnoreCase);
                for (int i = 0; i < s.Length; i++)
                {
                    if (containHeader)
                    {
                        tb.Columns.Add(s[i].ReplaceStringTrim(ReplaceString));
                    }
                    else
                    {
                        tb.Columns.Add("F" + i.ToString());
                    }
                }
            }

            //填充内容
            using (StreamReader sr = new StreamReader(filePath, System.Text.Encoding.Default))
            {
                var row = "";
                while ((row = sr.ReadLine()) != null)
                {
                    DataRow newRow = tb.NewRow();
                    var rowSplit = Regex.Split(row, splitString, RegexOptions.IgnoreCase);
                    for (int i = 0; i < tb.Columns.Count; i++)
                    {
                        newRow[i] = rowSplit[i].ReplaceStringTrim(ReplaceString);
                    }
                    tb.Rows.Add(newRow);
                }
            }

            if (containHeader)
            {
                tb.Rows.RemoveAt(0);
            }


            return tb;
        }

    }
}
