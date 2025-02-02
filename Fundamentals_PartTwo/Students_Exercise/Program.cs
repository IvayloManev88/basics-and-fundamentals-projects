namespace Students_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());
            Class classStudents = new();
            for (int i = 1; i <= numberOfStudents; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                Student currentStudent = new Student()
                {
                    FirstName=tokens[0],
                    LastName=tokens[1],
                    Grade=double.Parse(tokens[2])
                };
                classStudents.Students.Add(currentStudent);

            }
            List<Student> orderedClass = classStudents.Students.OrderByDescending(s => s.Grade).ToList();
            
            foreach (Student student in orderedClass)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
            }
        }
    }
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }
    }
    public class Class
    {
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
