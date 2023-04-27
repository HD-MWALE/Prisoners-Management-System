using Prisoners_Management_System.config;
using Prisoners_Management_System.views.components;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prisoners_Management_System.classes
{
    public class Dormitory
    {
        // declaring private globe variables
        private int _Id;
        private string _Code;
        private string _Name;
        private string _Description;
        private string _GenderType;
        private string _Type;
        // get and set globe variables
        public int Id { get { return _Id; } set { _Id = value; } }
        public string Code { get { return _Code; } set { _Code = value; } }
        public string Name { get { return _Name; } set { _Name = value; } }
        public string Description { get { return _Description; } set { _Description = value; } }
        public string GenderType { get { return _GenderType; } set { _GenderType = value; } }
        public string Type { get { return _Type; } set { _Type = value; } }

        public Dormitory() { }
        public Dormitory(int id)
        {
            Id = id;
        }
        public Dormitory(string name) 
        {
            Name = name;
        }
        public Dormitory(string name, string description, string genderType, string type)
        {
            Name = config.config.AES.Encrypt(name, Properties.Resources.PassPhrase);
            Description = config.config.AES.Encrypt(description, Properties.Resources.PassPhrase);
            GenderType = config.config.AES.Encrypt(genderType, Properties.Resources.PassPhrase);
            Type = config.config.AES.Encrypt(type, Properties.Resources.PassPhrase);
        }

        public string[,] DormitoryList;
        private DataSet dataSet = new DataSet();
        // save dormitory function
        public bool Save()
        {
            string fields = "`name`, `description`, `gendertype`, `type`";
            string data = "'" + Name + "', '" + Description + "', '" + GenderType + "', '" + Type + "'";
            if (database.Execute.Insert("dormitory", fields, data))
                return true;
            return false;
        }
        // check dormitory by name function
        public bool CheckDormitory(string name) 
        {
            dataSet = GetDormitories();
            if (dataSet != null)
                foreach (DataRow dataRow in dataSet.Tables["result"].Rows)
                    if (config.config.AES.Decrypt(dataRow["name"].ToString(), Properties.Resources.PassPhrase) == name)
                        return true;
            return false;
        }
        // get id by dormitory name function
        public int GetId(string name)
        {
            dataSet = GetDormitories();
            if (dataSet != null)
                foreach (DataRow dataRow in dataSet.Tables["result"].Rows)
                    if (config.config.AES.Decrypt((string)dataRow["name"], Properties.Resources.PassPhrase) == name)
                        return Convert.ToInt32(dataRow["id"]);
            return 0;
        }
        // get name by id function
        public string GetName(int id) 
        {
            dataSet = GetDormitories();
            if (dataSet != null)
                foreach (DataRow dataRow in dataSet.Tables["result"].Rows)
                    if ((int)dataRow["id"] == id)
                        return dataRow["name"].ToString();
            return "-";
        }
        // get dormitories function
        public DataSet GetDormitories() 
        {
            string data = "`id`, `name`, `description`, `gendertype`, `type`";
            (DataSet, string) response = database.Execute.Retrieve("SELECT " + data + " FROM " + "dormitory" + " ORDER BY `id`");
            if (response.Item2 != "server-error")
            {
                dataSet = response.Item1;
                if (dataSet != null)
                {
                    foreach (DataRow row in response.Item1.Tables["result"].Rows)
                    {
                        // decrypting dormitory details
                        row["name"] = config.config.AES.Decrypt(row["name"].ToString(), Properties.Resources.PassPhrase);
                        row["description"] = config.config.AES.Decrypt(row["description"].ToString(), Properties.Resources.PassPhrase);
                        row["gendertype"] = config.config.AES.Decrypt(row["gendertype"].ToString(), Properties.Resources.PassPhrase);
                        row["type"] = config.config.AES.Decrypt(row["type"].ToString(), Properties.Resources.PassPhrase);
                    }
                    return dataSet;
                }
            }
            return null;
        }
        // get dormitory details by id function
        public DataSet GetDormitoryDetails(int id) 
        {
            string data = "`id`, `name`, `description`, `gendertype`, `type`";
            string condition = "`id` = " + id;
            (DataSet, string) response = database.Execute.Retrieve("SELECT " + data + " FROM dormitory WHERE " + condition);
            if (response.Item2 != "server-error")
            {
                dataSet = response.Item1;
                if (dataSet != null)
                {
                    foreach (DataRow row in response.Item1.Tables["result"].Rows)
                    {
                        // decrypting dormitory details
                        row["name"] = config.config.AES.Decrypt(row["name"].ToString(), Properties.Resources.PassPhrase);
                        row["description"] = config.config.AES.Decrypt(row["description"].ToString(), Properties.Resources.PassPhrase);
                        row["gendertype"] = config.config.AES.Decrypt(row["gendertype"].ToString(), Properties.Resources.PassPhrase);
                        row["type"] = config.config.AES.Decrypt(row["type"].ToString(), Properties.Resources.PassPhrase);
                    }
                    return dataSet;
                }
            }
            return null;
        }
        // update dormitory by id function
        public bool Update(int id)
        {
            string data = "`name` = '" + Name + "', `description` = '" + Description + "', `gendertype` = '" + GenderType + "', `type` = '" + Type + "'";
            if (database.Execute.Update("dormitory", data, id))
                return true;
            return false;
        }
        // delete dormitory by id function
        public bool Delete(int id)
        {
            if (database.Execute.Delete("dormitory", id))
                return true;
            else
                return false;
        }
    }
}
