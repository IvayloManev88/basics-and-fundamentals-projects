namespace SoftUniParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> registeredCars = new();
            int numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 1; i <= numberOfCommands; i++)
            {
                List<string> commands = Console.ReadLine().Split().ToList();
                switch (commands[0])
                {
                    case "register":
                        if (registeredCars.ContainsKey(commands[1])) Console.WriteLine($"ERROR: already registered with plate number {commands[2]}");
                        else
                        {
                            registeredCars.Add(commands[1], commands[2]);
                            Console.WriteLine($"{commands[1]} registered {commands[2]} successfully");
                        }
                        break;


                    case "unregister":
                        if (!registeredCars.ContainsKey(commands[1])) Console.WriteLine($"ERROR: user {commands[1]} not found");
                        else
                        {
                            registeredCars.Remove(commands[1]);
                            Console.WriteLine($"{commands[1]} unregistered successfully");
                        }
                        break;
                }
               

            }
            foreach ((string userName, string licensePlateNumber) in registeredCars)
            {
                Console.WriteLine($"{userName} => {licensePlateNumber}");
            }
        }
    }
}
