using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int[] inputArray = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();
        int counter = 1;
        int MaxCounter = 1;
        int numberToPrint = inputArray[0];
        for (int i = 0; i < inputArray.Length - 1; i++)
        {
            if (inputArray[i] == inputArray[i + 1])
            {
                counter++;
            }
            else counter = 1;
            if (counter > MaxCounter)
            {
                MaxCounter = counter;
                numberToPrint = inputArray[i];
            }
        }
        for (int j = 0; j < MaxCounter; j++)
        {
            Console.Write(numberToPrint + " ");
        }
    }
}