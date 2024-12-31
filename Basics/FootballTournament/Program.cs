string teamName = Console.ReadLine();
int matchesPlayed = int.Parse(Console.ReadLine());
int countWins = 0;
int countDraws = 0;
int countLoses = 0;
int totalPoints = 0;
if (matchesPlayed == 0)
{
    Console.WriteLine($"{teamName} hasn't played any games during this season.");
    }
else
{
    for (int i = 0; i < matchesPlayed; i++)
    {
        string matchOutcome = Console.ReadLine();
        if (matchOutcome == "W") { countWins++; totalPoints += 3; }
        else if (matchOutcome == "D") { countDraws++; totalPoints++; }
        else if (matchOutcome == "L") countLoses++;
    }
    Console.WriteLine($"{teamName} has won {totalPoints} points during this season.");
    Console.WriteLine("Total stats:");
    Console.WriteLine($"## W: {countWins}");
    Console.WriteLine($"## D: {countDraws}");
    Console.WriteLine($"## L: {countLoses}");
    Console.WriteLine($"Win rate: {(countWins/(double)(countWins+ countDraws+ countLoses)):p2}");
}