namespace OpinionPoll
{
    internal class StartUp
    {
        static void Main()
        {
            int numberOfNames = int.Parse(Console.ReadLine());
            List<Person> peopleList = new List<Person>();
            for (int i = 0; i < numberOfNames; i++)
            {
                string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                int age = int.Parse(input[1]);
                Person currentPerson = new(name, age);
                peopleList.Add(currentPerson);
            }
            List<Person> orderedList = peopleList.OrderBy(p=>p.Name).Where(p => p.Age>30).ToList();
            foreach (Person person in orderedList)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
