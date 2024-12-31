char sector = char.Parse(Console.ReadLine());
int rowsFirstSector = int.Parse(Console.ReadLine());
int seatsCount  = int.Parse(Console.ReadLine());
int seats = 0;
int counter = 0;
for (char i='A'; i<=sector; i++, rowsFirstSector++)
{
    for (int j=1; j<=rowsFirstSector;j++)
    {
        if (j % 2 == 0) seats = seatsCount + 2;
        else seats = seatsCount;
        for (char k='a'; k<'a' + seats; k++)
        {
            counter++;
            Console.WriteLine($"{i}{j}{k}");
        }
    }
}
Console.WriteLine(counter);