using System;

decimal puzzle = (decimal)2.60;
decimal talkingDoll = (decimal)3;
decimal bear = (decimal)4.1;
decimal minion = (decimal)8.2;
decimal truck = (decimal)2;
decimal excursionPrice = decimal.Parse(Console.ReadLine());
int puzzleCount = int.Parse(Console.ReadLine());
int talkingDollCount = int.Parse(Console.ReadLine());
int bearCount = int.Parse(Console.ReadLine());
int minionCount = int.Parse(Console.ReadLine());
int truckCount = int.Parse(Console.ReadLine());

decimal totalIncome = puzzle * puzzleCount + talkingDoll * talkingDollCount + bear * bearCount + minion * minionCount + truck * truckCount;

if ((puzzleCount + talkingDollCount + bearCount + minionCount + truckCount) >= 50 )
{
    totalIncome = totalIncome * (decimal)0.75;
}
decimal rent = (decimal)0.1 * totalIncome;
totalIncome = totalIncome - rent;

if ((totalIncome - excursionPrice) >= 0)
{
    decimal incomeAfterExcursion = totalIncome - excursionPrice;
    Console.WriteLine($"Yes! {incomeAfterExcursion:f2} lv left.");
}
else
{
    decimal incomeAfterExcursion = excursionPrice - totalIncome;
   Console.WriteLine($"Not enough money! {incomeAfterExcursion:f2} lv needed.");
}