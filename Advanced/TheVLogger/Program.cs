namespace TheVLogger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Vlogger> database = new();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] currentInput = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string currentVloggerName = currentInput[0];
                if (currentInput.Length == 4)
                {
                    Vlogger currentVlogger = new()
                    {
                        vloggerName = currentVloggerName,
                        followers = new(),
                        following = new(),
                    };
                    
                    if (!database.ContainsKey(currentVloggerName))
                    {
                        database.Add(currentVloggerName, new());
                        database[currentVloggerName]=currentVlogger;
                    }

                }
                else
                {
                    string followingVloggerName = currentInput[0];
                    string followedVloggerName = currentInput[2];
                    if (!database.ContainsKey(followingVloggerName) || !database.ContainsKey(followedVloggerName)|| followingVloggerName== followedVloggerName) continue;
                    if (database[followedVloggerName].followers.Contains(followingVloggerName)) continue;
                    else
                    {
                        
                        database[followedVloggerName].followers.Add(followingVloggerName);
                       
                        database[followingVloggerName].following.Add(followedVloggerName);
                    }

                }
            }
            Dictionary<string, Vlogger> sorted = database.OrderByDescending(x => x.Value.followers.Count).ThenBy(x => x.Value.following.Count).ToDictionary(x=>x.Key, x=>x.Value);
            Console.WriteLine($"The V-Logger has a total of {sorted.Count} vloggers in its logs.");
            int counter = 1;
            foreach (Vlogger vlogger in sorted.Values)
            {
                Console.WriteLine($"{counter}. {vlogger.vloggerName} : {vlogger.followers.Count} followers, {vlogger.following.Count} following");
                if (counter == 1)
                {
                    vlogger.followers = vlogger.followers.OrderBy(x=>x).ToList();
                    foreach (string follower in vlogger.followers)
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                counter++;

            }

        }

        public class Vlogger
        {
            public string vloggerName { get; set; }
            public List<string> followers { get; set; }
            public List<string> following { get; set; }
        }
    }
}
