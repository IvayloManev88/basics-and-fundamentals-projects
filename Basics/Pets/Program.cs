int daysGone = int.Parse(Console.ReadLine());
int foodInKgs = int.Parse(Console.ReadLine());
double dogFoodPerDay = double.Parse(Console.ReadLine());
double catFoodPerDay = double.Parse(Console.ReadLine());
double turtleFoodPerDayInGRAM = double.Parse(Console.ReadLine());

double dogFoodNeeded = dogFoodPerDay * daysGone;
double catFoodNeeded = catFoodPerDay * daysGone;
double turtleFoodNeeded = turtleFoodPerDayInGRAM * daysGone / 1000.00;
double allFoodLeft = dogFoodNeeded + catFoodNeeded + turtleFoodNeeded;
if (foodInKgs <= allFoodLeft)
{
    Console.WriteLine($"{Math.Ceiling(allFoodLeft - foodInKgs)} more kilos of food are needed.");

}
else
{
    Console.WriteLine($"{Math.Floor(foodInKgs - allFoodLeft)} kilos of food left.");
}