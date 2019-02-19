using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exersize_6_3
{
    class Role : IEquatable<Role>
    {
        public string Name { get; private set; }

        public Role(string name)
        {
            Name = name;
        }

        public bool Equals(Role other)
        {
            return Name.Equals(other.Name);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
