using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Homework.Stepik
{
    public static class Icecream
    {
        public static void Execute()
        {
            var input = File.ReadLines(@"C:\Users\dimao\Downloads\ice.in")
                .Skip(1)
                .ToList();

            var producerList = new List<string>();
            var producerCount = 0;
            foreach (var icecream in input)
            {
                if (producerList.Contains(icecream))
                {
                    producerCount++;
                    producerList.Clear();
                }
                producerList.Add(icecream);
            }

            producerCount++;
            Console.WriteLine(producerCount);
        }
    }
}
