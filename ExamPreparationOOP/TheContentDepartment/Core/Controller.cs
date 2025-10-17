using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Core.Contracts;
using TheContentDepartment.Models;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories;
using TheContentDepartment.Repositories.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Core
{
    public class Controller : IController
    {
        private IRepository<IResource> resources;
        private IRepository<ITeamMember> members;

        public Controller()
        {
            this.resources = new ResourceRepository();
            this.members = new MemberRepository();
        }

        public string JoinTeam(string memberType, string memberName, string path)
        {
            if (memberType != nameof(TeamLead) && memberType != nameof(ContentMember))
                return string.Format(OutputMessages.MemberTypeInvalid, memberType);

            if (members.Models.Any(m => m.Path == path))
                return string.Format(OutputMessages.PositionOccupied);

            if (members.Models.Any(m => m.Name == memberName))
                return string.Format(OutputMessages.MemberExists, memberName);

            ITeamMember currentMember;
            currentMember = memberType switch
            {
                nameof(TeamLead) => new TeamLead(memberName, path),
                nameof(ContentMember) => new ContentMember(memberName, path),

            };

            this.members.Add(currentMember);
            return string.Format(OutputMessages.MemberJoinedSuccessfully, memberName);



        }

        public string CreateResource(string resourceType, string resourceName, string path)
        {
            if (resourceType != nameof(Exam) && resourceType != nameof(Workshop) && resourceType != nameof(Presentation))
                return string.Format(OutputMessages.ResourceTypeInvalid, resourceType);

            ITeamMember currentMember = members.Models.FirstOrDefault(m => m.Path == path);
            if (currentMember == null)
                return string.Format(OutputMessages.NoContentMemberAvailable, resourceName);

            if (currentMember.InProgress.Contains(resourceName))
                return string.Format(OutputMessages.ResourceExists, resourceName);

            IResource currentResource;
            currentResource = resourceType switch
            {
                nameof(Exam) => new Exam(resourceName, currentMember.Name),
                nameof(Workshop) => new Workshop(resourceName, currentMember.Name),
                nameof(Presentation) => new Presentation(resourceName, currentMember.Name)
            };
            this.resources.Add(currentResource);
            currentMember.WorkOnTask(resourceName);
            
            return string.Format(OutputMessages.ResourceCreatedSuccessfully, currentMember.Name, resourceType, resourceName);
        }

        public string ApproveResource(string resourceName, bool isApprovedByTeamLead)
        {
            IResource resource = resources.Models.FirstOrDefault(r => r.Name == resourceName);
            if (!resource.IsTested)
                return string.Format(OutputMessages.ResourceNotTested, resourceName);

            ITeamMember teamLead = members.Models.FirstOrDefault(m => m.GetType().Name == nameof(TeamLead));
            if (isApprovedByTeamLead)
            {
                resource.Approve();
                teamLead.FinishTask(resourceName);
                return string.Format(OutputMessages.ResourceApproved, teamLead.Name, resourceName);

            }
            else
            {
                resource.Test();
                
                return string.Format(OutputMessages.ResourceReturned, teamLead.Name, resourceName);
            }
        }



        public string DepartmentReport()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Finished Tasks:");
            foreach (IResource resource in resources.Models.Where(r => r.IsApproved))

            {
                result.AppendLine($"--{resource.ToString()}");
            }

            result.AppendLine("Team Report:");
            ITeamMember teamLead = members.Models.FirstOrDefault(m => m.GetType().Name == nameof(TeamLead));
            result.AppendLine($"--{teamLead.ToString()}");
            foreach (ITeamMember member in members.Models.Where(m => m.GetType().Name != nameof(TeamLead)))
            {
                result.AppendLine(member.ToString());
            }
            return result.ToString().TrimEnd();
        }



        public string LogTesting(string memberName)
        {
            ITeamMember member = members.TakeOne(memberName);
            if (member == null)
                return string.Format(OutputMessages.WrongMemberName);

            IResource resourse = resources.Models
                .Where(r => !r.IsTested && r.Creator == memberName)
                .OrderBy(r => r.Priority)
                .FirstOrDefault();
            if (resourse == null)
                return string.Format(OutputMessages.NoResourcesForMember, memberName);

            member.FinishTask(resourse.Name);
            ITeamMember teamLead = members.Models.FirstOrDefault(m => m.GetType().Name == nameof(TeamLead));
            teamLead.WorkOnTask(resourse.Name);
            resourse.Test();
            return string.Format(OutputMessages.ResourceTested, resourse.Name);


        }
    }
}
