using DocumentFormat.OpenXml.Wordprocessing;
using Google.Protobuf.WellKnownTypes;
using Roll_Call_And_Management_System.config;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roll_Call_And_Management_System.classes
{
    public class Crime
    {
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
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

        public enum CrimeType
        {
            Minor = 0, 
            Major = 1, 
        }
        private CrimeType _Type;
        public CrimeType Type 
        {
            get { return _Type; }
            set { _Type = value; }
        }

        private ArrayList _Committed = new ArrayList();
        public ArrayList Committed
        {
            get { return _Committed; }
            set { _Committed = value; }
        }

        public Crime()
        {
        }

        public Crime(string name, CrimeType type, string description)
        {
            Name = ini.AES.Encrypt(name, Properties.Resources.PassPhrase);
            Type = type;
            Description = ini.AES.Encrypt(description, Properties.Resources.PassPhrase);
        }

        public DataSet dataSet = new DataSet();
       
        public bool Save()
        {
            string fields = "`name`, `type`, `description`";
            string data = "'" + Name + "','" + Type + "','" + Description + "'";
            if (database.Execute.Insert("crime", fields, data))
                return true;
            return false;
        }

        public bool CheckCrime(string name) 
        {
            dataSet = GetCrimes();
            if (dataSet != null)
                foreach (DataRow dataRow in dataSet.Tables["result"].Rows)
                    if (ini.AES.Decrypt(dataRow["name"].ToString(), Properties.Resources.PassPhrase) == name)
                        return true;
            return false;
        }

        public int GetId(string name)
        {
            dataSet = GetCrimes();
            if (dataSet != null)
                foreach (DataRow dataRow in dataSet.Tables["result"].Rows)
                    if (ini.AES.Decrypt(dataRow["name"].ToString(), Properties.Resources.PassPhrase) == name)
                        return Convert.ToInt32(dataRow["id"]);
            return 0;
        }

        public DataSet GetCrimes()
        {
            (DataSet, string) response = database.Execute.Retrieve("SELECT `id`, `name`, `type`, `description` FROM " + "crime");
            if(response.Item2 != "server-error")
                return response.Item1;
            return null;
        }

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

        public bool Update(int id)
        {
            string data = "`name` = '" + Name + "', `type` = '" + Type + "', `description` = '" + Description + "'";
            if (database.Execute.Update("crime", data, id))
                return true;
            return false;
        }

        public bool Delete(int id)
        {
            if (database.Execute.Delete("crime", id))
                return true;
            else
                return false;
        }
    }
}
