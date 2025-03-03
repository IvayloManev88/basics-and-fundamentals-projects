using System.Security.Cryptography.X509Certificates;

namespace ManOWar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateShip = Console.ReadLine().Split(">").Select(int.Parse).ToList();
            List<int> warShip = Console.ReadLine().Split(">").Select(int.Parse).ToList();
            int maximumHealth = int.Parse(Console.ReadLine());
            string input = string.Empty;
            while ((input = Console.ReadLine())!= "Retire")
            {
                string[] inputs = input.Split();
                int damage = 0;
                int index = 0;
                switch (inputs[0])
                {
                    case "Fire":
                        index = int.Parse(inputs[1]);
                        damage = int.Parse(inputs[2]);
                        if (index >= 0 && index < warShip.Count)
                        {
                            warShip[index] -= damage;
                            if (warShip[index]<=0)
                            {
                                Console.WriteLine("You won! The enemy ship has sunken.");
                                return;
                            }
                        }
                        break;
                    case "Defend":
                        int startIndex = int.Parse(inputs[1]);
                        int endIndex = int.Parse(inputs[2]);
                        damage = int.Parse(inputs[3]);
                        if (startIndex >= 0 && startIndex < pirateShip.Count&& endIndex >= 0 && endIndex < pirateShip.Count)
                        {
                            for (int i = startIndex; i <= endIndex;i++)
                            {
                                pirateShip[i] -= damage;
                                if (pirateShip[i]<=0)
                                {
                                    Console.WriteLine("You lost! The pirate ship has sunken.");
                                    return;
                                }
                            }
                        }
                        break;
                    case "Repair":
                        index = int.Parse(inputs[1]);
                        int health = int.Parse(inputs[2]);
                        if (index >= 0 && index < pirateShip.Count)
                        {
                            pirateShip[index] += health;
                            if (pirateShip[index] > maximumHealth) pirateShip[index] = maximumHealth;
                        }
                            break;
                    case "Status":
                        int countToRepair = pirateShip.Where(x => x < 0.2* maximumHealth).Count();
                        Console.WriteLine($"{countToRepair} sections need repair.");
                        break;
                }

            }
            Console.WriteLine($"Pirate ship status: {pirateShip.Sum()}");
            Console.WriteLine($"Warship status: {warShip.Sum()}");

        }
    }
}
