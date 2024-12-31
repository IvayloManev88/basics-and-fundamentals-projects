int numberBalls = int.Parse(Console.ReadLine());
double totalPoints = 0;

int countRedBalls = 0;
int countOrangeBalls = 0;
int countYellowBalls = 0;
int countWhiteBalls = 0;
int countBlackBalls = 0;
int countOther = 0;
for (int i = 0; i < numberBalls; i++)
{
    string color = Console.ReadLine();
    if (color == "red") { totalPoints += 5; countRedBalls++;  }
    else if (color == "orange") { totalPoints += 10; countOrangeBalls++; }
    else if (color == "yellow") { totalPoints += 15; countYellowBalls++; }
    else if (color == "white") { totalPoints += 20; countWhiteBalls++; }
    else if (color == "black") { totalPoints = Math.Floor(totalPoints / 2.00); countBlackBalls++; }
    else countOther++;
    }
Console.WriteLine($"Total points: {totalPoints}");
Console.WriteLine($"Red balls: {countRedBalls}");
Console.WriteLine($"Orange balls: {countOrangeBalls}");
Console.WriteLine($"Yellow balls: {countYellowBalls}");
Console.WriteLine($"White balls: {countWhiteBalls}");
Console.WriteLine($"Other colors picked: {countOther}");
Console.WriteLine($"Divides from black balls: {countBlackBalls}");