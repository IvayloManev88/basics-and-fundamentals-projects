namespace FilterByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> personList = new List<Person>();
            int peopleCounter = int.Parse(Console.ReadLine());
            for (int i = 0; i < peopleCounter; i++)
            {
                personList.Add(ReadPeople());
            }
            string condition = Console.ReadLine();
            int ageThreshold = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();
            Func <Person, bool> filter = CreateFilter(condition, ageThreshold);
            personList = personList.Where(filter).ToList();
            Action<Person> printer = CreatePrinter(format);
            Func<Person, bool> CreateFilter(string condition, int ageThreshold)
            {
                if (condition == "older")
                {
                    return s => s.Age >= ageThreshold;
                }
                else return s => s.Age < ageThreshold;
            }
            Action<Person> CreatePrinter(string format)
            {
                //Action<Person> printer = null;
                if (format == "name")
                {
                    return s => Console.WriteLine($"{s.Name}");
                }
                else if (format == "age")
                {
                    return s => Console.WriteLine($"{s.Age}");
                }
                else if (format == "name age")
                {
                    return s => Console.WriteLine($"{s.Name} - {s.Age}");
                }
                return null;
                //return printer;
            }



            foreach (Person person in personList)
            {
                printer(person);
            }
        }

        public class Person
        {
            public Person(string name, int age)
            {
                Name = name;
                Age = age;

            }
            public string Name { get; set; }
            public int Age { get; set; }
        }
        public static Person ReadPeople()
        {
            string[] input = Console.ReadLine().
                Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string name = input[0];
            int age = int.Parse(input[1]);
            Person currentPerson = new Person(name, age);
            return currentPerson;
        }
        
       
    }

}
