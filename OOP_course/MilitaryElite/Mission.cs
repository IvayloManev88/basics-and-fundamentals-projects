using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
    public class Mission : IMission
    {
        private static HashSet<string> _validStates = new HashSet<string>
        {
            "InProgress",
            "Finished"
        };
        public string CodeName { get; }

        public string State { get; }
        public Mission(string codeName, string state)
        {
            if (!_validStates.Contains(state)) throw new ArgumentException("Invalid state");

            CodeName = codeName;
            State = state;
        }
        public override string ToString() => $"Code Name: {this.CodeName} State: {this.State}";
       
    }
}
