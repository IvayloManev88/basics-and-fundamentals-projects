namespace ExamPreparation_Pirates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputCity = string.Empty;
            List<City> cityList = new List<City>();
            while ((inputCity = Console.ReadLine()) != "Sail")
            {
                string[] inputCities = inputCity.Split("||");
                City currentCity= cityList.FirstOrDefault(city=>city.Name == inputCities[0]);
                if (currentCity != null)
                {
                    currentCity.IncreaseValues(int.Parse(inputCities[1]), int.Parse(inputCities[2]));
                }
                else
                {
                    City newCity = new(inputCities[0], int.Parse(inputCities[1]), int.Parse(inputCities[2]));
                    cityList.Add(newCity);
                }
            }
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commands = command.Split("=>");
                switch (commands[0])
                {
                    case "Plunder":
                        City plunderedCity = cityList.FirstOrDefault(city => city.Name == commands[1]);
                        int plunderedGold = int.Parse(commands[3]);
                        int plunderedPeople = int.Parse(commands[2]);
                        if (plunderedCity != null)
                        {
                            Console.WriteLine($"{plunderedCity.Name} plundered! {plunderedGold} gold stolen, {plunderedPeople} citizens killed.");
                            plunderedCity.PlunderedValues(plunderedPeople, plunderedGold);
                            if (plunderedCity.Population == 0 || plunderedCity.Gold == 0)
                            {
                                cityList.Remove(plunderedCity);
                                Console.WriteLine($"{commands[1]} has been wiped off the map!");
                            }
                            
                        }
                        break;
                    case "Prosper":
                        City prosperCity = cityList.FirstOrDefault(city => city.Name == commands[1]);
                        int addedGold = int.Parse(commands[2]);
                        if (addedGold >= 0)
                        {
                            prosperCity.IncreaseValues(0, addedGold);
                            Console.WriteLine($"{addedGold} gold added to the city treasury. {commands[1]} now has {prosperCity.Gold} gold.");
                        }
                        else Console.WriteLine("Gold added cannot be a negative number!");
                        break;
                }
            }
            if (cityList.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cityList.Count} wealthy settlements to go to:");
                foreach (City city in cityList)
                {
                    Console.WriteLine($"{city.Name} -> Population: {city.Population} citizens, Gold: {city.Gold} kg");
                }
            }
            else Console.WriteLine($"Ahoy, Captain! All targets have been plundered and destroyed!");

        }
    }
    public class City
    {
        public City(string name,int population,int gold)
        {
            Name = name;
            Population = population;
            Gold = gold;
        }
        public string Name { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }
        public void IncreaseValues(int population,int gold)
        {
            this.Population += population;
            this.Gold += gold;
        }
        public void PlunderedValues(int population, int gold)
        {
            this.Population -= population;
            this.Gold -= gold;

        }
    }
}
