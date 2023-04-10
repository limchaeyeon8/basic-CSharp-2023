using cs20_abxtractClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs20_abxtractClass
{

    abstract class AbstractParent                                   // 추상메소드 생성을 위해선 abstract 클래스로 만들어야 함
    {
        protected void MethodA()
        {
            Console.WriteLine("AbstractParent.MethodA()\n");
        }

        public void MethodB()                                       // 클래스랑 동일
        {
            Console.WriteLine("AbstractParent.MethodB()\n");
        }


        public abstract void MethodC();                             // 인터페이스랑 기능 동일 - 추상메소드
    }

    class Child : AbstractParent
    {
        public override void MethodC()                              // 추상메소드 재정의((== 구현))
        {
            Console.WriteLine("Child.MethodC() - 추상클래스 구현!\n");

            MethodA(); // * protected - 자기자신과 자시클래스 내에서 사용가능
        }
    }

    #region < 추상클래스 - 포유류 상속 예시 >
    abstract class Mammal                   // 포유류 최상위 클래스
    {
        public abstract void Sound();
    }

    class Dogs : Mammal
    {
        public override void Sound()
        {
            Console.WriteLine("멈멈~");
        }
    }

    class Cats : Mammal
    {

        public void Nurse()
        {
            Console.WriteLine("포유한다");
        }

        public override void Sound()
        {
            Console.WriteLine("웨옭~");
        }
    }
    #endregion


    internal class Program
    {
        static void Main(string[] args)
        {
            AbstractParent parent = new Child();

            parent.MethodC();
            parent.MethodB();
            // Parent.MethodA(); 는 protected라서 사용불가
        }
    }
}
