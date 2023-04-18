using MySql.Data.MySqlClient;
using Prisoners_Management_System.config;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prisoners_Management_System.database
{
    internal class Mysql
    {
        // declaring mysql connection
        static MySqlConnection conn;
        // declaring and initializing string provider
        public static string strProvider = "server=localhost;Database=prisoners_management_system;User ID=root;Password=";
        // opening mysql database connection
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
                config.config.Alerts.ServerMessage(ex.ToString());
                return false;
            }

        }
        // closing mysql database connection
        public void Close()
        {
            conn.Close();
            conn.Dispose();
        }
        // backing up mysql database 
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
                        mb.ExportToFile(config.config.Backup); 
                        conn.Close();
                    }
                }
            }
        }
        // restoring mysql database
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
                        mb.ImportFromFile(config.config.Backup);
                        conn.Close();
                    }
                }
            }
        }
        // retrieve data from mysql database returning dataset
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
                config.config.Alerts.ServerMessage(ex.ToString());
                return null;
            }
        }
        // retrieve data from mysql database returning datatable
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
                config.config.Alerts.ServerMessage(ex.ToString());
                return null;
            }
        }
        // executing query returning mysql data reader
        public MySqlDataReader ExecuteReader(string sql)
        {
            try
            {
                MySqlDataReader reader;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                reader = cmd.ExecuteReader();
                //Backup();
                return reader;
            }
            catch (Exception ex)
            {
                config.config.Alerts.ServerMessage(ex.ToString());
                return null;
            }
        }
        // executing non query returning number of rows affected
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
                config.config.Alerts.ServerMessage(ex.ToString());
                return -1;
            }
        }
    }
}
