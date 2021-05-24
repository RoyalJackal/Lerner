using System;
using System.IO;
using System.Linq;

namespace Homework.Stepik
{
    public static class Request
    {
        public static void Execute()
        {
            var input = File.ReadLines(@"C:\Users\dimao\Downloads\request2.in")
                .Skip(1)
                .Select(x => x.Split(" "))
                .Select(x => new Tuple<int, int>(int.Parse(x[0]), int.Parse(x[1])))
                .ToList();

            var arr = new int[50000];
            var max = 0;

            foreach (var interval in input)
            {
                for (int i = interval.Item1; i < interval.Item2; i++)
                {
                    arr[i]++;
                    max = Math.Max(max, arr[i]);
                }
            }

            Console.WriteLine(max);
        }
    }
}
