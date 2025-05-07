using static SoftUniExamResults.Program;

namespace SoftUniExamResults
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> languageToSubmissions = new Dictionary<string, int>();
            List<Participant> participants = new List<Participant>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] inputs = input.Split("-");
                string currentName = inputs[0];
                Participant currentParticipant = participants.FirstOrDefault(x => x.Name == currentName);
                if (inputs.Length == 2)
                {
                   
                    participants.Remove(currentParticipant);
                }
                else
                {
                    string language = inputs[1];
                    int points = int.Parse(inputs[2]);
                    if (!languageToSubmissions.ContainsKey(language))
                    {
                        languageToSubmissions.Add(language, 0);
                    }
                    languageToSubmissions[language] ++;
                    if (currentParticipant==null)
                    {
                        Participant inputParticipant = new(currentName, language, points);
                        
                        participants.Add(inputParticipant);
                    }
                    else if (currentParticipant.Score.ContainsKey(language))
                    {
                        if (currentParticipant.Score[language] < points) currentParticipant.Score[language] = points;
                        //no idea
                    }
                    else
                    {
                        currentParticipant.Score.Add(language, points);
                    }
                }

            }
            participants=participants.OrderByDescending(x => x.Total).ThenBy(x=>x.Name).ToList();
            Console.WriteLine("Results:");
            foreach (Participant participant in participants)
            {
                Console.WriteLine($"{participant.Name} | {participant.Total}");
            }
            Console.WriteLine("Submissions:");
            languageToSubmissions = languageToSubmissions.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key).ToDictionary(x=>x.Key,x=>x.Value);
            foreach ((string lang,int count) in languageToSubmissions)
            {
                Console.WriteLine($"{lang} - {count}");
            }
        }

        public class Participant
        {
            public Participant(string name, string language, int points)
            {
                Name = name;
                Score.Add(language, points);
            }

            public string Name { get; set; }
            public Dictionary<string, int> Score { get; set; } = new Dictionary<string, int>();
            public int Total => Score.Values.Sum();
        }
    }
}
