namespace ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary <string,List<string>> forceToJedi = new ();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                string[] inputs = new string[2];
                string name = string.Empty;
                string side = string.Empty;
                if (input.Contains('|'))
                {
                    inputs = input.Split(" | ");
                    name = inputs[1];
                    side = inputs[0];
                    if (!forceToJedi.ContainsKey(side))
                    {
                        forceToJedi.Add(side, new());
                    }
                    bool isNew = true;
                    foreach (List<string> names in forceToJedi.Values)
                    {
                        if (names.Contains(name))
                        {
                            isNew = false;
                        }
                    }
                    if (isNew) forceToJedi[side].Add(name);
                }
                else
                {
                    inputs = input.Split(" -> ");
                    name = inputs[0];
                    side = inputs[1];
                    if (!forceToJedi.ContainsKey(side))
                    {
                        forceToJedi.Add(side, new());
                    }
                    
                    string sideFound = string.Empty;
                    foreach (List<string> names in forceToJedi.Values)
                    {
                        if (names.Contains(name))
                        {
                            names.Remove(name);
                            
                        }
                    }
                    forceToJedi[side].Add(name);
                    Console.WriteLine($"{name} joins the {side} side!");
                }

            }
            forceToJedi=forceToJedi.OrderByDescending(x=>x.Value.Count()).ThenBy(x=>x.Key).ToDictionary(x=>x.Key,x=>x.Value);
            foreach ((string force, List<string> names) in forceToJedi)
            {
                if (names.Count() > 0)
                {
                    Console.WriteLine($"Side: {force}, Members: {names.Count}");
                    List<string>sorted = names.OrderBy(x=>x).ToList();
                    foreach (string name in sorted)
                    {
                        Console.WriteLine($"! {name}");
                    }
                }
            }

        }
    }
}
