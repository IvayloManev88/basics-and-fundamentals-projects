using System.Net.Http.Headers;

int k =int.Parse(Console.ReadLine());
int l = int.Parse(Console.ReadLine());
int m =int.Parse(Console.ReadLine());
int n =int.Parse(Console.ReadLine());


int countValid = 0;


    for (int i = k; i<=8; i++)
    {
        if (i % 2 == 0)
        {
            for (int j = 9; j >= l; j--)
            {
                if (j % 2 != 0)
                {
                    for (int o = m; o<=8; o++)
                    {
                        if (o % 2 == 0)
                        {
                            for (int p = 9; p >= n; p--)
                            {
                                if (p % 2 != 0)
                                {
                                    if (i == o && j == p)
                                    {
                                        Console.WriteLine("Cannot change the same player.");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{i}{j} - {o}{p}");
                                        countValid++;
                                    if (countValid >=6) return;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

