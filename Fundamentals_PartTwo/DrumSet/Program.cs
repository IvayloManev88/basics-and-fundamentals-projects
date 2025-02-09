namespace DrumSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double totalMoney = double.Parse(Console.ReadLine());
            List<int> drumList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> pricesList=new List<int>();
            for (int i = 0; i < drumList.Count; i++)
            {
                pricesList.Add(drumList[i]*3);
            }
            string input = string.Empty;
            while ((input = Console.ReadLine())!= "Hit it again, Gabsy!")
            {
                int hitPower = int.Parse(input);
                for (int i = 0;i< drumList.Count;i++)
                {
                    if (drumList[i] > hitPower) drumList[i] -= hitPower;
                    else
                    {
                        if (totalMoney >= pricesList[i])
                        {
                            drumList[i] = pricesList[i] / 3;
                            totalMoney -= pricesList[i];
                        }
                        else
                        {
                            drumList.RemoveAt(i);
                            pricesList.RemoveAt(i);
                            i--;
                        }

                    }
                }
            }
            
            Console.WriteLine(string.Join(" ", drumList.ToArray()));
            Console.WriteLine($"Gabsy has {totalMoney:F2}lv.");
        }
    }
}
