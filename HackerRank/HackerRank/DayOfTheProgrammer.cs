using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    public static class DayOfTheProgrammer
    {
        public static void Execute()
        {
            int year = Convert.ToInt32(Console.ReadLine().Trim());

            string result = dayOfProgrammer(year);

            Console.WriteLine(result);
        }

        static string dayOfProgrammer(int year)
        {
            //Implementation 1 
            string result = string.Empty;
            if (year < 1918)
            {
                if (year % 4 == 0)
                    result = $"12.09.{year}";
                else
                    result = $"13.09.{year}";
            }
            else if (year > 1918)
            {
                if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0))
                    result = $"12.09.{year}";
                else
                    result = $"13.09.{year}";
            }
            else
            {
                result = $"26.09.{year}";
            }
            return result;

            //Implementation 2
            if (year == 1918)
                return $"26.09.{year}";
            if ((year < 1918 && year % 4 == 0)
                || (year > 1918 && (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0))))
                return $"12.09.{year}";
            return $"13.09.{year}";
        }
    }
}
