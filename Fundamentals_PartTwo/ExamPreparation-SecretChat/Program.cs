using System.Text;

namespace ExamPreparation_SecretChat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder message = new StringBuilder();
            message.Append(Console.ReadLine()); 
            string input = string.Empty;
            while ((input=Console.ReadLine())!= "Reveal")
            {
                string[] inputs = input.Split(":|:");
                switch (inputs[0])
                {
                    case "InsertSpace":
                        message.Insert(int.Parse(inputs[1]), " ");
                        Console.WriteLine(message.ToString());
                        break;
                    case "Reverse":
                        
                        if (message.ToString().Contains(inputs[1]))
                        {
                            string stringToReverse = inputs[1];
                            int index =message.ToString().IndexOf(stringToReverse);
                            message.Remove(index, stringToReverse.Length);
                            for (int i = stringToReverse.Length - 1; i >= 0; i--)
                            {
                                message.Append(stringToReverse[i]);
                            }
                            Console.WriteLine(message.ToString());
                        }
                        else Console.WriteLine("error");
                        break;
                    case "ChangeAll":
                        message.Replace(inputs[1], inputs[2]);
                        Console.WriteLine(message.ToString());
                        break;
                }
                
            }
            Console.WriteLine($"You have a new text message: {message.ToString()}");
        }
    }
}
