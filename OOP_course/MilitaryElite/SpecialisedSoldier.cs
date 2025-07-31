using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
    public abstract class SpecialisedSoldier : Private,ISpecialisedSoldier
    {
        private static readonly HashSet<string> _validCorpsValues = new HashSet<string> { "Airforces", "Marines" };
        public string Corps { get; }
        protected SpecialisedSoldier(string id, string firstName, string lastNamedecimal, decimal salary, string corps) : base(id, firstName, lastNamedecimal, salary)
        {
            if (!_validCorpsValues.Contains(corps))
                throw new ArgumentException("Invalid corps");
            
               Corps = corps;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.Append($"Corps: {this.Corps}");

            return sb.ToString();
        }
    }
}
