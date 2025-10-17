using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsOfValor_TheGuildTrials.Models
{
    public class Spellblade : Hero
    {
        public Spellblade(string name, string runeMark) : base(name, runeMark, 50, 60, 60)
        {
        }

        public override void Train()
        {
            this.Power += 15;
            this.Mana += 10;
            this.Stamina += 10;
        }
    }
}
