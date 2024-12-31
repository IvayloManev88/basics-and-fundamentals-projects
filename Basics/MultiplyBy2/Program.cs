decimal i = decimal.Parse(Console.ReadLine());
decimal multiply = 0;
while (i >= 0)
{
    multiply = 2 * i;
    Console.WriteLine($"Result: {multiply:f2}");
    i = decimal.Parse(Console.ReadLine());
}
Console.WriteLine($"Negative number!");