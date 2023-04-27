using DocumentFormat.OpenXml.Office2010.Excel;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Prisoners_Management_System.config;
using Prisoners_Management_System.views.components;
using SQLitePCL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static Prisoners_Management_System.classes.Crime;

namespace Prisoners_Management_System.classes
{
    public class Inmate
    {
        // declaring private globe variables
        private int _Id;
        private string _Code;
        private string _FirstName;
        private string _MiddleName;
        private string _LastName;
        private string _Gender;
        private string _DateOfBirth;
        private string _Address;
        private string _MaritalStatus;
        private string _Complexion;
        private string _EyeColour;
        private string _EmergencyName;
        private string _EmergencyContact; 
        private string _EmergencyRelation;
        private int _VisitingPrivilege;
        private Crime _Crime;
        private Crimes_Committed _CrimesCommitted;
        private Sentence _Sentence;
        private Dormitory _Dormitory;
        private DataSet dataSet = new DataSet();
        public ArrayList arrayList = new ArrayList();
        // get and set globe variables
        public int Id { get { return _Id; } set { _Id = value; } }
        public string Code { get { return _Code; } set { _Code = value; } }
        public string FirstName { get { return _FirstName; } set { _FirstName = value; } }
        public string MiddleName { get { return _MiddleName; } set { _MiddleName = value; } }
        public string LastName { get { return _LastName; } set { _LastName = value; } }
        public string Gender { get { return _Gender; } set { _Gender = value; } }
        public string DateOfBirth { get { return _DateOfBirth; } set { _DateOfBirth = value; } }
        public string Address { get { return _Address; } set { _Address = value; } }
        public string MaritalStatus { get { return _MaritalStatus; } set { _MaritalStatus = value; } }
        public string Complexion { get { return _Complexion; } set { _Complexion = value; } }
        public string EyeColour { get { return _EyeColour; } set { _EyeColour = value; } }
        public string EmergencyName { get { return _EmergencyName; } set { _EmergencyName = value; } }
        public string EmergencyContact { get { return _EmergencyContact; } set { _EmergencyContact = value; } }
        public string EmergencyRelation { get { return _EmergencyRelation; } set { _EmergencyRelation = value; } }
        public int VisitingPrivilege { get { return _VisitingPrivilege; } set { _VisitingPrivilege = value; } }
        public Crime Crime { get { return _Crime; } set { _Crime = value; } }
        public Crimes_Committed CrimesCommitted { get { return _CrimesCommitted; } set { _CrimesCommitted = value; } }
        public Sentence Sentence { get { return _Sentence; } set { _Sentence = value; } }
        public Dormitory Dormitory { get { return _Dormitory; } set { _Dormitory = value; } }
        
