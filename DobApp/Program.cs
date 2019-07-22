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
                String name = getName();
              
                String dobStr = getDob();

                DateTimeOffset validDate = validateInput(dobStr);

                if (validDate != DateTimeOffset.MinValue)
                {
                    int totalDays = (DateTimeOffset.Now - validDate).Days;
                    FamilyMemberList.Add(new FamilyMember(name, validDate, totalDays));
                }

                Console.WriteLine();
                Console.Write("Do you want to continue (y/n)?");

            } while (Console.ReadKey().KeyChar != 'n');

            Sort s = new Sort();
            s.sortList(FamilyMemberList);
            
            Console.ReadKey();
        }

        private static string getName()
        {
            Console.Write("\nEnter your name: ");
            String name = Console.ReadLine();
            return name;
        }

        public static string getDob()
        {
            Console.Write("\nEnter your DOB(Use '/' as seperator): ");
            String dobStr = Console.ReadLine();
            return dobStr;
        }

        public static DateTimeOffset validateInput(string dobStr)
        {
            string format = "dd/MM/yyyy";
            DateTimeOffset dateTime;
            if (DateTimeOffset.TryParseExact(dobStr, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                if (dateTime > DateTimeOffset.Now)
                {
                    Console.WriteLine("Invalid Date!");
                    return DateTimeOffset.MinValue;
                }
                else
                    return dateTime;
            }
            else
            {
                Console.WriteLine("Not a date");
                return DateTimeOffset.MinValue;
            }
        }

        

        public static void printOutput(int years, int months, int days, String name, DateTimeOffset dob)
        {
            Console.WriteLine();
            Console.WriteLine("Name: {0}", name);
            Console.WriteLine("Age: {0} year(s), {1} month(s) and {2} day(s)", years, months, days);
            Console.WriteLine("Your born day of the week: {0}", dob.DayOfWeek);
        }
    }
}
