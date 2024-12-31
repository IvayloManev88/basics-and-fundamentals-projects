char input1 = char.Parse(Console.ReadLine());
char input2 = char.Parse(Console.ReadLine());
char input3 = char.Parse(Console.ReadLine());
int count = 0;
for (char i = input1; i <= input2; i++)
{
    if (i == input3) continue;
    for (char j = input1; j <= input2; j++)
    {
        if (j == input3) continue;

        for (char k = input1; k <= input2; k++)
        {
            if (k == input3) continue;

            count++;
            Console.Write($"{i}{j}{k} ");

        }
    }
}
Console.Write(count);