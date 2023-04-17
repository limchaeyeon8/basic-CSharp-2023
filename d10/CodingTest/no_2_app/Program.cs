using System;

namespace no_2_app
{
    class Boiler
    {
        //string boiler;
        //Boiler boiler = new Boiler();

        public string Brand { get; set; }
        private byte voltage;

        public byte Voltage
        {
            get { return this.Voltage; }
            set
            {
                if (this.Voltage == 110 || this.Voltage == 220)
                    this.Voltage = value;
                else
                    Console.WriteLine("■ 110V, 220V ONLY ■");
            }
        }

        public int Temperature
        {
            get { return this.Temperature; }
            set
            {
                if (this.Temperature <= 5) this.Temperature = 5;
                if (this.Temperature >= 70) this.Temperature = 70;
                else this.Temperature = value;
            }

        }
        public void PrintAll()
        {
            Console.WriteLine($"Brand : {Brand}\n Voltage : {Voltage}\n Temperature : {Temperature}\n");
        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Boiler kitturami = new Boiler { Brand = "귀뚜라미", Voltage = 220, Temperature = 45 };
            kitturami.PrintAll();
            Boiler kitturami0 = new Boiler { Brand = "귀뚜라미0", Voltage = 20, Temperature = 3 };
            kitturami.PrintAll();
        }
    }
}
