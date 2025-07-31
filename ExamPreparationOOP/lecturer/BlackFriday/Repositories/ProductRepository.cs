using BlackFriday.Models.Contracts;
using BlackFriday.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Repositories
{
    public class ProductRepository : IRepository<IProduct>
    {


        public List<IProduct> models;
        public ProductRepository()
        {
            models = new List<IProduct>();
        }

        public IReadOnlyCollection<IProduct> Models => models.AsReadOnly();


        public bool Exists(string name)
        {
           return models.Any(p=> p.ProductName == name);
        }

        public IProduct GetByName(string name)
        {
           
            return Models.FirstOrDefault(p => p.ProductName == name); 
        }

        public void AddNew(IProduct model)
        {
            models.Add(model);
        }


    }
}
