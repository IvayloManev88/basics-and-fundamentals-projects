namespace AdvertisementMessage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfMessages = int.Parse(Console.ReadLine());
            List<string> Phrases = new() { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can't live without this product." };
            List<string> Events = new List<string>() { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
            List<string> Authors = new List<string>() { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            List<string> Cities = new List<string>() { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };
            for (int i = 1; i <= numberOfMessages; i++)
            {
                
                Random random = new Random();
                int phraseIndex = random.Next(0, Phrases.Count);
                int eventsIndex = random.Next(0, Events.Count);
                int authorsIndex = random.Next(0, Authors.Count);
                int citiesIndex = random.Next(0, Cities.Count);
                Console.WriteLine($"{Phrases[phraseIndex]} {Events[eventsIndex]} {Authors[authorsIndex]} – {Cities[citiesIndex]}.");


            }
        }
    }
    //public class Message
    //{
    //    public Message()
    //    {
    //        List<string> Phrases = new() { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can't live without this product." };
    //        List<string> Events = new List<string>() { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
    //        List<string> Authors = new List<string>() { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
    //        List<string> Cities = new List<string>() { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

    //    }
    //    public List<string> Phrases { get; set; }
    //    public List<string> Events { get; set; }
    //    public List<string> Authors { get; set; }
    //    public List<string> Cities { get; set; }
    //}
}
