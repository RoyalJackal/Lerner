using System;
using System.IO;
using System.Linq;

namespace Homework.Stepik
{
    public static class Shops
    {
        public static void Execute()
        {
            var input = File.ReadLines(@"C:\Users\dimao\Downloads\shops2.in")
                .Skip(1)
                .Select(x => x.Split(" ")
                    .Select(y => long.Parse(y))
                    .OrderBy(y => y)
                    .ToList())
                .ToList();

            long result = 0;
            for (int i = 0; i < input[0].Count; i++)
                result += Math.Abs(input[0][i] - input[1][i]);

            Console.WriteLine(result);
        }
    }
}
