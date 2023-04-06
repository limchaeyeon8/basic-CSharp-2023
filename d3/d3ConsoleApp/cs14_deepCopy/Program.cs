using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs14_deepCopy
{

    class SomeClass
    {
        public int SomeField1;      // (+) 자바: 게터, 세터 { getter; setter; } / C#: 겟, 셋 { get; set; }
        public int SomeField2;

        // 깊은 복사
        public SomeClass DeepCopy()
        {
            SomeClass newCopy = new SomeClass();
            newCopy.SomeField1 = this.SomeField1;   // 새로운 인스턴스 생성하여 복사 대입 / Call by value
            newCopy.SomeField2 = SomeField2;        // this 생략 가능

            return newCopy;
        }
    }

    // this 사용법
    class Employee
    {
        private string Name;

        public void SetName(string Name)
        {
            this.Name = Name;   // 멤버변수(속성)과 메소드의 매개변수 이름이 대소문자까지 완전히 똑같을 때 둘을 비교하기 위해 사용
        }
    }

    // this 클래스
    class ThisClass
    {
        int a, b, c;

        public ThisClass()      // 오버로딩
        {
            this.a = 1;
        }
        public ThisClass(int b) : this()
        {
            this.b = b;
        }
        public ThisClass(int b, int c) : this(b)
        {
            this.c = c;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" 얕은 복사 시작 ");    // source와 target이 (주소복사) 값이 쉐어(!) <-- 조심~~~

            SomeClass source = new SomeClass();
            source.SomeField1 = 100;
            source.SomeField2 = 200;

            SomeClass target = source;                  // 타겟 생성 - source 할당
            target.SomeField2 = 300;                    // 복사된 객체

            Console.WriteLine("s.SomeField1 => {0}, s.SomeField2 => {1}",
                source.SomeField1, source.SomeField2);

            Console.WriteLine("t.SomeField1 => {0}, t.SomeField2 => {1}",
                target.SomeField1, target.SomeField2);

            //-------------------------------------

            Console.WriteLine("\n 깊은 복사 시작 ");

            SomeClass s = new SomeClass();
            s.SomeField1 = 100;
            s.SomeField2 = 200;

            SomeClass t = s.DeepCopy();     // 깊은 복사
            t.SomeField2 = 300;

            Console.WriteLine("s.SomeField1 => {0}, s.SomeField2 => {1}",
                s.SomeField1, s.SomeField2);

            Console.WriteLine("t.SomeField1 => {0}, t.SomeField2 => {1}",
                t.SomeField1, t.SomeField2);

        }
    }
}
