using System.ComponentModel.Design;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            int inputs = int.Parse(Console.ReadLine());
            List <IBuyer> list = new List <IBuyer> ();

            for (int i = 0; i < inputs; i++)
            {
                string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                IBuyer current = commands.Length switch
                {
                    3 => new Rebel(commands[0], int.Parse(commands[1]), commands[2]),
                    4 => new Citizen(commands[0], int.Parse(commands[1]), commands[2], DateTime.ParseExact(commands[3], "dd/MM/yyyy", CultureInfo.InvariantCulture)),
                    _ => null
                };

                if (current == null) continue;

                list.Add (current);
            }
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                IBuyer current = list.FirstOrDefault(n=>n.Name == input);
                if (current!=null)  current.BuyFood();
            }


            Console.WriteLine(list.Sum(s=>s.Food));
        }
    }
}
