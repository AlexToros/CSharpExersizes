using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exersize_7
{
    public abstract class Vehicle : IParkingUnit, IEquatable<Vehicle>
    {
        private string GRZ;
        private DateTime startParkingDate;
        private Parking usingParking;

        public Vehicle(string GRZ)
        {
            this.GRZ = GRZ;
        }

        public bool IsDisabled { get; set; }
        public void StartParking(Parking Parking)
        {
            startParkingDate = DateTime.Now;
            usingParking.Income(this);
            usingParking = Parking;
        }

        public decimal StopParking()
        {
            decimal cost = getPrice();
            usingParking.Outcome(this);
            usingParking = null;
            return cost;
        }

        private decimal getPrice()
        {
            int hours = (DateTime.Now - startParkingDate).Hours;
            return usingParking.PricePerHour * hours;
        }

        public bool Equals(Vehicle other)
        {
            return other.GRZ.Equals(GRZ);
        }
    }
}