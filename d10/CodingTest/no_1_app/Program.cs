using System;

namespace no_1_app
{
    class Boiler
    {
        //string boiler;
        //Boiler boiler = new Boiler();
        
        public string Brand;
        public int Voltage;
        public int Temperature;

        internal void PrintAll()
        {
            Console.WriteLine("▶브랜드명 : {0}\n▶볼트 : {1}\n▶온도 : {2}\n", Brand,Voltage, Temperature);

            return;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Boiler kitturami = new Boiler { Brand = "귀뚜라미", Voltage = 220, Temperature = 45 };
            kitturami.PrintAll();
        }
    }
}
