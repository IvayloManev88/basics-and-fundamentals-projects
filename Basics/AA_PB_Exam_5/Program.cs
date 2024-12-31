

int countSeaVacation = int.Parse(Console.ReadLine());
int countMountaintVacation = int.Parse(Console.ReadLine());
int countSeaSold = 0;
int countMountainSold  = 0;

double totalProfit = 0;
string input = "";
while ((input = Console.ReadLine())!="Stop")
{
    if (input == "sea")
    {
        if (countSeaSold < countSeaVacation)
        { 
        countSeaSold++;
        totalProfit += 680;
        }
        else continue;  
    }
    else if (input == "mountain")
    {
        if (countMountainSold < countMountaintVacation)
        {
            countMountainSold++;
            totalProfit += 499;
        }
    }
    if ((countSeaSold >= countSeaVacation) && (countMountainSold >= countMountaintVacation))
    {
        Console.WriteLine("Good job! Everything is sold.");
        break;
    }
}
Console.WriteLine($"Profit: {totalProfit} leva.");
