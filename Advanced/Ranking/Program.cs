using System.Security.Cryptography.X509Certificates;

namespace Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,string> contestToPassword = new Dictionary<string,string>();
            string input = string.Empty;
            List<Candidate> candidates = new List<Candidate>();
            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] inputs = input.Split(":");
                string contestName = inputs[0];
                string contestPassword = inputs[1];
                contestToPassword.Add(contestName, contestPassword);
                //not checking if its valid - assuming I will have  1 input only

            }
            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] inputs = input.Split("=>");
                string contestName = inputs[0];
                string contestPassword = inputs[1];
                string employeeName = inputs[2];
                int points = int.Parse(inputs[3]);
                if (contestToPassword.ContainsKey(contestName))
                {
                    if (contestToPassword[contestName] == contestPassword)
                    {
                        Candidate currentCandidate = candidates.FirstOrDefault(x=>x.Name== employeeName && x.ContestNameToPoints.ContainsKey(contestName));
                        if (currentCandidate != null)
                        {
                            if (points > currentCandidate.ContestNameToPoints[contestName]) currentCandidate.ContestNameToPoints[contestName] = points;
                        }
                        else if (!candidates.Any(x=>x.Name== employeeName))
                        {
                            currentCandidate = new(employeeName, contestName, points);
                            candidates.Add(currentCandidate);
                        }
                        else
                        {
                            currentCandidate = candidates.FirstOrDefault(x => x.Name == employeeName);
                            currentCandidate.ContestNameToPoints.Add(contestName, points);
                        }
                    }
                }
            }
            Candidate bestCandidate = candidates.OrderByDescending(x => x.ContestNameToPoints.Values.Sum()).First();
            Console.WriteLine($"Best candidate is {bestCandidate.Name} with total {bestCandidate.ContestNameToPoints.Values.Sum()} points.");
            Console.WriteLine("Ranking:");
            candidates=candidates.OrderBy(x=>x.Name).ThenByDescending(x=>x.ContestNameToPoints.Values).ToList();
            foreach (Candidate candidate in candidates)
            {
                IOrderedEnumerable<KeyValuePair<string, int>> sortedCandidate = candidate.ContestNameToPoints.OrderByDescending(x=>x.Value);
                Console.WriteLine(candidate.Name);
                
                foreach ((string contest, int contestPoints) in sortedCandidate)
                {

                    Console.WriteLine($"#  {contest} -> {contestPoints}");
                }
            }
        }
    }
    public class Candidate
    {
        public Candidate(string name, string contestName, int contestPoints)
        {
            Name = name;
            ContestNameToPoints.Add(contestName, contestPoints);
        }
        public string Name { get; set; }
        public Dictionary<string, int> ContestNameToPoints { get; set; } = new Dictionary<string, int>();
    }
}
