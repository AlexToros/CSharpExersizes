using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exersize_7
{
    public class MarketParking : Parking
    {
        public MarketParking(int MaxCapacity, int DisabledMaxCapacity, decimal PricePerHour) : base(MaxCapacity, DisabledMaxCapacity, PricePerHour)
        {
        }
    }
}