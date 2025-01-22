﻿namespace SumAdjacentEqualNumbers
{ 
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();
            for (int i = 0; i < numbers.Count; i++)
            {
                if ((i + 1) < numbers.Count && numbers[i] == numbers[i + 1])
                {
                    numbers[i] = numbers[i] * 2;
                    numbers.RemoveAt(i + 1);
                    i=-1;
                }
                
            }
            Console.WriteLine(string.Join(" ", numbers.ToArray()));
        }
    }
}
