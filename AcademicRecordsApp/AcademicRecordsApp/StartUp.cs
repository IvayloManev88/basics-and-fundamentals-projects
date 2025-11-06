using AcademicRecordsApp.Data;

namespace AcademicRecordsApp
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using AcademicRecordsDbContext context = new AcademicRecordsDbContext();

            string[] students = context.Students
                .Select(s=>s.FullName)
                .ToArray();
            Console.WriteLine(String.Join(Environment.NewLine,students));
        }
    }
}
