using System;

namespace no_3_app
{

    class Car
    {
        string name;
        string maker;
        string color;
        int yearModel;
        int maxSpeed;
        string uniqueNumber;

        public string Name { get => name; set => name = value; }
        public string Maker { get => maker; set => maker = value; }
        public string Color { get => color; set => color = value; }
        public int YearModel { get => yearModel; set => yearModel = value; }
        public int MaxSpeed { get => maxSpeed; set => maxSpeed = value; }
        public string UniqueNumber { get => uniqueNumber; set => uniqueNumber = value; }
    }

    class ElectricCar : Car
    {
        public void Start()
        {
            Console.WriteLine("아이오닉의 시동을 겁니다 드릉드릉");
        }

        public void Accelerate()
        {
            Console.WriteLine("최대시속 {0}km/h로 가속합니다 부와아아앙", MaxSpeed);
        }

        public void Recharge()
        {
            Console.WriteLine("달리면서 배터리를 충전합니다 띠로롱");
        }

        public void TurnRight()
        {
            Console.WriteLine("아이오닉을 우회전합니다 끼이익");
        }

        public void Brake()
        {
            Console.WriteLine("아이오닉의 브레이크를 밟습니다 끼읶!!!");
        }
    }

    class HybridCar : ElectricCar
    {
        public new void Recharge()
        {
            Console.WriteLine("달리면서 배터리를 충전합니다.");
        }
    }
    

    internal class Program
    {
        static void Main(string[] args)
        {
            HybridCar ioniq = new HybridCar();

            ioniq.Name = "아이오닉";
            ioniq.Maker = "현대자동차";
            ioniq.Color = "White";
            ioniq.YearModel = 2018;
            ioniq.MaxSpeed = 220;
            ioniq.UniqueNumber = "54라 3346";

            ioniq.Start();
            ioniq.Accelerate();
            ioniq.Recharge();
            ioniq.TurnRight();
            ioniq.Brake();
                  
        }
    }
}
