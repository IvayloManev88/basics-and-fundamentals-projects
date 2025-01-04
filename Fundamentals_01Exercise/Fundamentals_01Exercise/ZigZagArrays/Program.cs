using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int countOfRows = int.Parse(Console.ReadLine());
        int[] arrayOne = new int[countOfRows];
        int[] arrayTwo = new int[countOfRows];
        for (int i = 0; i < countOfRows; i++)
        {
            int[] inputArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            if (i % 2 == 0)
            {
                arrayOne[i] = inputArray[0];
                arrayTwo[i] = inputArray[1];
            }
            else
            {
                arrayOne[i] = inputArray[1];
                arrayTwo[i] = inputArray[0];
            }

        }
        Console.WriteLine(string.Join(" ", arrayOne));
        Console.WriteLine(string.Join(" ", arrayTwo));
    }
}