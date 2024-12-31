

decimal mackerelPrice = decimal.Parse(Console.ReadLine());
decimal sprinklePrice = decimal.Parse(Console.ReadLine());
double bonitoKgs = double.Parse(Console.ReadLine());
double safridKgs = double.Parse(Console.ReadLine());
double clamsKgs = double.Parse(Console.ReadLine());
decimal clamsPrice = (decimal) 7.50;
decimal bonitoPrice = (decimal) 1.60 * mackerelPrice;
decimal safridPrice = (decimal) 1.80 * sprinklePrice;
decimal totalPrice = Decimal.Round(((decimal) clamsKgs * clamsPrice) + ((decimal) safridKgs * safridPrice) + ((decimal) bonitoKgs * bonitoPrice), 2, MidpointRounding.AwayFromZero);

Console.WriteLine(totalPrice.ToString("0.00"));