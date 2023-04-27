using Google.Protobuf.WellKnownTypes;
using Prisoners_Management_System.config;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prisoners_Management_System.classes
{
    public class Visitor
    {
        // declaring private globe variables
        private int _Id;
        private string _Name;
        private string _Relation;
        private string _Contact;
        private string _Address;
        private Inmate _Inmate;
        private DataSet dataSet = new DataSet();
        // get and set globe variables
        public int Id { get { return _Id; } set { _Id = value; } }
        public string Name { get { return _Name; } set { _Name = value; } }
        public string Relation { get { return _Relation; } set { _Relation = value; } }
        public string Contact { get { return _Contact; } set { _Contact = value; } }
        public string Address { get { return _Address; } set { _Address = value; } }
        public Inmate Inmate { get { return _Inmate; } set { _Inmate = value; } }

        public Visitor()
        {
        }
        // setting globe variables
        public Visitor(string name, string relation, string contact, string address, Inmate inmate)
        {
            Name = config.config.AES.Encrypt(name, Properties.Resources.PassPhrase);
            Relation = config.config.AES.Encrypt(relation, Properties.Resources.PassPhrase);
            Contact = config.config.AES.Encrypt(contact, Properties.Resources.PassPhrase);
            Address = config.config.AES.Encrypt(address, Properties.Resources.PassPhrase);
            Inmate = inmate;
        }
        // setting globe variables
        public Visitor(int id, string name, string relation, string contact, DataSet dataSet)
        {
            Id = id;
            Name = name;
            Contact = contact;
            Relation = relation;
            this.dataSet = dataSet;
        }
        // save visitor details
        public bool Save()
        {
            string fields = "`name`, `relation`, `contact`, `address`";
            string data = "'" + Name + "','" + Contact + "','" + Relation + "','" + Address + "'";
            if (database.Execute.Insert("visitor", fields, data))
            {
                fields = "`visitor_id`, `inmate_id`";
                data = "" + GetId() + "," + Inmate.GetId(Inmate.Code) + "";
                database.Execute.Insert("visitation", fields, data);
                return true;
            }
            return false;
        }
        // get id
        public int GetId() 
        {
            string data = "`id`, `name`, `relation`, `contact`, `address`";
            string condition = "`date_created` = (SELECT MAX(`date_created`) FROM visitor) LIMIT 1;";
            (DataSet, string) response = database.Execute.Retrieve("SELECT " + data + " FROM visitation WHERE " + condition);
            if (response.Item2 != "server-error")
            {
                dataSet = response.Item1;
                if (dataSet != null)
                    foreach (DataRow dataRow in dataSet.Tables["result"].Rows)
                        return Convert.ToInt32(dataRow["id"]);
            }
            return 0;
        }
        public DataSet GetVisitors() 
        {
            string data = "visitor.`id`, visitor.`name`, visitor.`relation`, visitor.`contact`, visitor.`address`, inmate.`code`, inmate.`first_name`, inmate.`middle_name`, inmate.`last_name`, visitation.`date_created`";
            string condition = "visitor.`id` = visitation.`visitor_id` AND inmate.`id` = visitation.`inmate_id`";
            (DataSet, string) response = database.Execute.Retrieve("SELECT " + data + " FROM visitor, inmate, visitation WHERE " + condition);
            if (response.Item2 != "server-error")
            {
                dataSet = response.Item1;
                if (dataSet != null)
                {
                    foreach (DataRow row in response.Item1.Tables["result"].Rows)
                    {
                        // decrypting visitors details
                        row["name"] = config.config.AES.Decrypt(row["name"].ToString(), Properties.Resources.PassPhrase);
                        row["relation"] = config.config.AES.Decrypt(row["relation"].ToString(), Properties.Resources.PassPhrase);
                        row["contact"] = config.config.AES.Decrypt(row["contact"].ToString(), Properties.Resources.PassPhrase);
                        row["address"] = config.config.AES.Decrypt(row["address"].ToString(), Properties.Resources.PassPhrase);
                        row["code"] = config.config.AES.Decrypt(row["code"].ToString(), Properties.Resources.PassPhrase);
                        row["first_name"] = config.config.AES.Decrypt(row["first_name"].ToString(), Properties.Resources.PassPhrase);
                        row["middle_name"] = config.config.AES.Decrypt(row["middle_name"].ToString(), Properties.Resources.PassPhrase);
                        row["last_name"] = config.config.AES.Decrypt(row["last_name"].ToString(), Properties.Resources.PassPhrase);
                    }
                    return dataSet;
                }
            }
            return null;
        }
        // get visitor details by id
        public DataSet GetVisitorDetails(int id) 
        {
            string data = "`id`, `name`, `relation`, `contact`, `address`";
            (DataSet, string) response = database.Execute.Retrieve("SELECT " + data + " FROM " + "visitor" + "WHERE `id` = " + id);
            if (response.Item2 != "server-error")
            {
                dataSet = response.Item1;
                if (dataSet != null)
                {
                    foreach (DataRow row in response.Item1.Tables["result"].Rows)
                    {
                        // decrypting visitors details
                        row["name"] = config.config.AES.Decrypt(row["name"].ToString(), Properties.Resources.PassPhrase);
                        row["relation"] = config.config.AES.Decrypt(row["relation"].ToString(), Properties.Resources.PassPhrase);
                        row["contact"] = config.config.AES.Decrypt(row["contact"].ToString(), Properties.Resources.PassPhrase);
                        row["address"] = config.config.AES.Decrypt(row["address"].ToString(), Properties.Resources.PassPhrase);
                    }
                    return dataSet;
                }
            }
            return null;
        }
        // update visitor details
        public bool Update(int id)
        {
            string data = "`name` = '" + Name + "', `relation` = '" + Relation + "', `contact` = '" + Contact + "', `address` = '" + Address + "'";
            if (database.Execute.Update("visitor", data, id))
            {
                data = "`visitor_id` = " + GetId() + ", `inmate_id` = " + Inmate.Id;
                database.Execute.Update("visitation", data, id);
                return true;
            }
            return false;
        }
        // delete visitor details
        public bool Delete(int id)
        {
            if (database.Execute.Delete("visitor", id))
                return true;
            else
                return false;
        }
    }
}
