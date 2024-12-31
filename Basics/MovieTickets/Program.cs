int a1 = int.Parse(Console.ReadLine());
int a2 = int.Parse(Console.ReadLine());
int n = int.Parse(Console.ReadLine());


for (char c = (char)a1 ; c<= (char)a2-1;  c++)
{
    for (int i=1; i<=n-1; i++)
    {
        for (int j=1; j<= (n/2 -1); j++)
        {
            int lastNumber = (int)c;
            if ((lastNumber%2!=0) && (i+j+lastNumber)%2!=0)
            Console.WriteLine($"{c}-{i}{j}{lastNumber}");
            
        }
    }
}