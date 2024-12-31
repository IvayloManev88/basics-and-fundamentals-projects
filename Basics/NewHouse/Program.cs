string typeFlowers = Console.ReadLine();
int numberFlowers = int.Parse(Console.ReadLine());
int budget = int.Parse(Console.ReadLine());
double priceRoses = 5.00;
double priceDahlias = 3.80;
double priceNarcissus = 3.00;
double priceTulips = 2.80; 
double priceGladiolus = 2.50;
double totalPrice = 0.00;
double remainingMoney = 0;
switch (typeFlowers)
{
    case "Roses":
        
            if (numberFlowers > 80)
            {
                totalPrice = 0.9 * numberFlowers * priceRoses;
            }
            else totalPrice = numberFlowers * priceRoses;
        break;
    case "Dahlias":
        if (numberFlowers > 90)
        {
            totalPrice = 0.85 * numberFlowers * priceDahlias;
        }
        else totalPrice = numberFlowers * priceDahlias;
        break;
    case "Tulips":
        if (numberFlowers > 80)
        {
            totalPrice = 0.85 * numberFlowers * priceTulips;
        }
        else totalPrice = numberFlowers * priceTulips;
        break;
    case "Narcissus":
        if (numberFlowers < 120)
        {
            totalPrice = 1.15 * numberFlowers * priceNarcissus;
        }
        else totalPrice = numberFlowers * priceNarcissus;
        break;
    case "Gladiolus":
        if (numberFlowers < 80)
        {
            totalPrice = 1.20 * numberFlowers * priceGladiolus;
        }
        else totalPrice = numberFlowers * priceGladiolus;
        break;
}

if (budget >= totalPrice)
{
    remainingMoney = budget - totalPrice;
    Console.WriteLine($"Hey, you have a great garden with {numberFlowers} {typeFlowers} and {remainingMoney:f2} leva left.");
}
else
{
    remainingMoney =totalPrice - budget;
    Console.WriteLine($"Not enough money, you need {remainingMoney:f2} leva more.");
}