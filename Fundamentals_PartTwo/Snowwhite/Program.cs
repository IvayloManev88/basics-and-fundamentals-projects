namespace Snowwhite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dwarfsCountByColor = new Dictionary<string, int>();
            var dwarfs = new List<Dwarf>();

            while (true)
            {
                var input = Console.ReadLine()!;

                if (input == "Once upon a time")
                {
                    break;
                }

                var inputArgs = input.Split(" <:> ");

                var name = inputArgs[0];
                var color = inputArgs[1];
                var physics = int.Parse(inputArgs[2]);

                var currentDwarf = dwarfs.FirstOrDefault(d => d.Name == name && d.Color == color);

                if (currentDwarf is null)
                {
                    currentDwarf = new Dwarf
                    {
                        Name = name,
                        Color = color,
                        Physics = physics
                    };

                    dwarfs.Add(currentDwarf);
                    dwarfsCountByColor.TryAdd(color, 0);
                    dwarfsCountByColor[color]++;
                }

                if (physics > currentDwarf.Physics)
                {
                    currentDwarf.Physics = physics;
                }
            }

            var orderedDwarfs = dwarfs
                .OrderByDescending(x => x.Physics)
                .ThenByDescending(x => dwarfsCountByColor[x.Color])
                .ToList();

            foreach (var dwarf in orderedDwarfs)
            {
                Console.WriteLine($"({dwarf.Color}) {dwarf.Name} <-> {dwarf.Physics}");
            }
        }
        public class Dwarf
        {
            public required string Color { get; init; }

            public required string Name { get; init; }

            public int Physics { get; set; }
        }

    }
}
