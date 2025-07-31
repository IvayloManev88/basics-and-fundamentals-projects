using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl
{
    public class Rebel : IRebelable, IBuyer
    {
        public const int DefatultFood = 0;

        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Food = DefatultFood;
            Group = group;
        }

        public string Name { get; }

        public int Age { get; }

        public int Food { get; private set; }
        public string Group { get; }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
