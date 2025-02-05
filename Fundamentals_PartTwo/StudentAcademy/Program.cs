namespace StudentAcademy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> studentGrades = new();
            for (int i=1; i <= numberOfStudents; i++)
            {
                string currentStudent = Console.ReadLine();
                double studentGrade = double.Parse(Console.ReadLine());
                if (!studentGrades.ContainsKey(currentStudent)) studentGrades.Add(currentStudent, new List<double>());
                studentGrades[currentStudent].Add(studentGrade);

            }
            foreach ((string student, List<double> grades) in studentGrades)
            {
                double average = grades.Average();
                if (average >= 4.5)
                {
                    Console.WriteLine($"{student} -> {average:f2}");
                }
            }
        }
    }
}
