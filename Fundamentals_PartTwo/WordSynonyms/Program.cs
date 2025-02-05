namespace WordSynonyms
    
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberSynonims = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> Synonims = new();
            for (int i = 1; i <= numberSynonims; i++)
            {
                string generalWord = Console.ReadLine();
                string synonimWord = Console.ReadLine();
                if (!Synonims.ContainsKey(generalWord))
                {
                    Synonims.Add(generalWord, new List<string>());
                }
                Synonims[generalWord].Add(synonimWord);

            }
            foreach ((string word, List<string> synonims) in Synonims)
            {
                Console.WriteLine($"{word} - {string.Join(", ", synonims)}");
            }
        }
    }
}
