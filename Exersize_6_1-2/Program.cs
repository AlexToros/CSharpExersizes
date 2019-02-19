using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exersize_6_1_2
{
    public enum Color {
        Red,
        Green,
        Yellow
    }
    public interface IFruitVeget
    {
        decimal GetPrice();
        void SetPrice(decimal value);
    }
    public interface IApple
    {
        void SetSort(string sort);
        void SetSize(float size);
        void SetRoots(bool isRoots);
        string GetSort();
        float GetSize();
        bool GetRoots();
    }
    public interface IBerry
    {
        void SetColor(Color color);
        void SetHarvestingDate(DateTime date);
        void SetRoots(bool isRoots);
        Color GetColor();
        DateTime GetHarvestingDate();
        bool GetRoots();
    }
    abstract class Vegetables : IFruitVeget
    {
        private decimal price;
        protected string place;
        public string Name { get; set; }
        public string Shape { get; set; }

        public decimal GetPrice() => price;
        public void SetPrice(decimal value) => price = value;

        public override string ToString()
        {
            return string.Format("{0}, форма: {1}, производство: {2}, цена: {3:C}", Name, Shape, place, price);
        }
    }

    class Potato : Vegetables, IApple
    {
        private string sort;
        private float averageSize;
        private bool isRoots;

        public Potato(string sort, float averageSize, bool isRoots, string place, decimal price)
        {
            this.sort = sort;
            this.averageSize = averageSize;
            this.isRoots = isRoots;
            this.place = place;
            Name = "Яблоко";
            SetPrice(price);
        }

        public bool GetRoots() => isRoots;

        public float GetSize() => averageSize;

        public string GetSort() => sort;

        public void SetRoots(bool isRoots) => this.isRoots = isRoots;

        public void SetSize(float size) => averageSize = size;

        public void SetSort(string sort) => this.sort = sort;

        public override string ToString()
        {
            return base.ToString() + string.Format("\n\tСорт: {0}, средний размер: {1}, корнеплод: {2}", sort, averageSize, isRoots);
        }
    }
    class Tomato : Vegetables, IBerry
    {
        private Color color;
        private DateTime harvestingDate;
        private bool isRoots;

        public Tomato(Color color, DateTime harvestingDate, bool isRoots, string place, decimal price)
        {
            this.color = color;
            this.harvestingDate = harvestingDate;
            this.isRoots = isRoots;
            this.place = place;
            Name = "Ягода";
            SetPrice(price);
        }

        public Color GetColor() => color;

        public DateTime GetHarvestingDate() => harvestingDate;

        public bool GetRoots() => isRoots;

        public void SetColor(Color color) => this.color = color;

        public void SetHarvestingDate(DateTime date) => harvestingDate = date;

        public void SetRoots(bool isRoots) => this.isRoots = isRoots;

        public override string ToString()
        {
            return base.ToString() + string.Format("\n\tЦвет: {0}, дата сбора: {1}, корнеплод: {2}", color, harvestingDate.ToString("dd.MM.yyyy"), isRoots);
        }
    }
    abstract class Fruit : IFruitVeget
    {
        private decimal price;
        protected string place;
        public string Name { get; set; }
        public string Shape { get; set; }

        public decimal GetPrice() => price;
        public void SetPrice(decimal value) => price = value;

        public override string ToString()
        {
            return string.Format("{0}, форма: {1}, производство: {2}, цена: {3:C}",Name,Shape,place,price);
        }
    }

    class Apple : Fruit, IApple
    {
        private string sort;
        private float averageSize;
        private bool isRoots;

        public Apple(string sort, float averageSize, bool isRoots, string place, decimal price)
        {
            this.sort = sort;
            this.averageSize = averageSize;
            this.isRoots = isRoots;
            this.place = place;
            Name = "Яблоко";
            SetPrice(price);            
        }

        public bool GetRoots() => isRoots;

        public float GetSize() => averageSize;

        public string GetSort() => sort;

        public void SetRoots(bool isRoots) => this.isRoots = isRoots;

        public void SetSize(float size) => averageSize = size;

        public void SetSort(string sort) => this.sort = sort;

        public override string ToString()
        {
            return base.ToString() + string.Format("\n\tСорт: {0}, средний размер: {1}, корнеплод: {2}", sort, averageSize, isRoots);
        }
    }
    class Berry : Fruit, IBerry
    {
        private Color color;
        private DateTime harvestingDate;
        private bool isRoots;

        public Berry(Color color, DateTime harvestingDate, bool isRoots, string place, decimal price)
        {
            this.color = color;
            this.harvestingDate = harvestingDate;
            this.isRoots = isRoots;
            this.place = place;
            Name = "Ягода";
            SetPrice(price);
        }

        public Color GetColor() => color;

        public DateTime GetHarvestingDate() => harvestingDate;

        public bool GetRoots() => isRoots;

        public void SetColor(Color color) => this.color = color;

        public void SetHarvestingDate(DateTime date) => harvestingDate = date;

        public void SetRoots(bool isRoots) => this.isRoots = isRoots;

        public override string ToString()
        {
            return base.ToString() + string.Format("\n\tЦвет: {0}, дата сбора: {1}, корнеплод: {2}", color, harvestingDate.ToString("dd.MM.yyyy"), isRoots);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ru-ru");
            Console.OutputEncoding = Encoding.UTF8;
            Fruit[] fruits = {
                new Apple("Антоновка",20, false, "Краснодар", 100),
                new Berry(Color.Red,DateTime.Now,false,"Турция",200)
            };
            foreach (Fruit item in fruits)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
