namespace GenericSwapMethodStrings
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> input = new();
            for (int i = 0; i < n; i++)
            {
                input.Add(int.Parse(Console.ReadLine()));
            }
            int[] indexes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            SwapMethod(input, indexes[0], indexes[1]);
        }
        public static void SwapMethod<T>(List<T> input, int firstIndex, int secondIndex)
        {
            T helpItem = input[firstIndex];
            input[firstIndex]= input[secondIndex];
            input[secondIndex]= helpItem;
            foreach (T item in input)
            {
                Console.WriteLine($"{item.GetType()}: {item}");
            }
        }
    }
    
}
