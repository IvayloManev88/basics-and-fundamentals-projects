using System.Text;

namespace ExamPreparation_ImitationGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();
            string command = string.Empty;
            StringBuilder decryptedMessage = new StringBuilder();
            decryptedMessage.Append(encryptedMessage);
            while ((command=Console.ReadLine())!= "Decode")
            {
                string[] commands = command.Split("|");
                switch (commands[0])
                {
                    case "Move":
                        int numberOfLetters = int.Parse(commands[1]);
                        for (int i = 1; i<=numberOfLetters;i++)
                        {
                            char toCopy = decryptedMessage[0];
                            decryptedMessage.Remove(0, 1);
                            decryptedMessage.Append(toCopy);
                        }
                        
                    break;
                    case "Insert":
                        int index = int.Parse(commands[1]);
                        if (index>=0 && index<=decryptedMessage.Length)
                        {
                            decryptedMessage.Insert(index, commands[2]);
                        }
                        
                    break;
                    case "ChangeAll":
                        decryptedMessage.Replace(commands[1], commands[2]);
                        
                    break;
                }
            }
            Console.WriteLine($"The decrypted message is: {decryptedMessage.ToString()}");
        }
    }
}
