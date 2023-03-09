using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roll_Call_And_Management_System.database
{
    internal class Sqlite
    {
        static SQLiteConnection conn;
        public static string connstring = "Data Source=sqlite/prcms.db; Version = 3; New = True; Compress = True;"; 

        public bool Open()
        {
            try
            {
                conn = new SQLiteConnection();
                conn.ConnectionString = connstring;
                conn.Open();
                return true;
            }
            catch (Exception ex)
            {
                Config.ServerMessage(ex.ToString());
                return false;
            }

        }

        public void Close()
        {
            conn.Close();
            conn.Dispose();
        }

        public DataSet ExecuteDataSet(string sql)
        {
            try
            {
                DataSet ds = new DataSet();
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
                da.Fill(ds, "result");
                return ds;
            }
            catch (Exception ex)
            {
                Config.ServerMessage(ex.ToString());
                return null;
            }
        }
        public DataTable ExecuteDataTable(string sql)
        {
            try
            {
                DataTable dt = new DataTable();
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                Config.ServerMessage(ex.ToString());
                return null;
            }
        }
        public SQLiteDataReader ExecuteReader(string sql)
        {
            try
            {
                SQLiteDataReader reader;
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                Config.ServerMessage(ex.ToString());
                return null;
            }
        }
        public int ExecuteNonQuery(string sql)
        {
            try
            {
                int affected;
                SQLiteTransaction mytransaction = conn.BeginTransaction();
                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                affected = cmd.ExecuteNonQuery();
                mytransaction.Commit();
                return affected;
            }
            catch (Exception ex)
            {
                Config.ServerMessage(ex.ToString());
                return -1;
            }
        }
    }
}
