namespace GenericScale
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            EqualityScale<int> scale = new(5, 5);
            EqualityScale<int> scale2 = new(6,5);
            Console.WriteLine(scale.AreEqual());
            Console.WriteLine(scale2.AreEqual());
        }
    }
}
