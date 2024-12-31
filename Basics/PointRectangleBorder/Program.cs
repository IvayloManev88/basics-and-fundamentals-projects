using System.ComponentModel.Design;

decimal x1 = decimal.Parse(Console.ReadLine());
decimal y1  = decimal.Parse(Console.ReadLine());
decimal x2 = decimal.Parse(Console.ReadLine());
decimal y2  = decimal.Parse(Console.ReadLine());
decimal x = decimal.Parse(Console.ReadLine());
decimal y = decimal.Parse(Console.ReadLine());

if (x == x1 || x == x2)
{
    if (y1 <= y && y <= y2)
        Console.WriteLine($"Border");
    else Console.WriteLine($"Inside / Outside");
}
else if (y == y1 || y == y2)
{
    if (x1 <= x && x <= x2)
        Console.WriteLine($"Border");
    else Console.WriteLine($"Inside / Outside");
}
else Console.WriteLine($"Inside / Outside");

