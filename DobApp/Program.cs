using System;
using System.Globalization;

namespace DobApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            do
            {
                string dobStr = getInput();

                String status = validateInput(dobStr);

                if (status != null)
                {
                    DateTime dob = Convert.ToDateTime(status);
                    calcutateAge(dob);
                }
                Console.WriteLine();
                Console.Write("Do you want to continue (y/n)?");

            } while (Console.ReadKey().KeyChar != 'n');
        }

        private static string getInput()
        {
            Console.Write("\nEnter your DOB(Use '/' as seperator): ");
            String dobStr = Console.ReadLine();
            return dobStr;
        }

        private static String validateInput(string dobStr)
        {

            string format = "dd/MM/yyyy";
            DateTime dateTime;
            if (DateTime.TryParseExact(dobStr, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                if (dateTime > DateTime.Now)
                {
                    Console.WriteLine("Invalid Date!");
                    return null;
                }
                else
                    return dateTime.ToString();
            }
            else
            {
                Console.WriteLine("Not a date");
                return null;
            }
        }

        private static void calcutateAge(DateTime dob)
        {

            DateTime Now = DateTime.Now;
            int Years = new DateTime(DateTime.Now.Subtract(dob).Ticks).Year - 1;
            DateTime DOBDateNow = dob.AddYears(Years);
            int Months = 0;
            for (int i = 1; i <= 12; i++)
            {
                if (DOBDateNow.AddMonths(i) == Now)
                {
                    Months = i;
                    break;
                }
                else if (DOBDateNow.AddMonths(i) >= Now)
                {
                    Months = i - 1;
                    break;
                }
            }
            int Days = Now.Subtract(DOBDateNow.AddMonths(Months)).Days;

            Console.WriteLine("Age: {0} Year(s), {1} Month(s) and {2} Day(s)", Years, Months, Days);
            Console.WriteLine("Your Born day of the week: {0}", dob.DayOfWeek);
        }
    }
}
