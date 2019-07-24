using System;
using System.Globalization;
using System.Collections.Generic;

namespace DobApp
{
    class Program
    {
        public static void Main(string[] args)
        {

            List<FamilyMember> familyMemberList = new List<FamilyMember>();

            do
            {
              
                string type = null;
                while (type == null) { type = _GetType(); }

                string category = null;
                string name = null;
                if (string.Equals(type, "pet", StringComparison.CurrentCultureIgnoreCase))
                {
                    category = _GetCategory();
                }
                else
                {
                    name = _GetName();
                }

                string dobStr = _GetDob();

                DateTime validDate = _ValidateDob(dobStr);

                if (validDate != DateTime.MinValue)
                {
                    if (string.Equals(type, "person", StringComparison.CurrentCultureIgnoreCase))
                    {
                        familyMemberList.Add(new Person(type, name, validDate));
                    }
                    else
                    {
                        familyMemberList.Add(new Pet(type, category, validDate));
                    }
                }

                Console.WriteLine();
                Console.Write("Do you want to continue (y/n)?");

            } while (Console.ReadLine() != "n");
            
            List<FamilyMember> sortedList = FamilyMember.SortMembers(familyMemberList);

            foreach (var member in sortedList)
            {
                _PrintOutput(member);
                Console.WriteLine();
            }

            Console.WriteLine("\nPress any key to Exit..");
            Console.ReadKey();
        }
        private static string _GetType()
        {
            Console.Write("\nEnter type (Person/Pet): ");
            string type = Console.ReadLine();

            if (string.Equals(type, "pet", StringComparison.CurrentCultureIgnoreCase) || string.Equals(type, "person", StringComparison.CurrentCultureIgnoreCase))
            {
                return type;
            }

            Console.WriteLine("Please enter a valid type");
            return null;
        }

        private static string _GetCategory()
        {
            Console.Write("\nEnter Category (Eg: Cat): ");
            string category = Console.ReadLine();
            return category;
        }

        private static string _GetName()
        {
            Console.Write("\nEnter name: ");
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
            Console.WriteLine("Type: {0}", memberDetails.Type);
            if(memberDetails is Person)
            {
                var personMember = (Person)memberDetails;
                Console.WriteLine("Name: {0}", personMember.Name);
            }
            else
            {
                var petMember = (Pet)memberDetails;
                Console.WriteLine("Category: {0}", petMember.Category);
            }
            Console.WriteLine("Age: {0} year(s), {1} month(s) and {2} day(s)", memberDetails.Age.years, memberDetails.Age.months, memberDetails.Age.days);
            Console.WriteLine("Your born day of the week: {0}", memberDetails.Dob.DayOfWeek);
        }
    }
}
