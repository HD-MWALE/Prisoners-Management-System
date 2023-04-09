using Google.Protobuf.WellKnownTypes;
using Roll_Call_And_Management_System.config;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roll_Call_And_Management_System.classes
{
    public class Visitor
    {
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _Relation;
        public string Relation
        {
            get { return _Relation; }
            set { _Relation = value; }
        }

        private string _Contact;
        public string Contact
        {
            get { return _Contact; }
            set { _Contact = value; }
        }

        private string _Address;
        public string Address 
        {
            get { return _Address; }
            set { _Address = value; }
        }

        private Inmate _Inmate;
        public Inmate Inmate
        {
            get { return _Inmate; }
            set { _Inmate = value; }
        }

        public Visitor()
        {
        }

        public Visitor(string name, string relation, string contact, string address, Inmate inmate)
        {
            Name = ini.AES.Encrypt(name, Properties.Resources.PassPhrase);
            Relation = ini.AES.Encrypt(relation, Properties.Resources.PassPhrase);
            Contact = ini.AES.Encrypt(contact, Properties.Resources.PassPhrase);
            Address = ini.AES.Encrypt(address, Properties.Resources.PassPhrase);
            Inmate = inmate;
        }

        public Visitor(int id, string name, string relation, string contact, DataSet dataSet)
        {
            Id = id;
            Name = name;
            Contact = contact;
            Relation = relation;
            this.dataSet = dataSet;
        }

        public DataSet dataSet = new DataSet();
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
                    return dataSet;
            }
            return null;
        }
        public DataSet GetVisitorDetails(int id) 
        {
            string data = "`id`, `name`, `relation`, `contact`, `address`";
            (DataSet, string) response = database.Execute.Retrieve("SELECT " + data + " FROM " + "visitor" + "WHERE `id` = " + id);
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
            string data = "`name` = '" + Name + "', `relation` = '" + Relation + "', `contact` = '" + Contact + "', `address` = '" + Address + "'";
            if (database.Execute.Update("visitor", data, id))
            {
                data = "`visitor_id` = " + GetId() + ", `inmate_id` = " + Inmate.Id;
                database.Execute.Update("visitation", data, id);
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            if (database.Execute.Delete("visitor", id))
                return true;
            else
                return false;
        }
    }
}
