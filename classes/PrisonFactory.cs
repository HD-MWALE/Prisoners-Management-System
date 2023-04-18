using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prisoners_Management_System.classes
{
    // design factory
    public class PrisonFactory
    {
        // declaring classes
        public Crime Crime = new Crime();
        public Crimes_Committed Crimes_Committed = new Crimes_Committed();
        public Dormitory Dormitory = new Dormitory();
        public Inmate Inmate = new Inmate();
        public Inmate_History Inmate_History = new Inmate_History();
        public Reports Reports = new Reports();
        public Roll_Call Roll_Call = new Roll_Call(); 
        public Sentence Sentence = new Sentence();
        public User User = new User();
        public Visitor Visitor = new Visitor();
    }
}
