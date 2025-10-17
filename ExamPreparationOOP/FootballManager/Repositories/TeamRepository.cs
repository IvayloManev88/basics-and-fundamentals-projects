using FootballManager.Models.Contracts;
using FootballManager.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        private readonly List<ITeam> models;

        public TeamRepository()
        {
            this.models = new List<ITeam>();
            
            this.Models = models.AsReadOnly();
        }

        public IReadOnlyCollection<ITeam> Models { get; }

        public int Capacity => 10;

        public void Add(ITeam model)
        {
            if (this.models.Count<this.Capacity)
                this.models.Add(model);
        }

        public bool Exists(string name)
        {
            
            return this.Models.Any(t => t.Name == name);
        }

        public ITeam Get(string name)
        {
            return this.Models.FirstOrDefault(t => t.Name == name);
        }

        public bool Remove(string name)
        {
            ITeam team = this.models.FirstOrDefault(t => t.Name == name);
            if (team != null)
            {
                this.models.Remove(team);
                return true;
            }
            else return false;
        }
    }
}
