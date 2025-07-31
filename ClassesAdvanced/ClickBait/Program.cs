namespace ClickBait
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Queue<int> suggestedLinks = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> featuredArticles = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int targetValue = int.Parse(Console.ReadLine());
            List<int> finalFeed = new List<int>();
            while(suggestedLinks.Count > 0 && featuredArticles.Count > 0)
            {
                int currentLink = suggestedLinks.Dequeue();
                int currentArticle = featuredArticles.Pop();
                if (currentLink > currentArticle)
                {
                    int remainder = currentLink % currentArticle;
                    finalFeed.Add(-1*remainder);
                    if (remainder !=0) suggestedLinks.Enqueue(2*remainder);
                }
                else if (currentLink < currentArticle)
                {
                    int remainder = currentArticle % currentLink;
                    finalFeed.Add(remainder);
                    if (remainder != 0) featuredArticles.Push(2 * remainder);
                }
                else finalFeed.Add(0);
            }
            int totalCalculated = finalFeed.Sum();
            Console.WriteLine($"Final Feed: {string.Join(", ", finalFeed)}");
            if (totalCalculated >= targetValue)
                Console.WriteLine($"Goal achieved! Engagement Value: {totalCalculated}");
            else Console.WriteLine($"Goal not achieved! Short by: {targetValue - totalCalculated}");
            
        }
    }
}
