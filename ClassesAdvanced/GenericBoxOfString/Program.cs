﻿namespace GenericBoxOfString
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i< n; i++)
            {
                
                Box<int> box = new Box<int>()
                {
                    Element = int.Parse(Console.ReadLine())
                };
                Console.WriteLine(box.ToString());
            }
        }
    }
}
