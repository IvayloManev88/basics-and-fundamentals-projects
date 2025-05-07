using System.Threading.Tasks.Dataflow;

namespace AppliedArithmetics2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Action <int[] >> functions = new Dictionary<string, Action<int[]>>
            {
                ["add"] = arr => ApplyCommand(arr,num=> num+1),
                ["multiply"] = arr => ApplyCommand(arr, num => num *2),
                ["print"] = arr=> Console.WriteLine(string.Join(" ", arr)),
                ["subtract"] = arr => ApplyCommand(arr, num => num -1),
            };


            int[] numbers = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                if (functions.ContainsKey(command))
                {
                    functions[command](numbers);
                }

            }
            
        }

        static void ApplyCommand(int[] numbers, Func<int,int> changeArray)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = changeArray(numbers[i]); 
            }
        }
    }
}
