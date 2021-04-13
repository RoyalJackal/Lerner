using System;
using System.Collections.Generic;

namespace Homework.Day1
{
    public static class Task2
    {
        public static void Execute()
        {
            const int countryCount = 3;
            const int stageCount = 6;
            const int transportTime = 1;

            var min = int.MaxValue;

            int[,] matrix =
            {
                {1, 2, 4, 8, 3, 1},
                {2, 5, 2, 2, 1, 8},
                {3, 1, 3, 6, 7, 2}
            };

            var path = new Tuple<int, int>[countryCount, stageCount];

            for (var j = 1; j < stageCount; j++)
            {
                for (var i = 0; i < countryCount; i++)
                {
                    var stageMin = int.MaxValue;
                    var minCountry = -1;

                    for (var k = 0; k < countryCount; k++)
                    {
                        int localMin;
                        if (i == k)
                            localMin = matrix[i, j] + matrix[i, j - 1];
                        else
                            localMin = matrix[i, j] + transportTime + matrix[k, j - 1];

                        if (localMin < stageMin)
                        {
                            stageMin = localMin;
                            minCountry = k;
                        }
                    }

                    matrix[i, j] = stageMin;
                    path[i, j] = Tuple.Create(minCountry, j-1);
                }
            }

            var stageContry = -1;
            var currStage = stageCount - 1;
            for (var i = 0; i < countryCount; i++)
            {
                var localMin = matrix[i, stageCount - 1];

                if (min > localMin)
                {
                    min = localMin;
                    stageContry = i;
                }
            }

            var result = new List<int>();

            while (stageContry != -1 && currStage != -1)
            {
                result.Add(stageContry);

                if (path[stageContry, currStage] == null)
                {
                    stageContry = -1;
                    currStage = -1;
                }
                else
                {
                    stageContry = path[stageContry, currStage].Item1;
                    currStage = path[stageContry, currStage].Item2;
                }
            }

            result.Reverse();
            foreach (var s in result)
            {
                Console.Write($"{s} ");
            }

            Console.WriteLine($"Min time = {min}");
        }
    }
}
