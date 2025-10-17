using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Repositories.Contratcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsOfValor_TheGuildTrials.Repositories
{
    public class GuildRepository : IRepository<IGuild>
    {
        private readonly List<IGuild> guilds= new List<IGuild>();

        public IReadOnlyCollection<IGuild> Guilds => guilds.AsReadOnly();
        public void AddModel(IGuild entity)
        {
            this.guilds.Add(entity);
        }

        public IReadOnlyCollection<IGuild> GetAll()
        {
            return Guilds;
        }

        public IGuild GetModel(string runeMarkOrGuildName) => Guilds.FirstOrDefault(g => g.Name == runeMarkOrGuildName);
        
    }
}
