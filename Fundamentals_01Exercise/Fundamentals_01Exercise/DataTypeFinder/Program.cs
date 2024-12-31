using System;
using System.Dynamic;

namespace DataTypeFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
                    
        
                string input ="";
                int integer = 0;
                float floating = 0;
                char character = ' ';
                string stringType = "";
                bool boolean = false;
                bool sucessfullParse=false;

            while ((input = Console.ReadLine()) != "END")
            {

                if (int.TryParse(input, out integer)) Console.WriteLine($"{input} is integer type");
                else if (float.TryParse(input, out floating)) Console.WriteLine($"{input} is floating point type");
                else if (char.TryParse(input, out character)) Console.WriteLine($"{input} is character type");
                else if (bool.TryParse(input, out boolean)) Console.WriteLine($"{input} is boolean type");
                else  Console.WriteLine($"{input} is string type");
            }
                

            
        }
    }
}
