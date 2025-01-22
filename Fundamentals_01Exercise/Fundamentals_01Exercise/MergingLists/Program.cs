namespace MergingLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> list2 = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

            List<int> mergedList = new List<int>();
            int shorterListCount = list1.Count > list2.Count
                ? list2.Count
                : list1.Count;
            for (int i = 0; i < shorterListCount; i++)
            {
                mergedList.Add(list1[i]);
                mergedList.Add(list2[i]);
            }

            if (list2.Count > shorterListCount)
            {
                for (int i = shorterListCount; i < list2.Count; i++)
                {
                    mergedList.Add(list2[i]);
                }
            }
            else
            {
                for (int i = shorterListCount; i < list1.Count; i++)
                {
                    mergedList.Add(list1[i]);
                }
            }
            Console.WriteLine(string.Join(" ",mergedList));
        }
    }
}
