using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private readonly List<ISoldier> _soldiersUnderCommand;
        public IReadOnlyCollection<ISoldier> SoldiersUnderCommand { get; }
        public LieutenantGeneral(string id, string firstName, string lastNamedecimal, decimal salary) : base(id, firstName, lastNamedecimal, salary)
        {
            this._soldiersUnderCommand = new List<ISoldier>();
            this.SoldiersUnderCommand=_soldiersUnderCommand.AsReadOnly();
        }

        public void AddSoldierUnderCommand(ISoldier soldier) => this._soldiersUnderCommand.Add(soldier);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.Append("Privates:");
            foreach (ISoldier soldier in  this._soldiersUnderCommand)
            {
                sb.AppendLine();
                sb.Append("  ");
                sb.Append(soldier.ToString());
            }

            return sb.ToString();

        }

    }
}
