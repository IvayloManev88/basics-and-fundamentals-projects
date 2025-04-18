using System.Drawing;

namespace RadioactiveMutantVampireBunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = sizes[0];
            int cols = sizes[1];
            int rowIndex = 0;
            int colIndex = 0;
            char[,] matrix = new char[rows, cols];
            bool isDead = false;
            bool isEcaped = false;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                    if (matrix[row, col] == 'P')
                    {
                        rowIndex = row;
                        colIndex = col;
                    }
                }
            }
            string directions = Console.ReadLine();
            int i = 0;
            while (!isDead && !isEcaped)
            {
                char direction = directions[i];
                i++;
                if (matrix[rowIndex, colIndex]=='P') matrix[rowIndex, colIndex] = '.';
                if (direction == 'L')
                {
                    if (colIndex - 1 >= 0) colIndex = colIndex - 1;
                    else isEcaped=true;

                }
                else if (direction == 'R')
                {
                    if (colIndex + 1 < cols) colIndex = colIndex + 1;
                    else isEcaped = true;
                }
                else if (direction == 'U')
                {
                    if (rowIndex - 1 >= 0) rowIndex = rowIndex - 1;
                    else isEcaped = true;
                }
                else if (direction == 'D')
                {
                    if (rowIndex + 1 < rows) rowIndex = rowIndex + 1;
                    else isEcaped = true;
                }
                
                if (matrix[rowIndex, colIndex] != 'B')
                {
                    if (!isEcaped&&!isDead) matrix[rowIndex, colIndex] = 'P';
                }
                else isDead = true;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {

                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {

                        if (matrix[row, col] == 'B')
                        {
                            if (row - 1 >= 0) matrix[row - 1, col] = 'C';
                            if (col - 1 >= 0) matrix[row, col - 1] = 'C';
                            if (row + 1 < rows) matrix[row + 1, col] = 'C';
                            if (col + 1 < cols) matrix[row, col + 1] = 'C';
                        }
                    }


                }
                for (int row = 0; row < matrix.GetLength(0); row++)
                {

                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {

                        if (matrix[row, col] == 'C') matrix[row, col] = 'B';
                    }
                }


                if (matrix[rowIndex, colIndex] == 'B'&&!isEcaped) isDead = true;
               


                //for (int row = 0; row < matrix.GetLength(0); row++)
                //{

                //    for (int col = 0; col < matrix.GetLength(1); col++)
                //    {
                //        Console.Write(matrix[row, col]);
                //    }
                //    Console.WriteLine();
                //}


            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
            
            if (isEcaped) Console.WriteLine($"won: {rowIndex} {colIndex}");
            else if (isDead) Console.WriteLine($"dead: {rowIndex} {colIndex}");



        }
    }
}
