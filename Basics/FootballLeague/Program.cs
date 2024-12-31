int stadiumCapacity = int.Parse(Console.ReadLine());
int fanCount = int.Parse(Console.ReadLine());
double percentA = 0;
double percentB = 0;
double percentV = 0;
double percentG = 0;


for (int i = 0; i < fanCount; i++)
{
    string sector = Console.ReadLine();
    if (sector == "A") percentA++;
    if (sector == "B") percentB++;
    if (sector == "V") percentV++;
    if (sector == "G") percentG++;
}
percentA = percentA / (double)fanCount * 100;
percentB = percentB / (double)fanCount * 100;
percentG = percentG / (double)fanCount * 100;
percentV = percentV / (double)fanCount * 100;
double percentFanToCapacity = fanCount / (double)stadiumCapacity * 100;
Console.WriteLine($"{percentA:f2}%");
Console.WriteLine($"{percentB:f2}%");
Console.WriteLine($"{percentV:f2}%");
Console.WriteLine($"{percentG:f2}%");
Console.WriteLine($"{percentFanToCapacity:F2}%");