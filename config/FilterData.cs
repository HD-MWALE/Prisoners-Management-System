using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Prisoners_Management_System.config
{
    public class FilterData
    {
        // filter table (inmates near to be released)
        public static DataTable InmatesTable(DataTable table, DateTime startDate, DateTime endDate)
        {
            // search in datatable of inmates
            var filteredRows =
              from row in table.Rows.OfType<DataRow>()
              where (DateTime)row["end_date"] >= startDate
              where (DateTime)row["end_date"] <= endDate
              select row;
            // clone datatable schema
            var filteredTable = table.Clone();
            // import filtered rows in datatable
            filteredRows.ToList().ForEach(r => filteredTable.ImportRow(r));
            // return filtered datatable
            return filteredTable;
        }
        // filter table
        public static DataTable InmatesTable(DataTable table)
        {
            TimeSpan timeSpan = new TimeSpan(31449600000);
            // search in datatable of inmates
            var filteredRows =
              from row in table.Rows.OfType<DataRow>()
              where (DateTime)row["start_date"] <= DateTime.Now.Date.Subtract(timeSpan).Date.Subtract(timeSpan)
              where (DateTime)row["end_date"] >= DateTime.Now.Date.AddYears(1)
              select row;
            // clone datatable schema
            var filteredTable = table.Clone();
            // import filtered rows in datatable
            filteredRows.ToList().ForEach(r => filteredTable.ImportRow(r));
            // return filtered datatable
            return filteredTable;
        }
        // search inmates
        public static DataTable SearchInmate(DataTable dsInmates, string search) 
        {
            // search in datatable of inmates
            var filteredRows =
            from row in dsInmates.Rows.OfType<DataRow>()
            where (string)row["code"] == search ||
                    (string)row["first_name"] == search ||
                    (string)row["middle_name"] == search ||
                    (string)row["last_name"] == search ||
                    (string)row["gender"] == search
              select row;
            // clone datatable schema
            var filteredTable = dsInmates.Clone();
            // import filtered rows in datatable
            filteredRows.ToList().ForEach(r => filteredTable.ImportRow(r));
            // return filtered datatable
            return filteredTable;
        }
        // search inmates
        public static DataTable SearchInmateHistory(DataTable dsInmateHistories, string search) 
        {
            // search in datatable of inmate histories
            var filteredRows =
            from row in dsInmateHistories.Rows.OfType<DataRow>()
            where (string)row["action"] == search 
            select row;
            // clone datatable schema
            var filteredTable = dsInmateHistories.Clone();
            // import filtered rows in datatable
            filteredRows.ToList().ForEach(r => filteredTable.ImportRow(r));
            // return filtered datatable
            return filteredTable;
        }
        // search roll call
        public static DataTable SearchRollCall(DataTable dsRollCall, string search)  
        {
            // search in datatable of roll call
            var filteredRows =
            from row in dsRollCall.Rows.OfType<DataRow>()
            where (string)row["code"] == search ||
                  config.AES.Decrypt((string)row["name"], Properties.Resources.PassPhrase) == search
            select row;
            // clone datatable schema
            var filteredTable = dsRollCall.Clone();
            // import filtered rows in datatable
            filteredRows.ToList().ForEach(r => filteredTable.ImportRow(r));
            // return filtered datatable
            return filteredTable;
        }
        // search dormitory
        public static DataTable SearchDormitory(DataTable dsDormitory, string search)  
        {
            // search in datatable of dormitories
            var filteredRows =
            from row in dsDormitory.Rows.OfType<DataRow>()
            where (string)row["name"] == search ||
                    (string)row["gendertype"] == search ||
                    (string)row["type"] == search
            select row;
            // clone datatable schema
            var filteredTable = dsDormitory.Clone();
            // import filtered rows in datatable
            filteredRows.ToList().ForEach(r => filteredTable.ImportRow(r));
            // return filtered datatable
            return filteredTable;
        }
        // search users
        public static DataTable SearchUser(DataTable dsUsers, string search)
        {
            // search in datatable of inmates
            var filteredRows =
            from row in dsUsers.Rows.OfType<DataRow>()
            where (string)row["user_name"] == search ||
                    (string)row["first_name"] == search ||
                    (string)row["middle_name"] == search ||
                    (string)row["last_name"] == search ||
                    (string)row["email"] == search ||
                    (string)row["gender"] == search
            select row;
            // clone datatable schema
            var filteredTable = dsUsers.Clone();
            // import filtered rows in datatable
            filteredRows.ToList().ForEach(r => filteredTable.ImportRow(r));
            // return filtered datatable
            return filteredTable;
        }
        // search visitors
        public static DataTable SearchVisitor(DataTable dsVisitors, string search) 
        {
            // search in datatable of visitors
            var filteredRows =
            from row in dsVisitors.Rows.OfType<DataRow>()
            where (string)row["name"] == search ||
                    (string)row["first_name"] == search ||
                    (string)row["middle_name"] == search ||
                    (string)row["last_name"] == search ||
                    (string)row["relation"] == search ||
                    (string)row["contact"] == search ||
                    (string)row["address"] == search
            select row;
            // clone datatable schema
            var filteredTable = dsVisitors.Clone();
            // import filtered rows in datatable
            filteredRows.ToList().ForEach(r => filteredTable.ImportRow(r));
            // return filtered datatable
            return filteredTable;
        }
    }
}
