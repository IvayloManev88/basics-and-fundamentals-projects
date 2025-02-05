namespace Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> coursesParticipants = new();
            string command=string.Empty;
            while ((command=Console.ReadLine())!= "end")
            {
                string[] inputs = command.Split(" : ");
                if (!coursesParticipants.ContainsKey(inputs[0])) coursesParticipants.Add(inputs[0], new() { inputs[1] });
                else coursesParticipants[inputs[0]].Add(inputs[1]);
            }
            foreach ((string cources, List<string> person) in coursesParticipants)
            {
                Console.WriteLine($"{cources}: {person.Count}");
                foreach (string people in person)
                {
                    Console.WriteLine($"-- {people}");
                }
            }
        }
    }
}
