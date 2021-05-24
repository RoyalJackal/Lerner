using System;
using System.IO;
using System.Linq;

namespace Homework.Stepik
{
    public static class GoldBit
    {
        public static void Execute()
        {
            var input = File.ReadLines(@"C:\Users\dimao\Downloads\gold3.in")
                .Skip(1)
                .First()
                .Split(" ")
                .Select(x => long.Parse(x))
                .ToList();

            var result = long.MaxValue;

            for (int mask = 0; mask < 1 << input.Count; mask++)
            {
                long first = 0;
                long second = 0;
                for (int i = 0; i < input.Count; i++)
                {
                    if ((mask | (1 << i)) == mask)
                        first += input[i];
                    else
                        second += input[i];
                }
                result = Math.Min(result, Math.Abs(first - second));
            }

            Console.WriteLine(result);
        }
    }
}
