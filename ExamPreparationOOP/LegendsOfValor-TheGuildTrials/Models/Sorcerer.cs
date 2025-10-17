using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsOfValor_TheGuildTrials.Models
{
    public class Sorcerer : Hero
    {
        public Sorcerer(string name, string runeMark) : base(name, runeMark, 40, 120, 0)
        {
        }

        public override void Train()
        {
            this.Power += 20;
            this.Mana += 25;
        }
    }
}
