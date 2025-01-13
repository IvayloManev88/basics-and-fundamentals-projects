namespace VowelsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            VowelsCounter(input);
        }
        static void VowelsCounter(string input)
        {
            char[] chars = input.ToCharArray();
            int counter = 0;
            foreach (char c in chars)
            {
                if (c=='a' || c =='e'|| c == 'o' || c == 'u' || c == 'A' || c == 'E' || c == 'O' || c == 'U' || c == 'i' || c == 'I' || c == 'y' || c == 'Y' )
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
