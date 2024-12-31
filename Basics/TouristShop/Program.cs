double budget = double.Parse(Console.ReadLine());
string input = "";
double totalPrice = 0;
int count = 0;
while ((input = Console.ReadLine()) != "Stop")
{
    double productPrice = double.Parse(Console.ReadLine());
    count++;
    if (count % 3 == 0) productPrice /= 2;
    totalPrice += productPrice;
    if (totalPrice > budget)
    {
        Console.WriteLine($"You don't have enough money!");
        Console.WriteLine($"You need {(totalPrice - budget):f2} leva!");
        return;
    }
    
}
Console.WriteLine($"You bought {count} products for {totalPrice:f2} leva.");
