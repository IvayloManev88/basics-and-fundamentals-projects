using System.Linq;

namespace ShoppingList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> groceries = Console.ReadLine().Split("!").ToList();
            string input =string.Empty;
            while ((input=Console.ReadLine())!= "Go Shopping!")
            {
                List<string> inputs = input.Split().ToList();
                switch (inputs[0])
                {
                    case "Urgent":
                    if (!groceries.Contains(inputs[1])) groceries.Insert(0,inputs[1]);                     
                        break;
                    case "Unnecessary":
                    if (groceries.Contains(inputs[1])) groceries.Remove(inputs[1]);
                    break;
                    case "Correct":
                        if (groceries.Contains(inputs[1]))
                        {
                            groceries[groceries.FindIndex(g=> g== inputs[1])]= inputs[2];
                        }
                    break;
                    case "Rearrange":
                        if (groceries.Contains(inputs[1]))
                        {
                            groceries.RemoveAt(groceries.FindIndex(g => g == inputs[1]));
                            groceries.Add(inputs[1]);
                        }
                        break;



                }
            }
            Console.WriteLine(string.Join(", ", groceries));
        }
    }
}
