using System.ComponentModel.DataAnnotations;

string input = "";
double valueMax = int.MinValue;
string maxWord = "";

while ((input = Console.ReadLine())!= "End of words")
{
    double currValue = 0;
    int length = input.Length;
    for (int i = 0; i < length; i++)
    {
        int currentSymbol = input[i];
        currValue += currentSymbol;
    }
    if (input[0] == 'a' || input[0] == 'e' || input[0] == 'i' || input[0] == 'o'|| input[0] == 'u' || input[0] == 'y' || input[0] == 'A' || input[0] == 'E' || input[0] == 'I' || input[0] == 'O' || input[0] == 'U'|| input[0] == 'Y')
    {
        currValue = currValue * length;
    }
    else 
    { 
        currValue = Math.Floor(currValue / (double)length);
    }
    if (valueMax< currValue)
    {
        valueMax = currValue;
        maxWord = input;
    }
}
Console.WriteLine($"The most powerful word is {maxWord} - {valueMax}");