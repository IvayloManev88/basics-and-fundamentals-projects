string typeProjection = Console.ReadLine();
int r = int.Parse(Console.ReadLine());
int c = int.Parse(Console.ReadLine());
double pricePremiere = 12.00;
double priceNormal = 7.50;
double discount = 5.00;
double totalIncome = 0;

if (typeProjection == "Premiere")
{
    totalIncome = pricePremiere * r * c;
    Console.WriteLine($"{totalIncome:f2} leva");
}
else if (typeProjection == "Normal")
{
    totalIncome = priceNormal * r * c;
    Console.WriteLine($"{totalIncome:f2} leva");
}
else if (typeProjection == "Discount")
{
    totalIncome = discount * r * c;
    Console.WriteLine($"{totalIncome:f2} leva");
}