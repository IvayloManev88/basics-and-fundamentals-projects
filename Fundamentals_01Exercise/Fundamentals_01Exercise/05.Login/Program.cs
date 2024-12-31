using System.Security.Cryptography.X509Certificates;

namespace _05.Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = "";
            int usernameLength = username.Length-1;
            for (int i = 0; i <= usernameLength; i++)
            {
                char help = username[usernameLength-i];
                password = password.Insert((i),help.ToString());
            }

            int counter = 0;
            string input = "";
            while ((input=Console.ReadLine())!= password)
            {
                counter++;
                if (counter>=4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    return;
                }
                else Console.WriteLine("Incorrect password. Try again.");
                
            }

            Console.WriteLine($"User {username} logged in.");
        }
    }
}
