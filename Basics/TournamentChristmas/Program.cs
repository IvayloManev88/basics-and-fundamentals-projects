int tournamentCount = int.Parse(Console.ReadLine());
string input = "";
string lossOrWin = "";

int daysWon = 0;

double totalProfit = 0;
for (int i = 0; i < tournamentCount; i++)
{
    int countLoss = 0;
    int countWins = 0;
    double moneyForTheDay = 0;
    while ((input = Console.ReadLine())!="Finish")
    {
        lossOrWin = Console.ReadLine();
       if (lossOrWin == "win") { moneyForTheDay += 20; countWins++; }
        else countLoss++;
              
    }
    if (countWins > countLoss)
    {
        moneyForTheDay = moneyForTheDay * 1.1;
        daysWon++;
    }
    totalProfit += moneyForTheDay;

}
if (daysWon > (tournamentCount / 2.0))
{
    totalProfit = 1.2 * totalProfit;
    Console.WriteLine($"You won the tournament! Total raised money: {totalProfit:f2}");
}
else Console.WriteLine($"You lost the tournament! Total raised money: {totalProfit:f2}");

