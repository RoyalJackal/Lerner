using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Homework.Day1
{
    public class Task5
    {
        private readonly Dictionary<Tuple<int, int>, int> _dict = new Dictionary<Tuple<int, int>, int>();
        private readonly Dictionary<Tuple<int, int>, int> _dictForA = new Dictionary<Tuple<int, int>, int>();

        private int GlassBalls(int floors, int balls)
        {
            if (floors == 0)
                return 0;
            if (balls == 1)
                return floors - 1;
            if (_dict.ContainsKey(new Tuple<int, int>(floors, balls)))
                return _dict[new Tuple<int, int>(floors, balls)];
            
            var floorsArray = new List<int>();
            for (int i = 0; i < floors; i++)
                floorsArray.Add(Math.Max(GlassBalls(i, balls - 1), GlassBalls(floors - i, balls)));
            var result = floorsArray.Max();
            _dict.Add(new Tuple<int, int>(floors, balls), result);
            return result;
        }
        
        private int Fa(int floors, int balls)
        {
            if (floors == 0)
                return 0;
            if (balls == 1)
                return floors - 1;
            if (_dictForA.ContainsKey(new Tuple<int, int>(floors, balls)))
                return _dictForA[new Tuple<int, int>(floors, balls)];
            
            var floorsArray = new List<Tuple<int, int>>();
            for (int i = 0; i < floors; i++)
                floorsArray.Add(new Tuple<int, int>(Math.Max(GlassBalls(i, balls - 1), GlassBalls(floors - i, balls)), i));
            var result = floorsArray
                .OrderBy(x => x.Item1)
                .ThenByDescending(x => x.Item2)
                .First();
            _dictForA.Add(new Tuple<int, int>(floors, balls), result.Item2);
            return result.Item2;
        }

        public void Execute(int floors, int balls)
        {
            Console.WriteLine($"In the worst case it will take {GlassBalls(floors, balls)} tries.");

            var x = 0;
            var testsCount = 1;
            var testedFloors = new List<int>();

            while (floors != 1)
            {
                var currentFloor = x - 1 + Fa(floors, balls);
                testedFloors.Add(currentFloor);
                Console.WriteLine($"Try #{testsCount}. Throwing ball from floor {currentFloor}. Is ball broken? y/n");
                var option = Console.ReadKey().KeyChar;
                switch (option)
                {
                    case 'y':
                    {
                        floors = Fa(floors, balls);
                        balls -= 1;
                        break;
                    }
                    case 'n':
                    {
                        x += Fa(floors, balls);
                        floors -= Fa(floors, balls);
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Wrong input.");
                        return;
                    }
                }
                
                testsCount++;
            }
            
            Console.WriteLine($"Resulting floor = {x}");
            Console.WriteLine($"It was found in {testsCount - 1} tries.");
            
            Console.Write("Resulting path:");
            testedFloors.Reverse();
            foreach (var floor in testedFloors)
                Console.Write($" {floor},");
        }
    }
}