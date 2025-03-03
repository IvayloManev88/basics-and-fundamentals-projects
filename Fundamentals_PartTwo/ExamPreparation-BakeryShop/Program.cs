using System.Numerics;

namespace ExamPreparation_BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> productsToQuantity = new Dictionary<string, int>();
            string input = string.Empty;
            int soldCounter = 0;
            while ((input=Console.ReadLine())!= "Complete")
            {
                string[] inputs = input.Split();
                string product = inputs[2];
                int quantity = int.Parse(inputs[1]);
                switch (inputs[0])
                {
                    case "Receive":
                        if (quantity > 0)
                        {
                            if (!productsToQuantity.ContainsKey(product))
                            {
                                productsToQuantity.Add(product, 0);
                            }
                            productsToQuantity[product] += quantity;
                        }
                        break;
                    case "Sell":
                        if (!productsToQuantity.ContainsKey(product)) Console.WriteLine($"You do not have any {product}.");
                        else
                        {
                            if (quantity <= productsToQuantity[product])
                            {
                                productsToQuantity[product] -= quantity;
                                soldCounter += quantity;
                                Console.WriteLine($"You sold {quantity} {product}.");
                                if (productsToQuantity[product]==0) productsToQuantity.Remove(product);
                            }
                            else
                            {
                                Console.WriteLine($"There aren't enough {product}. You sold the last {productsToQuantity[product]} of them.");
                                soldCounter += productsToQuantity[product];
                                productsToQuantity.Remove(product);
                            }
                        }
                        break;

                }
            }
            foreach (KeyValuePair<string, int> products in productsToQuantity)
            {
                Console.WriteLine($"{products.Key}: {products.Value}");
            }
            Console.WriteLine($"All sold: {soldCounter} goods");
        }
    }
}
