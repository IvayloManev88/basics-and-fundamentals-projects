using System;

namespace MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = sizes[0];
            int cols = sizes[1];
            string[,] matrix = new string[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                string[] inputLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = inputLine[col];
                }
            }
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] commands = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (commands[0] != "swap" || commands.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                else
                {
                    bool isValid = false;
                    int rowsPrevious = int.Parse(commands[1]);
                    int colsPrevious = int.Parse(commands[2]);
                    isValid = IsValid(rowsPrevious, colsPrevious, matrix);
                    int rowsNew = int.Parse(commands[3]);
                    int colsNew = int.Parse(commands[4]);
                    isValid = IsValid(rowsNew, colsNew, matrix);
                    if (isValid)
                    {
                        string helpValue = matrix[rowsPrevious, colsPrevious];
                        matrix[rowsPrevious, colsPrevious] = matrix[rowsNew, colsNew];
                        matrix[rowsNew, colsNew] = helpValue;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }

                }
                for (int row = 0; row < rows; row++)
                {
                    
                    for (int col = 0; col < cols; col++)
                    {
                        Console.Write(matrix[row, col] +" ");
                    }
                    Console.WriteLine();
                }
            }
        }
        public static bool IsValid(int indexRow,int indexCol, string[,]matrix)
        {
            if (indexRow >= 0&& indexRow < matrix.GetLength(0)&& indexCol >= 0 && indexCol < matrix.GetLength(1)) return true;
            else return false;
        }

    }
}
