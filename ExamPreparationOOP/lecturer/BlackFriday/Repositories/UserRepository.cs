using BlackFriday.Models.Contracts;
using BlackFriday.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Repositories
{
    public class UserRepository : IRepository<IUser>
    {
        public List<IUser> models;
        public UserRepository()
        {
            models = new List<IUser>();
        }

        public IReadOnlyCollection<IUser> Models => models.AsReadOnly();

       

        public bool Exists(string name)
        {
            return models.Any(p => p.UserName == name);
        }

        public IUser GetByName(string name)
        {

            return Models.FirstOrDefault(p => p.UserName == name);
        }

        public void AddNew(IUser model)
        {
            models.Add(model);
        }

        

        
    }
}
