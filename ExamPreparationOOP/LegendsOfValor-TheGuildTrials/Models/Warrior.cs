using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsOfValor_TheGuildTrials.Models
{
    public class Warrior : Hero
    {
        public Warrior(string name, string runeMark) : base(name, runeMark, 60, 0, 100)
        {
        }

        public override void Train()
        {
            this.Power += 30;
            this.Stamina += 10;
        }
    }
}
