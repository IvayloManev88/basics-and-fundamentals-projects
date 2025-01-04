using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        double[] initialNumbers = Console.ReadLine().Split().Select(double.Parse).ToArray();
        int[] roundedNumbers = new int[initialNumbers.Length];
        for (int i = 0; i < initialNumbers.Length; i++)
        {
            roundedNumbers[i] = (int)Math.Round(initialNumbers[i], 0, MidpointRounding.AwayFromZero);
            Console.WriteLine($"{initialNumbers[i]} => {roundedNumbers[i]}");
        }

    }
}