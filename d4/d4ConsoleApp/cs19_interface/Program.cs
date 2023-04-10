using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace cs19_interface
{

    interface ILogger        // I를 꼭 붙임
    {
        void WriteLog(string log);
    }

    interface IFormattableLogger : ILogger      // 위아래 둘다 구현
    {
        void WriteLog(string format, params object[] args);     // 다중 파라미터를 받을 수 있는 형태(args; arguments)
    }

    class ConsoleLogger : ILogger       // implement; (인터페이스) 구현 (!= (클래스) 상속)
    {
        public void WriteLog(string log)
        {
            Console.WriteLine("{0}  {1}", DateTime.Now.ToLocalTime(),log);
        }
    }

    class ConsoleLogger2 : IFormattableLogger
    {
        public void WriteLog(string format, params object[] args)
        {
            string message = string.Format(format, args);
            Console.WriteLine("{0},  {1}", DateTime.Now.ToLocalTime(), message);
        }

        public void WriteLog(string log)
        {
            Console.WriteLine("{0}  {1}", DateTime.Now.ToLocalTime(), log);

        }
    }


    class Car
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public void stop() 
        {
            Console.WriteLine("정지!!");
        }
    }


    interface IHoverable
    {
        void Hover();       // 물에서 달린다
    }

    interface IFlyable
    {
        void Fly();         // 날다
    }


    class FlyHoverCar : Car, IFlyable, IHoverable     // Car 상속 받음    / 클래스 여러개 포함 불가 / 인터페이스 구현하면 오류 사라짐
    {
        public void Fly()
        {
            Console.WriteLine("납니다");
        }

        public void Hover()
        {
            Console.WriteLine("물에서 달립니다");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();       // new 클래스 (O) / new 인터페이스 (X)
            logger.WriteLog("안녕~~~~");
            
            IFormattableLogger logger2 = new ConsoleLogger2();
            logger2.WriteLog("{0} x {1} = {2}", 6, 5, (6 * 5));          // format argument
        }
    }
}
