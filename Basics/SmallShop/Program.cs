string product = Console.ReadLine();
string city = Console.ReadLine();
double quantity = double.Parse(Console.ReadLine());
double price = 0.00;
if (city == "Sofia")
{
    if (product == "coffee") price = 0.5;
    if (product == "water") price = 0.8;
    if (product == "beer") price = 1.2;
    if (product == "sweets") price = 1.45;
    if (product == "peanuts") price = 1.60;
}
else if (city == "Plovdiv")
{
    if (product == "coffee") price = 0.4;
    if (product == "water") price = 0.7;
    if (product == "beer") price = 1.15;
    if (product == "sweets") price = 1.3;
    if (product == "peanuts") price = 1.5;
}
else if (city == "Varna")
{
    if (product == "coffee") price = 0.45;
    if (product == "water") price = 0.7;
    if (product == "beer") price = 1.1;
    if (product == "sweets") price = 1.35;
    if (product == "peanuts") price = 1.55;
}
double totalPrice = price * quantity;
Console.WriteLine(totalPrice);