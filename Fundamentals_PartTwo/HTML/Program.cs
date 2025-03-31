using System.Text;

namespace HTML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder html = new StringBuilder();
            html.AppendLine("<h1>");
            html.AppendLine("\t" +Console.ReadLine());
            html.AppendLine("</h1>");
            html.AppendLine("<article>");
            html.AppendLine("\t"+Console.ReadLine());
            html.AppendLine("</article>");
            
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end of comments")
            {
                html.AppendLine("<div>");
                html.AppendLine("\t" + input);
                
                html.AppendLine("</div>");
            }
            Console.WriteLine(html.ToString());
        }
    }
}
