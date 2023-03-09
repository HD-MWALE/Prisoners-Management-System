using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Roll_Call_And_Management_System.classes
{
    public class Inmate_History
    {
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _Action;
        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }

        private int _Status;
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private DateTime _Date;
        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

        private string _Remarks;
        public string Remarks 
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }

        private int _InmateId;
        public int InmateId
        {
            get { return _InmateId; }
            set { _InmateId = value; }
        }

        private Inmate _Inmate;
        public Inmate Inmate
        {
            get { return _Inmate; }
            set { _Inmate = value; }
        }

        public DataSet dataSet = new DataSet();
        public ArrayList History = new ArrayList(); 
        public Inmate_History()
        {
        }

        public Inmate_History(string action, int status, DateTime date, string remarks, Inmate inmate)
        {
            Action = AES.Encrypt(action, Properties.Resources.PassPhrase);
            Status = status;
            Date = date;
            Remarks = AES.Encrypt(remarks, Properties.Resources.PassPhrase);
            Inmate = inmate;
        }
        public Inmate_History(string action, int status, DateTime date, string remarks, int inmateId) 
        {
            Action = AES.Encrypt(action, Properties.Resources.PassPhrase);
            Status = status;
            Date = Convert.ToDateTime(date.ToString("yyyy/MM/dd hh:mm:ss tt"));
            Remarks = AES.Encrypt(remarks, Properties.Resources.PassPhrase); 
            InmateId = inmateId; 
        }
        public bool Save()
        {
            string fields = "`action`, `status`, `date`, `remarks`, `inmate_id`";
            string data = "'" + Action + "', " + Status + ", '" + Date + "', '" + Remarks + "', " + InmateId;
            if (database.Execute.Insert(Properties.Resources.InmateHistoryTable, fields, data))
                return true;
            return false;
        }

        public int GetId(string action) 
        {
            dataSet = GetHistories(); 
            if (dataSet != null)
                foreach (DataRow dataRow in dataSet.Tables["result"].Rows)
                    if (AES.Decrypt(dataRow["action"].ToString(), Properties.Resources.PassPhrase) == action)
                        return Convert.ToInt32(dataRow["id"]);
            return 0;
        }

        public DataSet GetHistoriesByInmateId(int inmateid) 
        {
            (DataSet, string) response = database.Execute.Retrieve("SELECT `id`, `action`, `status`, `date`, `remarks`, `inmate_id` FROM " + Properties.Resources.InmateHistoryTable + " WHERE `inmate_id` = " + inmateid);
            if (response.Item2 != "server-error")
                return response.Item1;
            return null;
        }

        public DataSet GetHistories() 
        {
            (DataSet, string) response = database.Execute.Retrieve("SELECT `id`, `action`, `status`, `date`, `remarks`, `inmate_id` FROM " + Properties.Resources.InmateHistoryTable);
            if (response.Item2 != "server-error")
                return response.Item1;
            return null;
        }

        public ArrayList GetHistory(int id) 
        {
            dataSet = GetHistories();
            if (dataSet != null)
                foreach (DataRow row in dataSet.Tables["result"].Rows)
                    if (Convert.ToInt32(row["id"]) == id)
                    {
                        History.Add(row["id"]);
                        History.Add(row["action"]);
                        History.Add(row["status"]);
                        History.Add(row["date"]);
                        History.Add(row["remarks"]);
                        History.Add(row["inmate_id"]);
                        return History;
                    }
            return null;
        }

        public bool Update(int id)
        {
            string data = "`action` = '" + Action + "', `status` = " + Status + ", `date` = '" + Date + "', `remarks` = '" + Remarks + "', `inmate_id` = " + Inmate.Id;
            if (database.Execute.Update(Properties.Resources.InmateHistoryTable, data, id))
                return true;
            return false;
        }

        public bool Delete(int id)
        {
            if (database.Execute.Delete(Properties.Resources.InmateHistoryTable, id))
                return true;
            else
                return false;
        }
    }
}
