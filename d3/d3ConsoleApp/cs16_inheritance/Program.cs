using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs16_inheritance
{

    #region <부모클래스 선언>
    class Base      // 기반 또는 부모 클래스
    {
        // 자식클래스에서 상속 받으려면 private은 안 써야 함  / 상속 받을 일 없으면 써도 됨

        protected string Name;
        private string Color;       // 만약 상속을 할거면 private을 protected로 변경해야 함!
        public int Age;

        public Base(string Name, String Color, int Age)
        {
            this.Name = Name;
            this.Color = Color;
            this.Age = Age;
            Console.WriteLine("{0}.Base()", Name);
        }

        public void BaseMethod()
        {
            Console.WriteLine("{0}.BaseMethod()", Name);
        }

        public void GetColor()
        {
            Console.WriteLine("{0}.Base() {1}", Name, Color);
        }
    }
    #endregion

    class Child : Base          // 상속받은 이후 Base의 Name, Color, Age를 새로 만들거나 하지 않음
    {
        public Child(string Name, string Color, int Age) : base(Name, Color, Age)   // base는 부모 클래스 Base 의 생성자
        {
            Console.WriteLine("{0}.Child()", Name);
        }

        public void ChildMethod()
        {
            Console.WriteLine("{0}.ChildMethod()", Name);
        }

        public void GetColorChild()
        {
            // Console.WriteLine(Color);    // 접근 불가
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Base b = new Base("NameB", "White", 1);     // 3개의 매개변수 받음
            b.BaseMethod();
            b.GetColor();

            Child c = new Child("NameC", "Black", 2);   // 3개의 매개변수 받음
            c.ChildMethod();
            c.GetColor();               // Base.GetColor Black  ... c에서 Color 접근 불가!!!
        }
    }
}
