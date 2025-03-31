namespace SantaNew_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Dictionary<string, int> children = new Dictionary<string, int>();
            Dictionary<string,int> presents = new Dictionary<string, int>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputs = input.Split("->", StringSplitOptions.RemoveEmptyEntries);
                string childName = string.Empty;
                if (inputs[0]=="Remove")
                {
                     childName = inputs[1];
                    if (children.ContainsKey(childName)) children.Remove(childName);

                }
                else
                {
                    childName = inputs[0];
                    string toyName = inputs[1];
                    int toyCount = int.Parse(inputs[2]);
                    if (!children.ContainsKey(childName))
                    {
                        children.Add(childName, 0);
                    }
                    children[childName] += toyCount;
                    if (!presents.ContainsKey(toyName))
                    {
                        presents.Add(toyName, 0);
                    }
                    presents[toyName] += toyCount;
                }
            }
            children = children.OrderByDescending(x => x.Value).ThenBy(x=>x.Key).ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine("Children:");
            foreach (KeyValuePair<string, int> child in children)
            {
                Console.WriteLine($"{child.Key} -> {child.Value}");
            }
            Console.WriteLine("Presents:");
            foreach (KeyValuePair<string, int> present in presents)
            {
                Console.WriteLine($"{present.Key} -> {present.Value}");
            }
        }
    }
}
