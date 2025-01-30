namespace RandomizeWords
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] words = input.Split();
            Random rnd = new Random();
            for (int i = 0; i < words.Length; i++)
            {
                string temporaryWord = string.Empty;
                int randomIndex=rnd.Next(0, words.Length);
                temporaryWord = words[i];
                words[i] = words[randomIndex];
                words[randomIndex] = temporaryWord;
            }
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
