
int firstLimit = int.Parse(Console.ReadLine());
int secondLimit = int.Parse(Console.ReadLine());
int thirdLimit = int.Parse(Console.ReadLine());

for (int n1 = 2; n1<= firstLimit; n1+=2)
{
    for (int n2 = 2; n2<= secondLimit; n2++)
    {
        bool isPrime = true;
        for (int i =2; i<= Math.Sqrt(n2);i++)
        {
            if (n2%i==0)
            {
                isPrime = false;
                break;
            }
            
        }
      //  if (isPrime) Console.WriteLine(n2);
        for (int n3=2;n3<= thirdLimit;n3+=2)
        {
            if (isPrime)
            {
                Console.Write($"{n1} {n2} {n3}");
                Console.WriteLine();
            }
        }
    }
    
}