namespace Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            string input =string.Empty;
            while ((input=Console.ReadLine())!= "end")
            {
                List<string> inputs = input.Split().ToList();
                Student currentStudent = new Student();
                currentStudent.FirstName = inputs[0];
                currentStudent.LastName = inputs[1];
                currentStudent.Age=int.Parse(inputs[2]);
                currentStudent.HomeTown=inputs[3];
                students.Add(currentStudent);

            }
            string printCity = Console.ReadLine();
            foreach (Student student in students)
            {
                if (student.HomeTown==printCity)
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
        }
    }
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
    }
}
