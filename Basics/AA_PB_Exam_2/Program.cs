double tShirtPrice = double.Parse(Console.ReadLine());
double budgetToHit = double.Parse(Console.ReadLine());
double shortsPrice = 0.75 * tShirtPrice;
double socksPrice = 0.2 * shortsPrice;
double shoesPrice = 2 * (tShirtPrice + shortsPrice);
double total = 0.85 * (tShirtPrice + shortsPrice + socksPrice + shoesPrice);
if (total >= budgetToHit)

{
    Console.WriteLine("Yes, he will earn the world-cup replica ball!");
    Console.WriteLine($"His sum is {total:f2} lv.");
}
else
{
    Console.WriteLine("No, he will not earn the world-cup replica ball.");
    Console.WriteLine($"He needs {(budgetToHit - total):f2} lv. more.");
}