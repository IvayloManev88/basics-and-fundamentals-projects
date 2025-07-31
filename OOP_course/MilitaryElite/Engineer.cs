using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
    public class Engineer : SpecialisedSoldier,IEngineer
    {
        private readonly List<IRepair> _repairs;
        public IReadOnlyCollection<IRepair> Repairs { get; }
        public Engineer(string id, string firstName, string lastNamedecimal, decimal salary, string corps) : base(id, firstName, lastNamedecimal, salary, corps)
        {
            this._repairs = new List<IRepair>();
            this.Repairs = _repairs.AsReadOnly();
        }

        public void AddRepair(IRepair repair) => _repairs.Add(repair);


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.Append("Repairs:");

            foreach (IRepair repair in this._repairs)
            {
                sb.AppendLine();
                sb.Append("  ");
                sb.Append(repair.ToString());
            }
            return sb.ToString();

            
        }
    }
}
