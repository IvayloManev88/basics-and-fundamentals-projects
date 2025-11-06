using P01_HospitalDatabase.Data;

namespace P01_HospitalDatabase
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Db creation initialized");
            try
            {
                using HospitalContext dbContext = new HospitalContext();
                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();
                Console.WriteLine("Db creation success");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Db creation failed");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
