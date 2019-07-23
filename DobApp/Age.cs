using System;

namespace DobApp
{
    public class Age
    {
        public int years { get; private set; }
        public int months { get; private set; }
        public int days { get; private set; }

        public Age(DateTime dob)
        {
            DateTime today = DateTime.Now;

            this.months = today.Month - dob.Month;
            this.years = today.Year - dob.Year;

            if (today.Day < dob.Day)
            {
                months--;
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            this.days = (today - dob.AddMonths((years * 12) + months)).Days;

        }
    }
}
