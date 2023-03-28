using DocumentFormat.OpenXml.Spreadsheet;
using MySql.Data.MySqlClient;
using Roll_Call_And_Management_System.database;
using Roll_Call_And_Management_System.views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Roll_Call_And_Management_System.classes
{
    internal class Dummy
    {
        static MySqlConnection conn;
        public static string strProvider = "server=localhost;Database=prisoners_management_system;User ID=root;Password=";
        public static bool Open()
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
                //Config.ServerMessage(ex.ToString());
                return false;
            }

        }
        public static void Close()
        {
            conn.Close();
            conn.Dispose();
        }

        public static DataSet ExecuteDataSet(string sql)
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

        public static MySqlDataReader ExecuteReader(string sql)
        {
            try
            {
                MySqlDataReader reader;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
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
                MySqlTransaction mytransaction = conn.BeginTransaction();
                MySqlCommand cmd = conn.CreateCommand();
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

        public static DataSet Retrieve(string query)
        {
            DataSet dataSet = null;
            if (Open())
            {
                dataSet = ExecuteDataSet(query);
                Close();
            }
            return dataSet;
        }

        public static bool Insert(string table, string fields, string data)
        {
            bool IsSuccess = false;
            string Query = "INSERT INTO " + table + " (" + fields + ") VALUES (" + data + ")";
            if (Open())
            {
                if (ExecuteReader(Query) != null)
                    IsSuccess = true;
                else
                    IsSuccess = false;
                Close();
            }
            return IsSuccess;
        }

        public static bool Update(string table, string data, int id)
        {
            bool IsSuccess = false;
            string Query = "UPDATE " + table + " SET " + data + " WHERE id = " + id;
            if (Open())
            {
                if (ExecuteReader(Query) != null)
                {
                    IsSuccess = true;
                }
                else
                    IsSuccess = false;
                Close();
            }
            else
                IsSuccess = false;
            return IsSuccess;
        }

        public static void SetYear()
        {
            DataSet dataSet = Retrieve("SELECT `id`, `date_created` FROM `inmate`");
            int year = 2019;
            int count = 1;
            foreach (DataRow row in dataSet.Tables["result"].Rows)
            {
                int id = Convert.ToInt32(row["id"]);
                if (count > 0 && count < 14)
                {
                    Update("inmate", "`date_created` = '" + year + "-" + Convert.ToDateTime(row["date_created"]).Month + "-" + Convert.ToDateTime(row["date_created"]).Day + "'", id);
                    //Update("inmate", "`date_created` = '" + Convert.ToDateTime(row["date_created"]).ToString("dd/MM/yyyy hh:mm:ss tt") + "'", id);
                    if (count == 13)
                    {
                        year++;
                    }
                }
                else if (count > 13 && count < 34)
                {
                    Update("inmate", "`date_created` = '" + year + "-" + Convert.ToDateTime(row["date_created"]).Month + "-" + Convert.ToDateTime(row["date_created"]).Day + "'", id);
                    if (count == 33)
                    {
                        year++;
                    }
                }
                else if (count > 33 && count < 51)
                {
                    Update("inmate", "`date_created` = '" + year + "-" + Convert.ToDateTime(row["date_created"]).Month + "-" + Convert.ToDateTime(row["date_created"]).Day + "'", id);
                    if (count == 50)
                    {
                        year++;
                    }
                }
                else if (count > 50 && count < 70)
                {
                    Update("inmate", "`date_created` = '" + year + "-" + Convert.ToDateTime(row["date_created"]).Month + "-" + Convert.ToDateTime(row["date_created"]).Day + "'", id);
                    if (count == 69)
                    {
                        year++;
                    }
                }
                else if (count > 69 && count < 101)
                {
                    Update("inmate", "`date_created` = '" + year + "-" + Convert.ToDateTime(row["date_created"]).Month + "-" + Convert.ToDateTime(row["date_created"]).Day + "'", id);
                    if (count == 100)
                    {
                        year++;
                    }
                }
                count++;
            }
        }

        public static void RollCall() 
        {
            DataSet dataSet = Retrieve("SELECT `id` FROM `dormitory`");
            foreach(DataRow row in dataSet.Tables["result"].Rows) 
            {
                int days_in_year = 365;
                int years = 5;
                int rollcall = 3;
                int records = (days_in_year * years * rollcall)/10;
                for (int i = 0; i < records - 1; i++)
                {
                    string fields = "`code`, `dormitory_id`, `total_inmates`, `status`";
                    string data = "'Code" + i + "'," + row["id"].ToString() + ", 10, 'Status'";
                    Execute.Insert("roll_call", fields, data);
                }
            }
        }

        public static void Sentence()
        {
            DataSet dataSet = Retrieve("SELECT `id`, `start_date`, `end_date`, `status`, `inmate_id` FROM `sentence`");
            int year = 2019;
            int count = 1;
            foreach (DataRow row in dataSet.Tables["result"].Rows)
            {
                int id = Convert.ToInt32(row["id"]);
                string start_date = year + "-" + Convert.ToDateTime(row["start_date"]).Month + "-" + Convert.ToDateTime(row["start_date"]).Day;
                string end_date = (year + Convert.ToInt32(Config.Random.Next(1, 25))) + "-" + Convert.ToDateTime(row["end_date"]).Month + "-" + Convert.ToDateTime(row["end_date"]).Day;
                if (count > 0 && count < 14)
                {
                    Update("sentence", "`start_date` = '" + start_date + "', `end_date` = '" + end_date + "'", id);
                    if (count == 13)
                    {
                        year++;
                    }
                }
                else if (count > 13 && count < 34)
                {
                    Update("sentence", "`start_date` = '" + start_date + "', `end_date` = '" + end_date + "'", id);
                    if (count == 33)
                    {
                        year++;
                    }
                }
                else if (count > 33 && count < 51)
                {
                    Update("sentence", "`start_date` = '" + start_date + "', `end_date` = '" + end_date + "'", id);
                    if (count == 50)
                    {
                        year++;
                    }
                }
                else if (count > 50 && count < 70)
                {
                    Update("sentence", "`start_date` = '" + start_date + "', `end_date` = '" + end_date + "'", id);
                    if (count == 69)
                    {
                        year++;
                    }
                }
                else if (count > 69 && count < 101)
                {
                    Update("sentence", "`start_date` = '" + start_date + "', `end_date` = '" + end_date + "'", id);
                    if (count == 100)
                    {
                        year++;
                    }
                }
                count++;
            }
        }

        public static void Get() 
        {
            ArrayList list = new ArrayList();
            DataSet dataSet = Retrieve("SELECT `id`, `name`, `description`, `type`, `gendertype` FROM `dormitory`");
            foreach(DataRow row in dataSet.Tables["result"].Rows)
            {
                list.Add(Convert.ToInt32(row["id"]));
                list.Add(AES.Encrypt(row["name"].ToString().Trim(), Properties.Resources.PassPhrase));
                list.Add(AES.Encrypt(row["description"].ToString().Trim(), Properties.Resources.PassPhrase));
                list.Add(AES.Encrypt(row["type"].ToString().Trim(), Properties.Resources.PassPhrase));
                list.Add(AES.Encrypt(row["gendertype"].ToString().Trim(), Properties.Resources.PassPhrase));
                Update("dormitory", "`name` = '" + list[1].ToString() + "', `description` = '" + list[2].ToString() + "', `type` = '" + list[3].ToString() + "', `gendertype` = '" + list[4].ToString() + "'", Convert.ToInt32(list[0]));
                list = new ArrayList();
            }

            dataSet = Retrieve("SELECT `id`, `name`, `type`, `date_created`, `description` FROM `crime`");
            foreach (DataRow row in dataSet.Tables["result"].Rows)
            {
                list.Add(Convert.ToInt32(row["id"]));
                list.Add(AES.Encrypt(row["name"].ToString().Trim(), Properties.Resources.PassPhrase));
                list.Add(AES.Encrypt(row["description"].ToString().Trim(), Properties.Resources.PassPhrase));
                Update("crime", "`name` = '" + list[1].ToString() + "', `description` = '" + list[2].ToString() + "'", Convert.ToInt32(list[0]));
                list = new ArrayList();
            }
            dataSet = new DataSet();
            dataSet = Retrieve("SELECT `id`, `code`, `first_name`, `middle_name`, `last_name`, `gender`, `dob`, `eye_color`, `complexion`, `marital_status`, `address`, `emergency_name`, `emergency_contact`, `emergency_relation`, `dormitory_id`, `visiting_privilege`, `date_created` FROM `inmate`");
            int inmate = 1;
            foreach (DataRow row in dataSet.Tables["result"].Rows)
            {
                list.Add(Convert.ToInt32(row["id"]));
                list.Add(AES.Encrypt("Inmate" + inmate, Properties.Resources.PassPhrase));
                list.Add(AES.Encrypt(row["first_name"].ToString().Trim(), Properties.Resources.PassPhrase));
                list.Add(AES.Encrypt(row["middle_name"].ToString().Trim(), Properties.Resources.PassPhrase));
                list.Add(AES.Encrypt(row["last_name"].ToString().Trim(), Properties.Resources.PassPhrase));
                list.Add(AES.Encrypt(row["gender"].ToString().Trim(), Properties.Resources.PassPhrase));
                list.Add(AES.Encrypt(row["eye_color"].ToString().Trim(), Properties.Resources.PassPhrase));
                list.Add(AES.Encrypt(row["complexion"].ToString().Trim(), Properties.Resources.PassPhrase));
                list.Add(AES.Encrypt(row["marital_status"].ToString().Trim(), Properties.Resources.PassPhrase));
                list.Add(AES.Encrypt(row["address"].ToString().Trim(), Properties.Resources.PassPhrase));
                list.Add(AES.Encrypt(row["emergency_name"].ToString().Trim(), Properties.Resources.PassPhrase));
                list.Add(AES.Encrypt(row["emergency_contact"].ToString().Trim(), Properties.Resources.PassPhrase));
                list.Add(AES.Encrypt(row["emergency_relation"].ToString().Trim(), Properties.Resources.PassPhrase));
                Update("inmate", "`code` = '" + list[1].ToString() + "', `first_name` = '" + list[2].ToString() + "', `middle_name` = '" + list[3].ToString() + "', `last_name` = '" + list[4].ToString() + "', `gender` = '" + list[5].ToString() + "', `eye_color` = '" + list[6].ToString() + "', `complexion` = '" + list[7].ToString() + "', `marital_status` = '" + list[8].ToString() + "', `address` = '" + list[9].ToString() + "', `emergency_name` = '" + list[10].ToString() + "', `emergency_contact` = '" + list[11].ToString() + "', `emergency_relation` = '" + list[12].ToString() + "'", Convert.ToInt32(list[0]));
                list = new ArrayList();
                inmate++;
            }
            
            dataSet = new DataSet();
            dataSet = Retrieve("SELECT `id`, `email`, `user_name`, `first_name`, `middle_name`, `last_name`, `dob`, `role`, `password`, `otp`, `date_created`, `gender` FROM `user`");
            foreach (DataRow row in dataSet.Tables["result"].Rows)
            {
                list.Add(Convert.ToInt32(row["id"]));
                list.Add(AES.Encrypt(row["email"].ToString().Trim(), Properties.Resources.PassPhrase));
                list.Add(AES.Encrypt(row["email"].ToString().Trim().Split('@')[0], Properties.Resources.PassPhrase));
                list.Add(AES.Encrypt(row["first_name"].ToString().Trim(), Properties.Resources.PassPhrase));
                list.Add(AES.Encrypt(row["middle_name"].ToString().Trim(), Properties.Resources.PassPhrase));
                list.Add(AES.Encrypt(row["last_name"].ToString().Trim(), Properties.Resources.PassPhrase));
                list.Add(AES.Encrypt("Password4you", Properties.Resources.PassPhrase));
                list.Add(AES.Encrypt(row["otp"].ToString().Trim(), Properties.Resources.PassPhrase));
                list.Add(AES.Encrypt(row["gender"].ToString().Trim(), Properties.Resources.PassPhrase));
                Update("user", "`email` = '" + list[1].ToString() + "', `user_name` = '" + list[2].ToString() + "', `first_name` = '" + list[3].ToString() + "', `middle_name` = '" + list[4].ToString() + "', `last_name` = '" + list[5].ToString() + "', `password` = '" + list[6].ToString() + "', `otp` = '" + list[7].ToString() + "', `gender` = '" + list[8].ToString() + "'", Convert.ToInt32(list[0]));
                list = new ArrayList();
            }
            
            dataSet = new DataSet();
            dataSet = Retrieve("SELECT `id`, `name`, `contact`, `relation`, `date_created`, `address` FROM `visitor`");
            foreach (DataRow row in dataSet.Tables["result"].Rows)
            {
                list.Add(Convert.ToInt32(row["id"]));
                list.Add(AES.Encrypt(row["name"].ToString().Trim(), Properties.Resources.PassPhrase));
                list.Add(AES.Encrypt(row["contact"].ToString().Trim(), Properties.Resources.PassPhrase));
                list.Add(AES.Encrypt(row["relation"].ToString().Trim(), Properties.Resources.PassPhrase));
                list.Add(AES.Encrypt(row["address"].ToString().Trim(), Properties.Resources.PassPhrase));
                Update("visitor", "`name` = '" + list[1].ToString() + "', `contact` = '" + list[2].ToString() + "', `relation` = '" + list[3].ToString() + "', `address` = '" + list[4].ToString() + "'", Convert.ToInt32(list[0]));
                list = new ArrayList();
            }

            dataSet = new DataSet();
            dataSet = Retrieve("SELECT `id`, `action`, `status`, `date`, `remarks`, `inmate_id` FROM `inmate_history`");
            foreach (DataRow row in dataSet.Tables["result"].Rows)
            {
                list.Add(Convert.ToInt32(row["id"]));
                list.Add(AES.Encrypt(row["action"].ToString().Trim(), Properties.Resources.PassPhrase));
                list.Add(AES.Encrypt(row["remarks"].ToString().Trim(), Properties.Resources.PassPhrase));
                Update("inmate_history", "`action` = '" + list[1].ToString() + "', `remarks` = '" + list[2].ToString() + "'", Convert.ToInt32(list[0]));
                list = new ArrayList();
            }
        }
    }
}
