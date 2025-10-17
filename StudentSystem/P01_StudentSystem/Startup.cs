using P01_StudentSystem.Data;

namespace P01_StudentSystem
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Db creation initialized");
            try
            {
                using StudentSystemContext dbContext = new StudentSystemContext();
                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();
                Console.WriteLine("Db creation success");
            }
            catch (Exception e)
            {

                Console.WriteLine("Db creation failed");
                Console.WriteLine(e.Message);
            }
        }
    }
}
