using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exersize_4_3
{
    abstract class Vehicle
    {
        private const string FORMAT_STR = "{0,-15}|{1,-13},м|{2,-15}|{3,-15}";
        protected enum Environment
        {
            Earth,
            Sky,
            Water,
            UnderWater
        }
        protected enum State
        {
            Normal,
            Broken,
            Critical,
            NoFuel
        }
        private string currentInfo;
        protected Random rnd = new Random();
        protected bool CanRefuelOnTrack { get => environment == Environment.Earth; }
        protected string Name { get; set; }
        protected string Refuel_MSG { get; set; }
        protected string Disaster_MSG { get; set; }
        protected float TotalDistance { get; set; }
        protected float FuelConsumption { get; set; }
        protected float Speed { get; set; }
        protected float Safety { get; set; }
        protected float MaxFuel { get; set; }
        private float currentFuel;
        protected float CurrentFuel
        {
            get => currentFuel;
            set
            {
                if (value <= 0)
                {
                    state = State.NoFuel;
                    currentFuel = 0;
                }
                else
                {
                    state = State.Normal;
                    currentFuel = value;
                }
            }
        }
        
        protected State state;
        protected Environment environment;

        public virtual void Move()
        {
            if (TryDestiny())
            {
                currentInfo = "Произошла поломка!";
                return;
            }
            switch (state)
            {
                case State.Normal:
                    currentInfo = NormalMove();
                    break;
                case State.Broken:
                    currentInfo = TryRepair();
                    break;
                case State.Critical:
                    currentInfo = Disaster();
                    break;
                case State.NoFuel:
                    currentInfo = TryRefuel();
                    break;
                default:
                    currentInfo = "Неизвестное состояние";
                    break;
            }
        }

        private bool TryDestiny()
        {
            if (state == State.Normal)
            {
                float pivot = 0;
                switch (environment)
                {
                    case Environment.Earth:
                        pivot = 0.05f;
                        break;
                    case Environment.Sky:
                        pivot = 0.005f;
                        break;
                    case Environment.Water:
                        pivot = 0.05f;
                        break;
                    case Environment.UnderWater:
                        pivot = 0.005f;
                        break;
                }
                if (rnd.NextDouble() <= pivot)
                {
                    state = State.Broken;
                    return true;
                }
            }
            return false;
        }
        protected string NormalMove()
        {
            CurrentFuel -= FuelConsumption;
            TotalDistance += Speed;
            return string.Format("Пройдено всего: {0}м (+{1}м)", TotalDistance, Speed);
        }

        protected string TryRepair()
        {
            double tryChance = rnd.NextDouble();
            if (tryChance > Safety)
            {
                state = State.Critical;
                return "Неудачная попытка починки привела к критической неисправности";
            }
            else if (tryChance < 0.6)
            {
                state = State.Normal;
                return "Ремонт прошел успешно";
            }
            else
            {
                return "Ремонт продолжается";
            }            
        }

        protected string Disaster()
        {
            return Disaster_MSG;
        }

        protected string TryRefuel()
        {
            if (CanRefuelOnTrack)
            {
                CurrentFuel = MaxFuel;
                return "Кончилось топливо! " + Refuel_MSG;
            }
            else
            {
                state = State.Critical;
                return "Кончилось топливо, а заправиться негде!";
            }
        }
        public static string GetHeaders()
        {
            return string.Format(FORMAT_STR, "Название", "Пройдено", "Остаток топлива", "Информация");
        }
        public override string ToString()
        {
            return string.Format(FORMAT_STR,Name, TotalDistance, currentFuel,currentInfo);
        }
    }
    class Car : Vehicle
    {
        public Car(float MaxSpeed, float FuelConsumption, float MaxFuel) : this(MaxSpeed, FuelConsumption, MaxFuel, MaxFuel) { }
        public Car(float MaxSpeed, float FuelConsumption, float MaxFuel, float CurrentFuel)
        {
            Safety = 0.8f;
            rnd = new Random();
            environment = Environment.Earth;
            Speed = MaxSpeed;
            base.MaxFuel = MaxFuel;
            base.CurrentFuel = CurrentFuel;
            base.FuelConsumption = FuelConsumption;
            Disaster_MSG = "Ничего не поделать. Ждем эвакуатор.";
            Refuel_MSG = "Заправили полный бак!";
            Name = "Автомобиль";
        }
    }
    class Airplane : Vehicle
    {
        public Airplane(float MaxSpeed, float FuelConsumption, float MaxFuel) : this(MaxSpeed, FuelConsumption, MaxFuel, MaxFuel) { }
        public Airplane(float MaxSpeed, float FuelConsumption, float MaxFuel, float CurrentFuel)
        {
            Safety = 0.95f;
            rnd = new Random();
            environment = Environment.Sky;
            Speed = MaxSpeed;
            base.MaxFuel = MaxFuel;
            base.CurrentFuel = CurrentFuel;
            base.FuelConsumption = FuelConsumption;
            Disaster_MSG = "Мы падаем!";
            Name = "Самолет";
        }
    }
    class Horse : Vehicle
    {
        public Horse(float MaxSpeed, float FuelConsumption, float MaxFuel) : this(MaxSpeed, FuelConsumption, MaxFuel, MaxFuel) { }
        public Horse(float MaxSpeed, float FuelConsumption, float MaxFuel, float CurrentFuel)
        {
            Safety = 0.99f;
            rnd = new Random();
            environment = Environment.Earth;
            Speed = MaxSpeed;
            base.MaxFuel = MaxFuel;
            base.CurrentFuel = CurrentFuel;
            base.FuelConsumption = FuelConsumption;
            Disaster_MSG = "Ведем лошадку в поводу.";
            Refuel_MSG = "Дали еще овса!";
            Name = "Гужевая повозка";
        }
    }
    class Boat : Vehicle
    {
        public Boat(float MaxSpeed, float FuelConsumption, float MaxFuel) : this(MaxSpeed, FuelConsumption, MaxFuel, MaxFuel) { }
        public Boat(float MaxSpeed, float FuelConsumption, float MaxFuel, float CurrentFuel)
        {
            Safety = 0.8f;
            rnd = new Random();
            environment = Environment.Water;
            Speed = MaxSpeed;
            base.MaxFuel = MaxFuel;
            base.CurrentFuel = CurrentFuel;
            base.FuelConsumption = FuelConsumption;
            Disaster_MSG = "Дрейфуем";
            Name = "Моторная лодка";
        }
    }
}
