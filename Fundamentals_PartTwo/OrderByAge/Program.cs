using System.Xml.Linq;

namespace OrderByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            List<Person> peopleCatalog = new List<Person>();
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputs = input.Split();
                
                bool isInList=false;
                for (int i =0; i<peopleCatalog.Count;i++)
                {
                    if (inputs[1] == peopleCatalog[i].Id)
                    {
                        peopleCatalog[i].Name = inputs[0];
                        peopleCatalog[i].Age = int.Parse(inputs[2]);
                        isInList = true;
                    }
                }
                if (isInList) continue;
                else

                {
                    Person currentPerson = new()
                    {
                        Name = inputs[0],
                        Id = inputs[1],
                        Age = int.Parse(inputs[2])
                    };
                    peopleCatalog.Add(currentPerson);
                }
            }
            List<Person> sortedPeople = peopleCatalog.OrderBy(p => p.Age).ToList();
            foreach (Person person in sortedPeople)
            {
                Console.WriteLine($"{person.Name} with ID: {person.Id} is {person.Age} years old.");
            }
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public string Id { get; set; }

        public int Age { get; set; }
    }
}
