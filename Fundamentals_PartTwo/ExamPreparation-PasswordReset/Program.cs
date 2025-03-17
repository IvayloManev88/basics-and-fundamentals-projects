using System.ComponentModel.Design;
using System.Text;

namespace ExamPreparation_PasswordReset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputPassword = Console.ReadLine();
            StringBuilder passwordResetter = new StringBuilder();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Done")
            {
                string[] commands = command.Split();
                switch (commands[0])
                {
                    case "TakeOdd":
                        for (int i = 1; i<inputPassword.Length;i+=2)
                        {
                            passwordResetter.Append(inputPassword[i]);

                        }
                        Console.WriteLine(passwordResetter.ToString());
                        inputPassword = passwordResetter.ToString();
                        passwordResetter.Clear();
                        break;
                    case "Cut":
                        int index = int.Parse(commands[1]);
                        int lenght = int.Parse(commands[2]);
                        passwordResetter.Append(inputPassword);
                        string toCut=string.Empty;
                        for (int i=index; (i<index+lenght&&i<inputPassword.Length);i++)
                        {
                            toCut += inputPassword[i];
                        }
                        int cutIndex = inputPassword.IndexOf(toCut);
                        
                        
                            passwordResetter.Remove(cutIndex, lenght);
                        
                        
                        Console.WriteLine(passwordResetter.ToString());
                        inputPassword = passwordResetter.ToString();
                        passwordResetter.Clear();
                        break;
                    case "Substitute":
                        
                        int substituteIndex = inputPassword.IndexOf(commands[1]);
                        if (substituteIndex != -1)
                        {
                            passwordResetter.Append(inputPassword);
                            passwordResetter.Replace(commands[1], commands[2]);
                            Console.WriteLine(passwordResetter.ToString());
                            inputPassword = passwordResetter.ToString();
                            passwordResetter.Clear();
                        }
                        else Console.WriteLine("Nothing to replace!");
                        break;

                }
                
            }
            Console.WriteLine($"Your password is: {inputPassword}");

        }
    }

}
