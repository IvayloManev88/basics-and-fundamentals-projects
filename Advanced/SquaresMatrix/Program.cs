﻿namespace SquaresMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = sizes[0];
            int cols = sizes[1];
            char [,] matrix = new char[rows, cols];
            int equalCounter = 0;
            for (int row=0; row < rows; row++)
            {
                char[] inputLine= Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col=0; col < cols; col++)
                {
                    matrix[row,col] = inputLine[col];
                }
            }
            for (int row=0; row < rows-1;row++)
            {
                for (int col=0; col < cols-1; col++)
                {
                    if (matrix[row,col] == matrix[row+1,col+1]&& matrix[row, col]==matrix[row,col+1]&& matrix[row, col] == matrix[row + 1, col])
                    {
                        equalCounter++;
                    }
                }
            }
            Console.WriteLine(equalCounter);
        }
    }
}
