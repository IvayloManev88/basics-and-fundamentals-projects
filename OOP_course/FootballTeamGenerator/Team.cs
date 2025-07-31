using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator
{
    public class Team
    {
        private readonly Dictionary<string, Player> _players;

        public string Name { get; }
        public double Rating => this._players.Values.Sum(p => p.SkillLevel);

        public Team(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("A name should not be empty.");

            this.Name = name;
            this._players = new Dictionary<string, Player>();
        }

        public void AddPlayer(Player player)
        {
            this._players[player.Name] = player;
        }

        public bool RemovePlayer(string playerName)
        {
           return  this._players.Remove(playerName);
        }

    }
}
