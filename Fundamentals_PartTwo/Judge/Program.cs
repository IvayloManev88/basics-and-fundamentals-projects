using System.Security.Cryptography.X509Certificates;

namespace Judge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Students>> listOfStudents = new();
           
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "no more time")
            {
                string[] inputs = input.Split(" -> ");
                string course = inputs[1];
                string studentName = inputs[0];
                int points = int.Parse(inputs[2]);
               
                
                
                
                    
                
                if (!listOfStudents.ContainsKey(course))
                {
                    listOfStudents.Add(course, new());
                }

                if (!listOfStudents[course].Any(x => x.Name == studentName))
                {
                    Students inputStudent = new Students(studentName, course, points);
                    listOfStudents[course].Add(inputStudent);
                }
                else
                {
                    Students currentStudent = listOfStudents[course].FirstOrDefault(x => x.Name == studentName);
                    if (currentStudent.Points < points)
                    {
                        currentStudent.Points = points;

                        
                    }
                }

            }
            
            foreach (KeyValuePair<string, List<Students>> course in listOfStudents)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count()} participants");
                int counter = 1;
                List<Students> orderedStudents = course.Value.OrderByDescending(x => x.Points).ThenBy(x=>x.Name).ToList();
                foreach (Students student in orderedStudents)
                {
                    Console.WriteLine($"{counter}. {student.Name} <::> {student.Points}");
                    counter++;
                }
                
            }
            int counterIndividual = 1;
            Console.WriteLine("Individual standings:");
            Dictionary<string, int> individualDictionary = new Dictionary<string, int>();
            foreach (List<Students> students in listOfStudents.Values)
            {
                foreach (Students student in students)
                {
                    if (!individualDictionary.ContainsKey(student.Name))
                    {
                        individualDictionary.Add(student.Name, 0);

                    }
                    individualDictionary[student.Name] += student.Points;
                }
            }
            Dictionary<string, int> sortedIndividual = individualDictionary.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key).ToDictionary(x=> x.Key, x=>x.Value);
            foreach (var student in sortedIndividual)
            {
                Console.WriteLine($"{counterIndividual}. {student.Key} -> {student.Value}");
                    counterIndividual++;
            }
        }

        public class Students
        {

            public Students(string name, string className, int points)
            {
                Name = name;
                ClassName = className;
                Points = points;
            }

            public string Name { get; set; }
            public string ClassName { get; set; }
            public int Points { get; set; }





        }
    }
}
