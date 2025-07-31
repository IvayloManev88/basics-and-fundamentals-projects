using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl
{
    public class Citizen : IIdentifiable, IBirthdateable, IRebelable, IBuyer
    {
        public const int DefatultFood = 0;
        public Citizen(string name, int age, string id, DateTime birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
            Food = DefatultFood;
        }

        public string Name { get; }
        public int Age { get; }

        public string Id { get; }
        public DateTime Birthdate { get; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
