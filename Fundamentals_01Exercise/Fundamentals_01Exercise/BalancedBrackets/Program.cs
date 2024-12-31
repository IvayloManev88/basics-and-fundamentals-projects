using System.Security.Cryptography.X509Certificates;

namespace BalancedBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input = "";
            bool isOpened=false;
            bool isClosed = false;
            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine();
                char currentChar = ' ';
                char.TryParse(input, out currentChar);
                
                if (currentChar == '(')
                {
                    if (isOpened) break;
                    else
                    {
                        isOpened = true;
                        isClosed = false;
                    }
                }
                else if (currentChar == ')' && isOpened) 
                {
                    isClosed=true;
                    isOpened = false;
                }
            }
            if (isClosed && !isOpened) Console.WriteLine("BALANCED");
            else Console.WriteLine("UNBALANCED");




        }
    }
}
