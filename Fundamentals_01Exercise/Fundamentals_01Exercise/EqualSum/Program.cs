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
        bool areEqual = false;
        for (int i = 0; i < inputArray.Length; i++)
        {
            int leftSum = 0;
            int rightSum = 0;
            if (i == 0) leftSum = 0;
            else
            {

                for (int j = i - 1; j >= 0; j--)
                {
                    leftSum += inputArray[j];
                }
            }
            if (i == (inputArray.Length - 1)) rightSum = 0;
            else
            {
                for (int k = i + 1; k < inputArray.Length; k++)
                {
                    rightSum += inputArray[k];
                }
            }
            if (rightSum == leftSum)
            {
                areEqual = true;
                Console.WriteLine(i);
            }
        }
        if (!areEqual) Console.WriteLine("no");
    }
}