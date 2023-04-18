using DocumentFormat.OpenXml.Wordprocessing;
using Google.Protobuf.WellKnownTypes;
using Prisoners_Management_System.config;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prisoners_Management_System.classes
{
    public class Crime
    {
        // declaring crime type variable
        public enum CrimeType { Minor = 0, Major = 1, }
        // declaring private globe variables
        private int _Id;
        private string _Name;
        private string _Description;
        private CrimeType _Type;
        private ArrayList _Committed = new ArrayList();
        // get and set globe variables
        public int Id { get { return _Id; } set { _Id = value; } }
        public string Name { get { return _Name; } set { _Name = value; } }
        public string Description { get { return _Description; } set { _Description = value; } }
        public ArrayList Committed { get { return _Committed; } set { _Committed = value; } }
        public CrimeType Type { get { return _Type; } set { _Type = value; } }
         
        public Crime() { }

        public Crime(string name, CrimeType type, string description)
        {
            Name = config.config.AES.Encrypt(name, Properties.Resources.PassPhrase);
            Type = type;
            Description = config.config.AES.Encrypt(description, Properties.Resources.PassPhrase);
        }

        private DataSet dataSet = new DataSet();
        // save crime function
        public bool Save()
        {
            string fields = "`name`, `type`, `description`";
            string data = "'" + Name + "','" + Type + "','" + Description + "'";
            if (database.Execute.Insert("crime", fields, data))
                return true;
            return false;
        }
        // ckeck crime function
        public bool CheckCrime(string name) 
        {
            dataSet = GetCrimes();
            if (dataSet != null)
                foreach (DataRow dataRow in dataSet.Tables["result"].Rows)
                    if (config.config.AES.Decrypt(dataRow["name"].ToString(), Properties.Resources.PassPhrase) == name)
                        return true;
            return false;
        }
        // get id by crime name
        public int GetId(string name)
        {
            dataSet = GetCrimes();
            if (dataSet != null)
                foreach (DataRow dataRow in dataSet.Tables["result"].Rows)
                    if (config.config.AES.Decrypt(dataRow["name"].ToString(), Properties.Resources.PassPhrase) == name)
                        return Convert.ToInt32(dataRow["id"]);
            return 0;
        }
        // get crimes function
        public DataSet GetCrimes()
        {
            (DataSet, string) response = database.Execute.Retrieve("SELECT `id`, `name`, `type`, `description` FROM " + "crime");
            if(response.Item2 != "server-error")
                return response.Item1;
            return null;
        }
        // crime details by id function
        public ArrayList CrimeDetails(int id)  
        {
            dataSet = GetCrimes();
            if (dataSet != null)
                foreach (DataRow row in dataSet.Tables["result"].Rows)
                    if ((int)row["id"] == id)
                    {
                        Committed.Add(row["id"]);
                        Committed.Add(row["name"]);
                        Committed.Add(row["type"]);
                        Committed.Add(row["description"]);
                        return Committed;
                    }
            return null;
        }
        // update crime function
        public bool Update(int id)
        {
            string data = "`name` = '" + Name + "', `type` = '" + Type + "', `description` = '" + Description + "'";
            if (database.Execute.Update("crime", data, id))
                return true;
            return false;
        }
        // delete crime by id function
        public bool Delete(int id)
        {
            if (database.Execute.Delete("crime", id))
                return true;
            else
                return false;
        }
    }
}
