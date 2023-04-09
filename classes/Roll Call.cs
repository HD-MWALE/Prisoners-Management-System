using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.SqlServer.Dac.Model;
using Roll_Call_And_Management_System.config;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Roll_Call_And_Management_System.classes
{
    public class Roll_Call
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
        private int _Status;
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        private int _DormitoryId;
        public int DormitoryId
        {
            get { return _DormitoryId; }
            set { _DormitoryId = value; }
        }
        private int _InmateId;
        public int InmateId 
        {
            get { return _InmateId; }
            set { _InmateId = value; }
        }
        private Dormitory _Dormitory;
        public Dormitory Dormitory
        {
            get { return _Dormitory; }
            set { _Dormitory = value; }
        }
        private Inmate _Inmate;
        public Inmate Inmate
        {
            get { return _Inmate; }
            set { _Inmate = value; }
        }
        ArrayList Warden; 
        public Roll_Call()
        {
        }
        public Roll_Call(string code, int inmate_id, int status, string rollcall, ArrayList warden)  
        {
            Code = code;
            Status = status;
            InmateId = inmate_id;
            Warden = warden;
        }
        public Roll_Call(string code, int status, int dormitory_id)
        {
            Code = code;
            Status = status;
            DormitoryId = dormitory_id;
        }
        public Roll_Call(int id, string code, int status, int dormitory_id)
        {
            Id = id;
            Code = code;
            Status = status;
            DormitoryId = dormitory_id;
        }
        public DataSet dataSet = new DataSet();
        public DataSet Save()
        {
            Inmate = new Inmate();
            string fields = "`code`, `dormitory_id`, `total_inmates`, `status`";
            string data = "'" + Code + "'," + DormitoryId + ", " + Inmate.Count(DormitoryId) + ", 'Status'";
            if (database.Execute.Insert("roll_call", fields, data))
                return GetRollCall();
            return null;
        }
        public bool SaveInmate() 
        {
            Inmate = new Inmate();
            if(Status == 0)
                if (ini.Internet.IsInternetConnectionAvailable())
                {
                    DataSet set = Inmate.GetInmates();
                    ini.Internet.RollCallEmail((Code, set, InmateId), Warden[1].ToString());
                } 
            string fields = "`inmate_id`, `roll_call_id`, `status`";
            string data = InmateId + "," + GetId(Code) + ", '" + Status + "'";
            if (database.Execute.Insert("roll_calloninmate", fields, data))
                return true; 
            return false;
        }
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
        public bool Update(int id)
        {
            return false;
        }
        public bool Delete(int id)
        {
            if (database.Execute.Delete("roll_call", id))
                return true;
            else
                return false;
        }
    }
}
