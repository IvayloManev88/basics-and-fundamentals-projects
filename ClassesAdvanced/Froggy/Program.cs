namespace Froggy;

public class Program
{
    public static void Main()
    {
        int[] inputs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        Lake lake = new Lake(inputs);
        Console.WriteLine(string.Join(", ", lake));

    }
}
