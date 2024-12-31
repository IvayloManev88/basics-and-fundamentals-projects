string typeOfFuel = Console.ReadLine();
double fuelType = double.Parse(Console.ReadLine());

if (typeOfFuel == "Diesel")
{
    if (fuelType >= 25)
        Console.WriteLine($"You have enough diesel.");
    else Console.WriteLine($"Fill your tank with diesel!");
}
else if (typeOfFuel == "Gasoline")
{
    if (fuelType >= 25)
        Console.WriteLine($"You have enough gasoline.");
    else Console.WriteLine($"Fill your tank with gasoline!");
}
else if (typeOfFuel == "Gas")
{
    if (fuelType >= 25)
        Console.WriteLine($"You have enough gas.");
    else Console.WriteLine($"Fill your tank with gas!");
}
else Console.WriteLine($"Invalid fuel!");