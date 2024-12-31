int dancersCount = int.Parse(Console.ReadLine());
double pointsCount = double.Parse(Console.ReadLine());
string season = Console.ReadLine();
string place  = Console.ReadLine();
double priceAmount = 0;
if (place == "Bulgaria") priceAmount = pointsCount * dancersCount;
else if (place == "Abroad") priceAmount = 1.5 * (pointsCount * dancersCount);

if (place == "Bulgaria")
{
    if (season == "summer") priceAmount = priceAmount * 0.95;
    else if (season == "winter") priceAmount = priceAmount * 0.92;
}
else if (place == "Abroad")
{
    {
        if (season == "summer") priceAmount = priceAmount * 0.90;
        else if (season == "winter") priceAmount = priceAmount * 0.85;
    }
}
double donation = priceAmount * 0.75;
double amountPerPerson = (priceAmount * 0.25) / (double)dancersCount;

Console.WriteLine($"Charity - {donation:f2}");
Console.WriteLine($"Money per dancer - {amountPerPerson:f2}");
