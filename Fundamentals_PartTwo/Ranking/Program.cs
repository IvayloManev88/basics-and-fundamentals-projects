using System.Security.Cryptography.X509Certificates;

namespace Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> ContestsLists = new();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] inputs = input.Split(":");
                ContestsLists.Add(inputs[0], inputs[1]);

            }
            List<Contestant> contestants = new();
            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] inputs = input.Split("=>");

                if (ContestsLists.ContainsKey(inputs[0]) && ContestsLists[inputs[0]] == inputs[1])
                {
                    Dictionary<string, int> inputDictionary = new()
                    {
                        { inputs[0], int.Parse(inputs[3])}
                    };
                    Contestant currentContestant = new(inputs[2], int.Parse(inputs[3]), inputDictionary);

                    if (!contestants.Any(x => x.UserName == inputs[2]))
                    {
                        contestants.Add(currentContestant);
                    }
                    else
                    {
                        foreach (Contestant contestant in contestants)
                        {
                            if (contestant.UserName == inputs[2])
                            {
                                if (!contestant.ContestAndPoints.ContainsKey(inputs[0]))
                                {
                                    contestant.AddContest(inputs[0], int.Parse(inputs[3]));
                                }
                                else
                                {
                                    contestant.IncreaseTotal(inputs[0], int.Parse(inputs[3]));
                                }
                            }
                        }
                    }

                }

            }
            Contestant bestScore = contestants.Where(x=> x.TotalPoints == contestants.Max(x => x.TotalPoints)).FirstOrDefault();
            Console.WriteLine($"Best candidate is {bestScore.UserName} with total {bestScore.TotalPoints} points.");
            Console.WriteLine("Ranking: ");
            List <Contestant> orderedContestants =contestants.OrderBy(x => x.UserName).ToList();
            foreach (Contestant contestant in orderedContestants)
            {
                Dictionary< string, int> orderedContestant =contestant.ContestAndPoints.OrderByDescending(x => x.Value).ToDictionary(entry => entry.Key, entry => entry.Value); 
                Console.WriteLine($"{contestant.UserName}");
                foreach (KeyValuePair<string,int> key in orderedContestant)
                {
                    Console.WriteLine($"#  {key.Key} -> {key.Value}");
                }
            }
        }

        public class Contestant
        {
            public Contestant(string username, int userPoints, Dictionary<string, int> inputContest)
            {
                UserName = username;
                UserPoints = userPoints;
                ContestAndPoints = inputContest;
                TotalPoints = userPoints;
            }
            public string UserName { get; set; }
            public int UserPoints { get; set; }
            public Dictionary<string, int> ContestAndPoints { get; set; } = new();

            public int TotalPoints { get; set; }

            public void IncreaseTotal(string contest, int current)
            {
                if (this.ContestAndPoints[contest] < current)
                {
                    int helpValue = current - this.ContestAndPoints[contest];
                    ContestAndPoints[contest] = current;
                    this.TotalPoints += helpValue;
                }
            }
            public void AddContest(string name, int points)
            {
                this.ContestAndPoints.Add(name, points);
                this.TotalPoints += points;
            }



        }
    }
}