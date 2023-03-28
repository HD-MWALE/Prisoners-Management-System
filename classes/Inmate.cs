using DocumentFormat.OpenXml.Office2010.Excel;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Roll_Call_And_Management_System.views.components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Roll_Call_And_Management_System.classes
{
    public class Inmate
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

        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        private string _MiddleName;
        public string MiddleName
        {
            get { return _MiddleName; }
            set { _MiddleName = value; }
        }

        private string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        private string _Gender;
        public string Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }

        private string _DateOfBirth;
        public string DateOfBirth
        {
            get { return _DateOfBirth; }
            set { _DateOfBirth = value; }
        }

        private string _Address;
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        private string _MaritalStatus;
        public string MaritalStatus
        {
            get { return _MaritalStatus; }
            set { _MaritalStatus = value; }
        }

        private string _Complexion;
        public string Complexion
        {
            get { return _Complexion; }
            set { _Complexion = value; }
        }

        private string _EyeColour;
        public string EyeColour
        {
            get { return _EyeColour; }
            set { _EyeColour = value; }
        }

        private string _EmergencyName;
        public string EmergencyName
        {
            get { return _EmergencyName; }
            set { _EmergencyName = value; }
        }

        private string _EmergencyContact;
        public string EmergencyContact
        {
            get { return _EmergencyContact; }
            set { _EmergencyContact = value; }
        }

        private string _EmergencyRelation;
        public string EmergencyRelation
        {
            get { return _EmergencyRelation; }
            set { _EmergencyRelation = value; }
        }

        private int _VisitingPrivilege;
        public int VisitingPrivilege
        {
            get { return _VisitingPrivilege; }
            set { _VisitingPrivilege = value; }
        }

        private Crime _Crime;
        public Crime Crime
        {
            get { return _Crime; }
            set { _Crime = value; }
        }

        private Crimes_Committed _CrimesCommitted;
        public Crimes_Committed CrimesCommitted 
        {
            get { return _CrimesCommitted; }
            set { _CrimesCommitted = value; }
        } 

        private Sentence _Sentence;
        public Sentence Sentence 
        {
            get { return _Sentence; }
            set { _Sentence = value; }
        }

        private Dormitory _Dormitory;
        public Dormitory Dormitory
        {
            get { return _Dormitory; }
            set { _Dormitory = value; }
        }

        public Inmate() { }
        public Inmate(string code) 
        { 
            Code = code;
        }

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
            Code = AES.Encrypt(code, Properties.Resources.PassPhrase);
            FirstName = AES.Encrypt(firstName, Properties.Resources.PassPhrase);
            MiddleName = AES.Encrypt(middleName, Properties.Resources.PassPhrase);
            LastName = AES.Encrypt(lastName, Properties.Resources.PassPhrase);
            Gender = AES.Encrypt(gender, Properties.Resources.PassPhrase);
            DateOfBirth = dob.ToString("yyyy/MM/dd");
            Address = AES.Encrypt(address, Properties.Resources.PassPhrase);
            MaritalStatus = AES.Encrypt(maritalStatus, Properties.Resources.PassPhrase);
            EyeColour = AES.Encrypt(eyeColour, Properties.Resources.PassPhrase);
            Complexion = AES.Encrypt(complexion, Properties.Resources.PassPhrase);
            CrimesCommitted = crimeCommitted;
            EmergencyName = AES.Encrypt(emergencyName, Properties.Resources.PassPhrase);
            EmergencyContact = AES.Encrypt(emergencyContact, Properties.Resources.PassPhrase);
            EmergencyRelation = AES.Encrypt(emergencyRelation, Properties.Resources.PassPhrase);
            VisitingPrivilege = visitingPrivilege;
            Sentence = sentence;
            Dormitory = dormitory;
        }
        public Inmate(string code, Crimes_Committed crimeCommitted) 
        {
            Code = code;
            CrimesCommitted = crimeCommitted; 
        }
        public Inmate(int id)
        {
            Id = id;
        }

        public DataSet dataSet = new DataSet();
        public ArrayList arrayList = new ArrayList(); 
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
                    CrimesCommitted.InmateId = GetId(AES.Decrypt(Code, Properties.Resources.PassPhrase));
                    CrimesCommitted.Save();
                }
                Sentence.Save(GetId(AES.Decrypt(Code, Properties.Resources.PassPhrase)));
                return true; 
            }
            return false;
        }
        public int GetId(string code)
        {
            dataSet = GetInmates();
            if (dataSet != null)
                foreach (DataRow dataRow in dataSet.Tables["result"].Rows)
                    if (AES.Decrypt(dataRow["code"].ToString(), Properties.Resources.PassPhrase) == code)
                        return Convert.ToInt32(dataRow["id"]);

            return 0;
        }
        public DataSet GetInmates() 
        {
            string data = "inmate.`id`, inmate.`code`, inmate.`first_name`, inmate.`middle_name`, inmate.`last_name`, inmate.`gender`, inmate.`dob`, inmate.`dormitory_id`, inmate.`date_created`, inmate.`address`, inmate.`marital_status`, inmate.`eye_color`, inmate.`complexion`, inmate.`emergency_name`, inmate.`emergency_contact`, inmate.`emergency_relation`, inmate.`visiting_privilege`, sentence.`start_date`, sentence.`end_date`, sentence.`status`";
            (DataSet, string) response = database.Execute.Retrieve("SELECT " + data + " FROM inmate LEFT JOIN sentence ON inmate.id = sentence.inmate_id");
            if (response.Item2 != "server-error")
            {
                if (response.Item1 != null)
                    return response.Item1;
            }
            return null;
        }
        public ArrayList GetInmate(int id)   
        {
            dataSet = GetInmates();
            if (dataSet != null)
                foreach (DataRow dataRow in dataSet.Tables["result"].Rows)
                    if (Convert.ToInt32(dataRow["id"]) == id)
                    {
                        arrayList.Add(dataRow["code"]);
                        arrayList.Add(dataRow["last_name"]);
                        arrayList.Add(dataRow["first_name"]);
                        arrayList.Add(dataRow["middle_name"]);
                        return arrayList;
                    }

            return null;
        }

        public void SetVisitingPrivilege(int id, int Privilege)
        {
            string data = "`visiting_privilege` = " + Privilege;
            database.Execute.Update("inmate", data, id);
        }

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

        public bool Delete(int id)
        {
            if (database.Execute.Delete("inmate", id))
                return true;
            else
                return false;
        }
    }
}
