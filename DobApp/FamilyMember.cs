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

        public Tuple<int, int, int> calcutateAge(DateTime dob)
        {
            DateTime today = DateTime.Today;

            int months = today.Month - dob.Month;
            int years = today.Year - dob.Year;

            if (today.Day < dob.Day)
                months--;

            if (months < 0)
            {
                years--;
                months += 12;
            }

            int days = (today - dob.AddMonths((years * 12) + months)).Days;

            return Tuple.Create(years, months, days);
        }
    }
}
