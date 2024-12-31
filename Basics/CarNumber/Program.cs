int intervalStart = int.Parse(Console.ReadLine());
int intervalEnd = int.Parse(Console.ReadLine());

for  (int i = intervalStart; i<= intervalEnd; i++)
{
    for (int j = intervalStart; j<= intervalEnd; j++)
    {
        for (int k = intervalStart; k<= intervalEnd; k++)
        {
            for(int l = intervalStart; l<= intervalEnd; l++)
            {
                bool correctNumber = true;
                if (i % 2 == 0 && l % 2 == 0)
                {
                    correctNumber = false;
                    continue;
                }
                if (i % 2 != 0 && l % 2 != 0)
                {
                    correctNumber = false;
                    continue;
                }
               
                if (l>=i) 
                {
                    correctNumber = false;
                    continue;
                }
                if ((j+k)%2!=0) correctNumber = false;

                if(correctNumber)
                {
                    Console.Write($"{i}{j}{k}{l} ");
                }
                
            }
        }
    }
}