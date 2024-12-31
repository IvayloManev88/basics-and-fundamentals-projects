using System.ComponentModel.Design;

int count  = 0;
string input = "";
int maxPoints = int.MinValue;
string maxMovieName = "";
while (count < 7 && ((input = Console.ReadLine()) != "STOP"))
{
    count++;
    int totalPoints = 0;
    for (int i = 0; i < input.Length; i++)
    {
        int current = input[i];
        if (current >= 65 && current <= 90 ) totalPoints += current - input.Length;
        else if (current >= 97 && current <= 122) totalPoints += current - (2*input.Length);
        else totalPoints += current;
    }
    if (totalPoints > maxPoints)
    {
        maxPoints = totalPoints;
        maxMovieName = input;
    }
    
    
}
if (count >=7)
{
    Console.WriteLine("The limit is reached.");
}
Console.WriteLine($"The best movie for you is {maxMovieName} with {maxPoints} ASCII sum.");