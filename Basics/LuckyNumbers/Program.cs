int n = int.Parse(Console.ReadLine());

int countFirst = 0;
int countLast = 0;
for (int i = 1; i<=9; i++)
{
    for (int j = 1; j<=9; j++)
    {
        
        for (int k = 1; k<=9; k++)
        {
            for (int l = 1; l<=9; l++)
            {
                countLast += k + l;
                countFirst += i + j;
                if ((countFirst==countLast) && (n%countFirst==0))
                {
                    Console.Write($"{i}{j}{k}{l} ");
                }
                countLast = 0;
                countFirst = 0;
            }
        }
    }
}