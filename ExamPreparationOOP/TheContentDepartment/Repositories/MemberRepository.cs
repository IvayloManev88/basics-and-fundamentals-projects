using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories.Contracts;

namespace TheContentDepartment.Repositories
{
    public class MemberRepository : IRepository<ITeamMember>
    {
        private List<ITeamMember> models;
        public IReadOnlyCollection<ITeamMember> Models => this.models.AsReadOnly();

        public MemberRepository()
        {
            this.models = new List<ITeamMember>();
        }

        public void Add(ITeamMember model)
        {
            this.models.Add(model);
        }

        public ITeamMember TakeOne(string modelName)
        {
            return this.Models.FirstOrDefault(x => x.Name == modelName);
        }
    }
}
