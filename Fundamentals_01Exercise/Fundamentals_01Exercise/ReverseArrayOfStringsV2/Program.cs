using System;
using System.Linq;					
public class Program
{
    public static void Main()
    {
        string[] inputArray = Console.ReadLine().Split().ToArray();

        Array.Reverse(inputArray);
        Console.WriteLine(string.Join(" ", inputArray));
    }
}