using System.Diagnostics.Metrics;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            Family family = new Family();
            int numberOfFamily = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfFamily; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                int age = int.Parse(input[1]);
                Person person = new Person(name,age);
                family.AddMember(person);
            }
            Person oldestPerson =family.GetOldestMember();
            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }
    }
}
