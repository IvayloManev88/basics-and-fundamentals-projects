namespace BombNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> bombList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> detonations = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            while (bombList.Contains(detonations[0]))
            {
                for (int i=0; i<bombList.Count;i++)
                {
                    int getIndex = -1;
                    if (bombList[i]== detonations[0])
                    {
                        getIndex = i;
                        for (int j=1;j<= detonations[1];j++)
                        { 
                            if (i-j>=0) bombList[i-j]=-1;
                            if (i+j< bombList.Count) bombList[i + j] = -1;

                            
                            
                        }
                        bombList[i] = -1;
                        bombList.RemoveAll(b => b == -1);
                        break;
                    }
                }
            }
            int sum = 0;
            foreach (int bomb in bombList)
            {
                sum += bomb;
            }
            Console.WriteLine(sum);
        }
    }
}
