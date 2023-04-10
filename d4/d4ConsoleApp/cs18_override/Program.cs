using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs18_override
{
    #region < 오버라이드 >
    class ArmorSuite
    {
        public virtual void Init()
        {
            Console.WriteLine("\n기본 아머슈트");
        }
    }

    class IronMan : ArmorSuite
    {
        public override void Init()
        {
            base.Init();
            Console.WriteLine(">>리펄서 빔");
        }
    }

    class Warmachine : ArmorSuite
    {
        public override void Init()
        {
            //base.Init();      // 부모클래스의 Init() 실행 안 함
            Console.WriteLine(">>미니건");
            Console.WriteLine(">>돌격소총");
        }
    }

    #endregion


    class Parent
    {
        public void CurrentMethod()
        {
            Console.WriteLine("부모클래스 메소드");
        }
    }

    class Child : Parent
    {
        public new void CurrentMethod()     // new - 없어도 되지만 있는 게 더 정확; 숨김
        {
            Console.WriteLine("자식클래스 메소드");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--아머슈트 생산--");
            ArmorSuite suite = new ArmorSuite();
            suite.Init();

            Console.WriteLine("\n워머신 생산");
            Warmachine machine = new Warmachine();
            machine.Init();

            Console.WriteLine("\n아이언맨슈트 생산");
            IronMan iron = new IronMan();
            iron.Init();



        }
    }
}
