using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Enumeration;
using System.Linq;
using System.Xml;

namespace Homework
{
    public class Cities
    {
        public static void Execute()
        {
            var input = new List<string>
            {
                "new-york",
                "novgorod",
                "kazan"
            };

            var points = new Dictionary<char, LetterPoint>();
            foreach (var city in input)
            {
                if (!points.ContainsKey(city[0]))
                    points.Add(city[0], new LetterPoint(city[0]));
                points[city[0]].First++;

                if (!points.ContainsKey(city[city.Length - 1]))
                    points.Add(city[city.Length - 1], new LetterPoint(city[city.Length - 1]));
                points[city[city.Length - 1]].Last++;
            }

            var edges = new Dictionary<(char first, char last), Stack<string>>();
            foreach (var city in input)
            {
                if (!edges.ContainsKey((city[0], city[city.Length - 1])))
                    edges.Add((city[0], city[city.Length - 1]), new Stack<string>());
                edges[(city[0], city[city.Length - 1])].Push(city);
            }

            var isHalfEuler = false;
            var isEuler = Check(points, out isHalfEuler);
            Console.WriteLine(isEuler);
            Console.WriteLine(isHalfEuler);

            List<char> result;
            if (isEuler)
            {
                result = Find(points, edges, isHalfEuler);

                foreach (var city in input)
                {
                    if (!edges.ContainsKey((city[0], city[city.Length - 1])))
                        edges.Add((city[0], city[city.Length - 1]), new Stack<string>());
                    edges[(city[0], city[city.Length - 1])].Push(city);
                }
                for (int i = 0; i < result.Count - 1; i++)
                {
                    Console.Write(edges[(result[i], result[i + 1])].Pop() + " ");
                }
            }


        }

        private static bool Check(Dictionary<char, LetterPoint> points, out bool isHalfEuler)
        {
            isHalfEuler = false;
            var firstOdd = 0;
            var lastOdd = 0;
            foreach (var point in points)
            {
                if (point.Value.First == point.Value.Last - 1)
                    firstOdd++;
                else if (point.Value.First - 1 == point.Value.Last)
                    lastOdd++;
                else if (point.Value.First != point.Value.Last)
                    return false;
            }

            if (firstOdd == 1 && lastOdd == 1)
            {
                isHalfEuler = true;
                return true;
            }

            if (firstOdd != 0 || lastOdd != 0)
                return false;

            return true;
        }

        private static List<char> Find(Dictionary<char, LetterPoint> points, Dictionary<(char first, char last), Stack<string>> edges, bool isHalfEuler)
        {
            var result = new List<char>();

            char first;
            if (isHalfEuler)
                first = points.First(point => point.Value.First - 1 == point.Value.Last).Value.Value;
            else
                first = points.First().Value.Value;
            var stack = new Stack<char>();
            stack.Push(first);
            while (stack.Count > 0)
            {
                var currentPoint = stack.Peek();
                var foundEdge = false;
                foreach (var otherPoint in points)
                {
                    if (edges.ContainsKey((currentPoint, otherPoint.Value.Value)) &&
                        edges[(currentPoint, otherPoint.Value.Value)].Count > 0)
                    {
                        stack.Push(otherPoint.Value.Value);
                        edges[(currentPoint, otherPoint.Value.Value)].Pop();
                        foundEdge = true;
                        break;
                    }
                }

                if (!foundEdge)
                {
                    stack.Pop();
                    result.Add(currentPoint);
                }
            }

            result.Reverse();
            return result;
        }
    }

    public class LetterPoint
    {
        public char Value;
        public int First;
        public int Last;

        public LetterPoint(char value)
        {
            Value = value;
            First = 0;
            Last = 0;
        }
    }
}
