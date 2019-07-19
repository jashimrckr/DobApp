using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DobApp
{
    class FamilyMember
    {
        public String Name;
        public DateTime Dob;
        public int TotalDays;

        public FamilyMember(String name, DateTime dob, int totaldays)
        {
            this.Name = name;
            this.Dob = dob;
            this.TotalDays = totaldays; 
        }
    }
}
