namespace AaExamSThirdTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> heroes = new();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commands = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string heroName = commands[1];
                switch (commands[0])
                {
                    
                    case "Enroll":
                    if (!heroes.ContainsKey(heroName))
                        {
                        heroes[heroName] = new List<string>();
                    }
                    else Console.WriteLine($"{heroName} is already enrolled.");
                        break;

                    case "Learn":
                        string spell = commands[2];
                        if (!heroes.ContainsKey(heroName))
                        {
                            Console.WriteLine($"{heroName} doesn't exist.");
                        }
                        else
                        {
                            if (heroes[heroName].Contains(spell))
                            {
                                Console.WriteLine($"{heroName} has already learnt {spell}.");
                            }
                            else
                            {
                                heroes[heroName].Add(spell);
                            }
                        }
                        break;
                    case "Unlearn":
                         spell = commands[2];
                        if (!heroes.ContainsKey(heroName))
                        {
                            Console.WriteLine($"{heroName} doesn't exist.");
                        }
                        else
                        {
                            if (heroes[heroName].Contains(spell))
                            {
                                heroes[heroName].Remove(spell);
                            }
                            else
                            {
                                
                                Console.WriteLine($"{heroName} doesn't know {spell}.");
                            }
                        }
                        break;
                }

            }
            Console.WriteLine($"Heroes:");
            foreach (var hero in heroes)
            {
                Console.WriteLine($"== {hero.Key}: {string.Join(", ", hero.Value)}");
             }
        }
       
        
    }
}
