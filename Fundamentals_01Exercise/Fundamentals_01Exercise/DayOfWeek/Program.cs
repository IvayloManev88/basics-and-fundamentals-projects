using System;


public class Program
{
    public static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        string[] daysOfWeek = new string[]
        {
    "Monday",
    "Tuesday",
    "Wednesday",
    "Thursday",
    "Friday",
    "Saturday",
    "Sunday"
        };
        if ((number - 1) >= daysOfWeek.Length || number <= 0) Console.WriteLine("Invalid day!");
        else Console.WriteLine(daysOfWeek[number - 1]);

    }
}