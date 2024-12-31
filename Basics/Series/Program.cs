double budget = double.Parse(Console.ReadLine());
int n = int.Parse(Console.ReadLine());
double totalPrice = 0;

for  (int i = 0; i < n; i++)
{
    string movieName = Console.ReadLine();
    double moviePrice = double.Parse(Console.ReadLine());
    if (movieName == "Thrones") moviePrice = 0.5 * moviePrice;
    else if (movieName == "Lucifer") moviePrice = 0.6 * moviePrice;
    else if (movieName == "Protector") moviePrice = 0.7 * moviePrice;
    else if (movieName == "TotalDrama") moviePrice = 0.8 * moviePrice;
    else if (movieName == "Area") moviePrice = 0.9 * moviePrice;

    totalPrice += moviePrice;

}
if (totalPrice > budget) Console.WriteLine($"You need {totalPrice - budget:f2} lv. more to buy the series!");
else Console.WriteLine($"You bought all the series and left with {budget - totalPrice:f2} lv.");