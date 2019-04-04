using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exersize_4_3
{
    abstract class Vehicle
    {
        static Random rnd = new Random();
        private const string FORMAT_STR = "{0,-15}|{1,-13}|{2,-15}|{3,-15}";
        public enum Environment
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
        private float currentFuel;
        protected bool CanRefuelOnTrack { get => EnvironmentType == Environment.Earth; }
        protected float TotalDistance { get; set; }
        protected float FuelConsumption { get; set; }
        protected float Speed { get; set; }
        protected float MaxFuel { get; set; }

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

        public abstract Environment EnvironmentType { get; }
        public abstract string Disaster_MSG { get; }
        public abstract string Refuel_MSG { get; }
        public abstract string Name { get; }
        public abstract float Safety { get; }

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
            }
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

        protected string Disaster() => Disaster_MSG;

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
        public static string Headers => string.Format(FORMAT_STR, "Название", "Пройдено, м", "Остаток топлива", "Информация");

        public override string ToString() => string.Format(FORMAT_STR, Name, TotalDistance, currentFuel, currentInfo);

        private bool TryDestiny()
        {
            if (state == State.Normal)
            {
                float pivot = 0;
                switch (EnvironmentType)
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
    }
    class Car : Vehicle
    {
        public Car(float MaxSpeed, float FuelConsumption, float MaxFuel) : this(MaxSpeed, FuelConsumption, MaxFuel, MaxFuel) { }
        public Car(float MaxSpeed, float FuelConsumption, float MaxFuel, float CurrentFuel)
        {
            Speed = MaxSpeed;
            base.MaxFuel = MaxFuel;
            base.CurrentFuel = CurrentFuel;
            base.FuelConsumption = FuelConsumption;
        }
        public override string Disaster_MSG => "Ничего не поделать. Ждем эвакуатор.";
        public override string Refuel_MSG => "Заправили полный бак!";
        public override string Name => "Автомобиль";
        public override float Safety => 0.8f;
        public override Environment EnvironmentType => Environment.Earth;
    }
    class Airplane : Vehicle
    {
        public Airplane(float MaxSpeed, float FuelConsumption, float MaxFuel) : this(MaxSpeed, FuelConsumption, MaxFuel, MaxFuel) { }
        public Airplane(float MaxSpeed, float FuelConsumption, float MaxFuel, float CurrentFuel)
        {
            Speed = MaxSpeed;
            base.MaxFuel = MaxFuel;
            base.CurrentFuel = CurrentFuel;
            base.FuelConsumption = FuelConsumption;
        }
        public override string Disaster_MSG => "Мы падаем!";
        public override string Refuel_MSG => throw new NotImplementedException("Невозможно заправить данное ТС");
        public override string Name => "Самолет";
        public override float Safety => 0.95f;
        public override Environment EnvironmentType => Environment.Sky;
    }
    class Horse : Vehicle
    {
        public Horse(float MaxSpeed, float FuelConsumption, float MaxFuel) : this(MaxSpeed, FuelConsumption, MaxFuel, MaxFuel) { }
        public Horse(float MaxSpeed, float FuelConsumption, float MaxFuel, float CurrentFuel)
        {
            Speed = MaxSpeed;
            base.MaxFuel = MaxFuel;
            base.CurrentFuel = CurrentFuel;
            base.FuelConsumption = FuelConsumption;
        }
        public override string Disaster_MSG => "Ведем лошадку в поводу.";
        public override string Refuel_MSG => "Дали еще овса!";
        public override string Name => "Гужевая повозка";
        public override float Safety => 0.99f;
        public override Environment EnvironmentType => Environment.Earth;
    }
    class Boat : Vehicle
    {
        public Boat(float MaxSpeed, float FuelConsumption, float MaxFuel) : this(MaxSpeed, FuelConsumption, MaxFuel, MaxFuel) { }
        public Boat(float MaxSpeed, float FuelConsumption, float MaxFuel, float CurrentFuel)
        {
            Speed = MaxSpeed;
            base.MaxFuel = MaxFuel;
            base.CurrentFuel = CurrentFuel;
            base.FuelConsumption = FuelConsumption;
        }
        public override string Disaster_MSG => "Дрейфуем";
        public override string Refuel_MSG => throw new NotImplementedException("Невозможно заправить данное ТС");
        public override string Name => "Моторная лодка";
        public override float Safety => 0.8f;
        public override Environment EnvironmentType => Environment.Water;
    }
}
