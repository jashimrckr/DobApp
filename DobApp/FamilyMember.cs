using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DobApp
{
    class FamilyMember
    {
        public string Name { get; }
        public DateTime Dob { get; }
        public int TotalDays { get; }

        public FamilyMember(string name, DateTime dob, int totaldays)
        {
            this.Name = name;
            this.Dob = dob;
            this.TotalDays = totaldays; 
        }
    }

    class Age
    {
        public int years, months, days;

        public Age calcutateAge(DateTime dob)
        {
            DateTime today = DateTime.Now;
            //Console.WriteLine(((today - dob).Days)/(365.25/12));

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

