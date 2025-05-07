namespace EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> evenTime = new Dictionary<int, int>();
            int counter = int.Parse(Console.ReadLine());
            for (int i = 0; i < counter; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                if (!evenTime.ContainsKey(currentNumber))
                {
                    evenTime.Add(currentNumber, 0);
                }
                evenTime[currentNumber]++;
            }
            foreach ((int key, int value)in  evenTime)
            {
                if (value%2==0) Console.WriteLine(key);
            }
        }
    }
}
