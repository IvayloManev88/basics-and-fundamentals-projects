using System.ComponentModel.Design;
using System.Runtime.InteropServices.Marshalling;

namespace Kamino_Factory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string input = "";
            int maxCount = int.MinValue;
            int maxSum = int.MinValue;
            int[] BestArray= new int[length];
            int bestArraySequence = int.MinValue;
            int sequenceCounter = 0;
            int sequenceIndex = length;
            while ((input = Console.ReadLine())!= "Clone them!")
            {
                sequenceCounter++;
                int[] currentArray = input
                   .Split("!".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int currentCount = 0;
                int currentSum = 0;
                int startingIndex = length;
                bool isSequenceStarted = false;
                for (int i = 0; i < currentArray.Length; i++)
                {
                    if (currentArray[i] == 1 && !isSequenceStarted)
                    {
                        currentSum++;
                        isSequenceStarted = true;
                    }
                    else if (currentArray[i] == 1 && isSequenceStarted)
                    {
                        currentSum++;
                        currentCount++;
                        startingIndex = i - currentCount;
                    }
                    else if (currentArray[i] == 0)
                    {
                        isSequenceStarted = false;
                    }
                                       
                }




                if (currentCount>maxCount)
                {
                    maxCount = currentCount;
                    maxSum = currentSum;
                    BestArray = currentArray;
                    bestArraySequence = sequenceCounter;
                    sequenceIndex = startingIndex;
                }
                else if (currentCount==maxCount)
                {
                    if (sequenceIndex > startingIndex)
                    {
                        maxCount = currentCount;
                        maxSum = currentSum;
                        BestArray = currentArray;
                        bestArraySequence = sequenceCounter;
                        sequenceIndex = startingIndex;
                    }
                    else if (sequenceIndex == startingIndex)
                    {
                        if (currentSum > maxSum)
                        {
                            maxCount = currentCount;
                            maxSum = currentSum;
                            BestArray = currentArray;
                            bestArraySequence = sequenceCounter;
                            sequenceIndex = startingIndex;
                        }
                        
                    }
                }
                {
                    
                }
            }
            Console.WriteLine($"Best DNA sample {bestArraySequence} with sum: {maxSum}.");
            Console.WriteLine(string.Join(" ", BestArray));
        }
    }
}
