using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Exersize_4_3
{
    class Game
    {
        Vehicle[] vehicles;

        public Game(params Vehicle[] vehicles)
        {
            this.vehicles = vehicles;
        }
        
        public IEnumerable<string> Move()
        {
            foreach (var item in vehicles)
            {
                item.Move();
                yield return item.ToString();
            }
        }
    }
}
