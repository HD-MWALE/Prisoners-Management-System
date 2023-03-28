using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roll_Call_And_Management_System.database
{
    internal class Mysql
    {
        static MySqlConnection conn;
        //public static string strProvider = "server=localhost;Database=prcms_db;User ID=root;Password=";
        public static string strProvider = "server=localhost;Database=prisoners_management_system;User ID=root;Password=";
        public bool Open()
        {
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = strProvider;
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
        public void Backup()
        {
            using (MySqlConnection conn = new MySqlConnection(strProvider))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ExportToFile(Config.Backup);
                        conn.Close();
                    }
                }
            }
        }
        public static void Restore()
        {
            using (MySqlConnection conn = new MySqlConnection(strProvider))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ImportFromFile(Config.Backup);
                        conn.Close();
                    }
                }
            }
        }
        public DataSet ExecuteDataSet(string sql)
        {
            try
            {
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
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
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                Config.ServerMessage(ex.ToString());
                return null;
            }
        }
        public MySqlDataReader ExecuteReader(string sql)
        {
            try
            {
                MySqlDataReader reader;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                reader = cmd.ExecuteReader();
                Backup();
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
                MySqlTransaction mytransaction = conn.BeginTransaction();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                affected = cmd.ExecuteNonQuery();
                mytransaction.Commit();
                Backup();
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
