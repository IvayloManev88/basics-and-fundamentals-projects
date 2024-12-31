int offDays = int.Parse(Console.ReadLine());
int workDays = 365 - offDays;
int playMinutes = offDays * 127 + 63 * workDays;
int norm = 30000 - playMinutes;
if (norm > 0)
{
    Console.WriteLine($"Tom sleeps well");
    int hours = Math.Abs(norm / 60);
    int minutes = Math.Abs(norm % 60);
    Console.WriteLine($"{hours} hours and {minutes} minutes less for play");
}
else
{
    Console.WriteLine($"Tom will run away");
    int hours = Math.Abs(norm / 60);
    int minutes = Math.Abs(norm % 60);
    Console.WriteLine($"{hours} hours and {minutes} minutes more for play");
}