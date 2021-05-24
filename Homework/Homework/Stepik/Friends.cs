using System;
using System.IO;
using System.Linq;

namespace Homework.Stepik
{
    public static class Friends
    {
        public static void Execute()
        {
            var personCount = int.Parse(File.ReadLines(@"C:\Users\dimao\Downloads\friends.in")
                .First()
                .Split(" ")
                .First());

            var pairs = File.ReadLines(@"C:\Users\dimao\Downloads\friends.in")
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

            var result = 0;
            for (int mask = 1; mask < 1 << personCount; mask++)
            {
                var friendsCount = 0;
                var flag = true;

                for (int i = 0; i < personCount; i++)
                    if ((mask | (1 << i)) == mask)
                    {
                        friendsCount++;
                        if ((friendMasks[i] & mask) != mask)
                        {
                            flag = false;
                            break;
                        }
                    }
                if (flag)
                    result = Math.Max(result, friendsCount);
            }

            Console.WriteLine(result);
        }
    }
}
