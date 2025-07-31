namespace FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input;
            Dictionary<string, Team> teams = new Dictionary<string, Team>();
            while ((input = Console.ReadLine()) != "END") 
            {
                try
                {
                    ProcessCommand(input, teams);
                }
                catch (Exception e) 
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void ProcessCommand(string input, Dictionary<string,Team> teams)
        {
            string[] data = input.Split(";");
            string command = data[0];
            if (command == "Team")
            {
                Team team = new Team (data[1]);
                teams[team.Name] = team;
            }
            else
            {
                string teamName = data[1];

                if (!teams.ContainsKey(teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist.");
                    return;
                }

                Team team = teams[teamName];

                if (command == "Add")
                {
                    Player newPlayer = new Player(data[2], int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5]), int.Parse(data[6]), int.Parse(data[7]));
                    team.AddPlayer(newPlayer);
                    

                }
                else if (command == "Remove")
                {
                    if (!team.RemovePlayer(data[2])) Console.WriteLine($"Player {data[2]} is not in {teamName} team.");
                }
                else if (command == "Rating")
                {

                    Console.WriteLine($"{team.Name} - {team.Rating:f0}");
                } 
            }
        }
    }
}
