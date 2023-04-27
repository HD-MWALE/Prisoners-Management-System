using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Security.Cryptography;

namespace Prisoners_Management_System.database 
{
    internal class Execute 
    {
        // declaring and initializing globe variables
        static bool IsSuccess = false;
        static DataSet dataSet = new DataSet();
        static Mysql Mysql = new Mysql();
        static string Query = "";
        // insert query to mysql database
        public static bool Insert(string table, string fields, string data)
        {
            if (Mysql.Open())
            {
                Query = "INSERT INTO " + table + " (" + fields + ") VALUES (" + data + ")";
                if (Mysql.ExecuteReader(Query) != null)
                    IsSuccess = true;
                else
                    IsSuccess = false;
                Mysql.Close();
            }else
                return false;
            return IsSuccess;
        }
        // insert query to mysql database
        public static bool InsertRollCall(string table, string fields, string data) 
        {
            if (Mysql.Open())
            {
                Query = "INSERT INTO " + table + " (" + fields + ") VALUES " + data;
                if (Mysql.ExecuteReader(Query) != null)
                    IsSuccess = true;
                else
                    IsSuccess = false;
                Mysql.Close();
            }
            else
                return false;
            return IsSuccess;
        }
        // retrieve query from mysql database
        public static (DataSet, string) Retrieve(string query) 
        {
            if (Mysql.Open())
            {
                dataSet = Mysql.ExecuteDataSet(query);
                Mysql.Close();
            }
            else
                return (null, "server-error");
            return (dataSet, "true");
        }
        // retrieve query from mysql database
        public static DataSet Find(string table, string data, string condition) 
        {
            Query = "SELECT " + data + " FROM " + table + " " + condition;
            if (Mysql.Open())
            {
                dataSet = Mysql.ExecuteDataSet(Query);
                Mysql.Close();
            }
            dataSet = null;
            return dataSet;
        }
        // retrieve query from mysql database return a datatable
        public static DataTable ExecuteDataTable(string sql)
        { 
            if(Mysql.Open())
                return Mysql.ExecuteDataTable(sql);
            return null;
        }
        // retrieve query from mysql database return a dataset
        public static DataSet ExecuteDataSet(string sql) 
        {
            if (Mysql.Open())
                return Mysql.ExecuteDataSet(sql); 
            return null;
        }
        // update query to mysql database
        public static bool Update(string table, string data, int id)
        {
            Query = "UPDATE " + table + " SET " + data + " WHERE id = " + id;
            if (Mysql.Open())
            {
                if (Mysql.ExecuteReader(Query) != null)
                {
                    IsSuccess = true;
                }
                else
                    IsSuccess = false;
                Mysql.Close();
            }
            else
                IsSuccess = false;
            return IsSuccess;
        }
        // Undo delete query
        public static bool UndoDeleteFlag(string table, int id)  
        {
            if (Mysql.Open())
                if (Mysql.ExecuteReader("UPDATE " + table + " SET `delete_flag` = 1 WHERE id = " + id) != null)
                    IsSuccess = true;
                else
                    IsSuccess = false;
            else
                IsSuccess = false;
            Mysql.Close();
            return IsSuccess;
        }
        // delete query from mysql database
        public static bool DeleteFlag(string table, int id)
        {
            if (Mysql.Open())
                if (Mysql.ExecuteReader("UPDATE " + table + " SET `delete_flag` = 0 WHERE id = " + id) != null)
                    IsSuccess = true;
                else
                    IsSuccess = false;
            else
                IsSuccess = false;
            Mysql.Close();
            return IsSuccess;
        }
        // delete query from mysql database
        public static bool Delete(string table, int id)
        {
            Query = "DELETE FROM " + table + " WHERE id = " + id;
            if (Mysql.Open())
            {
                if (Mysql.ExecuteNonQuery(Query) != -1)
                {
                    IsSuccess = true;
                }
                else
                    IsSuccess = false;
                 Mysql.Close();
            }
            else
                IsSuccess = false;
            return IsSuccess;
        }   
    }
}
