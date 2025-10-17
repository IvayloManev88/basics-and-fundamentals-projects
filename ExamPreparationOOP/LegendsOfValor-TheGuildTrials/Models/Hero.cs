using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsOfValor_TheGuildTrials.Models
{
    public abstract class Hero : IHero
    {

        private string name;
        private string runeMark;
        private string guildName;
        private int power;
        private int mana;
        private int stamina;
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ErrorMessages.InvalidHeroName);
                this.name = value;
            }
        }

        public string RuneMark
        {
            get => this.runeMark;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ErrorMessages.InvalidHeroRuneMark);
                this.runeMark = value;
            }
        }

        public string GuildName
        {
            get => this.guildName;
            private set
            {
                this.guildName = value;
            }
        }

        public int Power { get; protected set; }


        public int Mana { get; protected set; }
       

        public int Stamina { get; protected set; }

        protected Hero(string name, string runeMark, int power, int mana, int stamina)
        {
            this.Name = name;
            this.RuneMark = runeMark;
            this.Power = power;
            this.Mana = mana;
            this.Stamina = stamina;
        }

        public string Essence() => $"Essence Revealed - Power [{this.Power}] Mana [{this.Mana}] Stamina [{this.Stamina}]";
        
        //here
        public void JoinGuild(IGuild guild)
        {
            this.GuildName = guild.Name;
        }

        public abstract void Train();

        public override string ToString() => $"Hero: [{this.Name}] of the Guild '{this.GuildName}' - RuneMark: {this.RuneMark}";
        

    }
}
