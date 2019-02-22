using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exersize_7
{
    public interface IParkingUnit
    {
        bool IsDisabled { get; set; }
        void StartParking(Parking Parking);
        decimal StopParking();
    }
}