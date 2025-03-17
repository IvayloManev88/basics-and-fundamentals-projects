namespace SnowwhiteWithClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Dwarf> dwarfList = new();
            string input = string.Empty;
            int counter = 0;
            while ((input = Console.ReadLine()) != "Once upon a time")
            {
                string[] inputs = input.Split(" <:> ");
                string color = inputs[1];
                string name = inputs[0];
                counter++;
                int physics = int.Parse(inputs[2]);
                Dwarf inputDwarf = new Dwarf(name, physics, counter, color);
                
                if (!dwarfList.Any(d=>d.Name==name&&d.Color==color))
                {
                    dwarfList.Add(inputDwarf);
                }
                else
                {
                    Dwarf currentDwarf = dwarfList.First(d=>d.Name==name&& d.Color==color);
                    if (currentDwarf!=null)
                    {
                        
                        if (currentDwarf.Physics < physics) currentDwarf.Physics = physics;
                    }
                    else
                    {
                        dwarfList.Add(inputDwarf);
                    }
                }
            }
            List<Dwarf> orderedDwarf = dwarfList.OrderByDescending(dwarf => dwarf.Physics).ThenByDescending(dwarf => dwarfList.Count(dw=> dw.Color ==dwarf.Color)).ToList();
            foreach (Dwarf dwarf in orderedDwarf)
            {
                
                    Console.WriteLine($"({dwarf.Color}) {dwarf.Name} <-> {dwarf.Physics}");
                
            }
        }
        public class Dwarf
        {
            public Dwarf(string name, int physics, int id, string color)
            {
                Name = name;
                Physics = physics;
                Id = id;
                Color = color;
            }
            public string Name { get; set; }
            public string Color { get; set; }
            public int Physics { get; set; }
            public int Id { get; set; }
        }
            
    }


}