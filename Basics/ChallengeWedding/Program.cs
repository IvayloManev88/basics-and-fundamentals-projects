int menCount = int.Parse(Console.ReadLine());
int womenCount  = int.Parse(Console.ReadLine());
int tableCount  = int.Parse(Console.ReadLine());
int currentOccupiedTables = 1;
for (int i = 1; i <= menCount; i++)
{
    for (int j = 1; j <= womenCount; j++)
    {
        if (currentOccupiedTables > tableCount) return;
        currentOccupiedTables++;
        Console.Write($"({i} <-> {j}) ");
       
    }
    
}