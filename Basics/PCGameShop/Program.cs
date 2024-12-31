int countSoldGames = int.Parse(Console.ReadLine());
int countHearthstone = 0;
int countFornite = 0;
int countOverwatch = 0;
int countOthers = 0;
for  (int i = 0; i < countSoldGames; i++)
{
    
    string gameName = Console.ReadLine();
    if (gameName == "Hearthstone") countHearthstone++;
    else if (gameName == "Fornite") countFornite++;
    else if (gameName == "Overwatch") countOverwatch++;
    else countOthers++;

}
Console.WriteLine($"Hearthstone - {countHearthstone/(double)(countSoldGames):p2}");
Console.WriteLine($"Fornite - {countFornite / (double)(countSoldGames):p2}");
Console.WriteLine($"Overwatch - {countOverwatch / (double)(countSoldGames):p2}");
Console.WriteLine($"Others - {countOthers / (double)(countSoldGames):p2}");