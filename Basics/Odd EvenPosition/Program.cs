int n = int.Parse(Console.ReadLine());
double oddSum = 0.00;
double evenSum = 0.00;
double oddMin = 1000000000.0;
double evenMin = 1000000000.0;
double oddMax = -1000000000.0;
double evenMax = -1000000000.0;
for (int i = 0; i < n; i++)
{
    double number = double.Parse(Console.ReadLine());
    //odd
    if (i%2==0)
    {
        oddSum += number;
        if (oddMin>number) oddMin = number;
        if (oddMax<number) oddMax = number;

    }
    //even
    else
    {
        evenSum += number;
        if (evenMin > number) evenMin = number;
        if (evenMax < number) evenMax = number;
    }

}
Console.WriteLine($"OddSum={oddSum:f2},");
if (oddMin == 1000000000.0) Console.WriteLine("OddMin=No,");
else Console.WriteLine($"OddMin={oddMin:f2},");
if (oddMax == -1000000000.0) Console.WriteLine("OddMax=No,");
else Console.WriteLine($"OddMax={oddMax:f2},");
Console.WriteLine($"EvenSum={evenSum:f2},");
if (evenMin == 1000000000.0) Console.WriteLine("EvenMin=No,");
else Console.WriteLine($"EvenMin={evenMin:f2},");
if (evenMax == -1000000000.0) Console.WriteLine("EvenMax=No");
else Console.WriteLine($"EvenMax={evenMax:f2}");