using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int sum = 0;
        foreach (int number in numbers)
        {
            if (number % 2 == 0)
            {
                sum += number;
            }
        }
        Console.WriteLine(sum);
    }
}