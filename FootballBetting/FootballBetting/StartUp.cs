using P02_FootballBetting.Data;

namespace P02_FootballBetting
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Db creation initialized");

            try
            {
                using FootballBettingContext dbContext = new FootballBettingContext();
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
