﻿namespace RemoveNegativesAndReverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            numbers.RemoveAll(n => n < 0);
            numbers.Reverse();
            if (numbers.Count ==0)
            {
                Console.WriteLine("empty");

            }
            else
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}
