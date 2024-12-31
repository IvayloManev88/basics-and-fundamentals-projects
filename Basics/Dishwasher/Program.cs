int detergentCount = int.Parse(Console.ReadLine());
int detergentMililiters = detergentCount * 750;
string input = "";
int Counter = 0;
int dish = 0;
int pot = 0;
while ((input = Console.ReadLine()) != "End")
{
    int numberOfDishes = int.Parse(input);
    Counter++;
    if (Counter % 3 == 0)
    {
        detergentMililiters -= numberOfDishes * 15;
        pot += numberOfDishes;

    }
    else
    {
        detergentMililiters -= numberOfDishes * 5;
        dish += numberOfDishes;
    }
    if (detergentMililiters < 0)
    {
        Console.WriteLine($"Not enough detergent, {Math.Abs(detergentMililiters)} ml. more necessary!");
        return;
    }
}
    
Console.WriteLine("Detergent was enough!");
Console.WriteLine($"{dish} dishes and {pot} pots were washed.");
Console.WriteLine($"Leftover detergent {detergentMililiters} ml.");