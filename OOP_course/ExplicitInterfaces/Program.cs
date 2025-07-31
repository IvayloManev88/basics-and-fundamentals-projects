namespace ExplicitInterfaces
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commands = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Citizen citizen = new Citizen(commands[0], commands[1], int.Parse(commands[2]));
                IPerson iperson = citizen;
                IResident iresident = citizen;
                Console.WriteLine(iperson.GetName());
                Console.WriteLine(iresident.GetName());
            }
        }
    }
}
