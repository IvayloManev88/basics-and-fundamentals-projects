using System.Net;

namespace StoreBoxes
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string input = string.Empty;
            List<Boxes> boxes = new();
            while ((input = Console.ReadLine())!="end")
            {
                List<string> tokens = input.Split().ToList();
                Boxes currentBox = new Boxes
                {
                    SerialNumber = tokens[0],
                    Item=new Item(tokens[1], decimal.Parse(tokens[3])),
                    ItemQuantity=int.Parse(tokens[2])


                };
                boxes.Add(currentBox);

                

                
            }
            List <Boxes> orderedBoxes = boxes.OrderByDescending(b=>b.BoxPrice).ToList();
            foreach (Boxes printBox in orderedBoxes)
            {
                //{boxSerialNumber}
                //-- { boxItemName} – ${ boxItemPrice}: { boxItemQuantity}
                //-- ${ boxPrice}
                Console.WriteLine(printBox.SerialNumber);
                Console.WriteLine($"-- {printBox.Item.Name} - ${printBox.Item.Price:f2}: {printBox.ItemQuantity}");
                Console.WriteLine($"-- ${printBox.BoxPrice:f2}");
            }
        }
    }
    public class Boxes
    {
        
        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }

        public decimal BoxPrice 
        {

            get 
            {
               return this.ItemQuantity * this.Item.Price;

            }
        }

      
    }
    public class Item
    {
        public Item (string name, decimal price)
        {
            Name= name;
            Price= price;
        }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    
}
