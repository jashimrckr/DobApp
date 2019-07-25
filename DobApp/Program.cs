using System;
using System.Globalization;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.IO;
using System.Xml.Serialization;

namespace DobApp
{
    class Program
    {
        public static void Main(string[] args)
        {

            List<FamilyMember> familyMemberList = new List<FamilyMember>();

            do
            {
                int type = 0;
                while (type == 0) { type = _GetType(); }

                string name = _GetName();

                string breed = null;
                string profession = null;
                if (type == 1)
                {
                    profession = _GetProfession();
                }
                else
                {
                    breed = _GetBreed();
                }

                string dobStr = _GetDob();

                DateTime validDate = _ValidateDob(dobStr);

                if (validDate != DateTime.MinValue)
                {
                    if (type == 1)
                    {
                        familyMemberList.Add(new Person(name, profession, validDate));
                    }
                    else
                    {
                        familyMemberList.Add(new Pet(name, breed, validDate));
                    }
                }

                Console.WriteLine();
                Console.Write("Do you want to continue (y/n)?");

            } while (Console.ReadLine() != "n");
            
            List<FamilyMember> sortedList = FamilyMember.SortMembers(familyMemberList);

            foreach (var member in sortedList)
            {
                _ProvideOutput(member);
                Console.WriteLine();
            }


            Console.WriteLine("\nPress any key to Exit..");
            Console.ReadKey();
        }
        private static int _GetType()
        {
            Console.WriteLine("\nEnter your choice: ");
            Console.WriteLine("\n1. Add Person to Family ");
            Console.WriteLine("\n2. Add Pet to Family ");

            int type = Convert.ToInt32(Console.ReadLine());

            if (type == 1 || type == 2)
            {
                return type;
            }
            Console.WriteLine("Please enter a valid type");
            return 0;
        }

        private static string _GetBreed()
        {
            Console.Write("\nEnter Breed: ");
            string breed = Console.ReadLine();
            return breed;
        }

        private static string _GetProfession()
        {
            Console.Write("\nEnter your Profession: ");
            string profession = Console.ReadLine();
            return profession;
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



        private static void _ProvideOutput(FamilyMember memberDetails)
        {
            var jsonSerialiser = new JavaScriptSerializer();
            
            //string personPath = @"D:\Person.txt";

            Console.WriteLine();
            Console.WriteLine("Name: {0}", memberDetails.Name);
            if (memberDetails is Person)
            {
                //var json = jsonSerialiser.Serialize(memberDetails);
                

                //if (!File.Exists(personPath))
                //{
                //    File.WriteAllText(personPath, json);
                //}
                //else
                //{
                //    File.AppendAllText(personPath, json); 
                //}

                var personMember = (Person)memberDetails;
                Console.WriteLine("Profession: {0}", personMember.Profession);
            }
            else
            {
                var petMember = (Pet)memberDetails;
                Console.WriteLine("Breed: {0}", petMember.Breed);
            }
            Console.WriteLine("Age: {0} year(s), {1} month(s) and {2} day(s)", memberDetails.Age.years, memberDetails.Age.months, memberDetails.Age.days);
            Console.WriteLine("Your born day of the week: {0}", memberDetails.Dob.DayOfWeek);
        }
    }
}