        public Inmate() { }
        // setting inmate code variable 
        public Inmate(string code) 
        { 
            Code = code;
        }
        // setting globe valiables
        public Inmate(int id, string code,
                       string firstName,
                       string middleName,
                       string lastName,
                       string gender,
                       DateTime dob,
                       string address,
                       string maritalStatus,
                       string eyeColour,
                       string complexion,
                       Crimes_Committed crimeCommitted, 
                       string emergencyName,
                       string emergencyContact,
                       string emergencyRelation,
                       int visitingPrivilege,
                       Sentence sentence, Dormitory dormitory)
        {
            Id = id;
            Code = config.config.AES.Encrypt(code, Properties.Resources.PassPhrase);
            FirstName = config.config.AES.Encrypt(firstName, Properties.Resources.PassPhrase);
            MiddleName = config.config.AES.Encrypt(middleName, Properties.Resources.PassPhrase);
            LastName = config.config.AES.Encrypt(lastName, Properties.Resources.PassPhrase);
            Gender = config.config.AES.Encrypt(gender, Properties.Resources.PassPhrase);
            DateOfBirth = dob.ToString("yyyy/MM/dd");
            Address = config.config.AES.Encrypt(address, Properties.Resources.PassPhrase);
            MaritalStatus = config.config.AES.Encrypt(maritalStatus, Properties.Resources.PassPhrase);
            EyeColour = config.config.AES.Encrypt(eyeColour, Properties.Resources.PassPhrase);
            Complexion = config.config.AES.Encrypt(complexion, Properties.Resources.PassPhrase);
            CrimesCommitted = crimeCommitted;
            EmergencyName = config.config.AES.Encrypt(emergencyName, Properties.Resources.PassPhrase);
            EmergencyContact = config.config.AES.Encrypt(emergencyContact, Properties.Resources.PassPhrase);
            EmergencyRelation = config.config.AES.Encrypt(emergencyRelation, Properties.Resources.PassPhrase);
            VisitingPrivilege = visitingPrivilege;
            Sentence = sentence;
            Dormitory = dormitory;
        }
        // setting inmate code and crimes committed variables
        public Inmate(string code, Crimes_Committed crimeCommitted) 
        {
            Code = code;
            CrimesCommitted = crimeCommitted; 
        }
        // setting id variable
        public Inmate(int id)
        {
            Id = id;
        }
        // save inmate details
        public bool Save()
        {
            string fields = "`code`, `first_name`, `middle_name`, `last_name`, `gender`, `dob`, `dormitory_id`, `address`, `marital_status`, `eye_color`, `complexion`, `emergency_name`, `emergency_contact`, `emergency_relation`, `visiting_privilege`";
            string data = "'" + Code + "','" + FirstName + "','" + MiddleName + "','" + LastName + "','" + Gender + "','" + DateOfBirth + "'," + Dormitory.GetId(Dormitory.Name) + ",'" + Address + "','" + MaritalStatus + "','" + EyeColour + "','" + Complexion + "','" + EmergencyName + "','" + EmergencyContact + "','" + EmergencyRelation + "'," + VisitingPrivilege;
            if (database.Execute.Insert("inmate", fields, data))
            {
                Crime = new Crime();
                foreach (string crime in CrimesCommitted.Committed)
                {
                    CrimesCommitted.CrimeId = Crime.GetId(crime);
                    CrimesCommitted.InmateId = GetId(config.config.AES.Decrypt(Code, Properties.Resources.PassPhrase));
                    CrimesCommitted.Save();
                }
                Sentence.Save(GetId(config.config.AES.Decrypt(Code, Properties.Resources.PassPhrase)));
                return true; 
            }
            return false;
        }
        // get id by inmate code
        public int GetId(string code)
        {
            dataSet = GetInmates();
            if (dataSet != null)
            {
                var dataRows = dataSet.Tables["result"].AsEnumerable()
                    .Where(row => row.Field<String>("code").Contains(code));
                foreach (DataRow dataRow in dataRows)
                    return Convert.ToInt32(dataRow["id"]);
            }
            return 0;
        }
        // get all inmates
        public DataSet GetInmates()
        {
            string data = "inmate.`id`, inmate.`code`, inmate.`first_name`, inmate.`middle_name`, inmate.`last_name`, inmate.`gender`, inmate.`dob`, inmate.`dormitory_id`, inmate.`date_created`, inmate.`address`, inmate.`marital_status`, inmate.`eye_color`, inmate.`complexion`, inmate.`emergency_name`, inmate.`emergency_contact`, inmate.`emergency_relation`, inmate.`visiting_privilege`, sentence.`start_date`, sentence.`end_date`, sentence.`status`";
            (DataSet, string) response = database.Execute.Retrieve("SELECT " + data + " FROM inmate LEFT JOIN sentence ON inmate.id = sentence.inmate_id order by inmate.date_created");
            if (response.Item2 != "server-error")
            {
                if (response.Item1 != null)
                {
                    foreach (DataRow row in response.Item1.Tables["result"].Rows)
                    {
                        // decrypting inmate details
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
        // get inmate by id
        public DataSet GetInmates(int id) 
        {
            string data = "inmate.`id`, inmate.`code`, inmate.`first_name`, inmate.`middle_name`, inmate.`last_name`, inmate.`gender`, inmate.`dob`, inmate.`dormitory_id`, inmate.`date_created`, inmate.`address`, inmate.`marital_status`, inmate.`eye_color`, inmate.`complexion`, inmate.`emergency_name`, inmate.`emergency_contact`, inmate.`emergency_relation`, inmate.`visiting_privilege`, sentence.`start_date`, sentence.`end_date`, sentence.`status`";
            (DataSet, string) response = database.Execute.Retrieve("SELECT " + data + " FROM inmate LEFT JOIN sentence ON inmate.id = sentence.inmate_id WHERE inmate.id = " + id + " order by inmate.date_created");
            if (response.Item2 != "server-error")
            {
                if (response.Item1 != null)
                {
                    foreach (DataRow row in response.Item1.Tables["result"].Rows)
                    {
                        // decrypting inmate details
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
        // get all inmates for a dormitory
        public DataSet GetInmates(string name)
        {
            _Dormitory = new Dormitory();
            string data = "inmate.`id`, inmate.`code`, inmate.`first_name`, inmate.`middle_name`, inmate.`last_name`, inmate.`gender`, inmate.`dob`, inmate.`dormitory_id`, inmate.`date_created`, inmate.`address`, inmate.`marital_status`, inmate.`eye_color`, inmate.`complexion`, inmate.`emergency_name`, inmate.`emergency_contact`, inmate.`emergency_relation`, inmate.`visiting_privilege`, sentence.`start_date`, sentence.`end_date`, sentence.`status`, dormitory.name";
            (DataSet, string) response = database.Execute.Retrieve("SELECT " + data + " FROM dormitory INNER JOIN inmate ON dormitory.id = inmate.dormitory_id INNER JOIN sentence ON inmate.id = sentence.inmate_id WHERE inmate.dormitory_id = " + _Dormitory.GetId(name));
            if (response.Item2 != "server-error")
            {
                if (response.Item1 != null)
                {
                    foreach (DataRow row in response.Item1.Tables["result"].Rows)
                    {
                        // decrypting inmate details
                        row["code"] = config.config.AES.Decrypt(row["code"].ToString(), Properties.Resources.PassPhrase);
                        row["first_name"] = config.config.AES.Decrypt(row["first_name"].ToString(), Properties.Resources.PassPhrase);
                        row["middle_name"] = config.config.AES.Decrypt(row["middle_name"].ToString(), Properties.Resources.PassPhrase);
                        row["last_name"] = config.config.AES.Decrypt(row["last_name"].ToString(), Properties.Resources.PassPhrase);
                        row["gender"] = config.config.AES.Decrypt(row["gender"].ToString(), Properties.Resources.PassPhrase);
                        row["address"] = config.config.AES.Decrypt(row["address"].ToString(), Properties.Resources.PassPhrase);
                        row["marital_status"] = config.config.AES.Decrypt(row["marital_status"].ToString(), Properties.Resources.PassPhrase);
                    }
                    return response.Item1;
                }
            }
            return null;
        }

        public DataTable GetInmates(DataSet crimes)
        {
            string data = "inmate.`id`, inmate.`code`, inmate.`first_name`, inmate.`middle_name`, inmate.`last_name`, inmate.`gender`, inmate.`dob`, inmate.`dormitory_id`, inmate.`date_created`, inmate.`address`, inmate.`marital_status`, inmate.`eye_color`, inmate.`complexion`, inmate.`emergency_name`, inmate.`emergency_contact`, inmate.`emergency_relation`, inmate.`visiting_privilege`, sentence.`start_date`, sentence.`end_date`, sentence.`status`, dormitory.name";
            (DataSet, string) response = database.Execute.Retrieve("SELECT " + data + " FROM dormitory INNER JOIN inmate ON dormitory.id = inmate.dormitory_id INNER JOIN sentence ON inmate.id = sentence.inmate_id");
            if (response.Item2 != "server-error")
            {
                if (response.Item1 != null)
                {
                    var dataSet = response.Item1.Tables["result"].Clone();

                    foreach (DataRow currentRow in response.Item1.Tables["result"].Rows)
                    {
                        var dataRows = crimes.Tables["result"].AsEnumerable()
                            .Where(row =>
                                row.Field<int>("inmate_id") == Convert.ToInt32(currentRow["id"])
                            );
                        var dataRows2 = dataRows.AsEnumerable() 
                            .Where(row =>
                                row.Field<String>("type") == CrimeType.Major.ToString()
                            );
                        if (dataRows2.AsEnumerable().Count() == 0)
                        {
                            // decrypting inmate details
                            currentRow["code"] = config.config.AES.Decrypt(currentRow["code"].ToString(), Properties.Resources.PassPhrase);
                            currentRow["first_name"] = config.config.AES.Decrypt(currentRow["first_name"].ToString(), Properties.Resources.PassPhrase);
                            currentRow["middle_name"] = config.config.AES.Decrypt(currentRow["middle_name"].ToString(), Properties.Resources.PassPhrase);
                            currentRow["last_name"] = config.config.AES.Decrypt(currentRow["last_name"].ToString(), Properties.Resources.PassPhrase);
                            currentRow["gender"] = config.config.AES.Decrypt(currentRow["gender"].ToString(), Properties.Resources.PassPhrase);
                            currentRow["address"] = config.config.AES.Decrypt(currentRow["address"].ToString(), Properties.Resources.PassPhrase);
                            currentRow["marital_status"] = config.config.AES.Decrypt(currentRow["marital_status"].ToString(), Properties.Resources.PassPhrase);
                            dataSet.ImportRow(currentRow);
                        }
                    }
                    return dataSet;
                }
            }
            return null;
        }
        // get inmate by id
        public ArrayList GetInmate(int id)   
        {
            dataSet = GetInmates();
            if (dataSet != null)
            {
                var dataRows = dataSet.Tables["result"].AsEnumerable()
                   .Where(row => row.Field<String>("id").Contains(id.ToString()));
                foreach (DataRow dataRow in dataRows)
                {
                    arrayList.Add(dataRow["code"]);
                    arrayList.Add(dataRow["last_name"]);
                    arrayList.Add(dataRow["first_name"]);
                    arrayList.Add(dataRow["middle_name"]);
                    return arrayList;
                }
            }

            return null;
        }
        // update inmate visiting privilege
        public void SetVisitingPrivilege(int id, int Privilege)
        {
            string data = "`visiting_privilege` = " + Privilege;
            database.Execute.Update("inmate", data, id);
        }
        // count inmates in dormitory by id
        public int Count(int dormitoryid)
        {
            dataSet = GetInmates();
            int count = 0;
            if (dataSet != null)
                foreach (DataRow row in dataSet.Tables["result"].Rows)
                    if (Convert.ToInt32(row["dormitory_id"]) == dormitoryid)
                        count++;
            return count;
        }
        // update inmate details by id
        public bool Update(int id)
        {
            string data = "`first_name` = '" + FirstName + "', `middle_name` = '" + MiddleName + "', `last_name` = '" + LastName + "', `gender` = '" + Gender + "', `dob` = '" + DateOfBirth + "', `address` = '" + Address + "', `marital_status` = '" + MaritalStatus + "', `eye_color` = '" + EyeColour + "', `complexion` = '" + Complexion + "', `emergency_name` = '" + EmergencyName + "', `emergency_contact` = '" + EmergencyContact + "', `emergency_relation` = '" + EmergencyRelation + "', `visiting_privilege` = " + VisitingPrivilege;
            if (database.Execute.Update("inmate", data, id))
            {
                Sentence.Update(id); 
                Crime = new Crime();
                foreach (string crime in CrimesCommitted.Committed)
                    if(!CrimesCommitted.CheckCrimeCommitted(Crime.GetId(crime), id))
                    {
                        CrimesCommitted.CrimeId = Crime.GetId(crime);
                        CrimesCommitted.InmateId = id;
                        CrimesCommitted.Save();
                    }
                return true;
            }
            else
                return false;
        }
        // delete inmate by id
        public bool Delete(int id)
        {
            if (database.Execute.Delete("inmate", id))
                return true;
            else
                return false;
        }
    }
}
