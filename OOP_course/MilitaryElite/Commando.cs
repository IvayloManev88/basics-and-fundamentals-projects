using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private readonly List<IMission> _missions;
        public IReadOnlyCollection<IMission> Missions { get; }
        public Commando(string id, string firstName, string lastNamedecimal, decimal salary, string corps) : base(id, firstName, lastNamedecimal, salary, corps)
        {
            this._missions = new List<IMission>();
            this.Missions = _missions.AsReadOnly();
        }

        public void AddMission(IMission mission)=> _missions.Add(mission);


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            
            sb.Append("Missions:");
            foreach (IMission mission in this._missions)
            {
                sb.AppendLine();
                sb.Append("  ");
                sb.Append(mission.ToString());
            }
            return sb.ToString();
             
        }
    }
}
