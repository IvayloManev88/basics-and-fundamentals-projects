using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl
{
    public interface IBirthdateable
    {
        public string Name { get; }
        public DateTime Birthdate { get; }
    }
}
