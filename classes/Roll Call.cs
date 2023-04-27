using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.SqlServer.Dac.Model;
using Prisoners_Management_System.config;
using Prisoners_Management_System.views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        public Roll_Call(string code, ArrayList warden)  
        {
            Code = code;
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
        public bool SaveInmate(FlowLayoutPanel flowLayoutPanelScanned, FlowLayoutPanel flowLayoutPanelRemaining)  
        {
            Inmate = new Inmate();
            string fields = "`inmate_id`, `roll_call_id`, `status`";
            bool IsFirst = true;
            string data = "";
            Id = GetId(Code);
            foreach (views.components.facial.sub.inmate control in flowLayoutPanelScanned.Controls)
            {
                if (IsFirst)
                {
                    data = "(" + Inmate.GetId(control.Name) + "," + _Id + ", 1)";
                    IsFirst = false;
                }
                else
                {
                    data += ",(" + Inmate.GetId(control.Name) + "," + _Id + ", 1)";
                }
            }
            foreach (views.components.facial.sub.inmate control in flowLayoutPanelRemaining.Controls)
            {
                if (IsFirst)
                {
                    data = "(" + Inmate.GetId(control.Name) + "," + _Id + ", 0)";
                    IsFirst = false;
                }
                else
                {
                    data += ",(" + Inmate.GetId(control.Name) + "," + _Id + ", 0)";
                }
                if (config.config.Internet.IsInternetConnectionAvailable())
                {
                    DataSet set = Inmate.GetInmates(Inmate.GetId(control.Name));
                    if(set != null)
                        config.config.Internet.RollCallFeedBack((Code, set), Warden[1].ToString());
                }
            }
            if (config.config.Internet.IsInternetConnectionAvailable() && flowLayoutPanelRemaining.Controls.Count == 0)
                config.config.Internet.FeedBack(Code, Warden[1].ToString());
            if (database.Execute.InsertMore("roll_calloninmate", fields, data))
                return true; 
            return false;
        }
        // save feedback
        public void SaveFeedback(int inmate_id, int roll_call_id, int roll_call_inmate_id) 
        {
            Inmate = new Inmate();
            string fields = "`inmate_id`, `roll_call_id`";
            string data = inmate_id + "," + roll_call_id;
            database.Execute.Insert("feedbacks", fields, data);
            fields = "status = 1";
            database.Execute.Update("roll_calloninmate", fields, roll_call_inmate_id); 
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
            string Condition = "`code` = '" + Code + "' order by date_created DESC";
            (DataSet, string) response = database.Execute.Retrieve("SELECT " + data + " FROM roll_call WHERE " + Condition);
            if (response.Item2 != "server-error")
            {
                dataSet = response.Item1;
                if (dataSet != null)
                    return dataSet;
            }
            return null;
        }
        public int CheckFeedBack() 
        {
            string Condition = "roll_calloninmate.status = 0";
            (DataSet, string) response = database.Execute.Retrieve("SELECT roll_calloninmate.status FROM inmate INNER JOIN roll_calloninmate ON inmate.id = roll_calloninmate.inmate_id WHERE " + Condition);
            if(response.Item1 != null)
                return response.Item1.Tables["result"].Rows.Count;
            return 0;
        }
        // get feedback
        public DataSet GetFeedBack() 
        {
            string data = "inmate.id, inmate.code, inmate.first_name, inmate.middle_name, inmate.last_name, inmate.gender, inmate.dob, inmate.dormitory_id, inmate.date_created, inmate.address, inmate.marital_status, inmate.eye_color, inmate.complexion, inmate.emergency_name, inmate.emergency_contact, inmate.emergency_relation, inmate.visiting_privilege, roll_calloninmate.id AS roll_call_inmate_id, roll_calloninmate.roll_call_id, roll_calloninmate.status, roll_calloninmate.date_created";
            string Condition = "roll_calloninmate.status = 0 ORDER BY roll_calloninmate.date_created";
            (DataSet, string) response = database.Execute.Retrieve("SELECT " + data + " FROM inmate INNER JOIN roll_calloninmate ON inmate.id = roll_calloninmate.inmate_id WHERE " + Condition);
            if (response.Item2 != "server-error")
            {
                dataSet = response.Item1;
                if (dataSet != null)
                {
                    foreach (DataRow row in response.Item1.Tables["result"].Rows)
                    {
                        // decrypting roll call details
                        row["code"] = config.config.AES.Decrypt(row["code"].ToString(), Properties.Resources.PassPhrase);
                        row["first_name"] = config.config.AES.Decrypt(row["first_name"].ToString(), Properties.Resources.PassPhrase);
                        row["middle_name"] = config.config.AES.Decrypt(row["middle_name"].ToString(), Properties.Resources.PassPhrase);
                        row["last_name"] = config.config.AES.Decrypt(row["last_name"].ToString(), Properties.Resources.PassPhrase);
                        row["gender"] = config.config.AES.Decrypt(row["gender"].ToString(), Properties.Resources.PassPhrase);
                        row["address"] = config.config.AES.Decrypt(row["address"].ToString(), Properties.Resources.PassPhrase);
                        row["marital_status"] = config.config.AES.Decrypt(row["marital_status"].ToString(), Properties.Resources.PassPhrase);
                        row["eye_color"] = config.config.AES.Decrypt(row["eye_color"].ToString(), Properties.Resources.PassPhrase);
                        row["complexion"] = config.config.AES.Decrypt(row["complexion"].ToString(), Properties.Resources.PassPhrase);
                        row["emergency_name"] = config.config.AES.Decrypt(row["emergency_name"].ToString(), Properties.Resources.PassPhrase);
                        row["emergency_contact"] = config.config.AES.Decrypt(row["emergency_contact"].ToString(), Properties.Resources.PassPhrase);
                        row["emergency_relation"] = config.config.AES.Decrypt(row["emergency_relation"].ToString(), Properties.Resources.PassPhrase);
                    }
                    return dataSet;
                }
            }
            return null;
        }
        // get all feedback dataset
        public DataSet GetFeedBacks() 
        {
            string data = "inmate.id, inmate.code, inmate.first_name, inmate.middle_name, inmate.last_name, inmate.gender, inmate.dob, inmate.dormitory_id, inmate.date_created, inmate.address, inmate.marital_status, inmate.eye_color, inmate.complexion, inmate.emergency_name, inmate.emergency_contact, inmate.emergency_relation, inmate.visiting_privilege, roll_calloninmate.id AS roll_call_inmate_id, roll_calloninmate.roll_call_id, roll_calloninmate.status, roll_calloninmate.date_created";
            string Condition = "ORDER BY roll_calloninmate.date_created Desc";
            (DataSet, string) response = database.Execute.Retrieve("SELECT " + data + " FROM inmate INNER JOIN feedbacks ON feedbacks.inmate_id = inmate.id INNER JOIN roll_calloninmate ON feedbacks.roll_call_id = roll_calloninmate.id " + Condition);
            if (response.Item2 != "server-error")
            {
                dataSet = response.Item1;
                if (dataSet != null)
                {
                    foreach (DataRow row in response.Item1.Tables["result"].Rows)
                    {
                        // decrypting roll call details
                        row["code"] = config.config.AES.Decrypt(row["code"].ToString(), Properties.Resources.PassPhrase);
                        row["first_name"] = config.config.AES.Decrypt(row["first_name"].ToString(), Properties.Resources.PassPhrase);
                        row["middle_name"] = config.config.AES.Decrypt(row["middle_name"].ToString(), Properties.Resources.PassPhrase);
                        row["last_name"] = config.config.AES.Decrypt(row["last_name"].ToString(), Properties.Resources.PassPhrase);
                        row["gender"] = config.config.AES.Decrypt(row["gender"].ToString(), Properties.Resources.PassPhrase);
                        row["address"] = config.config.AES.Decrypt(row["address"].ToString(), Properties.Resources.PassPhrase);
                        row["marital_status"] = config.config.AES.Decrypt(row["marital_status"].ToString(), Properties.Resources.PassPhrase);
                        row["eye_color"] = config.config.AES.Decrypt(row["eye_color"].ToString(), Properties.Resources.PassPhrase);
                        row["complexion"] = config.config.AES.Decrypt(row["complexion"].ToString(), Properties.Resources.PassPhrase);
                        row["emergency_name"] = config.config.AES.Decrypt(row["emergency_name"].ToString(), Properties.Resources.PassPhrase);
                        row["emergency_contact"] = config.config.AES.Decrypt(row["emergency_contact"].ToString(), Properties.Resources.PassPhrase);
                        row["emergency_relation"] = config.config.AES.Decrypt(row["emergency_relation"].ToString(), Properties.Resources.PassPhrase);
                    }
                    return dataSet;
                }
            }
            return null;
        }
        // get roll call details by code
        public DataSet GetDetails(string code)   
        {
            string data = "inmate.`id`,  inmate.`code`, inmate.`first_name`, inmate.`middle_name`, inmate.`last_name`, inmate.`gender`, inmate.`dob`, inmate.`dormitory_id`, inmate.`date_created`, inmate.`address`, inmate.`marital_status`, inmate.`eye_color`, inmate.`complexion`, inmate.`emergency_name`, inmate.`emergency_contact`, inmate.`emergency_relation`, inmate.`visiting_privilege`, sentence.`start_date`, sentence.`end_date`, sentence.`status`";
            string Condition = "roll_calloninmate.`roll_call_id` = " + GetId(code) + " order by inmate.date_created DESC"; 
            (DataSet, string) response = database.Execute.Retrieve("SELECT " + data + " FROM sentence INNER JOIN inmate ON inmate.id = sentence.inmate_id INNER JOIN roll_calloninmate ON roll_calloninmate.`inmate_id` =  inmate.`id` WHERE " + Condition);
            if (response.Item2 != "server-error")
            {
                if (response.Item1 != null)
                {
                    foreach (DataRow row in response.Item1.Tables["result"].Rows)
                    {
                        // decrypting roll call details
                        row["code"] = config.config.AES.Decrypt(row["code"].ToString(), Properties.Resources.PassPhrase);
                        row["first_name"] = config.config.AES.Decrypt(row["first_name"].ToString(), Properties.Resources.PassPhrase);
                        row["middle_name"] = config.config.AES.Decrypt(row["middle_name"].ToString(), Properties.Resources.PassPhrase);
                        row["last_name"] = config.config.AES.Decrypt(row["last_name"].ToString(), Properties.Resources.PassPhrase);
                        row["gender"] = config.config.AES.Decrypt(row["gender"].ToString(), Properties.Resources.PassPhrase);
                        row["address"] = config.config.AES.Decrypt(row["address"].ToString(), Properties.Resources.PassPhrase);
                        row["marital_status"] = config.config.AES.Decrypt(row["marital_status"].ToString(), Properties.Resources.PassPhrase);
                        row["eye_color"] = config.config.AES.Decrypt(row["eye_color"].ToString(), Properties.Resources.PassPhrase);
                        row["complexion"] = config.config.AES.Decrypt(row["complexion"].ToString(), Properties.Resources.PassPhrase);
                        row["emergency_name"] = config.config.AES.Decrypt(row["emergency_name"].ToString(), Properties.Resources.PassPhrase);
                        row["emergency_contact"] = config.config.AES.Decrypt(row["emergency_contact"].ToString(), Properties.Resources.PassPhrase);
                        row["emergency_relation"] = config.config.AES.Decrypt(row["emergency_relation"].ToString(), Properties.Resources.PassPhrase);
                    }
                    return response.Item1;
                }
            }
            return null;
        }
        // get all roll calls
        public DataSet GetRollCalls() 
        {
            string data = "roll_call.`id`, roll_call.`code`, roll_call.`dormitory_id`, roll_call.`total_inmates`, roll_call.`status`, roll_call.`date_created`, dormitory.name, dormitory.gendertype";
            (DataSet, string) response = database.Execute.Retrieve("SELECT " + data + " FROM roll_call INNER JOIN dormitory ON dormitory.id = roll_call.dormitory_id order by roll_call.date_created DESC;");
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
