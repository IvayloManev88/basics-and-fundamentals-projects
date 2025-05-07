namespace PredicateParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Func<string, string, bool>> filters = new()
            {
                ["StartsWith"] = (arg, name) => name.StartsWith(arg),
                ["EndsWith"] = (arg, name) => name.EndsWith(arg),
                ["Length"] = (arg, name) => name.Length==int.Parse(arg),
            };
            string[] goingToTheParty = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string command =string.Empty;
            while ((command = Console.ReadLine())!= "Party!")
            {
                string[] commands = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = commands[0];
                string condition = commands[1];
                string arg = commands[2];
                Func<string,string, bool> currentFunc = filters[condition];
                List<string> resultName = new List<string>();
                for (int i = 0; i < goingToTheParty.Length; i++)
                {
                    if (currentFunc(arg,goingToTheParty[i]))
                    {
                        if (action=="Remove")
                        {

                        }
                        else if (action=="Double")
                        {
                            resultName.Add(goingToTheParty[i]);
                            resultName.Add(goingToTheParty[i]);

                        }
                    }
                    else resultName.Add(goingToTheParty[i]);
                }
                goingToTheParty= resultName.ToArray();
            }
            if (goingToTheParty.Length > 0)
            {
                Console.WriteLine($"{string.Join(", ", goingToTheParty)} are going to the party!");
            }
            else Console.WriteLine("Nobody is going to the party!");
        }
    }
}
