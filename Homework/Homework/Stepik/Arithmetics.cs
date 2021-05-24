using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Homework.Stepik
{
    public static class Arithmetics
    {
        private static List<int> minusIndexes;
        private static int target;

        public static void Execute()
        {
            var sum = int.Parse(File.ReadLines(@"C:\Users\dimao\Downloads\arithm2.in").First().Split(" ")[1]);

            var input = File.ReadLines(@"C:\Users\dimao\Downloads\arithm2.in")
                .Skip(1)
                .Select(x => x.Split(" "))
                .First()
                .Select(x => int.Parse(x))
                .ToList();

            minusIndexes = new List<int>();
            target = (input.Sum() - sum) / 2;

            Recursive(input, 1, 0, new List<int>());

            var result = "" + input[0];
            for (int i = 1; i < input.Count; i++)
            {
                if (minusIndexes.Contains(input[i]))
                {
                    minusIndexes.Remove(input[i]);
                    result += "-" + input[i];
                }
                else
                    result += "+" + input[i];
            }

            Console.WriteLine(result);
        }

        private static void Recursive(List<int> input, int idx, int currSum, List<int> currentNumbers)
        {
            if (currSum > target) return;
            if (currSum == target)
            {
                foreach (var number in currentNumbers)
                    minusIndexes.Add(number);
                target = -1;
                return;
            }

            for (int i = idx; i < input.Count; i++)
                Recursive(input, idx + 1, currSum + input[i], currentNumbers.Concat(new []{input[i]}).ToList());
        }
    }
}
