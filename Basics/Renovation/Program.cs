int length = int.Parse(Console.ReadLine());
int height  = int.Parse(Console.ReadLine());
int noPaintPercent  = int.Parse(Console.ReadLine());
double paintVolume =Math.Ceiling(4*( (length * height) * (1 - (noPaintPercent / 100.00))));
int currentPaintedVolume = 0;
string input = "";
while ((input = Console.ReadLine()) != "Tired!")
{
    int liters = int.Parse(input);
    currentPaintedVolume += liters;
    if (currentPaintedVolume >= paintVolume) break;
}

if (currentPaintedVolume < paintVolume) Console.WriteLine($"{paintVolume - currentPaintedVolume} quadratic m left.");
else if (currentPaintedVolume > paintVolume) Console.WriteLine($"All walls are painted and you have {currentPaintedVolume - paintVolume} l paint left!");
else Console.WriteLine("All walls are painted! Great job, Pesho!");