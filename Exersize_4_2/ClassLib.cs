using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exersize_4_2
{
    enum BuildingType
    {
        Office,
        House,
        Villa
    }
    class Building
    {
        private BuildingType type;
        private int floorCount;
        private double totalSquare;
        private int peopleCount;

        public Building(BuildingType Type, int FloorCount, double Square, int PeopleCount = 0)
        {
            type = Type;
            floorCount = FloorCount;
            totalSquare = Square;
            peopleCount = PeopleCount;
        }

        public override string ToString()
        {
            return string.Format("Это здание типа {0}, имеет этажей в количестве - {1}шт., общей площадью - {2} кв.м.\nПроживает жильцов: {3}",
                type.ToString(), floorCount,totalSquare,peopleCount);
        }
    }
}
