using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Models
{
    public class Client : User
    {
        public IReadOnlyDictionary<string, bool> Purchases
        {
            get
            {
                return purchases;
            }
        }

       

        private Dictionary<string, bool> purchases;
        public Client(string userName, string email) : base(userName, email, false)
        {
            purchases = new Dictionary<string, bool>();
        }


        public void PurchaseProduct(string productName, bool blackFridayFlag)
        {
            purchases.Add(productName,blackFridayFlag);
        }
    }
}
