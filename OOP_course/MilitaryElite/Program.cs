using MilitaryElite.Interfaces;

namespace MilitaryElite
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, ISoldier> soldiers = ReadSoldiers();

            foreach (ISoldier soldier in soldiers.Values)
            {
                Console.WriteLine(soldier);
            }
        }

        private static Dictionary<string, ISoldier> ReadSoldiers()
        {
            string input;
            Dictionary <string, ISoldier> soldiers = new Dictionary<string, ISoldier>();
            while ((input = Console.ReadLine()) != "End")
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    ISoldier currentSoldier = ReadSoldier(data, soldiers);
                    soldiers[currentSoldier.Id] = currentSoldier;
                }
                catch
                {

                }
              
            }
            return soldiers;
        }

        private static ISoldier ReadSoldier(string[] data, Dictionary<string, ISoldier> soldiers)
        {
            if (data[0] == nameof(Private))
            {
                Private currentPrivate = new Private(data[1], data[2], data[3], decimal.Parse(data[4]));
                return currentPrivate;
            }
            else if (data[0] == nameof(LieutenantGeneral))
            {
                LieutenantGeneral currentLeutenant = new LieutenantGeneral(data[1], data[2], data[3], decimal.Parse(data[4]));
                for (int i = 5; i<data.Length;i++)
                {
                    ISoldier soldierUnderCommand = soldiers[data[i]];
                    currentLeutenant.AddSoldierUnderCommand(soldierUnderCommand);
                }
                return currentLeutenant;
            }
            else if (data[0] == nameof(Engineer))
            {
                Engineer engineer = new Engineer(data[1], data[2], data[3], decimal.Parse(data[4]), data[5]);
                for (int i = 6; i<data.Length; i+=2)
                {
                    Repair repair = new Repair(data[i], int.Parse(data[i+1]));
                    engineer.AddRepair(repair);
                }
                                
                return engineer;
            }
            else if (data[0] == nameof(Commando))
            {
                Commando comanndo = new Commando(data[1], data[2], data[3], decimal.Parse(data[4]), data[5]);

                for (int i = 6; i < data.Length; i += 2)
                {
                    try
                    {
                    Mission mission = new Mission(data[i], data[i + 1]);
                    comanndo.AddMission(mission);

                    }
                    catch { }
                }
                return comanndo;
            }
            else if (data[0] == nameof(Spy))
            {
                Spy spy = new Spy(data[1], data[2], data[3], int.Parse(data[4]));
                return spy;
            }

            throw new InvalidOperationException("Invalid soldier type");
        }
    }
}
