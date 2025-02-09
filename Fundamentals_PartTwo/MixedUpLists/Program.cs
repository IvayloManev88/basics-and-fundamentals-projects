using System.ComponentModel.Design;

namespace MixedUpLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List <int> firstList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> combinedList = new List<int>();

            int shorterListElements = 0;
            if (firstList.Count>secondList.Count) shorterListElements=secondList.Count;
            else shorterListElements = firstList.Count;


            for (int i=0; i< (firstList.Count>secondList.Count?secondList.Count:firstList.Count); i++)
            {
                combinedList.Add(firstList[i]);
                combinedList.Add(secondList[secondList.Count-1-i]);
                firstList.RemoveAt(i);
                secondList.RemoveAt(secondList.Count - 1 - i);
                i--;
            }
            int min = 0;
            int max = 0;
            if (firstList.Count>0)
            {
                if (firstList[0] > firstList[1])
                {
                    min = firstList[1]; max = firstList[0];
                }
                else
                {
                    min = firstList[0]; max = firstList[1];
                }
            }
            else if (secondList.Count > 0)
            {
                if (secondList[0] > secondList[1])
                {
                    min = secondList[1]; max = secondList[0];
                }
                else
                {
                    min = secondList[0]; max = secondList[1];
                }

            }
            List<int> outputList = combinedList.Where(x => x > min && x < max).ToList();
            outputList.Sort();

            Console.WriteLine(string.Join(" ", outputList));

        }
         
    }
}
