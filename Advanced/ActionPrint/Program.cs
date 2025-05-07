namespace ActionPrint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            Action<string> print = name => Console.WriteLine(name);
            foreach (string name in names)
            {
                
                print(name);
            }


        }
        /*public static Action<string> PrintName(string name)
        {
           
            return (output)=> Console.WriteLine(name);
        */
    }
}
