using System;
using System.Globalization;

namespace DobApp
{
    class Program
    {

        private static void AgeCalculator(DateTime dob)
        {

            int year = DateTime.Now.Year - dob.Year;
            //Console.WriteLine(DateTime.Now.DayOfYear);
           
            //Console.WriteLine(DateTime.Today);
            //Console.WriteLine(dob.DayOfYear);
            if (DateTime.Now.DayOfYear < dob.DayOfYear)
                year = year - 1;

            Console.WriteLine("Age: {0} Year(s), {1} Month(s) and {2} Day(s)", year, Math.Abs(DateTime.Now.Month - dob.Month), Math.Abs(DateTime.Now.Day - dob.Day));
            Console.WriteLine("Your Born day of the week: {0}", dob.DayOfWeek);
        }

        private static void DateValidation(string dobStr)
        {
         
            string format = "dd/MM/yyyy";
            DateTime dateTime;
            if (DateTime.TryParseExact(dobStr, format, CultureInfo.InvariantCulture,DateTimeStyles.None, out dateTime))
            {
                if (dateTime > DateTime.Now)
                    Console.WriteLine("Invalid Date!");
                else
                    AgeCalculator(dateTime);
            }
            else
            {
                Console.WriteLine("Not a date");
            }


        }

        public static void Main(string[] args)
        {
            do
            {
                Console.Write("\nEnter your DOB(Use '/' as seperator): ");
                String dobStr = Console.ReadLine();

                DateValidation(dobStr);

                Console.WriteLine();
                Console.Write("Do you want to continue (y/n)?");

            } while (Console.ReadKey().KeyChar != 'n');
        }
    }
}
