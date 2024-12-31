int groupsNumber = int.Parse(Console.ReadLine());
double p1 = 0;
double p2 = 0;
double p3 = 0;
double p4 = 0;
double p5 = 0;
int allPeople = 0;
for (int i = 0; i < groupsNumber; i++)
{
int numberOfMountainers = int.Parse(Console.ReadLine());
    allPeople += numberOfMountainers;
    if (numberOfMountainers >40 ) p5 += numberOfMountainers;
    else if (numberOfMountainers > 25) p4 += numberOfMountainers;
    else if (numberOfMountainers > 12) p3 += numberOfMountainers;
    else if (numberOfMountainers > 5) p2 += numberOfMountainers;
    else p1 += numberOfMountainers;
}
Console.WriteLine($"{(p1/allPeople*100):f2}%");
Console.WriteLine($"{(p2 / allPeople * 100):f2}%");
Console.WriteLine($"{(p3 / allPeople * 100):f2}%");
Console.WriteLine($"{(p4 / allPeople * 100):f2}%");
Console.WriteLine($"{(p5 / allPeople * 100):f2}%");