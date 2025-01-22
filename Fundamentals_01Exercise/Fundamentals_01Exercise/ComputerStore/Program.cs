using System.Diagnostics;

namespace ComputerStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            decimal totalAmountNoTaxes = 0;
            decimal inputAmount = 0;
            while ((input !="regular") && (input != "special"))
            {
                inputAmount=decimal.Parse(input);
                if (inputAmount<=0)
                {
                    Console.WriteLine("Invalid price!");
                    input = Console.ReadLine();
                    continue;
                }
                totalAmountNoTaxes += inputAmount;
                input = Console.ReadLine();
            }
            if (totalAmountNoTaxes == 0) Console.WriteLine("Invalid order!");
            else
            {
                decimal totalAmount = (decimal)1.2 * totalAmountNoTaxes;
                decimal taxesAmount = (decimal)0.2 * totalAmountNoTaxes;
                if (input == "special")
                {
                    totalAmount = totalAmount * (decimal)0.9;
                }

                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {totalAmountNoTaxes:f2}$");
                Console.WriteLine($"Taxes: {taxesAmount:f2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {totalAmount:f2}$");

            }
        }
    }
}
