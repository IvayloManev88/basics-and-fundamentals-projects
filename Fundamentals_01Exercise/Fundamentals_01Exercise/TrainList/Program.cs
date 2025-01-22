namespace TrainList
{
    internal class Program
    {
        static void Main(string[] args)
        {
           List<int> wagoons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int maxCapacity = int.Parse(Console.ReadLine());
            string command =string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                List<string> commands = command.Split().ToList();
                if (commands[0] == "Add")
                {
                    int peopleInNewWagon = int.Parse(commands[1]);
                    wagoons.Add(peopleInNewWagon);
                }
                else
                {
                    int peopleToAddToCurrentWagon = int.Parse(commands[0]);
                    for (int i = 0; i < wagoons.Count; i++)
                    {
                        if (wagoons[i] + peopleToAddToCurrentWagon <= maxCapacity)
                        {
                            wagoons[i] += peopleToAddToCurrentWagon;
                            break;
                        }

                    }
                }
            }
            Console.WriteLine(string.Join(" ", wagoons));
        }
    }
}
