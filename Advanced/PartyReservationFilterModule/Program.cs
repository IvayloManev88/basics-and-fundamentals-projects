using System.ComponentModel.Design;

namespace PartyReservationFilterModule
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //condition name : (arg)=> (invitedPersons) =>true  
            Dictionary<string, Func<string, Func<string, bool>>> filterFactories = new()
            {
                ["Starts with"] = (arg) => (invitedPerson) => invitedPerson.StartsWith(arg),
                ["Ends with"] = (arg) => (invitedPerson) => invitedPerson.EndsWith(arg),
                ["Length"] = (arg) =>
                {
                    int length = int.Parse(arg);
                    return (invitedPerson)=>invitedPerson.Length==length;
                },
                ["Contains"] = (arg) => (invitedPerson) => invitedPerson.Contains(arg)
            };
            Dictionary<(string Name, string Arg), Func<string, bool>> filters = new();
            string[] invitedPersons = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Print")
            {
                string[] commands = command.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string typeFilter = commands[0];
                string condition = commands[1];
                string arg = commands[2];
                (string Name, string Arg) filterKey  = (condition, arg);

                if (typeFilter == "Remove filter")
                {
                    filters.Remove(filterKey);
                }
                else if (typeFilter =="Add filter")
                {
                    Func <string, Func<string, bool>> factory = filterFactories[condition];
                    Func <string, bool> filter = factory(arg);
                    filters[filterKey] = filter;
                }
                
            }
            foreach (string invited in  invitedPersons)
            {
                bool isValid = true;
                foreach (Func<string, bool > filter in filters.Values)
                {
                    if (filter(invited))
                    {
                        isValid = false;
                        break;

                    }

                }
                if (isValid) Console.Write($"{invited} ");

            }
            Console.WriteLine();
        }
    }
}
