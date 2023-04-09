using Bunifu.Core;
using DocumentFormat.OpenXml.Office2010.Excel;
using Google.Protobuf.WellKnownTypes;
using Org.BouncyCastle.Ocsp;
using Org.BouncyCastle.Security;
using Roll_Call_And_Management_System.config;
using Roll_Call_And_Management_System.views;
using Roll_Call_And_Management_System.views.components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Roll_Call_And_Management_System.classes
{
    public class User
    {
        public enum UserRole
        {
            Admin = 1,
            Guard = 2
        }

        private int _Id;
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        private string _Email;
        public string Email 
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set
            { _FirstName = value; }
        }

        private string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        private string _MiddleName;
        public string MiddleName
        {
            get { return _MiddleName; }
            set { _MiddleName = value; }
        }

        private UserRole _Role;
        public UserRole Role
        {
            get { return _Role; }
            set { _Role = value; }
        }

        private string _Gender;
        public string Gender 
        {
            get { return _Gender; }
            set { _Gender = value; }
        }

        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        private string _OTP;
        public string OTP 
        {
            get { return _OTP; }
            set { _OTP = value; }
        }

        private string _DateOfBirth;
        public string DateOfBirth
        {
            get { return _DateOfBirth; }
            set { _DateOfBirth = value; }
        }

        public User() { }
        public User(string username, string password) 
        {
            UserName = username;
            Email = username;
            Password = password;
        }
        public User(int id, string email, string username, string firstname, string middlename, string lastname, string gender, DateTime dob)
        {
            Id = id;
            Email = ini.AES.Encrypt(email, Properties.Resources.PassPhrase);
            UserName = ini.AES.Encrypt(username, Properties.Resources.PassPhrase);
            FirstName = ini.AES.Encrypt(firstname, Properties.Resources.PassPhrase);
            LastName = ini.AES.Encrypt(lastname, Properties.Resources.PassPhrase);
            MiddleName = ini.AES.Encrypt(middlename, Properties.Resources.PassPhrase);
            Gender = ini.AES.Encrypt(gender, Properties.Resources.PassPhrase);
            DateOfBirth = dob.ToString("yyyy/MM/dd");
        }
        public User(string email, string username, string firstname, string middlename, string lastname, string gender, DateTime dob, UserRole role)
        {
            Email = ini.AES.Encrypt(email, Properties.Resources.PassPhrase);
            UserName = ini.AES.Encrypt(username, Properties.Resources.PassPhrase);
            FirstName = ini.AES.Encrypt(firstname, Properties.Resources.PassPhrase);
            LastName = ini.AES.Encrypt(lastname, Properties.Resources.PassPhrase);
            MiddleName = ini.AES.Encrypt(middlename, Properties.Resources.PassPhrase);
            Gender = ini.AES.Encrypt(gender, Properties.Resources.PassPhrase);
            Role = role;
            Password = ini.AES.Encrypt("otp", Properties.Resources.PassPhrase);
            OTP = ini.AES.Encrypt(ini.Generate.Random.Next(100000, 999999).ToString(), Properties.Resources.PassPhrase);
            DateOfBirth = dob.ToString("yyyy/MM/dd");
        }
        public User(string username)
        {
            UserName = username;
            Password = ini.AES.Encrypt("otp", Properties.Resources.PassPhrase);
            OTP = ini.AES.Encrypt(ini.Generate.Random.Next(100000, 999999).ToString(), Properties.Resources.PassPhrase);
        }
        //public string[,] List;
        public DataSet dataSet = new DataSet();
        public ArrayList Auth = new ArrayList();

        public (bool, bool) Save()
        {
            if (ini.Internet.IsInternetConnectionAvailable())
            {
                string fields = "`email`, `user_name`, `first_name`, `middle_name`, `last_name`, `gender`, `dob`, `role`, `password`, `otp`";
                string data = "'" + Email + "', '" + UserName + "', '" + FirstName + "', '" + MiddleName + "', '" + LastName + "', '" + Gender + "', '" + DateOfBirth + "', '" + Role + "', '" + Password + "', '" + OTP + "'";

                if (database.Execute.Insert("user", fields, data))
                {
                    ini.Internet.Email((ini.AES.Decrypt(UserName, Properties.Resources.PassPhrase), ini.AES.Decrypt(OTP, Properties.Resources.PassPhrase)), ini.AES.Decrypt(Email, Properties.Resources.PassPhrase));
                    return (true, true);
                }
                return (false, true);
            }
            return (false, false);
        }
        public (bool, bool) ForgotPassword() 
        {
            if (ini.Internet.IsInternetConnectionAvailable())
            {
                string data = "`password` = '" + Password + "', `otp` = '" + OTP + "'";
                if (database.Execute.Update("user", data, GetId(UserName)))
                {
                    ini.Internet.Email((UserName, ini.AES.Decrypt(OTP, Properties.Resources.PassPhrase)), Email);
                    return (true, true);
                }
                return (false, true);
            }
            return (false, false);
        }
        public (DataSet, string) GetUsers() 
        {
            string fields = "`id`, `email`, `user_name`, `first_name`, `middle_name`, `last_name`, `gender`, `dob`, `role`";
            return database.Execute.Retrieve("SELECT " + fields + " FROM user");
        }
        public int GetId(string username) 
        {
            (DataSet, string) response = GetUsers();
            if (response.Item1 != null)
            {
                foreach (DataRow data in response.Item1.Tables["result"].Rows)
                    if (ini.AES.Decrypt(Convert.ToString(data["user_name"]), Properties.Resources.PassPhrase) == username)
                    {
                        Email = ini.AES.Decrypt(Convert.ToString(data["email"]), Properties.Resources.PassPhrase);
                        return Convert.ToInt32(data["id"]);
                    }
            }
            return 0;
        }
        public DataSet GetUserDetails(int id) 
        {
            dataSet = GetUsers().Item1;
            if (dataSet != null)
                foreach (DataRow dataRow in dataSet.Tables["result"].Rows)
                    if (Convert.ToInt32(dataRow["id"]) == id)
                    {
                        return dataSet;
                    }
            return null;
        }
        public (ArrayList, string) Login()
        {
            string fields = "`id`, `email`, `user_name`, `first_name`, `last_name`, `middle_name`, `gender`, `dob`, `role`, `password`, `otp`";
            (DataSet, string) responce = database.Execute.Retrieve("SELECT " + fields + " FROM user");
            if (responce.Item2 != "server-error")
            {
                dataSet = responce.Item1;
                if (dataSet != null)
                {
                    foreach (DataRow dataRow in dataSet.Tables["result"].Rows)
                    {
                        Auth = new ArrayList();
                        if (UserName == ini.AES.Decrypt((string)dataRow["user_name"], Properties.Resources.PassPhrase)
                            || Email == ini.AES.Decrypt((string)dataRow["email"], Properties.Resources.PassPhrase))
                        {
                            Auth.Add(dataRow["id"]);
                            Auth.Add(ini.AES.Decrypt((string)dataRow["email"], Properties.Resources.PassPhrase));
                            Auth.Add(ini.AES.Decrypt((string)dataRow["user_name"], Properties.Resources.PassPhrase));
                            Auth.Add(ini.AES.Decrypt((string)dataRow["first_name"], Properties.Resources.PassPhrase));
                            Auth.Add(ini.AES.Decrypt((string)dataRow["last_name"], Properties.Resources.PassPhrase));
                            Auth.Add(ini.AES.Decrypt((string)dataRow["middle_name"], Properties.Resources.PassPhrase));
                            Auth.Add(ini.AES.Decrypt((string)dataRow["gender"], Properties.Resources.PassPhrase));
                            Auth.Add(Convert.ToDateTime(dataRow["dob"]).ToString("dd/MM/yyyy"));
                            Auth.Add((string)dataRow["role"]);
                            Auth.Add(ini.AES.Decrypt((string)dataRow["password"], Properties.Resources.PassPhrase));
                            Auth.Add(ini.AES.Decrypt((string)dataRow["otp"], Properties.Resources.PassPhrase));
                            if (ini.AES.Decrypt((string)dataRow["password"], Properties.Resources.PassPhrase) == Password)
                                Auth.Add("regular");
                            else if (ini.AES.Decrypt((string)dataRow["otp"], Properties.Resources.PassPhrase) == Password)
                                Auth.Add("new");
                            else
                                Auth = null;
                            break;
                        }
                        Auth = null;
                    }
                }
                else
                    Auth = null;
            }
            else
            {
                return (Auth, responce.Item2);
            }
            return (Auth, "login");
        }
        public bool ChangePassword(ArrayList Auth, string password)
        {
            string data = "`otp` = '" + ini.AES.Encrypt("otp", Properties.Resources.PassPhrase) + "', `password` = '" + ini.AES.Encrypt(password, Properties.Resources.PassPhrase) + "'";
            if (database.Execute.Update("user", data, (int)Auth[0]))
                return true;
            return false;
        }
        public bool Update(int id)
        {
            string data = "`first_name` = '" + FirstName + "', `last_name` = '" + LastName + "', `role` = '" + Role + "', `gender` = '" + Gender + "', `dob` = '" + DateOfBirth + "', `middle_name` = '" + MiddleName + "', `email` = '" + Email + "'"; 
            if (database.Execute.Update("user", data, id))
                return true;
            return false;
        }
        public bool Delete(int id)
        {
            if (database.Execute.Delete("user", id))
                return true;
            else
                return false;
        }
    }
}
