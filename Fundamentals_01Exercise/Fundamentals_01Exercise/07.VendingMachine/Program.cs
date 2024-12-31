namespace _07.VendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            double amountAvailable = 0;
            
            while ((input = Console.ReadLine())!="Start")
            {
                double money = double.Parse(input);
                switch (money)
                {
                    case 0.1:
                    case 0.2:
                    case 0.5:
                    case 1:
                    case 2:
                        {
                            amountAvailable += money;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine($"Cannot accept {money}");
                        }
                        break;
                }            

            }
            while ((input = Console.ReadLine()) != "End")
            {
                double price = 0;
                switch (input)
                {
                    case "Nuts":
                        price = 2; 
                    break;
                    case "Water":
                        price = 0.7;
                    break;
                    case "Crisps":
                        price = 1.5; 
                    break;
                    case "Soda":
                        price = 0.8; 
                    break;
                    case "Coke":
                        price = 1; 
                    break;
                    default :
                        Console.WriteLine("Invalid product");
                    break;
                }

                if ((amountAvailable - price) >= 0 && price != 0) 
                {
                    Console.WriteLine($"Purchased {input.ToLower()}");
                    amountAvailable -= price;
                }
                else if ((amountAvailable - price) < 0 && price != 0)
                {
                    Console.WriteLine("Sorry, not enough money");
                }
            }
            Console.WriteLine($"Change: {amountAvailable:f2}");
        }
    }
}
