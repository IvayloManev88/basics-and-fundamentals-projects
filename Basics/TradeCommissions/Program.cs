string city = Console.ReadLine();
double salesVolume = double.Parse(Console.ReadLine());
double commission = 0;
if (city == "Sofia")
{
    if (0 <= salesVolume && salesVolume <= 500)
        commission = 0.05;
    else if (500 <= salesVolume && salesVolume <= 1000)
        commission = 0.07;
    else if (1000 <= salesVolume && salesVolume <= 10000)
        commission = 0.08;
    else if (salesVolume > 10000)
        commission = 0.12;
}
else if (city == "Varna")
{
    if (0 <= salesVolume && salesVolume <= 500)
        commission = 0.045;
    else if (500 <= salesVolume && salesVolume <= 1000)
        commission = 0.075;
    else if (1000 <= salesVolume && salesVolume <= 10000)
        commission = 0.10;
    else if (salesVolume > 10000)
        commission = 0.13;
}
else if (city == "Plovdiv")
{
    if (0 <= salesVolume && salesVolume <= 500)
        commission = 0.055;
    else if (500 <= salesVolume && salesVolume <= 1000)
        commission = 0.08;
    else if (1000 <= salesVolume && salesVolume <= 10000)
        commission = 0.12;
    else if (salesVolume > 10000)
        commission = 0.145;
}

if (commission == 0)
    Console.WriteLine("error");

else
{
    double totalCommission = commission * salesVolume;
    Console.WriteLine($"{totalCommission:f2}");
}