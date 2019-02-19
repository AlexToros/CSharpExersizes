using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exersize_6_3
{
    class User : IRoleContainer
    {
        private List<Role> roleList;
        public string Name { get; private set; }
        public string Password { get; private set; }

        public User(string name, string password)
        {
            roleList = new List<Role>();
            Name = name;
            Password = password;
        }

        public void AddRole(Role role)
        {
            if (!roleList.Contains(role))
                roleList.Add(role);
        }

        public void RemoveRole(Role role)
        {
            roleList.Remove(role);
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, string.Join(",", roleList));
        }
    }
}
