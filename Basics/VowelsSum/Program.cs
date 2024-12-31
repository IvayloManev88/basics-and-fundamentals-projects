string textInput = Console.ReadLine();
int sum = 0;
for (int i = 0; i< textInput.Length; i++)
{
   
    if (textInput[i] == 'a') sum += 1;
    else if (textInput[i] == 'e') sum += 2;
    else if (textInput[i] == 'i') sum += 3;
    else if (textInput[i] == 'o') sum += 4;
    else if (textInput[i] == 'u') sum += 5;

}
Console.WriteLine(sum);
