using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exersize_6_3
{
    class Group : List<User>, IRoleContainer
    {
        public string Name { get; private set; }

        public Group(string name)
        {
            Name = name;
        }

        public void AddRole(Role role)
        {
            ForEach(user => user.AddRole(role));
        }

        public void RemoveRole(Role role)
        {
            ForEach(user => user.RemoveRole(role));
        }

        public override string ToString()
        {
            return Name + "\n\t" + string.Join("\n\t", this);
        }
    }
}
