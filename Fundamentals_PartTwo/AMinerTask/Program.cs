namespace AMinerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resources = new();
            string input = string.Empty;
            while ((input = Console.ReadLine())!="stop")
            {
                string resourcesName = input;
                int resourcesVolume = int.Parse(Console.ReadLine());
                if (resources.ContainsKey(resourcesName)) resources[resourcesName] += resourcesVolume;
                else resources.Add(resourcesName, resourcesVolume);

            }
            foreach ((string name, int volume) in resources)
            {
                Console.WriteLine($"{name} -> {volume}");
            }
        }
    }
}
