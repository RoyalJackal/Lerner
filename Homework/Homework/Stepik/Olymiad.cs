using System;
using System.IO;
using System.Linq;

namespace Homework.Stepik
{
    public static class Olymiad
    {
        public static void Execute()
        {
            var time = int.Parse(File.ReadLines(@"C:\Users\dimao\Downloads\contest.in").First().Split(" ")[1]);

            var input = File.ReadLines(@"C:\Users\dimao\Downloads\contest.in")
                .Skip(1)
                .Select(x => x.Split(" "))
                .First()
                .Select(x => int.Parse(x))
                .OrderBy(x => x)
                .ToList();

            var spentTime = 0;
            var penalty = 0;
            var taskCount = 0;

            foreach (var task in input)
            {
                spentTime += task;
                if (spentTime > time) break;

                penalty += spentTime;
                taskCount++;
            }

            Console.WriteLine(taskCount);
            Console.WriteLine(penalty);
        }
    }
}
