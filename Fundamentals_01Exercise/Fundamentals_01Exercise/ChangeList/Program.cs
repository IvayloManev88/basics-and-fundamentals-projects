namespace ChangeList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToList();
            string command=string.Empty;
            while ((command=Console.ReadLine())!="end")
            {
                List<string> commandsInput = command.Split().ToList();
                switch (commandsInput[0])
                {
                    case "Delete":
                        numbers.RemoveAll(n=> n==int.Parse(commandsInput[1]));
                        break;
                    case "Insert":
                        numbers.Insert(int.Parse(commandsInput[2]), int.Parse(commandsInput[1]));
                        break;

                }

            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
