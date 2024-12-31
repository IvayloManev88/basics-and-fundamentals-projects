using System;
using System.ComponentModel.Design;

int n = int.Parse(Console.ReadLine());
string timeOfDay = Console.ReadLine();

if (timeOfDay == "day")
{

    if (n < 20)
    {
        double transportPriceTaxi = Math.Round(0.7 + 0.79 * n, 2);
        Console.WriteLine($"{transportPriceTaxi:f2}");
    }
    else if (n >= 100)
    {
        double transportPriceTaxi = Math.Round(0.7 + 0.79 * n, 2);
        double transportPriceBus = Math.Round(0.09 * n, 2);
        double transportPriceTrain = Math.Round(0.06 * n, 2);
        if (transportPriceTaxi > transportPriceBus && transportPriceBus > transportPriceTrain)
        {
            Console.WriteLine($"{transportPriceTrain:f2}");
        }
        else if (transportPriceTaxi > transportPriceBus && transportPriceBus < transportPriceTrain)
        {
            Console.WriteLine($"{transportPriceBus:f2}");
        }
        else
            Console.WriteLine($"{transportPriceTaxi:f2}");
    }
    else
    {
        double transportPriceTaxi = Math.Round(0.7 + 0.79 * n, 2);
        double transportPriceBus = Math.Round(0.09 * n, 2);
        if (transportPriceTaxi > transportPriceBus)
        {
            Console.WriteLine($"{transportPriceBus:f2}");
        }
        else
        {
            Console.WriteLine($"{transportPriceTaxi:f2}");
        }
    }
   
    
}
else
{
    if (n < 20)
    {
        double transportPriceTaxi = Math.Round(0.7 + 0.9 * n, 2);
        Console.WriteLine($"{transportPriceTaxi:f2}");
    }
    else if (n >= 100)
    {
        double transportPriceTaxi = Math.Round(0.7 + 0.9 * n, 2);
        double transportPriceBus = Math.Round(0.09 * n, 2);
        double transportPriceTrain = Math.Round(0.06 * n, 2);
        if (transportPriceTaxi > transportPriceBus && transportPriceBus > transportPriceTrain)
        {
            Console.WriteLine($"{transportPriceTrain:f2}");
        }
        else if (transportPriceTaxi > transportPriceBus && transportPriceBus < transportPriceTrain)
        {
            Console.WriteLine($"{transportPriceBus:f2}");
        }
        else
            Console.WriteLine($"{transportPriceTaxi:f2}");
    }
    else
    {
        double transportPriceTaxi = Math.Round(0.7 + 0.9 * n, 2);
        double transportPriceBus = Math.Round(0.09 * n, 2);
        if (transportPriceTaxi > transportPriceBus)
        {
            Console.WriteLine($"{transportPriceBus:f2}");
        }
        else
        {
            Console.WriteLine($"{transportPriceTaxi:f2}");
        }
    }
}











