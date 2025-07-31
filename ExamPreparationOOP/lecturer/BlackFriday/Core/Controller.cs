using BlackFriday.Core.Contracts;
using BlackFriday.Models;
using BlackFriday.Models.Contracts;
using BlackFriday.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Core
{
    public class Controller : IController
    {
        private string[] validProductTypes = new string[] { "Item", "Service" };
        private IApplication application;

        public Controller()
        {
            this.application = new Application();
        }

        public string AddProduct(string productType, string productName, string userName, double basePrice)
        {
            if (!validProductTypes.Contains(productType))
            {
                return String.Format(OutputMessages.ProductIsNotPresented, productType);
            }

            if (application.Products.Exists(productName))
            {
                return String.Format(OutputMessages.ProductNameDuplicated, productName);
            }
           
            IUser user = application.Users.GetByName(userName);
            if (user == null || user is Client)
            {
                return String.Format(OutputMessages.UserIsNotAdmin, userName);
            }
            IProduct product;
            if (productType == "Item")
            {
                 product = new Item(productName, basePrice);
            }
            else 
            {
                 product = new Service(productName, basePrice);
            }
            application.Products.AddNew(product);

            return String.Format(OutputMessages.ProductAdded, productType, productName, $"{basePrice:f2}");
        }

        public string ApplicationReport()
        {
           StringBuilder sb = new StringBuilder();
            List<IUser> admins = application.Users.Models.Where(u=>u is Admin).ToList();
            sb.AppendLine("Application administration:");
            foreach (IUser admin in admins.OrderBy(u=>u.UserName))
            {
                sb.AppendLine(admin.ToString());
            }

            List<Client> clients = application.Users.Models.Where(u => u is Client)
                .Select(u => (Client)u)
                .OrderBy(u=>u.UserName)
                .ToList();
            sb.AppendLine("Clients:");
           foreach (Client client in clients)
            {
                sb.AppendLine(client.ToString());
                if (client.Purchases.Values.Any(v=>v)) 
                    {

                        sb.AppendLine($"-Black Friday Purchases: {client.Purchases.Values.Where(v => v).Count()}");
                    }
                foreach (var (purchase,promotion) in  client.Purchases.Where(p=>p.Value))
                {
                    sb.Append("--");
                    sb.AppendLine(purchase);
                }

            }



            return sb.ToString().Trim();
        }

        public string PurchaseProduct(string userName, string productName, bool blackFridayFlag)
        {
            IUser user = application.Users.GetByName(userName);
            if (user == null || user is Admin)
            {
                return String.Format(OutputMessages.UserIsNotClient, userName);
            }

            if (!application.Products.Exists(productName))
            {
                return String.Format(OutputMessages.ProductDoesNotExist, productName);
            }

            IProduct product = application.Products.GetByName(productName);
            if (product.IsSold)
            {
                return String.Format(OutputMessages.ProductOutOfStock, productName);
            }

            product.ToggleStatus();
            Client client = (Client)user;
            client.PurchaseProduct(productName, blackFridayFlag);

            double price = product.BasePrice;
            if (blackFridayFlag)
            {
                price = product.BlackFridayPrice;
            }
            return String.Format(OutputMessages.ProductPurchased,userName, productName,$"{price:f2}");
        }

        public string RefreshSalesList(string userName)
        {
            IUser user = application.Users.GetByName(userName);
            if (user == null || user is Client)
            {
                return String.Format(OutputMessages.UserIsNotAdmin, userName);
            }
            int counter = 0;
            foreach (IProduct product in application.Products.Models.Where(x=>x.IsSold))
            {
                counter++;
                product.ToggleStatus();
            }
            return String.Format(OutputMessages.SalesListRefreshed, counter);
        }

        public string RegisterUser(string userName, string email, bool hasDataAccess)
        {
            if (application.Users.Exists(userName))
                return String.Format(OutputMessages.UserAlreadyRegistered, userName);
            else if (application.Users.Models.Any(u=>u.Email==email))
                return String.Format(OutputMessages.SameEmailIsRegistered, email);

            if (hasDataAccess)
            {
                int adminCount = application.Users.Models.Count(u=>u.HasDataAccess==true);
                if (adminCount >= 2)
                    return String.Format(OutputMessages.AdminCountLimited);
                
                IUser admin = new Admin(userName,email);
                application.Users.AddNew(admin);
                return String.Format(OutputMessages.AdminRegistered,userName);
            }
            else
            {
                IUser client = new Client(userName, email);
                application.Users.AddNew(client);
                return String.Format(OutputMessages.ClientRegistered, userName);
            }
        }

        public string UpdateProductPrice(string productName, string userName, double newPriceValue)
        {
            if (!application.Products.Exists(productName))
            {
                return String.Format(OutputMessages.ProductDoesNotExist, productName);
            }

            IUser user = application.Users.GetByName(userName);
            if (user == null || user is Client)
            {
                return String.Format(OutputMessages.UserIsNotAdmin, userName);
            }

            IProduct product = application.Products.GetByName(productName);
            double oldPrice = product.BasePrice;
            product.UpdatePrice(newPriceValue);
            return String.Format(OutputMessages.ProductPriceUpdated, productName, $"{oldPrice:f2}", $"{newPriceValue:f2}");
        }
    }
}
