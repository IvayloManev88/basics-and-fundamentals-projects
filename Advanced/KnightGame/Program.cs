using System.Drawing;

namespace KnightGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] chessBoard = new char[size, size];
            for (int row = 0; row < size; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    chessBoard[row, col] = input[col];
                }
            }
            int removeCounter = 0;
            while (true)
            {
                int maxAttacker =int.MinValue;
                int maxRow=int.MinValue;
                int maxCol= int.MinValue;

                for (int row = 0; row < size; row++)
                {

                    for (int col = 0; col < size; col++)
                    {
                        if (chessBoard[row, col] == 'K')
                        {
                            // row-2, col-1
                            // row-2, col+1
                            // row-1, col-2
                            // row-1, col+2
                            // row+1, col-2
                            // row+1, col+2
                            // row+2, col-1
                            // row+2, col+1
                            int currentAttacker = 0;

                            if (isValid(size, row - 2, col - 1) && chessBoard[row - 2, col - 1] == 'K')
                            {
                                currentAttacker++;
                            }
                            if (isValid(size, row - 2, col + 1) && chessBoard[row - 2, col + 1] == 'K')
                            {
                                currentAttacker++;
                            }
                            if (isValid(size, row - 1, col - 2) && chessBoard[row - 1, col - 2] == 'K')
                            {
                                currentAttacker++;
                            }
                            if (isValid(size, row - 1, col + 2) && chessBoard[row - 1, col + 2] == 'K')
                            {
                                currentAttacker++;
                            }
                            if (isValid(size, row + 1, col - 2) && chessBoard[row + 1, col - 2] == 'K')
                            {
                                currentAttacker++;
                            }
                            if (isValid(size, row + 1, col + 2) && chessBoard[row + 1, col + 2] == 'K')
                            {
                                currentAttacker++;
                            }
                            if (isValid(size, row + 2, col - 1) && chessBoard[row + 2, col - 1] == 'K')
                            {
                                currentAttacker++;
                            }
                            if (isValid(size, row + 2, col + 1) && chessBoard[row + 2, col + 1] == 'K')
                            {
                                currentAttacker++;
                            }
                            if (currentAttacker>maxAttacker)
                            {
                                maxAttacker = currentAttacker;
                                maxRow = row;
                                maxCol = col;
                            }
                            
                        }
                    }
                }
                if (maxAttacker > 0)
                {
                    chessBoard[maxRow, maxCol] = '0';
                    removeCounter++;
                }
                else break;
            }
            Console.WriteLine(removeCounter);
        }
        public static bool isValid(int size, int row, int col)
        {
            
            if (row>=0&&row<size&&col>=0&&col<size) return true;
            else return false;

        }
    }
}
