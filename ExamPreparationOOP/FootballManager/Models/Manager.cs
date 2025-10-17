using FootballManager.Models.Contracts;
using FootballManager.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Models
{
    public abstract class Manager : IManager
    {
        private string name;
        private double ranking;

        public double Ranking
        {
            get { return ranking; }
            protected set
            {
                if (value < 0) ranking = 0;
                else if (value > 100) ranking = 100;
                else ranking = value;

            }
        }


        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.ManagerNameNull);
                name = value;

            }
        }




        public Manager(string name, double ranking)
        {
            Name = name;
            Ranking = ranking;
        }




        public abstract void RankingUpdate(double updateValue);


        //here
        public override string ToString() => $"{this.Name} - {this.GetType().Name} (Ranking: {this.Ranking:F2})";


    }
}
