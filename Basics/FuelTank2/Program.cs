double gasolinePrice = 2.22;
double dieselPrice = 2.33;
double gasPrice = 0.93;

string typeOfFuel = Console.ReadLine();
int fuelLiters = int.Parse(Console.ReadLine());
string clubCard = Console.ReadLine();
double discountVolume = 0.00;
double totalFuelPrice = 0.00;
if (fuelLiters > 25)
{
    discountVolume = 0.10;
}
else if (fuelLiters > 20)
{
    discountVolume = 0.08;
}
else
{
    discountVolume = 0.00;
}

if (clubCard == "Yes")
{
    if (typeOfFuel == "Gas")
        {
        totalFuelPrice = ((0.93 - 0.08) * fuelLiters) - ((0.93 - 0.08) * fuelLiters) * discountVolume;
        Console.WriteLine($"{totalFuelPrice:f2} lv.");
        }     
    else if (typeOfFuel == "Gasoline")
        {
        totalFuelPrice = ((2.22 - 0.18) * fuelLiters) - ((2.22 - 0.18) * fuelLiters) * discountVolume;
        Console.WriteLine($"{totalFuelPrice:f2} lv.");
        }
    else if (typeOfFuel == "Diesel")
        {
        totalFuelPrice = ((2.33 - 0.12) * fuelLiters) - ((2.33 - 0.12) * fuelLiters) * discountVolume;
        Console.WriteLine($"{totalFuelPrice:f2} lv.");
        }
}
else if (clubCard == "No")
{
    if (typeOfFuel == "Gas")
    {
        totalFuelPrice = ((0.93) * fuelLiters) - ((0.93) * fuelLiters) * discountVolume;
        Console.WriteLine($"{totalFuelPrice:f2} lv.");
    }
    else if (typeOfFuel == "Gasoline")
    {
        totalFuelPrice = ((2.22) * fuelLiters) - ((2.22) * fuelLiters) * discountVolume;
        Console.WriteLine($"{totalFuelPrice:f2} lv.");
    }
    else if (typeOfFuel == "Diesel")
    {
        totalFuelPrice = ((2.33) * fuelLiters) - ((2.33) * fuelLiters) * discountVolume;
        Console.WriteLine($"{totalFuelPrice:f2} lv.");
    }
}