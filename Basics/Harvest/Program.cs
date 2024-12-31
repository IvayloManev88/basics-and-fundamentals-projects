int area = int.Parse(Console.ReadLine());
double grapePerSquareMeter = double.Parse(Console.ReadLine());
int wineNeeded = int.Parse(Console.ReadLine());
int employeeCount = int.Parse(Console.ReadLine());

double wineArea = area * 0.4;
double grapeKgs = wineArea * grapePerSquareMeter;
double litersProduced = (grapeKgs / 2.5);
if (wineNeeded > litersProduced)
{
    Console.WriteLine($"It will be a tough winter! More {Math.Floor(wineNeeded - litersProduced)} liters wine needed.");
}
else
{
    double restWine = Math.Ceiling(litersProduced - wineNeeded);
    Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(litersProduced)} liters.");
    double litersPerPerson = Math.Ceiling(restWine / employeeCount);
    Console.WriteLine($"{restWine} liters left -> {litersPerPerson} liters per person.");
}

