namespace Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] bombs= new int[size,size];
            for (int row=0; row<bombs.GetLength(0); row++)
            {
                int[] inputLine = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col=0; col< bombs.GetLength(1); col++)
                {
                    bombs[row,col] = inputLine[col];
                }
            }
            string[] booms = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i=0; i< booms.Length; i++)
            {
                int[] helpArray = booms[i].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int boomRow = helpArray[0];
                int boomCol = helpArray[1];
                if (isValid(boomRow, boomCol, size) && bombs[boomRow, boomCol]>0)
                {
                    int boomPower = bombs[boomRow, boomCol];
                    bombs[boomRow, boomCol] = 0;
                    if (isValid(boomRow - 1, boomCol - 1, size) && bombs[boomRow - 1, boomCol - 1] > 0) bombs[boomRow - 1, boomCol - 1] -= boomPower;
                    if (isValid(boomRow - 1, boomCol, size) && bombs[boomRow - 1, boomCol] > 0) bombs[boomRow - 1, boomCol] -= boomPower;
                    if (isValid(boomRow - 1, boomCol + 1, size) && bombs[boomRow - 1, boomCol + 1] > 0) bombs[boomRow - 1, boomCol + 1] -= boomPower;
                    if (isValid(boomRow, boomCol - 1, size) && bombs[boomRow, boomCol - 1] > 0) bombs[boomRow, boomCol - 1] -= boomPower;
                    if (isValid(boomRow, boomCol + 1, size) && bombs[boomRow, boomCol + 1] > 0) bombs[boomRow, boomCol + 1] -= boomPower;
                    if (isValid(boomRow + 1, boomCol - 1, size) && bombs[boomRow + 1, boomCol - 1] > 0) bombs[boomRow + 1, boomCol - 1] -= boomPower;
                    if (isValid(boomRow + 1, boomCol, size) && bombs[boomRow + 1, boomCol] > 0) bombs[boomRow + 1, boomCol] -= boomPower;
                    if (isValid(boomRow + 1, boomCol + 1, size) && bombs[boomRow + 1, boomCol + 1] > 0) bombs[boomRow + 1, boomCol + 1] -= boomPower;
                }

            }
            int aliveBombs = 0;
            int sumBombs = 0;
            foreach (int bomb in bombs)
            {
                if (bomb>0)
                {
                    aliveBombs++;
                    sumBombs += bomb;
                }
            }
            Console.WriteLine($"Alive cells: {aliveBombs}");
            Console.WriteLine($"Sum: {sumBombs}");
            for (int row = 0; row < bombs.GetLength(0); row++)
            {
                
                for (int col = 0; col < bombs.GetLength(1); col++)
                {
                    Console.Write(bombs[row, col] +" ");
                }
                Console.WriteLine();
            }
        }
        public static bool isValid(int row, int col, int size)
        {
            if (row>=0 && col>=0 &&row<size&&col<size) return true;
            else return false;
        }
    }
}
