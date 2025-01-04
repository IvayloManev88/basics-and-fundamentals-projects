using System;
using System.Linq;

public class Program
{
    public static void Main()
    {

        int numberOfWagons = int.Parse(Console.ReadLine());
        int[] passangerArray = new int[numberOfWagons];
        int sum = 0;
        for (int i = 0; i <= (passangerArray.Length - 1); i++)
        {
            passangerArray[i] = int.Parse(Console.ReadLine());
            sum += passangerArray[i];
        }
        Console.WriteLine(string.Join(" ", passangerArray));
        Console.WriteLine(sum);
    }
}