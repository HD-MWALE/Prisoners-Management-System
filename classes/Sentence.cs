using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Prisoners_Management_System.classes
{
    public class Sentence
    {
        // declaring private globe variables
        private int _Id;
        private DateTime _StartDate;
        private DateTime _EndDate;
        private int _Status;
        private DataSet dataSet = new DataSet();
        // get and set globe variables
        public int Id { get { return _Id; } set { _Id = value; } }
        public DateTime StartDate { get { return _StartDate; } set { _StartDate = value; } }
        public DateTime EndDate { get { return _EndDate; } set { _EndDate = value; } }
        public int Status { get { return _Status; } set { _Status = value; } }
        // setting globe variables
        public Sentence(DateTime startDate, DateTime endDate, int status)
        {
            _StartDate = startDate; ;
            _EndDate = endDate;;
            Status = status;
        }
        public Sentence()
        {

        }
        // save inmate sentence
        public bool Save(int inmateid)
        {
            string fields = "`start_date`, `end_date`, `status`, `inmate_id`";
            string data = "'" + StartDate.ToString("yyyy/MM/dd hh:mm:ss tt") + "','" + EndDate.ToString("yyyy/MM/dd hh:mm:ss tt") + "', 1," + inmateid;
            if (database.Execute.Insert("sentence", fields, data))
                return true;
            return false;
        }
        // get all sentences
        public DataSet GetSentences()
        {
            string data = "*";
            (DataSet, string) response = database.Execute.Retrieve("SELECT " + data + " FROM sentence");
            if (response.Item2 != "server-error")
            {
                dataSet = response.Item1;
                if (dataSet != null)
                    return dataSet;
            }
            return null;
        }
        // get sentence id by inmate id
        public int GetId(int inmateid)
        {
            string data = "`id`";
            string condition = " `inmate_id` = " + inmateid + " LIMIT 1;";
            (DataSet, string) response = database.Execute.Retrieve("SELECT " + data + " FROM sentence WHERE " + condition);
            if (response.Item2 != "server-error")
            {
                dataSet = response.Item1;
                if (dataSet != null)
                    foreach (DataRow dataRow in dataSet.Tables["result"].Rows)
                        return Convert.ToInt32(dataRow["id"]);
            }
            return 0;
        }
        // get sentence details by id
        public DataSet GetSentenceDetails(int id) 
        {
            string data = "`id`, `name`, `type`";
            (DataSet, string) response = database.Execute.Retrieve("SELECT " + data + " FROM sentence WHERE `id` = " + id);
            if (response.Item2 != "server-error")
            {
                dataSet = response.Item1;
                if (dataSet != null)
                    return dataSet;
            }
            return null;
        }
        // update sentence
        public bool Update(int inmateid)
        {
            string data = "`start_date` = '" + StartDate + "', `end_date` = '" + EndDate + "', `status` = " + Status;
            if (database.Execute.Update("sentence", data, GetId(inmateid)))
                return true;
            return false;
        }
        // delete sentence
        public bool Delete(int id)
        {
            if (database.Execute.Delete("sentence", id))
                return true;
            else
                return false;
        }
    }
}
