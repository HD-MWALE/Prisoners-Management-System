using Bunifu.Core;
using DocumentFormat.OpenXml.Office2010.Excel;
using Google.Protobuf.WellKnownTypes;
using Org.BouncyCastle.Ocsp;
using Org.BouncyCastle.Security;
using Prisoners_Management_System.config;
using Prisoners_Management_System.views;
using Prisoners_Management_System.views.components;
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

namespace Prisoners_Management_System.classes
{
    public class User
    {
        // declaring user role variable
        public enum UserRole { Admin = 1, Guard = 2 }
        // declaring private globe variables
        private int _Id;
        private string _UserName;
        private string _Email;
        private string _FirstName;
        private string _LastName;
        private string _MiddleName;
        private UserRole _Role;
        private string _Gender;
        private string _Password;
        private string _OTP;
        private string _DateOfBirth;
        private DataSet dataSet = new DataSet();
        // public variable
        public ArrayList Auth = new ArrayList();
        // get and set globe variables
        public int Id { get { return _Id; } set { _Id = value; } }
        public string UserName { get { return _UserName; } set { _UserName = value; } }
        public string Email { get { return _Email; } set { _Email = value; } }
        public string FirstName { get { return _FirstName; } set { _FirstName = value; } }
        public string LastName { get { return _LastName; } set { _LastName = value; } }
        public string MiddleName { get { return _MiddleName; } set { _MiddleName = value; } }
        public UserRole Role { get { return _Role; } set { _Role = value; } }
        public string Gender { get { return _Gender; } set { _Gender = value; } }
        public string Password { get { return _Password; } set { _Password = value; } }
        public string OTP { get { return _OTP; } set { _OTP = value; } }
        public string DateOfBirth { get { return _DateOfBirth; } set { _DateOfBirth = value; } }

