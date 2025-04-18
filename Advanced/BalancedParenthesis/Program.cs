using System.Security.Cryptography.X509Certificates;

namespace BalancedParenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //{ [ ( ) ] } 
            Stack<char> parenthesis = new();
            string input = Console.ReadLine();
            for (int i = 0; i< input.Length; i++)
            {
                if ((input[i] == ')' || input[i] == ']' || input[i] == '}')&&parenthesis.Count==0)
                {
                    Console.WriteLine("NO");
                    return;
                }
                    else if (input[i] == '(' || input[i] == '[' || input[i] == '{')
                {
                    parenthesis.Push(input[i]);
                }
                else if (input[i] == ')')
                {
                    if (parenthesis.Peek() == '(') parenthesis.Pop();
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
                else if (input[i] == ']')
                {
                    if (parenthesis.Peek() == '[') parenthesis.Pop();
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
                else if (input[i] == '}')
                {
                    if (parenthesis.Peek() == '{') parenthesis.Pop();
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }

            }
            if (parenthesis.Count == 0) Console.WriteLine("YES");
        }
    }
}
