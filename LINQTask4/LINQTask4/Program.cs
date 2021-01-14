using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LINQTask4
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] { -15, 13, 125, 356, -489, 6, 28, 15, 91, 34, 68, 33 };

            var oddTwoDigitNumbers = GetOddTwoDigitNumbers(numbers, 3);
            foreach (var number in oddTwoDigitNumbers)
                Console.WriteLine(number);
            Console.WriteLine();

            var strs = File.ReadAllLines("db.txt");
            var dataBase = new List<Record>();

            foreach (var str in strs)
            {
                var data = str.Split();

                var record = new Record()
                {
                    ClientID = int.Parse(data[0]),
                    Year = int.Parse(data[1]),
                    Month = int.Parse(data[2]),
                    Duration = int.Parse(data[3])
                };

                dataBase.Add(record);
            }
            PrintMonthsDurations(dataBase);


            Console.ReadKey();
        }

        static int[] GetOddTwoDigitNumbers(int[] array, int index)
        {

            return array
                .Skip(index)
                .Where(x => x >= 10 && x <= 99 && x % 2 == 1)
                .Distinct()
                .OrderBy(x => x)
                .ToArray();

        }

        static void PrintMonthsDurations(List<Record> array)
        {
            var a = array
                .GroupBy(x => x.Month)
                .Select(x => (x.Select(y => y.Duration).Sum(), x.Key))
                .OrderByDescending(x => x.Item1)
                .ThenBy(x => x.Item2)
                .ToArray();

            Console.WriteLine($"Суммарная продолжительность: {a.Sum(x => x.Item1)}");

            foreach (var elem in a)
            {
                Console.WriteLine($"В месяце №{elem.Item2} продолжительность занятий составляет: {elem.Item1} ");
            }
        }
    }
}
