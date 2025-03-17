namespace DragonArmy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary <string, List<Dragon>> dragonColors = new Dictionary<string, List<Dragon>>();
            int countDragons = int.Parse(Console.ReadLine());
            for (int i = 0; i < countDragons; i++)
            {
                string[] inputs = Console.ReadLine().Split();
                string color = inputs[0];
                string name = inputs[1];
                int damage = (inputs[2] != "null") ? int.Parse(inputs[2]) : 45;
                int health = (inputs[3] != "null") ? int.Parse(inputs[3]) : 250;
                int armor = (inputs[4] != "null") ? int.Parse(inputs[4]) : 10;
                Dragon inputDragon = new Dragon()
                {
                    Name = name,
                    Damage = damage,
                    Health = health,
                    Armor = armor,

                };
                if (!dragonColors.ContainsKey(color))
                {
                    dragonColors.Add(color, new List<Dragon>());
                }

                if (!dragonColors[color].Any(d=>d.Name==name))
                {
                    dragonColors[color].Add(inputDragon);
                }
                else
                {
                    Dragon matchDragon = dragonColors[color].FirstOrDefault(d=>d.Name==name);
                    matchDragon.Damage = damage;
                    matchDragon.Health = health;
                    matchDragon.Armor = armor;
                }


            }

            foreach (KeyValuePair<string, List<Dragon>> dragons in dragonColors)
            {
                List<Dragon> orderedDragon = new();
                orderedDragon = dragons.Value.OrderBy(x => x.Name).ToList();
                dragonColors[dragons.Key] = orderedDragon;
                Console.WriteLine($"{dragons.Key}::({dragons.Value.Average(x=> x.Damage):f2}/{dragons.Value.Average(x => x.Health):f2}/{dragons.Value.Average(x => x.Armor):f2})");
                foreach (Dragon dragon in orderedDragon)
                {
                    Console.WriteLine($"-{dragon.Name} -> damage: {dragon.Damage}, health: {dragon.Health}, armor: {dragon.Armor}");
                }
            }
            
            
        }
    }
    public class Dragon
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
    }
}
