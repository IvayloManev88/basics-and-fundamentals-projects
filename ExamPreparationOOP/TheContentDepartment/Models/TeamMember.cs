using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    public abstract class TeamMember : ITeamMember
    {

        private string name;
        
        private List<string> inProgress;

        private string path;
        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhiteSpace);
                name = value; 
            }
        }
            

        public  string Path
        {
            get => path;
            protected set
            {
                path = value;
            }
        }



        public IReadOnlyCollection<string> InProgress => inProgress.AsReadOnly();

        protected TeamMember(string name, string path)
        {
            this.Name = name;
            this.Path = path;
            this.inProgress = new List<string>();
            
        }

        public void FinishTask(string resourceName)
        {
            this.inProgress.Remove(resourceName);
        }

        public void WorkOnTask(string resourceName)
        {
            if (!inProgress.Contains(resourceName))
            {
                this.inProgress.Add(resourceName);
            }
        }
    }
}
