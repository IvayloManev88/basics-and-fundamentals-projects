namespace PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int[] helparray= new int[input];
            helparray[0] = 1;
            Console.WriteLine("1");
            for (int i = 2; i <= input; i++)
            {
                int[] previousRow = new int[i-1];
                previousRow = helparray.Where(x => x != 0).ToArray();
                int[] currentRow = new int[i];
                for (int j = 0; j < i; j++)
                {
                   
                    if (j - 1 >=0) currentRow[j] += previousRow[j - 1];
                    if (previousRow.Length > j) currentRow[j] += previousRow[j];
                                       
                }
                for (int l = 0; l < currentRow.Length; l++)
                {
                    helparray[l] = currentRow[l];

                }
                Console.WriteLine(string.Join(" ", currentRow));
            }
        }
    }
}
