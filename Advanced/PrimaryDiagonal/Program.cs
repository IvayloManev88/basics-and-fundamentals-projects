﻿namespace PrimaryDiagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size,size];
            for (int row = 0; row < size; row++)
            {
                int[] inputLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row,col]= inputLine[col];
                }
            }
            int sum = 0;
            for (int i = 0; i < size; i++)
                sum += matrix[i, i];
            Console.WriteLine(sum);
        }
    }
}
