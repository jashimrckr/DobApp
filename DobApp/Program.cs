using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;

namespace DobApp
{
    class Program
    {
        public static void Main(string[] args)
        {

            List<FamilyMember> FamilyMemberList = new List<FamilyMember>();

            do
            {
                Console.Write("\nEnter your name: ");
                String name = Console.ReadLine();

                String dobStr = getInput();

                DateTime validDate = validateInput(dobStr);

                if (validDate != DateTime.MinValue)
                {
                    int totalDays = (DateTime.Now - validDate).Days;
                    Console.WriteLine(totalDays);
                    FamilyMemberList.Add(new FamilyMember(name, validDate, totalDays));
                }

                Console.WriteLine();
                Console.Write("Do you want to continue (y/n)?");

            } while (Console.ReadKey().KeyChar != 'n');

            List<FamilyMember> SortedList = FamilyMemberList.OrderBy(o => o.TotalDays).ToList();
            foreach (var member in SortedList)
            {
                var result = calcutateAge(member.Dob);
                printOutput(result.Item1, result.Item2, result.Item3, member.Name, member.Dob);
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        public static string getInput()
        {
            Console.Write("\nEnter your DOB(Use '/' as seperator): ");
            String dobStr = Console.ReadLine();
            return dobStr;
        }

        public static DateTime validateInput(string dobStr)
        {
            string format = "dd/MM/yyyy";
            DateTime dateTime;
            if (DateTime.TryParseExact(dobStr, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                if (dateTime > DateTime.Now)
                {
                    Console.WriteLine("Invalid Date!");
                    return DateTime.MinValue;
                }
                else
                    return dateTime;
            }
            else
            {
                Console.WriteLine("Not a date");
                return DateTime.MinValue;
            }
        }

        private static Tuple<int, int, int> calcutateAge(DateTime dob)
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

        public static void printOutput(int years, int months, int days, String name, DateTime dob)
        {
            Console.WriteLine();
            Console.WriteLine("Name: {0}", name);
            Console.WriteLine("Age: {0} year(s), {1} month(s) and {2} day(s)", years, months, days);
            Console.WriteLine("Your born day of the week: {0}", dob.DayOfWeek);
        }
    }
}
