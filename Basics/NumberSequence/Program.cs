int n = int.Parse(Console.ReadLine());
int max = int.MinValue;
int min = int.MaxValue;
for (int i = 0; i < n; i++)
{
    int currentNumber = int.Parse(Console.ReadLine());
    if (currentNumber > max) max = currentNumber;
    if (currentNumber < min) min = currentNumber;
}
Console.WriteLine($"Max number: {max}");
Console.WriteLine($"Min number: {min}");