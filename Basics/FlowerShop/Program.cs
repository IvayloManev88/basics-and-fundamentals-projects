double magnoliaPrice = 3.25;
double zumbuliPrice = 4.00;
double rosesPrice = 3.50;
double cactusesPrice = 8.00;
int magnoliaCount = int.Parse(Console.ReadLine());
int zumbulicount =  int.Parse(Console.ReadLine());
int rosesCount = int.Parse(Console.ReadLine());
int cactusesCount = int.Parse(Console.ReadLine());
double presentPrice = double.Parse(Console.ReadLine());
double incomeFromSale = (magnoliaPrice * magnoliaCount + zumbuliPrice * zumbulicount + rosesPrice * rosesCount + cactusesPrice * cactusesCount) * 0.95;
if  (incomeFromSale >= presentPrice )
{
    Console.WriteLine($"She is left with {Math.Floor(incomeFromSale - presentPrice)} leva.");
}
else
{
    Console.WriteLine($"She will have to borrow {Math.Ceiling(presentPrice - incomeFromSale)} leva.");
}