namespace RubberDuckDebuggers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> timeSequence = new Queue<int>(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> numberOfTasks = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Dictionary<string, int> ducks = new Dictionary<string, int>()
            {
                {"Darth Vader Ducky", 0 },
                { "Thor Ducky",0},
                { "Big Blue Rubber Ducky",0},
                { "Small Yellow Rubber Ducky",0} 
            };
            while (numberOfTasks.Count > 0&& timeSequence.Count > 0)
            {
                int currentTime = timeSequence.Dequeue();
                int currentTask = numberOfTasks.Pop();
                int multiplication = currentTime * currentTask;
                if (multiplication <= 60) ducks["Darth Vader Ducky"]++;
                else if (multiplication <=120) ducks["Thor Ducky"]++;
                else if (multiplication <= 180) ducks["Big Blue Rubber Ducky"]++;
                else if (multiplication <= 240) ducks["Small Yellow Rubber Ducky"]++;
                else
                {
                    timeSequence.Enqueue(currentTime);
                    numberOfTasks.Push(currentTask-2);
                }
            }
            Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");
            foreach (var duck in ducks)
            {
                Console.WriteLine($"{duck.Key}: {duck.Value}");
            }
         }
    }
}
