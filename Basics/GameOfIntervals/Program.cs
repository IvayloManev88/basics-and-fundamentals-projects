int turnCount = int.Parse(Console.ReadLine());
double p0to9 = 0;
double p10to19 = 0;
double p20to29 = 0;
double p30to39 = 0;
double p40to50 = 0;
double pInvalidNumber = 0;
double totalPoints = 0;
for (int i = 0; i < turnCount; i++)
{
    double number = double.Parse(Console.ReadLine());
    if (number < 0 || number > 50)
    {
        pInvalidNumber++;
        totalPoints = totalPoints / 2.00;
    }
    else if (number < 10)
    {
        p0to9++;
        totalPoints = totalPoints + number * 0.2;
    }
    else if (number < 20)
    {
        p10to19++;
        totalPoints = totalPoints + number * 0.3;
    }
    else if (number < 30)

    {
        p20to29++;
        totalPoints = totalPoints +(number * 0.4);
    }
    else if (number < 40)
    {
        p30to39++;
        totalPoints += 50;
    }
    else
    {
        p40to50++;
        totalPoints += 100;
    }
}
p0to9 = p0to9 / (double)turnCount * 100;
p10to19= p10to19 / (double)turnCount * 100;
p20to29 = p20to29/ (double)turnCount * 100;
p30to39 = p30to39 / (double)turnCount * 100;
p40to50 = p40to50/ (double)turnCount*100;
pInvalidNumber = pInvalidNumber / (double)turnCount * 100;
Console.WriteLine($"{totalPoints:f2}");
Console.WriteLine($"From 0 to 9: {p0to9:f2}%");
Console.WriteLine($"From 10 to 19: {p10to19:f2}%");
Console.WriteLine($"From 20 to 29: {p20to29:f2}%");
Console.WriteLine($"From 30 to 39: {p30to39:f2}%");
Console.WriteLine($"From 40 to 50: {p40to50:f2}%");
Console.WriteLine($"Invalid numbers: {pInvalidNumber:f2}%");