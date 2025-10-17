using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories.Contracts;

namespace TheContentDepartment.Repositories
{
    public class ResourceRepository : IRepository<IResource>
    {
        private List<IResource> models;
        public IReadOnlyCollection<IResource> Models => this.models.AsReadOnly();
        public ResourceRepository()
        {
            models = new List<IResource>();
        }

        public void Add(IResource model)
        {
            models.Add(model);
        }

        public IResource TakeOne(string modelName)
        {
            return Models.FirstOrDefault(x => x.Name == modelName);
        }
    }
}
