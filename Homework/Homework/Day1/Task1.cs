using System;
using System.Collections.Generic;

namespace Homework.Day1
{
    public static class Task1
    {
        private static Random rnd = new Random();
        
        private static double Function(List<double> variables)
        {
            var denominator = 0.0;
            foreach (var item in variables)
                denominator += item;

            return variables[0] / denominator;
        }

        private static List<double> Randomize(int count)
        {
            var variables = new List<double>();
            for (var i = 0; i < count; i++)
                variables.Add(rnd.NextDouble());

            return variables;
        }
        
        public static void Execute(int count, int iterations)
        {
            if (count < 2)
            {
                Console.WriteLine("Wrong variable count");
                return;
            }
            
            if (iterations < 1)
            {
                Console.WriteLine("Wrong iterations");
                return;
            }

            var passed = 0;
            for (int i = 0; i < iterations; i++)
            {
                var variables = Randomize(count);
                var result = Function(variables);
                var y = rnd.NextDouble();
                if (y < result) passed++;
            }
            
            Console.WriteLine(passed / (double)iterations);
        }
    }
}