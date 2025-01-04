using System;


public class Program
{
    public static void Main()
    {
        int counter = int.Parse(Console.ReadLine());
        int[] numbers = new int[counter];
        for (int i = 0; i < counter; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }
        for (int j = counter - 1; j >= 0; j--)
        {
            Console.Write(numbers[j] + " ");
        }
    }
}