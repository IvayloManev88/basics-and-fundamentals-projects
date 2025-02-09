namespace OldestFamilyMember
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputs = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int i = 0; i < inputs; i++)
            {
                string[] token = Console.ReadLine().Split();
                family.AddMember(token[0], int.Parse(token[1]));
            }
            Console.WriteLine($"{family.OldestPerson().Name} {family.OldestPerson().Age}");

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
        public class Family
        {
            public List<Person> Families { get; set; } = new List<Person>();

            public void AddMember(string name, int age)
            {
                Families.Add(new Person(name, age));
            }
            public Person OldestPerson ()
            {
                List<Person> orderedList = Families.OrderByDescending(a => a.Age).ToList();
                return orderedList[0];
            }
        }
    }
}
