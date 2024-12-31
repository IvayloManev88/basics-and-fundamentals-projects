int a = int.Parse(Console.ReadLine());
int b = int.Parse(Console.ReadLine());
int maxPasswords = int.Parse(Console.ReadLine());  
int count = 0;
for (char i = '#'; i<='7';i++)
{
   for (char j = '@'; j <= '`'; j++)
    {
        for (int k = 1; k<=a;k++)
        {
            for (int l = 1; l <= b; l++)
            {
                count++;
                Console.Write($"{i}{j}{k}{l}{j}{i}|");
                if (k == a && l == b) return;
                if (count == maxPasswords) return;
            }
        }


        if (i == '`') i = '@';
    }
      
        
    if (i == '7') i = '#';

}
