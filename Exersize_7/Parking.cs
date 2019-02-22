using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exersize_7
{
    public abstract class Parking
    {
        private int maxCapacity;
        private int disabledMaxCapacity;
        private List<IParkingUnit> unitsOnParking;
        private List<IParkingUnit> disabledUnitsOnParking;

        public Parking(int MaxCapacity, int DisabledMaxCapacity, decimal PricePerHour)
        {
            maxCapacity = MaxCapacity - DisabledMaxCapacity;
            disabledMaxCapacity = DisabledMaxCapacity;
            unitsOnParking = new List<IParkingUnit>();
            disabledUnitsOnParking = new List<IParkingUnit>();
        }

        public decimal PricePerHour { get; private set; }

        public int PlacesLeft
        {
            get => maxCapacity - unitsOnParking.Count();
        }

        public int DisabledPlacesLeft
        {
            get => disabledMaxCapacity - disabledUnitsOnParking.Count();
        }

        private bool Remove(IParkingUnit vehicle, List<IParkingUnit> collection)
        {
            return collection.Remove(vehicle);
        }

        private void Add(IParkingUnit vehicle, int maxCapacity, List<IParkingUnit> collection)
        {
            if (collection.Count() == maxCapacity)
                throw new Exception("Парковка полностью заполнена!");
            collection.Add(vehicle);
        }

        public virtual void Income(IParkingUnit Unit)
        {
            if (Unit.IsDisabled)
                Add(Unit, disabledMaxCapacity, disabledUnitsOnParking);
            else
                Add(Unit, maxCapacity, unitsOnParking);
        }

        public virtual bool Outcome(IParkingUnit Unit)
        {
            if (Unit.IsDisabled)
                return Remove(Unit, disabledUnitsOnParking);
            else
                return Remove(Unit, unitsOnParking);
        }
    }
}