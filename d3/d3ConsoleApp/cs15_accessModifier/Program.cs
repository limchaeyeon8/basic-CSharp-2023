using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs15_accessModifier
{

    class WaterHeater
    {
        protected int temp;     // public으로 한다면 GetTemp, SetTemp 만든 의미가 사라짐

        public void SetTemp(int temp)
        {
            if (temp < -5 || temp > 40)
            {
                Console.WriteLine("범위 이탈");
                return;
            }

            this.temp = temp;
        }
        
        public int GetTemp() 
        { 
            return this.temp;
        }

        internal void TurnOnHeater()
        {
            Console.WriteLine("보일러 켭니다 : {0}", temp);
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            WaterHeater boiler = new WaterHeater();
            boiler.SetTemp(30);      // protected - 내부 접근 / 상속받은 자식에서 접근 가능
            Console.WriteLine(boiler.GetTemp());
            boiler.TurnOnHeater();
        }
    }
}
