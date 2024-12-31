int n = int.Parse(Console.ReadLine());
double allLiters = 0;
double allDegrees = 0;
for (int i = 0; i < n; i++)
{
    double liters = double.Parse(Console.ReadLine());
    double degrees = double.Parse(Console.ReadLine());
    allLiters += liters;
    allDegrees += degrees * liters;
}

Console.WriteLine($"Liter: {allLiters:f2}");
double averageDegrees = allDegrees / allLiters;
Console.WriteLine($"Degrees: {averageDegrees:f2}");
if (averageDegrees < 38) Console.WriteLine("Not good, you should baking!");
else if  (averageDegrees <=42) Console.WriteLine("Super!");
else  Console.WriteLine("Dilution with distilled water!");