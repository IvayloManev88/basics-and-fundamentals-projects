using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        string[] inputArray = Console.ReadLine().Split().ToArray();
        for (int i = 0; i < inputArray.Length / 2; i++)
        {
            string temp = inputArray[i];
            inputArray[i] = inputArray[inputArray.Length - 1 - i];
            inputArray[inputArray.Length - 1 - i] = temp;
        }
        Console.WriteLine(string.Join(" ", inputArray));
    }
}