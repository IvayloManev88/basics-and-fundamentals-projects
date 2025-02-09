using System.Diagnostics;

namespace ShoppingSpree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> priceList = new List<Product>();
            string[] peopleTokens = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < peopleTokens.Length; i++)
            {
                string[] currentTokens = peopleTokens[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
                Person currentPerson = new()
                {
                    Name = currentTokens[0],
                    Money = decimal.Parse(currentTokens[1])
                };
                people.Add(currentPerson);
            }
            string[] productTokens = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0;i < productTokens.Length;i++)
            {
                string[] currentTokens = productTokens[i].Split("=",StringSplitOptions.RemoveEmptyEntries);
                Product currentProduct = new()
                {
                    ProductName = currentTokens[0],
                    Price = decimal.Parse(currentTokens[1])
                };
                priceList.Add(currentProduct);
            }
            string input =string.Empty;
            while ((input =Console.ReadLine())!="END")
            {
                string[] buyingTokens = input.Split();
                Person buyingPerson = people.FirstOrDefault(p => p.Name==buyingTokens[0]);
                buyingPerson.Buying(buyingTokens[1], priceList);
            }

            foreach (Person person in people)
            {
                List<string> outputProducts = person.BagOfProduct.Select(p=>p.ProductName).ToList();
                if (outputProducts.Any())
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", outputProducts)}");
                }
                else Console.WriteLine($"{person.Name} - Nothing bought");
            }



        }


        public class Person
        {
            
                
                
            public string Name { get; set; }
            public decimal Money { get; set; }
            public List<Product> BagOfProduct { get; set; }=new List<Product>();
            public void Buying(string productName, List<Product>priceList)
            {
                decimal currentPrice = priceList.FirstOrDefault(p=> p.ProductName== productName).Price;
                if (Money >= currentPrice)
                {
                    Money -= currentPrice;
                    Console.WriteLine($"{this.Name} bought {productName}");
                    this.BagOfProduct.Add(new Product(productName));
                }
                else Console.WriteLine($"{this.Name} can't afford {productName}");
            }
        }
        public class Product
        {
            public Product()
            {

            }
            public Product(string productName)
            {
                ProductName= productName;
            }
            public string ProductName { get; set; }
            public decimal Price { get; set; }
        }
    }
}
