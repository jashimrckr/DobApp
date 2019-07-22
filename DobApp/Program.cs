using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DobApp
{
    class Program
    {
        public static void Main(string[] args)
        {

            List<FamilyMember> FamilyMemberList = new List<FamilyMember>();

            do
            {
                string name = getName();
              
                string dobStr = getDob();

                DateTime validDate = validateDob(dobStr);

                if (validDate != DateTime.MinValue)
                {
                    int totalDays = (DateTime.Now - validDate).Days;
                    FamilyMemberList.Add(new FamilyMember(name, validDate, totalDays));
                }

                Console.WriteLine();
                Console.Write("Do you want to continue (y/n)?");

            } while (Console.ReadKey().KeyChar != 'n');

            Sort sortObj = new Sort();
            List<FamilyMember> sortedList = sortObj.sortMembers(FamilyMemberList);

            Age ageObj = new Age();

            foreach (var member in sortedList)
            {
                Age result = ageObj.calcutateAge(member.Dob);
                printOutput(result, member.Name, member.Dob);
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        private static string getName()
        {
            Console.Write("\nEnter your name: ");
            string name = Console.ReadLine();
            return name;
        }

        public static string getDob()
        {
            Console.Write("\nEnter your DOB(Use '/' as seperator): ");
            string dobStr = Console.ReadLine();
            return dobStr;
        }

        public static DateTime validateDob(string dobStr)
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

        public static void printOutput(Age result, string name, DateTime dob)
        {
            Console.WriteLine();
            Console.WriteLine("Name: {0}", name);
            Console.WriteLine("Age: {0} year(s), {1} month(s) and {2} day(s)", result.years, result.months, result.days);
            Console.WriteLine("Your born day of the week: {0}", dob.DayOfWeek);
        }
    }
}
