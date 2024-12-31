string input = "";
int maxPoints= int.MinValue;
string maxPointsName = "";

while ((input = Console.ReadLine())!="Stop")
{
    int totalPoints = 0;
    int length = input.Length;
    for (int i = 0; i < length; i++)
    {
        int ascii = input[i];
        int inputNumber = int.Parse(Console.ReadLine());
        if (ascii == inputNumber)
        {
            totalPoints += 10;
        }
        else totalPoints += 2;
      
    }
    if (maxPoints<= totalPoints)
    {
        maxPoints = totalPoints;
        maxPointsName = input;
    }
}
Console.WriteLine($"The winner is {maxPointsName} with {maxPoints} points!");