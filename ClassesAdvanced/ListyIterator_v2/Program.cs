namespace ListyIterator;

public class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        ListyIterator<string> iterator = new ListyIterator<string>(input.Skip(1));

        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            try
            {
                if (command == "Move") Console.WriteLine(iterator.Move());
                else if (command == "Print") Console.WriteLine(iterator.Current);
                else if (command == "PrintAll") Console.WriteLine(string.Join(" ", iterator));
                else if (command == "HasNext") Console.WriteLine(iterator.HasNext());

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
