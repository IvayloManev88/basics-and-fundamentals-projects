namespace Students_V2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                List<string> inputs = input.Split().ToList();
                Student currentStudent = new Student()
                {
                    FirstName = inputs[0],
                    LastName = inputs[1],
                    Age = int.Parse(inputs[2]),
                    HomeTown = inputs[3]

                };
                bool matchingNames = false;
                foreach (Student s in students) {
                    {
                        if (currentStudent.FirstName == s.FirstName && currentStudent.LastName == s.LastName)
                        {
                            s.Age = currentStudent.Age;
                            s.HomeTown = currentStudent.HomeTown;
                            matchingNames = true;
                        }
                    }

                    }
                if (!matchingNames) students.Add(currentStudent);

            }
            string printCity = Console.ReadLine();
            foreach (Student student in students)
            {
                if (student.HomeTown == printCity)
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
