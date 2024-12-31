double priceOver20kg = double.Parse(Console.ReadLine ());
double luggageWeight  = double.Parse(Console.ReadLine ());
int daysTravel  = int.Parse(Console.ReadLine());
int luggageCount = int.Parse(Console.ReadLine());
double totalPrice = 0;
if (luggageWeight < 10) totalPrice = priceOver20kg * 0.2;
else if (luggageWeight <= 20) totalPrice = priceOver20kg * 0.5;
else totalPrice = priceOver20kg;

if (daysTravel < 7) totalPrice = totalPrice * 1.4;
else if (daysTravel <= 30) totalPrice = totalPrice * 1.15;
else totalPrice = totalPrice * 1.1;
Console.WriteLine($"The total price of bags is: {totalPrice* luggageCount:f2} lv. ");