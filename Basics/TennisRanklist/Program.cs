int tournamentCount = int.Parse(Console.ReadLine());
int initialPoints = int.Parse(Console.ReadLine());
double totalPoints = initialPoints;
int wonTournaments = 0;
for (int i = 0; i < tournamentCount; i++)
{
    string tournamentPhase = Console.ReadLine();
    if (tournamentPhase == "W")
    {
        wonTournaments++;
        totalPoints += 2000;
    }
    else if (tournamentPhase == "F") totalPoints += 1200;
    else if (tournamentPhase == "SF") totalPoints += 720;
}
Console.WriteLine($"Final points: {totalPoints}");
Console.WriteLine($"Average points: {Math.Floor((totalPoints - initialPoints)/tournamentCount)}");
double percentWon = wonTournaments / (double)tournamentCount * 100;
Console.WriteLine($"{percentWon:f2}%");