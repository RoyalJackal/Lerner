using System;
using System.IO;
using System.Linq;

namespace Homework.Stepik
{
    public static class News
    {
        public static void Execute()
        {
            var personCount = int.Parse(File.ReadLines(@"C:\Users\dimao\Downloads\new.in")
                .First()
                .Split(" ")
                .First());

            var pairs = File.ReadLines(@"C:\Users\dimao\Downloads\new.in")
                .Skip(1)
                .Select(x => x.Split(" "))
                .Select(x => new Tuple<int, int>(int.Parse(x[0]) - 1, int.Parse(x[1]) - 1))
                .ToList();

            var friendMasks = new int[personCount];
            for (int i = 0; i < personCount; i++)
                friendMasks[i] |= 1 << i;
            foreach (var pair in pairs)
            {
                friendMasks[pair.Item1] |= 1 << pair.Item2;
                friendMasks[pair.Item2] |= 1 << pair.Item1;
            }

            var result = int.MaxValue;
            for (int mask = 1; mask < 1 << personCount; mask++)
            {
                var friendsCount = 0;
                var totalMask = 0;

                for (int i = 0; i < personCount; i++)
                    if ((mask | (1 << i)) == mask)
                    {
                        friendsCount++;
                        totalMask |= friendMasks[i];
                    }
                if (totalMask == (1 << personCount) - 1)
                    result = Math.Min(result, friendsCount);
            }

            Console.WriteLine(result);
        }
    }
}
