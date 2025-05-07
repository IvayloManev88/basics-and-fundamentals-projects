using System.ComponentModel;

namespace SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> normal = new HashSet<string>();
            HashSet<string> vip = new HashSet<string>();
            string guestListFill = string.Empty;
            while ((guestListFill = Console.ReadLine()) != "PARTY")
            {


                _ = Char.IsDigit(guestListFill[0]) ? vip.Add(guestListFill) : normal.Add(guestListFill);
            }
               
            while ((guestListFill = Console.ReadLine()) != "END")
            {
                
                _ = vip.Contains(guestListFill) ? vip.Remove(guestListFill): normal.Remove(guestListFill);


            }
            Console.WriteLine($"{vip.Count + normal.Count}");
            foreach (string guest in vip) Console.WriteLine(guest);
            foreach (string guest in normal) Console.WriteLine(guest);

        }
    }
}
