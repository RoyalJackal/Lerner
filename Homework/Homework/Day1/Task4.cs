using System;
using System.Collections.Generic;

namespace Homework.Day1
{
    public static class Task4
    {
        public static void Execute()
        {
            int[] array =
            {
                5, 10, 6, 12, 3, 24, 7, 8
            };

            var maxLengths = new int[array.Length];
            var maxLengthPrevs = new int[array.Length];

            for (var i = 0; i < array.Length; i++)
            {
                maxLengths[i] = 1;
                maxLengthPrevs[i] = -1;
                for (var j = 0; j < i; j++)
                {
                    if (array[i] > array[j])
                    {
                        if (1 + maxLengths[j] > maxLengths[i])
                        {
                            maxLengths[i] = maxLengths[j] + 1;
                            maxLengthPrevs[i] = j;
                        }
                    }
                }
            }

            var max = maxLengths[0];
            var maxPos = 0;

            for (var i = 0; i < array.Length; i++)
            {
                if (maxLengths[i] > max)
                {
                    max = maxLengths[i];
                    maxPos = i;
                }
            }

            var logs = new List<int>();
            while (maxPos != -1)
            {
                logs.Add(array[maxPos]);
                maxPos = maxLengthPrevs[maxPos];
            }
            logs.Reverse();

            foreach (var log in logs)
            {
                Console.Write($"{log} ");
            }

            Console.WriteLine();
            Console.WriteLine($"Max length = {max}");
        }
    }
}
