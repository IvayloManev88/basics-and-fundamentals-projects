namespace Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(", ");
            Article article = new Article()
            {
                Title = inputs[0],
                Content = inputs[1],
                Author = inputs[2],
            };
            int inputsNumber=int.Parse(Console.ReadLine());
            for (int i = 1; i<=inputsNumber; i++)
            {
                string[] tokens = Console.ReadLine().Split(": ");
                switch (tokens[0])
                {
                    case "Edit":
                        article.Edit(tokens[1]);
                        break;
                    case "ChangeAuthor":
                        article.ChangeAuthor(tokens[1]);
                        break;
                    case "Rename":
                        article.Rename(tokens[1]);
                        break;
                }
            }
            Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
        }
    }
    public class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public void Edit(string input)
        {
            Content = input;
        }
        public void ChangeAuthor(string input)
        {
            Author = input;
        }
        public void Rename(string input)
        {
            Title = input;
        }
    }
}
