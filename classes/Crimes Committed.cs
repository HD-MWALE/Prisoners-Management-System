﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prisoners_Management_System.classes
{
    public class Crimes_Committed
    {
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private int _CrimeId;
        public int CrimeId
        {
            get { return _CrimeId; }
            set { _CrimeId = value; }
        }

        private int _InmateId;
        public int InmateId
        {
            get { return _InmateId; }
            set { _InmateId = value; }
        }

        private ArrayList _Committed = new ArrayList();
        public ArrayList Committed
        {
            get { return _Committed; }
            set { _Committed = value; }
        }

        public Crimes_Committed()
        {
        }

        public Crimes_Committed(ArrayList committed)
        {
            Committed = committed;
        }

        public Crimes_Committed(int id, int crimeid, int inmateid, ArrayList committed)
        {
            Id = id;
            CrimeId=crimeid;
            InmateId = inmateid;
            Committed = committed;
        }
        public Crimes_Committed(int crimeid, int inmateid)
        {
            CrimeId = crimeid;
            InmateId = inmateid;
        }

        public Crimes_Committed(int id, int crimeid, int inmateid)
        {
            Id = id;
            CrimeId = crimeid;
            InmateId = inmateid;
        }

        private DataSet dataSet = new DataSet();

        public bool Save()
        {
            string fields = "`crime_id`, `inmate_id`";
            string data = CrimeId + "," + InmateId;
            if (database.Execute.Insert("crimes_committed", fields, data))
                return true;
            return false;
        }

        public int GetId(int crimeId, int inmateId)
        {
            (DataSet, string) response = database.Execute.Retrieve("SELECT `id` FROM crimes_committed");
            if (response.Item2 != null)
            {
                dataSet = response.Item1;
                if (dataSet != null)
                    foreach (DataRow dataRow in dataSet.Tables["result"].Rows)
                        if (CrimeId == crimeId && InmateId == inmateId)
                            return Convert.ToInt32(dataRow["id"]);
            }
            return 0;
        }

        public bool CheckCrimeCommitted(int crimeid, int inmateid)
        {
            string data = "`id`";
            string condition = "`crime_id` = " + crimeid + ", `inmate_id` = " + inmateid + "";
            (DataSet, string) response = database.Execute.Retrieve("SELECT " + data + " FROM crimes_committed, inmate WHERE " + condition);
            if (response.Item2 != "server-error")
            {
                dataSet = response.Item1;
                if (dataSet != null)
                    return true;
            }
            return false;
        }

        public DataSet GetAll()
        {
            (DataSet, string) response = database.Execute.Retrieve("SELECT crime.`id`, crime.`name`, crime.`type`, crime.`description`, crimes_committed.inmate_id FROM crime INNER JOIN crimes_committed ON crime.`id` = crimes_committed.`crime_id`");
            if (response.Item2 != "server-error")
            {
                dataSet = response.Item1;
                if (dataSet != null)
                {
                    foreach (DataRow row in response.Item1.Tables["result"].Rows)
                    {
                        // decrypting crime committed details
                        row["name"] = config.config.AES.Decrypt(row["name"].ToString(), Properties.Resources.PassPhrase);
                        row["description"] = config.config.AES.Decrypt(row["description"].ToString(), Properties.Resources.PassPhrase);
                    }
                    return dataSet;
                }
            }
            return null;
        }
        public ArrayList GetById(int id) 
        {
            dataSet = GetAll();
            if (dataSet != null)
            {
                foreach (DataRow dataRow in dataSet.Tables["result"].Rows)
                    Committed.Add(dataRow["name"]);
                return Committed;
            }
            return null;
        }

        public bool Update(int id)
        {
            string data = "`crime_id` = '" + CrimeId + "', `inmate_id` = " + InmateId;
            if (database.Execute.Update("crimes_committed", data, id))
                return true;
            return false;
        }
        public bool Delete(int id)
        {
            if (database.Execute.Delete("crimes_committed", id))
                return true;
            else
                return false;
        }
    }
}
