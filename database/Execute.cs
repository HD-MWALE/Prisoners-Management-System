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

namespace Roll_Call_And_Management_System.database 
{
    internal class Execute 
    {
        static bool IsSuccess;
        static DataSet dataSet = new DataSet();
        static Mysql Sql = new Mysql();
        //static Sqlite Sql = new Sqlite();
        static string Query = "";

        public static bool Insert(string table, string fields, string data)
        {
            if (Sql.Open())
            {
                Query = "INSERT INTO " + table + " (" + fields + ") VALUES (" + data + ")";
                if (Sql.ExecuteReader(Query) != null)
                    IsSuccess = true;
                else
                    IsSuccess = false;
                Sql.Close();
            }else
                return false;
            return IsSuccess;
        }

        public static (DataSet, string) Retrieve(string query) 
        {
            if (Sql.Open())
            {
                dataSet = Sql.ExecuteDataSet(query);
                Sql.Close();
            }
            else
                return (null, "server-error");
            return (dataSet, "true");
        }

        public static DataSet Find(string table, string data, string condition) 
        {
            Query = "SELECT " + data + " FROM " + table + " " + condition;
            if (Sql.Open())
            {
                dataSet = Sql.ExecuteDataSet(Query);
                Sql.Close();
            }
            dataSet = null;
            return dataSet;
        }

        public static DataTable ExecuteDataTable(string sql)
        { 
            if(Sql.Open())
                return Sql.ExecuteDataTable(sql);
            return null;
        }

        public static DataSet ExecuteDataSet(string sql) 
        {
            if (Sql.Open())
                return Sql.ExecuteDataSet(sql); 
            return null;
        }

        public static bool Update(string table, string data, int id)
        {
            Query = "UPDATE " + table + " SET " + data + " WHERE id = " + id;
            if (Sql.Open())
            {
                if (Sql.ExecuteReader(Query) != null)
                {
                    IsSuccess = true;
                }
                else
                    IsSuccess = false;
                Sql.Close();
            }
            else
                IsSuccess = false;
            return IsSuccess;
        }

        public static bool UndoDeleteFlag(string table, int id)  
        {
            if (Sql.Open())
                if (Sql.ExecuteReader("UPDATE " + table + " SET `delete_flag` = 1 WHERE id = " + id) != null)
                    IsSuccess = true;
                else
                    IsSuccess = false;
            else
                IsSuccess = false;
            Sql.Close();
            return IsSuccess;
        }

        public static bool DeleteFlag(string table, int id)
        {
            if (Sql.Open())
                if (Sql.ExecuteReader("UPDATE " + table + " SET `delete_flag` = 0 WHERE id = " + id) != null)
                    IsSuccess = true;
                else
                    IsSuccess = false;
            else
                IsSuccess = false;
            Sql.Close();
            return IsSuccess;
        }

        public static bool Delete(string table, int id)
        {
            Query = "DELETE FROM " + table + " WHERE id = " + id;
            if (Sql.Open())
            {
                if (Sql.ExecuteNonQuery(Query) != -1)
                {
                    IsSuccess = true;
                }
                else
                    IsSuccess = false;
                 Sql.Close();
            }
            else
                IsSuccess = false;
            return IsSuccess;
        }   
    }
}
