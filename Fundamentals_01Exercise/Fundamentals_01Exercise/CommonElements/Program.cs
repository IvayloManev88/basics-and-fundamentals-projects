using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        string[] firstRowInput = Console.ReadLine()
            .Split()
            .ToArray();
        string[] secondRowInput = Console.ReadLine()
            .Split()
            .ToArray();
        for (int i = 0; i < secondRowInput.Length; i++)
        {
            for (int j = 0; j < firstRowInput.Length; j++)
            {
                if (secondRowInput[i] == firstRowInput[j]) Console.Write(firstRowInput[j] + " ");
            }
        }
    }
}