using LegendsOfValor_TheGuildTrials.Core.Contracts;
using LegendsOfValor_TheGuildTrials.Models;
using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Repositories;
using LegendsOfValor_TheGuildTrials.Repositories.Contratcs;
using LegendsOfValor_TheGuildTrials.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsOfValor_TheGuildTrials.Core
{
    public class Controller : IController
    {
        private IRepository<IHero> heroes;
        private IRepository<IGuild> guilds;

        public Controller()
        {
            this.heroes = new HeroRepository();
            this.guilds = new GuildRepository();
        }

        public string AddHero(string heroTypeName, string heroName, string runeMark)
        {
            if (heroTypeName != "Warrior" && heroTypeName != "Sorcerer" && heroTypeName != "Spellblade")
                return string.Format(OutputMessages.InvalidHeroType, heroTypeName);
            if (heroes.GetModel(runeMark) != null)
                return string.Format(OutputMessages.HeroAlreadyExists, runeMark);
            IHero hero;
            if (heroTypeName == "Warrior") hero = new Warrior(heroName, runeMark);
            else if (heroTypeName == "Sorcerer") hero = new Sorcerer(heroName, runeMark);
            else hero = new Spellblade(heroName, runeMark);

            heroes.AddModel(hero);
            return string.Format(OutputMessages.HeroAdded, heroTypeName, heroName, runeMark);
        }

        public string CreateGuild(string guildName)
        {
            if (guilds.GetModel(guildName) != null)
                return string.Format(OutputMessages.GuildAlreadyExists, guildName);

            Guild guild = new Guild(guildName);
            guilds.AddModel(guild);
            return string.Format(OutputMessages.GuildCreated, guildName);

        }

        public string RecruitHero(string runeMark, string guildName)
        {
            IHero currentHero = heroes.GetModel(runeMark);
            IGuild currentGuild = guilds.GetModel(guildName);
            if (currentHero == null)
                return string.Format(OutputMessages.HeroNotFound, runeMark);
            if (currentGuild == null)
                return string.Format(OutputMessages.GuildNotFound, guildName);
            if (!string.IsNullOrEmpty(currentHero.GuildName))
                return string.Format(OutputMessages.HeroAlreadyInGuild, currentHero.Name);
            if (currentGuild.IsFallen)
                return string.Format(OutputMessages.GuildIsFallen, currentGuild.Name);
            if (currentGuild.Wealth < 500)
                return string.Format(OutputMessages.GuildCannotAffordRecruitment, currentGuild.Name);

            bool isHeroAllowed = false;
            string typeHero = currentHero.GetType().Name;
            string typeGuild = currentGuild.Name;
            if (typeHero == "Warrior")
            {
                if (typeGuild == "WarriorGuild" || typeGuild == "ShadowGuild") isHeroAllowed = true;
            }
            else if (typeHero == "Sorcerer")
            {
                if (typeGuild == "SorcererGuild" || typeGuild == "ShadowGuild") isHeroAllowed = true;
            }
            else if (typeHero == "Spellblade")
            {
                if (typeGuild == "SorcererGuild" || typeGuild == "WarriorGuild") isHeroAllowed = true;
            }
            if (!isHeroAllowed)
                return string.Format(OutputMessages.HeroTypeNotCompatible, typeHero, typeGuild);


            currentHero.JoinGuild(currentGuild);
            currentGuild.RecruitHero(currentHero);
            return string.Format(OutputMessages.HeroRecruited, currentHero.Name, currentGuild.Name);


        }

        public string StartWar(string attackerGuildName, string defenderGuildName)
        {
            IGuild attacker = guilds.GetModel(attackerGuildName);
            IGuild defender = guilds.GetModel(defenderGuildName);
            if (attacker == null || defender == null)
                return string.Format(OutputMessages.OneOfTheGuildsDoesNotExist);
            if (attacker.IsFallen || defender.IsFallen)
                return string.Format(OutputMessages.OneOfTheGuildsIsFallen);
            int attackerPower = 0;
            int defenderPower = 0;
            List<IHero> attackerHeroes = heroes.GetAll().Where(h => h.GuildName == attacker.Name).ToList();
            foreach (IHero hero in attackerHeroes)
            {
                attackerPower += hero.Power + hero.Mana + hero.Stamina;

            }
            List<IHero> defenderHeroes = heroes.GetAll().Where(h => h.GuildName == defender.Name).ToList();
            foreach (IHero hero in defenderHeroes)
            {
                defenderPower += hero.Power + hero.Mana + hero.Stamina;

            }
            if (attackerPower > defenderPower)
            {
                int wonGold = defender.Wealth;
                attacker.WinWar(wonGold);
                defender.LoseWar();
                return string.Format(OutputMessages.WarWon, attacker.Name, defender.Name, wonGold);
            }
            else
            {
                int wonGold = attacker.Wealth;
                defender.WinWar(wonGold);
                attacker.LoseWar();
                return string.Format(OutputMessages.WarLost, defender.Name, wonGold, attacker.Name );
            }

        }

        public string TrainingDay(string guildName)
        {

            IGuild currentGuild = guilds.GetModel(guildName);
            if (currentGuild == null)
                return string.Format(OutputMessages.GuildNotFound, guildName);

            if (currentGuild.IsFallen)
                return string.Format(OutputMessages.GuildTrainingDayIsFallen, guildName);

            int totalTrainingCost = 200 * currentGuild.Legion.Count();
            if (currentGuild.Wealth < totalTrainingCost)
                return string.Format(OutputMessages.TrainingDayFailed, guildName);
            List<IHero> heroesToTrain = heroes.GetAll().Where(h => h.GuildName == guildName).ToList();
            currentGuild.TrainLegion(heroesToTrain);
            return string.Format(OutputMessages.TrainingDayStarted, guildName, heroesToTrain.Count, totalTrainingCost);

        }

        public string ValorState()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Valor State:");
            foreach (IGuild guild in guilds.GetAll().OrderByDescending(g => g.Wealth))
            {
                sb.AppendLine($"{guild.Name} (Wealth: {guild.Wealth})");
                foreach (IHero hero in heroes.GetAll().Where(h => h.GuildName == guild.Name).OrderBy(h => h.Name))
                {
                    sb.AppendLine($"-{hero.ToString()}");
                    sb.AppendLine($"--{hero.Essence()}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
