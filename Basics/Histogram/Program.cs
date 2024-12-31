int n = int.Parse(Console.ReadLine());
double p1 = 0.00;
double p2 = 0.00;
double p3 = 0.00;
double p4 = 0.00;
double p5 = 0.00;
for (int i = 0; i < n; i++)
{
    int newValue = int.Parse(Console.ReadLine());
    if (newValue < 200) p1++;
    else if (newValue < 400) p2++;
    else if (newValue < 600) p3++;
    else if (newValue < 800) p4++;
    else if (newValue >= 800) p5++;
}
p1 = p1 / (double)n * 100;
p2 = p2 / (double)n * 100;
p3 = p3 / (double)n * 100;
p4 = p4 / (double)n * 100;
p5 = p5 / (double)n * 100;

Console.WriteLine($"{p1:f2}%");
Console.WriteLine($"{p2:f2}%");
Console.WriteLine($"{p3:f2}%");
Console.WriteLine($"{p4:f2}%");
Console.WriteLine($"{p5:f2}%"); 