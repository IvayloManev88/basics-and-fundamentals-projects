using BlackFriday.Models.Contracts;
using BlackFriday.Repositories;
using BlackFriday.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Models
{
    public class Application : IApplication
    {

        public IRepository<IProduct> products;
        public IRepository<IUser> users;
        public IRepository<IProduct> Products => products;
        public IRepository<IUser> Users => users;

        public Application()
        {
            this.products = new ProductRepository();
            this.users = new UserRepository();
        }
    }
}
