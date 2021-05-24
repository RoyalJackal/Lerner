using System;
using System.IO;
using System.Linq;

namespace Homework.Stepik
{
    public static class ContinuousBackpack
    {
        public static void Execute()
        {
            var capacity = int.Parse(File.ReadLines(@"C:\Users\dimao\Downloads\cont.in").First().Split(" ")[1]);

            var input = File.ReadLines(@"C:\Users\dimao\Downloads\cont.in")
                .Skip(1)
                .Select(x => x.Split(" "))
                .Select(x => new Tuple<int, int, int>(int.Parse(x[0]), int.Parse(x[1]), int.Parse(x[1]) / int.Parse(x[0])))
                .OrderByDescending(x => x.Item3)
                .ToList();

            var price = 0;
            var weight = 0;
            var i = 0;
            while (weight < capacity)
            {
                if (weight + input[i].Item1 >= capacity)
                {
                    price += (input[i].Item2 / input[i].Item1) * (capacity - weight);
                    weight = capacity;
                }
                else
                {
                    weight += input[i].Item1;
                    price += input[i].Item2;
                }

                i++;
                if (i == input.Count) break;
            }

            Console.WriteLine(price);
        }
    }
}
