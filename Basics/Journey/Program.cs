double budget = double.Parse(Console.ReadLine());
string season = Console.ReadLine();
string destination = "";
string typeOfStay = "";
double moneySpent = 0;

if (budget <= 100)
{
    destination = "Bulgaria";
    if (season == "summer")
    {
        typeOfStay = "Camp";
        moneySpent = 0.3 * budget;
    }
    else if (season == "winter")
    {
        typeOfStay = "Hotel";
        moneySpent = 0.7 * budget;
    }
}
else if (budget > 1000)
{
    destination = "Europe";
    typeOfStay = "Hotel";
    moneySpent = 0.9 * budget;
}
else
{
    destination = "Balkans";
    if (season == "summer")
    {
        typeOfStay = "Camp";
        moneySpent = 0.4 * budget;
    }
    else if (season == "winter")
    {
        typeOfStay = "Hotel";
        moneySpent = 0.8 * budget;
    }
}

Console.WriteLine($"Somewhere in {destination}");
Console.WriteLine($"{typeOfStay} - {moneySpent:f2}");