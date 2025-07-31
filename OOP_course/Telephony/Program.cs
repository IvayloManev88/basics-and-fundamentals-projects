using System.Runtime.CompilerServices;

namespace Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] websites = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);


            foreach (string number in numbers)
            {

                
                if (number.All(char.IsDigit))
                {
                    if (number.Length == 7)
                    {
                        StationaryPhone phone = new StationaryPhone();
                        Console.WriteLine(phone.Call(number));
                    }
                    else if (number.Length == 10)
                    {
                        Smartphone phone = new Smartphone();
                        Console.WriteLine(phone.Call(number));
                    }
                    else Console.WriteLine("Invalid number!");

                }
                else Console.WriteLine("Invalid number!");

            }

            foreach (string web in websites)
            {
                Smartphone phone = new Smartphone();
                Console.WriteLine(phone.Browse(web));
            }
        }
    }
}
