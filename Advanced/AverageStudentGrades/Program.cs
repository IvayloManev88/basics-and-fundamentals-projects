namespace AverageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> studentGreades = new();
            int studentCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < studentCount; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                decimal grade = decimal.Parse(input[1]);
                if (!studentGreades.ContainsKey(name))
                {
                    studentGreades.Add(name, new());
                }
                studentGreades[name].Add(grade);
            }
            foreach ((string name, List<decimal> grades)in  studentGreades)
            {
                Console.Write($"{name} -> ");
                foreach (decimal grade in grades)
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.Write($"(avg: {grades.Average():f2})");
                Console.WriteLine();
            }
        }
    }
}
