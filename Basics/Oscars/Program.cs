string actorName = Console.ReadLine();
double accademyPoints = double.Parse(Console.ReadLine());
int juryNumber = int.Parse(Console.ReadLine());
double points = accademyPoints;
for (int i = 0; i < juryNumber && points < 1250.5; i++)
{
    string juryName = Console.ReadLine();
    double juryPoints = double.Parse(Console.ReadLine());
    points = points + juryName.Length * juryPoints / 2.00;

    if (points >= 1250.5)
    {
        Console.WriteLine($"Congratulations, {actorName} got a nominee for leading role with {points:f1}!");
    }

}

if (points < 1250.5) Console.WriteLine($"Sorry, {actorName} you need {(1250.5 - points):f1} more!");