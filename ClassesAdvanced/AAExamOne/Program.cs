namespace AAExamOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack <int> energy = new Stack<int>(Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Queue <int> distances = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            List <(string name, int value)> resourses = new ();
            resourses.Add(("Iron", 80));
            resourses.Add(("Titanium", 90));
            resourses.Add(("Aluminium", 100));
            resourses.Add(("Chlorine", 60));
            resourses.Add(("Sulfur", 70));
            List <string> collectedResources = new List<string>();

            while (energy.Count > 0 && distances.Count > 0)
            {
                int currentEnergy = energy.Pop();
                int currentDistance = distances.Dequeue();
                (string resourceName, int resourceDifficulty) = resourses[0];
                if (currentDistance+currentEnergy>= resourceDifficulty)
                {
                    collectedResources.Add(resourceName);
                    resourses.RemoveAt(0);
                }
                if (resourses.Count == 0)
                {
                    Console.WriteLine("Mission complete! All minerals have been collected.");
                    break;
                }

            }
            if (resourses.Count > 0)
            {
                Console.WriteLine("Mission not completed! Awaiting further instructions from Earth.");
            }
            if (collectedResources.Count > 0)
            {
                Console.WriteLine("Collected resources:");
                foreach (string resourceName in collectedResources)
                {
                    Console.WriteLine(resourceName);
                }
            }

        }
    }
}
