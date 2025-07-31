using System.Security.Cryptography.X509Certificates;

namespace ListyIterator
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            ListyIterator<string> list = null;
            while ((command = Console.ReadLine()) != "END")
            {
                string [] commands = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                switch (commands[0])
                {
                    case "Create":
                       list = new ListyIterator<string>(commands.Skip(1).ToArray());
                        
                        break;
                    case "HasNext":
                        bool hasNext = list.HasNext();
                        Console.WriteLine(hasNext);
                        break;
                    case "Print":
                        list.Print();
                        break;
                    case "Move":
                        bool canMove = list.Move();
                        Console.WriteLine(canMove);
                        break;
                }
            }
            
        }
    }
}