        public User() { }
        // setting username, email and password variables
        public User(string username, string password) 
        {
            UserName = username;
            Email = username;
            Password = password;
        }
        // setting globe variables
        public User(int id, string email, string username, string firstname, string middlename, string lastname, string gender, DateTime dob)
        {
            Id = id;
            Email = config.config.AES.Encrypt(email, Properties.Resources.PassPhrase);
            UserName = config.config.AES.Encrypt(username, Properties.Resources.PassPhrase);
            FirstName = config.config.AES.Encrypt(firstname, Properties.Resources.PassPhrase);
            LastName = config.config.AES.Encrypt(lastname, Properties.Resources.PassPhrase);
            MiddleName = config.config.AES.Encrypt(middlename, Properties.Resources.PassPhrase);
            Gender = config.config.AES.Encrypt(gender, Properties.Resources.PassPhrase);
            DateOfBirth = dob.ToString("yyyy/MM/dd");
        }
        // setting globe variables
        public User(string email, string username, string firstname, string middlename, string lastname, string gender, DateTime dob, UserRole role)
        {
            Email = config.config.AES.Encrypt(email, Properties.Resources.PassPhrase);
            UserName = config.config.AES.Encrypt(username, Properties.Resources.PassPhrase);
            FirstName = config.config.AES.Encrypt(firstname, Properties.Resources.PassPhrase);
            LastName = config.config.AES.Encrypt(lastname, Properties.Resources.PassPhrase);
            MiddleName = config.config.AES.Encrypt(middlename, Properties.Resources.PassPhrase);
            Gender = config.config.AES.Encrypt(gender, Properties.Resources.PassPhrase);
            Role = role;
            Password = config.config.AES.Encrypt("otp", Properties.Resources.PassPhrase);
            OTP = config.config.AES.Encrypt(config.config.Generate.Random.Next(100000, 999999).ToString(), Properties.Resources.PassPhrase);
            DateOfBirth = dob.ToString("yyyy/MM/dd");
        }
        // setting globe variables
        public User(string username)
        {
            UserName = username;
            Password = config.config.AES.Encrypt("otp", Properties.Resources.PassPhrase);
            OTP = config.config.AES.Encrypt(config.config.Generate.Random.Next(100000, 999999).ToString(), Properties.Resources.PassPhrase);
        }
        // save user details
        public (bool, bool) Save()
        {
            if (config.config.Internet.IsInternetConnectionAvailable())
            {
                string fields = "`email`, `user_name`, `first_name`, `middle_name`, `last_name`, `gender`, `dob`, `role`, `password`, `otp`";
                string data = "'" + Email + "', '" + UserName + "', '" + FirstName + "', '" + MiddleName + "', '" + LastName + "', '" + Gender + "', '" + DateOfBirth + "', '" + Role + "', '" + Password + "', '" + OTP + "'";

                if (database.Execute.Insert("user", fields, data))
                {
                    config.config.Internet.SendOTPEmail((config.config.AES.Decrypt(UserName, Properties.Resources.PassPhrase), config.config.AES.Decrypt(OTP, Properties.Resources.PassPhrase)), config.config.AES.Decrypt(Email, Properties.Resources.PassPhrase));
                    return (true, true);
                }
                return (false, true);
            }
            return (false, false);
        }
        // forgot password function
        public (bool, bool) ForgotPassword() 
        {
            if (config.config.Internet.IsInternetConnectionAvailable())
            {
                string data = "`password` = '" + Password + "', `otp` = '" + OTP + "'";
                if (database.Execute.Update("user", data, GetId(UserName)))
                {
                    config.config.Internet.SendOTPEmail((UserName, config.config.AES.Decrypt(OTP, Properties.Resources.PassPhrase)), Email);
                    return (true, true);
                }
                return (false, true);
            }
            return (false, false);
        }
        // get all users
        public (DataSet, string) GetUsers() 
        {
            string fields = "`id`, `email`, `user_name`, `first_name`, `middle_name`, `last_name`, `gender`, `dob`, `role`";
            return database.Execute.Retrieve("SELECT " + fields + " FROM user");
        }
        // get id by username
        public int GetId(string username) 
        {
            (DataSet, string) response = GetUsers();
            if (response.Item1 != null)
            {
                foreach (DataRow data in response.Item1.Tables["result"].Rows)
                    if (config.config.AES.Decrypt(Convert.ToString(data["user_name"]), Properties.Resources.PassPhrase) == username)
                    {
                        Email = config.config.AES.Decrypt(Convert.ToString(data["email"]), Properties.Resources.PassPhrase);
                        return Convert.ToInt32(data["id"]);
                    }
            }
            return 0;
        }
        // get user details by id
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
        // login function
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
                        if (UserName == config.config.AES.Decrypt((string)dataRow["user_name"], Properties.Resources.PassPhrase)
                            || Email == config.config.AES.Decrypt((string)dataRow["email"], Properties.Resources.PassPhrase))
                        {
                            Auth.Add(dataRow["id"]);
                            Auth.Add(config.config.AES.Decrypt((string)dataRow["email"], Properties.Resources.PassPhrase));
                            Auth.Add(config.config.AES.Decrypt((string)dataRow["user_name"], Properties.Resources.PassPhrase));
                            Auth.Add(config.config.AES.Decrypt((string)dataRow["first_name"], Properties.Resources.PassPhrase));
                            Auth.Add(config.config.AES.Decrypt((string)dataRow["last_name"], Properties.Resources.PassPhrase));
                            Auth.Add(config.config.AES.Decrypt((string)dataRow["middle_name"], Properties.Resources.PassPhrase));
                            Auth.Add(config.config.AES.Decrypt((string)dataRow["gender"], Properties.Resources.PassPhrase));
                            Auth.Add(Convert.ToDateTime(dataRow["dob"]).ToString("dd/MM/yyyy"));
                            Auth.Add((string)dataRow["role"]);
                            Auth.Add(config.config.AES.Decrypt((string)dataRow["password"], Properties.Resources.PassPhrase));
                            Auth.Add(config.config.AES.Decrypt((string)dataRow["otp"], Properties.Resources.PassPhrase));
                            if (config.config.AES.Decrypt((string)dataRow["password"], Properties.Resources.PassPhrase) == Password)
                                Auth.Add("regular");
                            else if (config.config.AES.Decrypt((string)dataRow["otp"], Properties.Resources.PassPhrase) == Password)
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
        // change password function
        public bool ChangePassword(ArrayList Auth, string password)
        {
            string data = "`otp` = '" + config.config.AES.Encrypt("otp", Properties.Resources.PassPhrase) + "', `password` = '" + config.config.AES.Encrypt(password, Properties.Resources.PassPhrase) + "'";
            if (database.Execute.Update("user", data, (int)Auth[0]))
                return true;
            return false;
        }
        // update user
        public bool Update(int id)
        {
            string data = "`first_name` = '" + FirstName + "', `last_name` = '" + LastName + "', `role` = '" + Role + "', `gender` = '" + Gender + "', `dob` = '" + DateOfBirth + "', `middle_name` = '" + MiddleName + "', `email` = '" + Email + "'"; 
            if (database.Execute.Update("user", data, id))
                return true;
            return false;
        }
        // delete user
        public bool Delete(int id)
        {
            if (database.Execute.Delete("user", id))
                return true;
            else
                return false;
        }
    }
}
