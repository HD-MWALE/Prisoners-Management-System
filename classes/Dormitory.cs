using Roll_Call_And_Management_System.config;
using Roll_Call_And_Management_System.views.components;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roll_Call_And_Management_System.classes
{
    public class Dormitory
    {
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _Code;
        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
        }
         
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        private string _GenderType;
        public string GenderType
        {
            get { return _GenderType; }
            set { _GenderType = value; }
        }

        private string _Type;
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        public Dormitory()
        {
        }
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
            Name = ini.AES.Encrypt(name, Properties.Resources.PassPhrase);
            Description = ini.AES.Encrypt(description, Properties.Resources.PassPhrase);
            GenderType = ini.AES.Encrypt(genderType, Properties.Resources.PassPhrase);
            Type = ini.AES.Encrypt(type, Properties.Resources.PassPhrase);
        }

        public string[,] DormitoryList;
        public DataSet dataSet = new DataSet();
        public bool Save()
        {
            string fields = "`name`, `description`, `gendertype`, `type`";
            string data = "'" + Name + "', '" + Description + "', '" + GenderType + "', '" + Type + "'";
            if (database.Execute.Insert("dormitory", fields, data))
                return true;
            return false;
        }

        public bool CheckDormitory(string name) 
        {
            dataSet = GetDormitories();
            if (dataSet != null)
                foreach (DataRow dataRow in dataSet.Tables["result"].Rows)
                    if (ini.AES.Decrypt(dataRow["name"].ToString(), Properties.Resources.PassPhrase) == name)
                        return true;
            return false;
        }

        public int GetId(string name)
        {
            dataSet = GetDormitories();
            if (dataSet != null)
                foreach (DataRow dataRow in dataSet.Tables["result"].Rows)
                    if (ini.AES.Decrypt((string)dataRow["name"], Properties.Resources.PassPhrase) == name)
                        return Convert.ToInt32(dataRow["id"]);
            return 0;
        }
        public string GetName(int id) 
        {
            dataSet = GetDormitories();
            if (dataSet != null)
                foreach (DataRow dataRow in dataSet.Tables["result"].Rows)
                    if ((int)dataRow["id"] == id)
                        return dataRow["name"].ToString();
            return "-";
        }
        public DataSet GetDormitories() 
        {
            string data = "`id`, `name`, `description`, `gendertype`, `type`";
            (DataSet, string) response = database.Execute.Retrieve("SELECT " + data + " FROM " + "dormitory" + " ORDER BY `id`");
            if (response.Item2 != "server-error")
            {
                dataSet = response.Item1;
                if (dataSet != null)
                    return dataSet;
            }
            return null;
        }

        public DataSet GetDormitoryDetails(int id) 
        {
            string data = "`id`, `name`, `description`, `gendertype`, `type`";
            string condition = "`id` = " + id;
            (DataSet, string) response = database.Execute.Retrieve("SELECT " + data + " FROM dormitory WHERE " + condition);
            if (response.Item2 != "server-error")
            {
                dataSet = response.Item1;
                if (dataSet != null)
                    return dataSet;
            }
            return null;
        }
        
        public bool Update(int id)
        {
            string data = "`name` = '" + Name + "', `description` = '" + Description + "', `gendertype` = '" + GenderType + "', `type` = '" + Type + "'";
            if (database.Execute.Update("dormitory", data, id))
                return true;
            return false;
        }
        public bool Delete(int id)
        {
            if (database.Execute.Delete("dormitory", id))
                return true;
            else
                return false;
        }
    }
}
