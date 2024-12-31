double priceSpring = 3000;
double priceAutumn = 4200;
double priceSummer = 4200;
double priceWinter = 2600;
int budget = int.Parse(Console.ReadLine());
string season = Console.ReadLine();
int numberFisherman = int.Parse(Console.ReadLine());
double totalMoney = 0;
double boatPrice = 0;
double moneyLeft = 0;
if (numberFisherman <= 6)
{
    if (season == "Spring") boatPrice = priceSpring;
    else if (season == "Summer") boatPrice = priceSummer;
    else if (season == "Autumn") boatPrice = priceAutumn;
    else if (season =="Winter") boatPrice= priceWinter;
    totalMoney = boatPrice * 0.9;
}
else if (numberFisherman >=12)
{
    if (season == "Spring") boatPrice = priceSpring;
    else if (season == "Summer") boatPrice = priceSummer;
    else if (season == "Autumn") boatPrice = priceAutumn;
    else if (season == "Winter") boatPrice = priceWinter;
    totalMoney = boatPrice * 0.75;
}
else
{
    if (season == "Spring") boatPrice = priceSpring;
    else if (season == "Summer") boatPrice = priceSummer;
    else if (season == "Autumn") boatPrice = priceAutumn;
    else if (season == "Winter") boatPrice = priceWinter;
    totalMoney = boatPrice * 0.85;
}

if ((totalMoney != 0 ) && (numberFisherman % 2 == 0) && (season != "Autumn"))
{
    totalMoney = totalMoney * 0.95;
}
if (budget >= totalMoney)
{
    moneyLeft = budget - totalMoney;
    Console.WriteLine($"Yes! You have {moneyLeft:f2} leva left.");
}
else
{
    moneyLeft = totalMoney - budget;
    Console.WriteLine($"Not enough money! You need {moneyLeft:f2} leva.");
}