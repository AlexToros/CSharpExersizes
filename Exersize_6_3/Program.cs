using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exersize_6_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Role CR = new Role("Create");
            Role FA = new Role("FullAccess");
            Role RO = new Role("ReadOnly");

            Group Admins = new Group("Admins");
            Group Users = new Group("Users");

            User Bob = new User("Bob", "1111");
            User Mary = new User("Mary", "1111");
            User Alex = new User("Alex", "1111");
            User Tom = new User("Tom", "1111");

            Admins.Add(Bob);
            Users.Add(Mary);
            Users.Add(Alex);
            Admins.AddRole(FA);
            Users.AddRole(RO);
            Tom.AddRole(CR);
            Mary.AddRole(CR);

            IRoleContainer[] rc = {
                Admins, Users, Tom, Mary
            };
            foreach (var item in rc)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
