using System.Linq;
using System;
using System.Collections.Generic;

namespace TeamworkProjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfTeams = int.Parse(Console.ReadLine());
            ListOfTeams ListOfTeams = new ListOfTeams();
            for (int i = 1; i <= numberOfTeams; i++)
            {
                string[] teamInit = Console.ReadLine().Split("-");
                Team currentTeam = new()
                {
                    TeamName=teamInit[1],
                    Creator=teamInit[0]
                };
              
                if (ListOfTeams.Teams.Any(c => c.TeamName == currentTeam.TeamName)) Console.WriteLine($"Team {currentTeam.TeamName} was already created!");
                else if (ListOfTeams.Teams.Any(c => c.Creator == currentTeam.Creator)) Console.WriteLine($"{currentTeam.Creator} cannot create another team!");
                else
                {
                    ListOfTeams.Teams.Add(currentTeam);

                    Console.WriteLine($"Team {currentTeam.TeamName} has been created by {currentTeam.Creator}!");
                }
            }
            string members = string.Empty;
            while ((members = Console.ReadLine())!= "end of assignment")
            {
                string[] member = members.Split("->");
                Team team = ListOfTeams.Teams.FirstOrDefault(c => c.TeamName == member[1]);
                if (team == null) { Console.WriteLine($"Team {member[1]} does not exist!"); }
                else if (ListOfTeams.Teams.Any(c => c.Members.Contains(member[0]))|| ListOfTeams.Teams.Any(c => c.Creator.Contains(member[0]))) { Console.WriteLine($"Member {member[0]} cannot join team {member[1]}!"); }
                else
                {
                    team.Members.Add(member[0]);
                }



            }

            List<Team> orderedList = ListOfTeams.Teams.OrderByDescending(team => team.Members.Count).ThenBy(team => team.TeamName).ToList();
            for (int i=0; i<orderedList.Count;i++)
            {
                Team currentTeam = orderedList[i];
                if (currentTeam.Members.Count>0)
                {
                    currentTeam.Members.Sort();
                    Console.WriteLine(currentTeam.TeamName);
                    Console.WriteLine($"- {currentTeam.Creator}");
                    foreach(string member in currentTeam.Members)
                    {
                        Console.WriteLine($"-- {member}");
                    }
                }
               
            }
            Console.WriteLine($"Teams to disband:");
            List<Team> noMembers = orderedList.Where(s=> s.Members.Count==0).ToList();
            foreach (Team member in noMembers)
            {
                Console.WriteLine(member.TeamName);
            }
          
        }
    }
    public class Team
    {
        public string TeamName { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; } = new();
    }
    public class ListOfTeams
    {
        public List<Team> Teams { get; set; } = new();
    }
}
