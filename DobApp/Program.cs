using System;
using System.Globalization;
using System.Collections.Generic;

namespace DobApp
{
    class Program
    {
        public static void Main(string[] args)
        {

            List<FamilyMember> FamilyMemberList = new List<FamilyMember>();

            do
            {
                string name = _GetName();
              
                string dobStr = _GetDob();

                DateTime validDate = _ValidateDob(dobStr);

                if (validDate != DateTime.MinValue)
                {
                    FamilyMemberList.Add(new FamilyMember(name, validDate));
                }

                Console.WriteLine();
                Console.Write("Do you want to continue (y/n)?");

            } while (Console.ReadKey().KeyChar != 'n');
            
            List<FamilyMember> sortedList = FamilyMember.SortMembers(FamilyMemberList);

            foreach (var member in sortedList)
            {
                _PrintOutput(member);
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        private static string _GetName()
        {
            Console.Write("\nEnter your name: ");
            string name = Console.ReadLine();
            return name;
        }

        private static string _GetDob()
        {
            Console.Write("\nEnter your DOB(Use '/' as seperator): ");
            string dobStr = Console.ReadLine();
            return dobStr;
        }

        private static DateTime _ValidateDob(string dobStr)
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
                return dateTime;
            }
            else
            {
                Console.WriteLine("Not a date");
                return DateTime.MinValue;
            }
        }

        private static void _PrintOutput(FamilyMember memberDetails)
        {
            Console.WriteLine();
            Console.WriteLine("Name: {0}", memberDetails.Name);
            Console.WriteLine("Age: {0} year(s), {1} month(s) and {2} day(s)", memberDetails.Age.years, memberDetails.Age.months, memberDetails.Age.days);
            Console.WriteLine("Your born day of the week: {0}", memberDetails.Dob.DayOfWeek);
        }
    }
}
