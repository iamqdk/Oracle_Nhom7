using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace StockM
{
    class Utility
    {
        public static OracleConnection conn;
        public static OracleCommand cmd;
        public static OracleDataAdapter da;
        public OracleConnection openDB()
        {
            conn = new OracleConnection("Data Source =  (DESCRIPTION = " +
    "(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))" +
    "(CONNECT_DATA =" +
      "(SERVER = DEDICATED)" +
      "(SERVICE_NAME = db11g)" +
    ")" +
 "); User Id=HR; password=123;");
            return conn;
        }
        public static void OpenConnection()
        {

            string sql = "Data Source =  (DESCRIPTION = " +
    "(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))" +
    "(CONNECT_DATA =" +
      "(SERVER = DEDICATED)" +
      "(SERVICE_NAME = db11g)" +
    ")" +
 "); User Id=HR; password=123;";
            try
            {
                conn = new OracleConnection(sql);
                conn.Open();
            }
            catch (OracleException EX)
            {

            }
        }
        public static void DisConnection()
        {
            conn.Close();
            conn.Dispose();
            conn = null;
        }
        public static DataTable getDataTable(string sql)
        {
            cmd = new OracleCommand(sql, conn);
            da = new OracleDataAdapter();
            da.SelectCommand = cmd;

            DataTable table1 = new DataTable();
            da.Fill(table1);
            da.Dispose();
            cmd.Dispose();
            return table1;
        }
        public static void Excute(string sql)
        {
            cmd = new OracleCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }
    }
}
