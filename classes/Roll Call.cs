using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.SqlServer.Dac.Model;
using Prisoners_Management_System.config;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Prisoners_Management_System.classes
{
    public class Roll_Call
    {
        // declaring private globe variables
        private int _Id;
        private string _Code;
        private int _Status;
        private int _DormitoryId;
        private int _InmateId;
        private Dormitory _Dormitory;
        private Inmate _Inmate;
        private DataSet dataSet = new DataSet();
        // get and set globe variables
        public int Id { get { return _Id; } set { _Id = value; } }
        public string Code { get { return _Code; } set { _Code = value; } }
        public int Status { get { return _Status; } set { _Status = value; } }
        public int DormitoryId { get { return _DormitoryId; } set { _DormitoryId = value; } }
        public int InmateId { get { return _InmateId; } set { _InmateId = value; } }
        public Dormitory Dormitory { get { return _Dormitory; } set { _Dormitory = value; } }
        public Inmate Inmate { get { return _Inmate; } set { _Inmate = value; } }
        ArrayList Warden; 
        public Roll_Call()
        {
        }
        // setting globe variables
        public Roll_Call(string code, int inmate_id, int status, string rollcall, ArrayList warden)  
        {
            Code = code;
            Status = status;
            InmateId = inmate_id;
            Warden = warden;
        }
        // setting globe variables
        public Roll_Call(string code, int status, int dormitory_id)
        {
            Code = code;
            Status = status;
            DormitoryId = dormitory_id;
        }
        // setting globe variables
        public Roll_Call(int id, string code, int status, int dormitory_id)
        {
            Id = id;
            Code = code;
            Status = status;
            DormitoryId = dormitory_id;
        }
        // save roll call
        public DataSet Save()
        {
            Inmate = new Inmate();
            string fields = "`code`, `dormitory_id`, `total_inmates`, `status`";
            string data = "'" + Code + "'," + DormitoryId + ", " + Inmate.Count(DormitoryId) + ", 'Status'";
            if (database.Execute.Insert("roll_call", fields, data))
                return GetRollCall();
            return null;
        }
        // save inmate on roll call
        public bool SaveInmate() 
        {
            Inmate = new Inmate();
            if(Status == 0)
                if (config.config.Internet.IsInternetConnectionAvailable())
                {
                    DataSet set = Inmate.GetInmates();
                    config.config.Internet.RollCallFeedBack((Code, set, InmateId), Warden[1].ToString());
                } 
            string fields = "`inmate_id`, `roll_call_id`, `status`";
            string data = InmateId + "," + GetId(Code) + ", '" + Status + "'";
            if (database.Execute.Insert("roll_calloninmate", fields, data))
                return true; 
            return false;
        }
        // get id by roll call code
        public int GetId(string code) 
        {
            string data = "`id`";
            string Condition = "`code` = '" + code + "'"; 
            (DataSet, string) response = database.Execute.Retrieve("SELECT " + data + " FROM roll_call WHERE " + Condition);
            if (response.Item2 != "server-error")
            {
                dataSet = response.Item1;
                if (dataSet != null)
                    foreach(DataRow row in dataSet.Tables["result"].Rows)
                        return Convert.ToInt32(row["id"]);
            }
            return 0;
        }
        // get roll call by code
        public DataSet GetRollCall()
        {
            string data = "`id`, `code`, `dormitory_id`, `total_inmates`, `status`, `date_created`";
            string Condition = "`code` = '" + Code + "'";
            (DataSet, string) response = database.Execute.Retrieve("SELECT " + data + " FROM roll_call WHERE " + Condition);
            if (response.Item2 != "server-error")
            {
                dataSet = response.Item1;
                if (dataSet != null)
                    return dataSet;
            }
            return null;
        }
        // get feedback
        public DataSet GetFeedBack() 
        {
            string data = "inmate.id, inmate.code, inmate.first_name, inmate.middle_name, inmate.last_name, inmate.gender, inmate.dob, inmate.dormitory_id, inmate.date_created, inmate.address, inmate.marital_status, inmate.eye_color, inmate.complexion, inmate.emergency_name, inmate.emergency_contact, inmate.emergency_relation, inmate.visiting_privilege, rollcall.status";
            string Condition = "rollcall.inmate_id =  inmate.id";
            (DataSet, string) response = database.Execute.Retrieve("SELECT " + data + " FROM inmate, roll_calloninmate rollcall WHERE " + Condition);
            if (response.Item2 != "server-error")
            {
                dataSet = response.Item1;
                if (dataSet != null)
                    return dataSet;
            }
            return null;
        }
        // get roll call details by code
        public DataSet GetDetails(string code)   
        {
            string data = "`id`,  `code`, `first_name`, `middle_name`, `last_name`, `gender`, `dob`, `dormitory_id`, `date_created`, `address`, `marital_status`, `eye_color`, `complexion`, `emergency_name`, `emergency_contact`, `emergency_relation`, `visiting_privilege`";
            string Condition = "rollcall.`inmate_id` =  `id` AND rollcall.`roll_call_id` = " + GetId(code) + "  Limit 25"; 
            (DataSet, string) response = database.Execute.Retrieve("SELECT " + data + " FROM inmate, roll_calloninmate rollcall WHERE " + Condition);
            if (response.Item2 != "server-error")
            {
                dataSet = response.Item1;
                if (dataSet != null)
                    return dataSet;
            }
            return null;
        }
        // get all roll calls
        public DataSet GetRollCalls() 
        {
            string data = "`id`, `code`, `dormitory_id`, `total_inmates`, `status`, `date_created`";
            (DataSet, string) response = database.Execute.Retrieve("SELECT " + data + " FROM roll_call Limit 25");
            if (response.Item2 != "server-error")
            {
                dataSet = response.Item1;
                if (dataSet != null)
                    return dataSet;
            }
            return null;
        }
        // get roll call details by id
        public DataSet GetRollCallDetails(int id) 
        {
            string data = "`id`, `code`, `dormitory_id`, `total_inmates`, `status`, `date_created`";
            (DataSet, string) response = database.Execute.Retrieve("SELECT " + data + " FROM `roll_call` WHERE `id` = " + id);
            if (response.Item2 != "server-error")
            {
                dataSet = response.Item1;
                if (dataSet != null)
                    return dataSet;
            }
            return null;
        }
        // update roll call
        public bool Update(int id)
        {
            return false;
        }
        // delete roll call 
        public bool Delete(int id)
        {
            if (database.Execute.Delete("roll_call", id))
                return true;
            else
                return false;
        }
    }
}
