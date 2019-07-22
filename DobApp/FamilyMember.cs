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
        public DateTimeOffset Dob;
        public int TotalDays;

        public FamilyMember(String name, DateTimeOffset dob, int totaldays)
        {
            this.Name = name;
            this.Dob = dob;
            this.TotalDays = totaldays; 
        }

        public class Age {

            public int years, months, days;

            public Age calcutateAge(DateTimeOffset dob)
            {
                DateTimeOffset today = DateTimeOffset.Now;

                months = today.Month - dob.Month;
                years = today.Year - dob.Year;

                if (today.Day < dob.Day)
                    months--;

                if (months < 0)
                {
                    years--;
                    months += 12;
                }

                days = (today - dob.AddMonths((years * 12) + months)).Days;

                Age values = new Age();
                values.years = years;
                values.months = months;
                values.days = days;
                return values;
             }

         }
    }
}
