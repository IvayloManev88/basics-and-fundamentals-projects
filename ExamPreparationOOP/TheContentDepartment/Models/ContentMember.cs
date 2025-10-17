using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    public class ContentMember : TeamMember
    {
        private readonly string[] validPaths = new string[] { "CSharp", "JavaScript", "Python", "Java" };


        public ContentMember(string name, string path) : base(name, path)
        {
            if (path != "Python" && path != "CSharp" && path != "Java" && path != "JavaScript")
                throw new ArgumentException(string.Format(ExceptionMessages.PathIncorrect, path));

        }

        public override string ToString() => $"{this.Name} - {this.Path} path. Currently working on {this.InProgress.Count} tasks.";


    }
}
