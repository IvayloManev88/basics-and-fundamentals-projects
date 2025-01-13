using System.IO.IsolatedStorage;

namespace CharactersInRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char a = char.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());
            CharPrinter(a, b);
        }
        static void CharPrinter(char a, char b)
        {
            int beginningChar = 0;
            int endingChar = 0;
            if ((int)a < (int)b)
            {
                beginningChar = (int)a;
                endingChar = (int)b;
            }
            else
            {
                beginningChar = (int)b;
                endingChar = (int)a;
            }
            char[] output= new char[(endingChar - beginningChar-1)];
            int array = 0;
            for (int i = (beginningChar+1); i < endingChar; i++)
            {
                
                output[array] = (char)i;
                array++;
            }
            Console.WriteLine(string.Join(" ", output));
        }
    }
}
