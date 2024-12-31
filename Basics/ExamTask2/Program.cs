
int goalsOurTeam = 0;
int goalsOtherTeam = 0;
string resultMatch = "";
int countWonMatches  = 0;
int countLostMatches = 0;
int countDrawMatches = 0;
for (int i=0; i<3; i++)
{
    resultMatch = Console.ReadLine();
    goalsOurTeam = int.Parse(resultMatch[0].ToString());
    goalsOtherTeam = int.Parse(resultMatch[2].ToString());
    if (goalsOurTeam > goalsOtherTeam) countWonMatches++;
    else if (goalsOurTeam < goalsOtherTeam) countLostMatches++;
    else if (goalsOurTeam == goalsOtherTeam) countDrawMatches++;

}
Console.WriteLine($"Team won {countWonMatches} games.");
Console.WriteLine($"Team lost {countLostMatches} games.");
Console.WriteLine($"Drawn games: {countDrawMatches}");