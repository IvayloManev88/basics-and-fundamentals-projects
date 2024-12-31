
int a = int.Parse(Console.ReadLine());
int b = int.Parse(Console.ReadLine());
int maxPasswords = int.Parse(Console.ReadLine());
int count = 0;

int i = 35;
int j = 64;
        for (int k = 1; k <= a; k++)
        {
            for (int l = 1; l <= b; l++)
            {
                char one = ((char)i);
                char two = ((char)j);
                count++;
                Console.Write($"{one}{two}{k}{l}{two}{one}|");
                i++;
                j++;
                if (i > 55) i = 35;
                if (j > 96) j = 64;

                
                if (count >= maxPasswords) return;
            }

        }
