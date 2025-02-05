namespace CompanyUsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companyList = new();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputs = input.Split(" -> ");
                if (!companyList.ContainsKey(inputs[0]))
                {
                    companyList.Add(inputs[0], new());
                    companyList[inputs[0]].Add(inputs[1]);
                }
                else
                {
                    if (companyList[inputs[0]].Contains(inputs[1])) continue;
                    else companyList[inputs[0]].Add(inputs[1]);
                }
            }
            foreach ((string companyName, List<string> employees)in companyList)
            {
                Console.WriteLine(companyName);
                foreach (string employee in employees)
                {
                    Console.WriteLine("-- " + employee);
                }
            }
        }
    }
}
