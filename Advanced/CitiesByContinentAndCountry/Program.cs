namespace CitiesByContinentAndCountry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> continents = new();
            for (int i = 0; i < numberOfInputs; i++)
            {
                string[] inputs = Console.ReadLine().Split();
                string continentName = inputs[0];
                string countryName = inputs[1];
                string cityName = inputs[2];
                if (!continents.ContainsKey(continentName))
                {
                    continents.Add(continentName, new());
                }
                if (!continents[continentName].ContainsKey(countryName))
                {
                    continents[continentName].Add(countryName, new());
                }
                continents[continentName][countryName].Add(cityName);
            }
            foreach (string continentName in continents.Keys)
            {
                Console.WriteLine($"{continentName}:");
                foreach ((string country,List<string> city) in  continents[continentName])
                {
                    Console.WriteLine($"{country} -> {string.Join(", ", city)}");
                }
            }
        }
    }
}
