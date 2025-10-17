using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Championship.Tests
{
    public class Tests
    {
       

        [Test]
        public void ConstructorWorking()
        {
            League league = new League();
            Assert.AreEqual(league.Capacity, 10);
            Assert.That(league.Teams, Is.Empty);
            Assert.That(league.Teams.Count, Is.Zero);
        }

        [Test]
        public void AddTeamShouldThrowIfReachedCapacity()
        {
            League league = new League();
            for (int i = 0; i < 10; i++)
            {
                Team team = new Team($"Team {i}");
                league.AddTeam(team);
            }

            Team team1 = new Team($"Team 10");

            Assert.Throws<InvalidOperationException>(() => league.AddTeam(team1), "League is full.");
        }

        [Test]
        public void AddTeamShouldThrowIfSameTeamIsEntered()
        {
            League league = new League();
            Team team = new Team($"Team 1");
            league.AddTeam(team);

            Assert.Throws<InvalidOperationException>(() => league.AddTeam(team), "Team already exists.");
        }

        [Test]
        public void AddTeamShouldWork()
        {
            League league = new League();
            Team[] teams = new Team[10];
            for (int i = 0; i < 10; i++)
            {
                Team team = new Team($"Team {i}");
                league.AddTeam(team);
                teams[i] = team;
            }
            Assert.AreEqual(10, league.Teams.Count());
            Assert.AreEqual(teams, league.Teams);

        }


        [Test]
        public void RemoveTeamWithNoSuchTeamShouldReturnFalse()
        {
            League league = new League();
            Team team = new Team($"Team 1");
            league.AddTeam(team);
            bool result = league.RemoveTeam("No such team");

            Assert.That(result, Is.False);
            Assert.AreEqual(1, league.Teams.Count());
        }

        [Test]
        public void RemoveTeamShouldWork()
        {
            League league = new League();
            Team team = new Team($"Team 1");
            league.AddTeam(team);
            bool result = league.RemoveTeam(team.Name);

            Assert.That(result, Is.True);
            Assert.AreEqual(0, league.Teams.Count());
        }


        [Test]
        public void PlayMatchWithoutATeamShouldThrow()
        {
            League league = new League();
            Team home = new Team($"Team Home");
            Team away = new Team($"Team Away");
            Assert.Throws<InvalidOperationException>(() => league.PlayMatch(home.Name, away.Name, 0, 0), "One or both teams do not exist.");
            league.AddTeam(home);
            Assert.Throws<InvalidOperationException>(() => league.PlayMatch(home.Name, away.Name, 0, 0), "One or both teams do not exist.");
            league.AddTeam(away);
            league.RemoveTeam(home.Name);
            Assert.Throws<InvalidOperationException>(() => league.PlayMatch(home.Name, away.Name, 0, 0), "One or both teams do not exist.");


        }

        [Test]
        public void PlayMatchHomeShouldWin()
        {
            League league = new League();
            Team home = new Team($"Team Home");
            Team away = new Team($"Team Away");
            league.AddTeam(home);
            league.AddTeam(away);
            league.PlayMatch(home.Name, away.Name, 1, 0);
            Team homeAfterMatch = league.Teams.First(t => t.Name == home.Name);
            Assert.AreEqual(homeAfterMatch.Wins, 1);

        }

        [Test]
        public void PlayMatchAwyaShouldWin()
        {
            League league = new League();
            Team home = new Team($"Team Home");
            Team away = new Team($"Team Away");
            league.AddTeam(home);
            league.AddTeam(away);
            league.PlayMatch(home.Name, away.Name, 0, 1);
            Team awayAfterMatch = league.Teams.First(t => t.Name == away.Name);
            Assert.AreEqual(awayAfterMatch.Wins, 1);

        }
        [Test]
        public void PlayMatchDraw()
        {
            League league = new League();
            Team home = new Team($"Team Home");
            Team away = new Team($"Team Away");
            league.AddTeam(home);
            league.AddTeam(away);
            league.PlayMatch(home.Name, away.Name, 0, 0);
            Team homeAfterMatch = league.Teams.First(t => t.Name == home.Name);
            Team awayAfterMatch = league.Teams.First(t => t.Name == away.Name);
            Assert.AreEqual(awayAfterMatch.Draws, 1);
            Assert.AreEqual(homeAfterMatch.Draws, 1);

        }


        [Test]
        public void GetTeamInfoWithNoSuchTeamShouldThrow()
        {
            League league = new League();
            Team home = new Team($"Team Home");
            Team away = new Team($"Team Away");
            league.AddTeam(home);
            Assert.Throws<InvalidOperationException>(() => league.GetTeamInfo(away.Name), "Team does not exist.");

        }

        [Test]
        public void GetTeamInfoShouldWork()
        {
            League league = new League();
            Team home = new Team($"Team Home");
            Team away = new Team($"Team Away");
            league.AddTeam(away);
            league.AddTeam(home);
            league.PlayMatch(home.Name, away.Name, 0, 0);
            league.PlayMatch(home.Name, away.Name, 1, 0);
            league.PlayMatch(home.Name, away.Name, 0, 1);
            string result = league.GetTeamInfo(home.Name);
            Assert.AreEqual($"Team Home - 4 points (1W 1D 1L)", result);


        }
    }
}