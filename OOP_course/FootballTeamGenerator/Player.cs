using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator
{
    public class Player
    {
       

        public string Name { get; }
        public int Endurance { get; }
        public int Sprint {  get; }
        public int Dribble { get; }
        public int Passing { get; }
        public int Shooting { get; }

        public double SkillLevel { get; }

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            if (string.IsNullOrWhiteSpace(name) == null) throw new ArgumentException("A name should not be empty.");
            ValidateStat(endurance,nameof(this.Endurance));
            ValidateStat(sprint, nameof(this.Sprint));
            ValidateStat(dribble, nameof(this.Dribble));
            ValidateStat(passing, nameof(this.Passing));
            ValidateStat(shooting, nameof(this.Shooting));

            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
            this.SkillLevel = (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.0;
        }

        private static void ValidateStat(int statValue, string statName)
        {
            if (statValue < 0 || statValue > 100) throw new ArgumentException($"{statName} should be between 0 and 100.");
        }

    }
}
