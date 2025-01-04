using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        string[] inputArray = Console.ReadLine().Split().ToArray();
        string[] reverseArray = new string[inputArray.Length];
        for (int i = 0; i < inputArray.Length; i++)
        {
            reverseArray[i] = inputArray[inputArray.Length - 1 - i];
        }
        Console.WriteLine(string.Join(" ", reverseArray));
    }
}