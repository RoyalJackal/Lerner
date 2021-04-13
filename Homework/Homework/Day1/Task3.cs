using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Homework.Day1
{
    public static class Task3
    {
        public static void Execute(string word1, string word2)
        {
            var matrix = new int[word1.Length + 1, word2.Length + 1];

            for (int i = 1; i <= word1.Length; i++)
            {
                for (int j = 1; j <= word2.Length; j++)
                {
                    if (word1[i - 1].CompareTo(word2[j - 1]) == 0)
                    {
                        matrix[i, j] = matrix[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        matrix[i, j] = Math.Max(matrix[i - 1, j], matrix[i, j - 1]);
                    }
                }
            }

            var x = word1.Length;
            var y = word2.Length;

            var result = new List<char>();
            while (x > 0 && y > 0)
            {
                if (word1[x - 1].CompareTo(word2[y - 1]) == 0)
                {
                    result.Add(word1[x-1]);
                    x--;
                    y--;
                }
                else if (matrix[x-1,y] == matrix[x,y])
                {
                    x--;
                }
                else
                {
                    y--;
                }
            }

            result.Reverse();
            foreach (var item in result)
            {
                Console.Write(item);
            }
            Console.WriteLine();
            Console.WriteLine($"Length = {result.Count}");
        }
    }
}
