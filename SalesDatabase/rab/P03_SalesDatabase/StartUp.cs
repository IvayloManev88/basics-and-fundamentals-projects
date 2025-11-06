using P03_SalesDatabase.Data;

namespace P03_SalesDatabase
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("DB Initializing");
            try
            {
                using SalesContext context = new SalesContext();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Console.WriteLine("Database created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Db Creation error");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
