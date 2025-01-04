using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        int[] inputNumbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();
        int sumOddNumnbers = 0;
        int sumEvenNumbers = 0;
        foreach (int currentNumber in inputNumbers)
        {
            if (currentNumber % 2 == 0) sumEvenNumbers += currentNumber;
            else sumOddNumnbers += currentNumber;
        }
        Console.WriteLine(sumEvenNumbers - sumOddNumnbers);
    }
}