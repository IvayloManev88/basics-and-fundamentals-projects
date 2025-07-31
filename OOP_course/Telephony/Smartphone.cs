using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Browse(string website)
        {
            foreach (char c in website)
            {
                if (char.IsDigit(c))
                {
                    return "Invalid URL!";
                      
                }
            }
            return $"Browsing: {website}!";
        }

        public string Call(string number) => $"Calling... {number}";
          
        
    }
}
