int n = int.Parse(Console.ReadLine());
string input = "";
double sumGrades = 0;
double sumAllGrades = 0;

int counterProblems = 0;
while ((input = Console.ReadLine())!="Finish")
{
    counterProblems++;
    
    sumGrades = 0;
    for (int i = 0; i < n; i++)
    {
        double grade = double.Parse(Console.ReadLine());
        sumGrades += grade;
    }
    sumAllGrades += sumGrades;
    Console.WriteLine($"{input} - {sumGrades / (double)n:f2}.");
}
Console.WriteLine($"Student's final assessment is {sumAllGrades / (counterProblems*n):f2}.");