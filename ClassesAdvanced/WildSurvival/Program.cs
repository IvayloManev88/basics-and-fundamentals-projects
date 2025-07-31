namespace WildSurvival
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> bees = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> beeEaters = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));


            while (bees.Count > 0&& beeEaters.Count > 0)
            {
                int currentBee = bees.Dequeue();
                int currentBeeEater = beeEaters.Pop();
                if (currentBeeEater*7>currentBee)
                {
                    
                        currentBeeEater -= currentBee / 7;
                    
                    if (beeEaters.Count > 0)
                    {
                        currentBeeEater += beeEaters.Pop();
                    }
                    beeEaters.Push(currentBeeEater);
                }
                else if (currentBee>currentBeeEater*7)
                {
                    currentBee -= currentBeeEater*7;
                    bees.Enqueue(currentBee);

                }
            }
            Console.WriteLine("The final battle is over!");
            if (bees.Count ==0 && beeEaters.Count ==0) Console.WriteLine("But no one made it out alive!");
            else if (bees.Count>0) Console.WriteLine($"Bee groups left: {string.Join(", ",bees)}");
            else if (beeEaters.Count>0) Console.WriteLine($"Bee-eater groups left: {string.Join(", ", beeEaters)}");
        }
    }
}
