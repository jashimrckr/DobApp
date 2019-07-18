using System;

namespace DobApp
{
    class Program
    {

        private static void AgeCalculator(DateTime dob)
        {
            Console.WriteLine("Age: {0} Year(s), {1} Month(s) and {2} Day(s)", Math.Abs(DateTime.Now.Year - dob.Year), Math.Abs(DateTime.Now.Month - dob.Month), Math.Abs(DateTime.Now.Day - dob.Day));
            Console.WriteLine("Your Born day of the week: {0}", dob.DayOfWeek);
        }

        private static void DateValidation(string dobStr)
        {
            try
            {
                DateTime dob = DateTime.ParseExact(dobStr, "dd/MM/yyyy", null);

                if (dob > DateTime.Now)
                    Console.WriteLine("Invalid Date!");

                else
                {
                    AgeCalculator(dob);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Date!");

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
