using FootballManager.Core.Contracts;
using FootballManager.Models;
using FootballManager.Models.Contracts;
using FootballManager.Repositories;
using FootballManager.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Core
{
    public class Controller : IController
    {
        private TeamRepository championship = new TeamRepository();

        public string JoinChampionship(string teamName)
        {
            if (championship.Models.Count >= 10)
                return String.Format(OutputMessages.ChampionshipFull);
            if (championship.Exists(teamName))
                return String.Format(OutputMessages.TeamWithSameNameExisting, teamName);

            Team team = new Team(teamName);
            championship.Add(team);
            return String.Format(OutputMessages.TeamSuccessfullyJoined, teamName);

        }

        public string SignManager(string teamName, string managerTypeName, string managerName)
        {
            if (!championship.Exists(teamName))
                return String.Format(OutputMessages.TeamDoesNotTakePart, teamName);
            if (managerTypeName != nameof(AmateurManager)&& managerTypeName != nameof(ProfessionalManager)&& managerTypeName != nameof(SeniorManager))
                return String.Format(OutputMessages.ManagerTypeNotPresented, managerTypeName);
            Team currentTeam = (Team)championship.Get(teamName);
            if (currentTeam.TeamManager != null)
                return String.Format(OutputMessages.TeamSignedWithAnotherManager, teamName, currentTeam.TeamManager.Name);

            if (championship.Models.Any(t => t.TeamManager!=null && t.TeamManager.Name == managerName))
                return String.Format(OutputMessages.ManagerAssignedToAnotherTeam, managerName);
            
            IManager manager = managerTypeName switch
            {
                "AmateurManager" => new AmateurManager(managerName),
                "SeniorManager" => new SeniorManager(managerName),
                "ProfessionalManager" => new ProfessionalManager(managerName)
            };

            currentTeam.SignWith(manager);
            return String.Format(OutputMessages.TeamSuccessfullySignedWithManager, managerName, teamName);


        }


        public string MatchBetween(string teamOneName, string teamTwoName)
        {
            if (!championship.Exists(teamOneName) || !championship.Exists(teamTwoName))
                return String.Format(OutputMessages.OneOfTheTeamDoesNotExist);

            Team teamOne = (Team)championship.Get(teamOneName);
            Team teamTwo = (Team)championship.Get(teamTwoName);
            if (teamOne.PresentCondition==teamTwo.PresentCondition)
            {
                teamOne.GainPoints(1);
                teamTwo.GainPoints(1);
                return String.Format(OutputMessages.MatchIsDraw, teamOneName, teamTwoName);
            }
            else
            {
                Team winner = teamOne.PresentCondition>teamTwo.PresentCondition?teamOne:teamTwo;
                Team looser = teamOne.PresentCondition > teamTwo.PresentCondition ? teamTwo : teamOne;
                winner.GainPoints(3);
                if (winner.TeamManager != null)
                    winner.TeamManager.RankingUpdate(5);
                if (looser.TeamManager != null)
                    looser.TeamManager.RankingUpdate(-5);
                return String.Format(OutputMessages.TeamWinsMatch, winner.Name, looser.Name);
            }

        }


        public string ChampionshipRankings()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***Ranking Table***");
            int counter = 1;
            foreach (Team team in championship.Models.Where(t => t.TeamManager != null).OrderByDescending(t => t.ChampionshipPoints).ThenByDescending(t => t.PresentCondition))
            {
                sb.AppendLine($"{counter}. {team.ToString()}/{team.TeamManager.ToString()}");
                counter++;
            }

            return sb.ToString().TrimEnd();
        }

        

       

        public string PromoteTeam(string droppingTeamName, string promotingTeamName, string managerTypeName, string managerName)
        {
            if (!championship.Exists(droppingTeamName))
                return String.Format(OutputMessages.DroppingTeamDoesNotExist, droppingTeamName);

            if (championship.Exists(promotingTeamName))
                return String.Format(OutputMessages.TeamWithSameNameExisting, promotingTeamName);

            Team newTeam = new Team(promotingTeamName);
            
            
            foreach (Team team in championship.Models) 
                team.ResetPoints();

            championship.Remove(droppingTeamName);
            championship.Add(newTeam);
            SignManager(newTeam.Name, managerTypeName, managerName);
            return String.Format(OutputMessages.TeamHasBeenPromoted, promotingTeamName);
        }

        
    }
}
