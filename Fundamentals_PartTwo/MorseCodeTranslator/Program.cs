using System.Text;

namespace MorseCodeTranslator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputMessage = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            StringBuilder message = new StringBuilder();
            Dictionary<string, char> morseCode = new()
            {
                {".-", 'A'},
                {"-...",'B'},
                {"-.-.",'C'},
                {"-..",'D'},
                {".", 'E'},
                {"..-.",'F'},
                {"--.",'G'},
                {"....",'H'},
                { "..",'I'},
                {".---",'J'},
                {"-.-",'K'},
                {".-..",'L'},
                {"--",'M'},
                {"-.",'N'},
                {"---",'O'},
                {".--.",'P'},
                {"--.-",'Q'},
                {".-.",'R'},
                {"...",'S'},
                {"-",'T'},
                {"..-",'U'},
                {"...-",'V'},
                {".--",'W'},
                {"-..-",'X'},
                {"-.--", 'Y'},
                {"--..",'Z'},
                {"-----",'0'},
                {".----",'1'},
                {"..---",'2'},
                {"...--",'3'},
                {"....-",'4'},
                {".....",'5'},
                {"-....",'6'},
                {"--...",'7'},
                {"---..",'8'},
                {"----.",'9'}

            };
            for (int i = 0; i < inputMessage.Length; i++)
            {
                string currentString = inputMessage[i];
                if (currentString == "|") message.Append(" ");
                else
                {
                    message.Append(morseCode[currentString]);
                }
            }
            Console.WriteLine(message.ToString());
        }
    }
}
