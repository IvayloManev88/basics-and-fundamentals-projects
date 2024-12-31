string country = Console.ReadLine();
string discipline = Console.ReadLine();

double scoreDifficulty = 0;
double scorePerformance = 0;

if  (country == "Russia")
{
    if (discipline == "ribbon")
    {
        scoreDifficulty = 9.100;
        scorePerformance = 9.400;
    }
    else if (discipline == "hoop")
    {
        scoreDifficulty = 9.300;
        scorePerformance = 9.800;
    }
    else if (discipline== "rope")
    {
        scoreDifficulty = 9.600;
        scorePerformance = 9.000;
    }
}
else if (country == "Bulgaria")
{
    if (discipline == "ribbon")
    {
        scoreDifficulty = 9.600;
        scorePerformance = 9.400;
    }
    else if (discipline == "hoop")
    {
        scoreDifficulty = 9.550;
        scorePerformance = 9.750;
    }
    else if (discipline == "rope")
    {
        scoreDifficulty = 9.500;
        scorePerformance = 9.400;
    }
}
else if (country == "Italy")
{
    if (discipline == "ribbon")
    {
        scoreDifficulty = 9.200;
        scorePerformance = 9.500;
    }
    else if (discipline == "hoop")
    {
        scoreDifficulty = 9.450;
        scorePerformance = 9.350;
    }
    else if (discipline == "rope")
    {
        scoreDifficulty = 9.700;
        scorePerformance = 9.150;
    }
}

double totalScore = scoreDifficulty + scorePerformance;
double percentage = (20 -totalScore) / 20;
Console.WriteLine($"The team of {country} get {totalScore:f3} on {discipline}.");
Console.WriteLine($"{percentage:p2}");

