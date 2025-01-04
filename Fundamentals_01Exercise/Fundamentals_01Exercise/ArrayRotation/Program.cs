using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        int[] arrayInput = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();
        int[] arrayOutput = new int[arrayInput.Length];
        int numberOfRotations = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfRotations; i++)
        {
            int temp = arrayInput[0];
            for (int j = 0; j <= arrayInput.Length - 1; j++)
            {

                if (j == arrayInput.Length - 1)
                {
                    arrayInput[j] = temp;
                }
                else arrayInput[j] = arrayInput[j + 1];
            }
        }
        Console.WriteLine(string.Join(" ", arrayInput));
    }
}