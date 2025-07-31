namespace ComparingObjects;

public class Program
{
    public static void Main()
    {
        List<Person> list = new List<Person>();
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] inputs = input.Split(" ",
                StringSplitOptions.RemoveEmptyEntries);
            Person person = new Person(inputs[0], inputs[2], int.Parse(inputs[1]));
            list.Add(person);

        }
        int position = int.Parse(Console.ReadLine());
        Person requested = list[position - 1];
        int matches = 0;
        foreach (Person person in list)
        {
            if (Comparer<Person>.Default.Compare(person, requested)==0)
            {
                matches++;
            }

        }
        if (matches == 1) Console.WriteLine("No matches");
        else Console.WriteLine($"{matches} {list.Count - matches} {list.Count}");

    }
}
