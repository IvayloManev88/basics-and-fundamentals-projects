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

        while (inputNumbers.Length > 1)
        {
            int[] consolidated = new int[inputNumbers.Length - 1];
            for (int i = 0; i < inputNumbers.Length - 1; i++)
            {
                consolidated[i] = inputNumbers[i] + inputNumbers[i + 1];
            }
            inputNumbers = consolidated;
        }
        Console.WriteLine(inputNumbers[0]);
    }
}