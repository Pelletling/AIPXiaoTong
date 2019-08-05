using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Framework.Common
{
    /// <summary>
        /// 超级数据库操作类
        /// </summary>
    public class DBHelper
    {
        private string connectionString;
        public DBHelper(string connectionString)
        {
            this.connectionString = connectionString;

        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public DataSet GetDataSet(string SQLString)
        {
            using (var conn = new OracleConnection(connectionString))
            {
                conn.Open();
                DataSet ds = new DataSet();
                OracleDataAdapter oda = new OracleDataAdapter(SQLString, conn);
                oda.Fill(ds);

                return ds;
            }
        }

        /// <summary>
        /// 获取DataSet第一行的第一个值
        /// </summary>
        /// <param name="SQLString"></param>
        /// <returns></returns>
        public string GetFristValue(string SQLString)
        {
            using (var conn = new OracleConnection(connectionString))
            {
                conn.Open();
                DataSet ds = new DataSet();
                OracleDataAdapter oda = new OracleDataAdapter(SQLString, conn);
                oda.Fill(ds);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0].ToString();
                }

                return "";
            }
        }
    }
}
