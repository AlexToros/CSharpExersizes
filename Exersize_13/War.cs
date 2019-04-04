using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exersize_13
{
    class EventDamageArgs : EventArgs
    {
        public int Damage { get; set; }
        public EventDamageArgs(int damage)
        {
            Damage = damage;
        }
    }
    static class War
    {
        static Random rnd = new Random();

        public static bool WarIsOver { get; private set; }

        private static Country cntr1;

        private static Country cntr2;

        public static void Start(Country country1, Country country2)
        {
            WarIsOver = false;
            cntr1 = country1;
            cntr2 = country2;

            country1.OnSurreder += Country_OnSurreder;
            country2.OnSurreder += Country_OnSurreder;

            country1.OnAirStrike += country2.AirReaction;
            country1.OnArtilleryStrike += country2.ArtilleryReaction;
            country1.OnTankStrike += country2.TankReaction;
            country1.OnSurreder += country2.IAmAWinner;

            country2.OnAirStrike += country1.AirReaction;
            country2.OnArtilleryStrike += country1.ArtilleryReaction;
            country2.OnTankStrike += country1.TankReaction;
            country2.OnSurreder += country1.IAmAWinner;

            startWar();
        }

        private static void startWar()
        {
            while (!WarIsOver)
            {
                Turn(cntr1);
                Turn(cntr2);
            }
        }

        private static void Turn(Country cntr)
        {
            double temp = rnd.NextDouble();
            if (temp < 0.333)
                cntr.TankAttack();
            else if (temp < 0.666)
                cntr.AirAttack();
            else
                cntr.ArtAttack();
        }

        private static void Country_OnSurreder(object sender, EventArgs e)
        {
            WarIsOver = true;
        }
    }

    abstract class Country
    {
        public delegate void DamageHandler(object sender, EventDamageArgs args);

        protected ConsoleColor color;

        protected string name;

        private int health;

        public int Health
        {
            get => health;
            set
            {
                health = value;
                if (health <= 0)
                    Invoke(OnSurreder);
            }
        }

        public Country(int health, int tankD, int artD, int airD)
        {
            this.health = health;
            TankDamage = tankD;
            ArtilleryDamage = artD;
            AirDamage = airD;
        }

        public int TankDamage { get; private set; }

        public int AirDamage { get; private set; }

        public int ArtilleryDamage { get; private set; }

        public event DamageHandler OnArtilleryStrike;

        public event DamageHandler OnTankStrike;

        public event DamageHandler OnAirStrike;

        public event EventHandler OnSurreder;

        public virtual void TankAttack() => Invoke(OnTankStrike, TankDamage);

        public virtual void ArtAttack() => Invoke(OnArtilleryStrike, ArtilleryDamage);

        public virtual void AirAttack() => Invoke(OnAirStrike, AirDamage);

        public virtual void TankReaction(object sender, EventDamageArgs args) => Health -= args.Damage;

        public virtual void ArtilleryReaction(object sender, EventDamageArgs args) => Health -= args.Damage;

        public virtual void AirReaction(object sender, EventDamageArgs args) => Health -= args.Damage;

        public abstract void IAmAWinner(object sender, EventArgs args);

        private void Invoke(EventHandler @event)
        {
            @event?.Invoke(this, null);
        }
        private void Invoke(DamageHandler @event, int damage)
        {
            @event?.Invoke(this, new EventDamageArgs(damage));
        }
        protected void Print(string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }

    class China : Country
    {
        public China(int health, int tankD, int artD, int airD) : base(health, tankD, artD, airD)
        {
            color = ConsoleColor.Red;
            name = "Китай";
        }

        public override void AirAttack()
        {            
            Print($"{name} атакует с воздуха!");
            base.AirAttack();
        }

        public override void AirReaction(object sender, EventDamageArgs args)
        {
            Print($"Народ страны {name} страдает от воздушных атак");
            base.AirReaction(sender, args);
        }

        public override void ArtAttack()
        {
            Print($"{name} готовит массивный артиллерийский удар");
            base.ArtAttack();
        }

        public override void ArtilleryReaction(object sender, EventDamageArgs args)
        {
            Print($"Все в укрытие! Страну {name} бомбят!");
            base.ArtilleryReaction(sender, args);
        }

        public override void IAmAWinner(object sender, EventArgs args)
        {
            Print($"{name} празднует победу! В мире воцарился социализм!");
        }

        public override void TankAttack()
        {
            Print($"{name} вводит танковые войска!");
            base.TankAttack();
        }

        public override void TankReaction(object sender, EventDamageArgs args)
        {
            Print($"{name} роет проивотанковые окопы");
            base.TankReaction(sender, args);
        }
    }

    class USA : Country
    {
        public USA(int health, int tankD, int artD, int airD) : base(health, tankD, artD, airD)
        {
            color = ConsoleColor.Blue;
            name = "США";
        }

        public override void AirAttack()
        {
            Print($"{name} совершает воздушную атаку!");
            base.AirAttack();
        }

        public override void AirReaction(object sender, EventDamageArgs args)
        {
            Print($"{name} вынуждено задействовать ПВО");
            base.AirReaction(sender, args);
        }

        public override void ArtAttack()
        {
            Print($"{name} разворачивает артиллерийские подразделения");
            base.ArtAttack();
        }

        public override void ArtilleryReaction(object sender, EventDamageArgs args)
        {
            Print($"{name} под артобстрелом!");
            base.ArtilleryReaction(sender, args);
        }

        public override void IAmAWinner(object sender, EventArgs args)
        {
            Print($"{name} празднует победу! Капитализм шагает по планете!");
        }

        public override void TankAttack()
        {
            Print($"{name} вводит танковые войска!");
            base.TankAttack();
        }

        public T Foo<T>(object obj)
        {
            T res = (T)Convert.ChangeType(obj, typeof(T));
            return res;
        }

        public override void TankReaction(object sender, EventDamageArgs args)
        {
            Print($"{name} вынуждено защищаться от танков противника");
            base.TankReaction(sender, args);
        }
    }
}
