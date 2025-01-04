using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        int[] firstRowOfNumbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();
        int[] secondRowOfNumbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();
        int sum = 0;
        for (int i = 0; i < firstRowOfNumbers.Length; i++)
        {
            if (firstRowOfNumbers[i] != secondRowOfNumbers[i])
            {
                Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                return;
            }
            else sum += firstRowOfNumbers[i];
        }
        Console.WriteLine($"Arrays are identical. Sum: {sum}");
    }
}