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

        for (int j = 0; j < inputArray.Length; j++)
        {
            int biggerElement = int.MinValue;
            for (int i = j + 1; i < inputArray.Length; i++)
            {

                if (inputArray[i] > biggerElement)
                {
                    biggerElement = inputArray[i];
                }
            }
            if (biggerElement < inputArray[j]) Console.Write(inputArray[j] + " ");
        }
    }
}