using System.ComponentModel.Design;

string fruit = Console.ReadLine();
string dayOfWeek = Console.ReadLine();
double amount = double.Parse(Console.ReadLine());
double price = 0.00;
if (dayOfWeek == "Monday" || dayOfWeek == "Tuesday" || dayOfWeek == "Wednesday" || dayOfWeek == "Thursday" || dayOfWeek == "Friday")
{
    switch (fruit)
    {
        case "banana": price = 2.5; break;
        case "apple": price = 1.2; break;
        case "orange": price = 0.85; break;
        case "grapefruit": price = 1.45; break;
        case "kiwi": price = 2.7; break;
        case "pineapple": price = 5.50; break;
        case "grapes": price = 3.85; break;

        
    }
}
else if (dayOfWeek == "Saturday" || dayOfWeek == "Sunday")
{
    switch (fruit)
    {
        case "banana": price = 2.7; break;
        case "apple": price = 1.25; break;
        case "orange": price = 0.90; break;
        case "grapefruit": price = 1.60; break;
        case "kiwi": price = 3.00; break;
        case "pineapple": price = 5.60; break;
        case "grapes": price = 4.20; break;

        
    }
}
if (price == 0)
    Console.WriteLine("error");
else
{
    double totalPrice = price * amount;
    Console.WriteLine($"{totalPrice:f2}");
}