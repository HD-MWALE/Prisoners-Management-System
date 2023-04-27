using DocumentFormat.OpenXml.Wordprocessing;
using Prisoners_Management_System.config;
using Prisoners_Management_System.views.components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Prisoners_Management_System.classes
{
    public class Inmate_History
    {
        // declaring private globe variables
        private int _Id;
        private string _Action;
        private int _Status;
        private DateTime _Date;
        private string _Remarks;
        private int _InmateId;
        private Inmate _Inmate;
        private DataSet dataSet = new DataSet();
        public ArrayList History = new ArrayList();
        // get and set globe variables
        public int Id { get { return _Id; } set { _Id = value; } }
        public string Action { get { return _Action; } set { _Action = value; } }
        public int Status { get { return _Status; } set { _Status = value; } }
        public DateTime Date { get { return _Date; } set { _Date = value; } }
        public string Remarks { get { return _Remarks; } set { _Remarks = value; } }
        public int InmateId { get { return _InmateId; } set { _InmateId = value; } }
        public Inmate Inmate { get { return _Inmate; } set { _Inmate = value; } }

        public Inmate_History() { }

        public Inmate_History(string action, int status, DateTime date, string remarks, Inmate inmate)
        {
            Action = config.config.AES.Encrypt(action, Properties.Resources.PassPhrase);
            Status = status;
            Date = date;
            Remarks = config.config.AES.Encrypt(remarks, Properties.Resources.PassPhrase);
            Inmate = inmate;
        }
        public Inmate_History(string action, int status, DateTime date, string remarks, int inmateId) 
        {
            Action = config.config.AES.Encrypt(action, Properties.Resources.PassPhrase);
            Status = status;
            Date = Convert.ToDateTime(date.ToString("yyyy/MM/dd hh:mm:ss tt"));
            Remarks = config.config.AES.Encrypt(remarks, Properties.Resources.PassPhrase); 
            InmateId = inmateId; 
        }
        // save inmate history function
        public bool Save()
        {
            string fields = "`action`, `status`, `date`, `remarks`, `inmate_id`";
            string data = "'" + Action + "', " + Status + ", '" + Date + "', '" + Remarks + "', " + InmateId;
            if (database.Execute.Insert("inmate_history", fields, data))
                return true;
            return false;
        }
        // get id by action function
        public int GetId(string action) 
        {
            dataSet = GetHistories(); 
            if (dataSet != null)
                foreach (DataRow dataRow in dataSet.Tables["result"].Rows)
                    if (config.config.AES.Decrypt(dataRow["action"].ToString(), Properties.Resources.PassPhrase) == action)
                        return Convert.ToInt32(dataRow["id"]);
            return 0;
        }
        // get inmate history by inmate id function
        public DataSet GetHistoriesByInmateId(int inmateid) 
        {
            (DataSet, string) response = database.Execute.Retrieve("SELECT `id`, `action`, `status`, `date`, `remarks`, `inmate_id` FROM inmate_history WHERE `inmate_id` = " + inmateid);
            if (response.Item2 != "server-error")
            {
                foreach (DataRow row in response.Item1.Tables["result"].Rows)
                {
                    // decrypting inmate history details
                    row["action"] = config.config.AES.Decrypt(row["action"].ToString(), Properties.Resources.PassPhrase);
                    row["remarks"] = config.config.AES.Decrypt(row["remarks"].ToString(), Properties.Resources.PassPhrase);
                }
                return response.Item1;
            }
            return null;
        }
        // get inmate history function
        public DataSet GetHistories() 
        {
            (DataSet, string) response = database.Execute.Retrieve("SELECT `id`, `action`, `status`, `date`, `remarks`, `inmate_id` FROM inmate_history");
            if (response.Item2 != "server-error")
            {
                foreach (DataRow row in response.Item1.Tables["result"].Rows)
                {
                    // decrypting inmate history details
                    row["action"] = config.config.AES.Decrypt(row["action"].ToString(), Properties.Resources.PassPhrase);
                    row["remarks"] = config.config.AES.Decrypt(row["remarks"].ToString(), Properties.Resources.PassPhrase);
                }
                return response.Item1;
            }
            return null;
        }
        // get inmate history by id function
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
        // update inmate history by id
        public bool Update(int id)
        {
            string data = "`action` = '" + Action + "', `status` = " + Status + ", `date` = '" + Date + "', `remarks` = '" + Remarks + "', `inmate_id` = " + Inmate.Id;
            if (database.Execute.Update("inmate_history", data, id))
                return true;
            return false;
        }
        // delete inmate history by id
        public bool Delete(int id)
        {
            if (database.Execute.Delete("inmate_history", id))
                return true;
            else
                return false;
        }
    }
}
