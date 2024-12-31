int tournamentCount = int.Parse(Console.ReadLine());
int initialPoints = int.Parse(Console.ReadLine());
int finalPoints = 0;
double averagePoints = 0;
int countWonTournaments = 0;

for  (int i = 0; i < tournamentCount; i++)
{
    string result = Console.ReadLine();
    if (result == "W")
    {
        countWonTournaments++;
        finalPoints += 2000;
    }
    else if (result == "F") finalPoints += 1200;
    else if (result == "SF") finalPoints += 720;
}
averagePoints = Math.Floor((double)finalPoints / (double)tournamentCount);

Console.WriteLine($"Final points: {finalPoints + initialPoints}");
Console.WriteLine($"Average points: {averagePoints}");
Console.WriteLine($"{(double)countWonTournaments /(double)tournamentCount:p2}");
