double budget = double.Parse(Console.ReadLine());
int statistCount = int.Parse(Console.ReadLine());
double clothesPrice = double.Parse(Console.ReadLine());

double decor = 0.1 * budget;
double statistTotalPrice = 0;
if (statistCount > 150)
{
    statistTotalPrice = statistCount * clothesPrice * 0.9;
}
else
{
    statistTotalPrice = statistCount * clothesPrice;
}
double finalPrice = budget - statistTotalPrice - decor;
if (finalPrice >= 0)
{
    Console.WriteLine($"Action!");
    Console.WriteLine($"Wingard starts filming with {finalPrice:f2} leva left.");
}
else
{
    Console.WriteLine($"Not enough money!");
    Console.WriteLine($"Wingard needs {Math.Abs(finalPrice):f2} leva more.");
}