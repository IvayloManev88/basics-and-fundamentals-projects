namespace AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ints = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                Action<int[]> command=null;
                if (input == "add")
                {
                    command = ints =>
                    {
                        for (int i = 0; i < ints.Length; i++)
                        {
                            ints[i] = ints[i] + 1;
                        }
                    };
                }
                else if (input == "multiply")
                {
                    command = ints =>
                    {
                        for (int i = 0; i < ints.Length; i++)
                        {
                            ints[i] = ints[i] * 2;
                        }
                    };
                }
                else if (input == "subtract")
                {
                    command = ints =>
                    {
                        for (int i = 0; i < ints.Length; i++)
                        {
                            ints[i] = ints[i] - 1;
                        }
                    };
                }
                else if (input == "print")
                {
                    command = ints => Console.WriteLine(string.Join(" ", ints));
                    
                }
                command(ints);
            }
        }
    }
}
