using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs17_inheritance
{

    #region < 기본 상속 개념 >
    // 상속해줄 부모 클래스

    class Parent
    {
        public string Name;
        
        public Parent(string Name)
        {
            this.Name = Name;
            Console.WriteLine("{0} from Parent 생성자", Name);
        }

        public void ParentMethod()
        {
            Console.WriteLine("{0} from Parent 메소드", Name);

        }
    }

    // 상속받을 자식클래스
    class Child : Parent
    {
        public Child(string Name) : base(Name)      // 부모클래스를 먼저 실행한 뒤 자신 생성자를 실행
        {
            Console.WriteLine("{0} From Child 생성자", Name);
        }
        public void ChildMethod()
        {
            Console.WriteLine("{0} From Child 메소드", Name);
        }
    }

    #endregion


    #region < 클래스간 형식변환 >
    // 클래스간 형변환 DB처리
    class Mammal // 포유류
    {
        public void  Nurse()    // 기르다
        {
            Console.WriteLine("포유류 기르다");
        }
    }

    class Dogs : Mammal
    {
        public void Bark()
        {
            Console.WriteLine("멍멍!");
        }
    }

   class Cats : Mammal
    {
        public void Meow()
        {
            Console.WriteLine("야옹!");
        }
    }

    class Elephants : Mammal
    {
        public void Poo()
        {
            Console.WriteLine("뿌우~");
        }
    }

    class ZooKepper
    {
        public void Wash(Mammal mammal)
        {
            if  (mammal is Elephants) 
            {
                var animal = mammal as Elephants;
                Console.WriteLine("코끼리를 씻깁니다");
                animal.Poo();
            }
            else if (mammal is Dogs)
            {
                var animal = mammal as Dogs;
                Console.WriteLine("강아지를 씻깁니다");
                animal.Bark();
            }
            else if (mammal is Cats)
            {
                var animal = mammal as Cats;
                Console.WriteLine("고양이를 씻깁니다");
                animal.Meow();
            }
        }
    }
    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            #region < 기본상속 개념 >

            Parent p = new Parent("p");
            p.ParentMethod();

            Console.WriteLine("자식클래스 생성");
            Child c = new Child("c");

            c.ParentMethod();
            c.ChildMethod();

            #endregion

            #region < 클래스간 형식변환 >

            // Mammal mammal = new Mammal();    // 기본
            Mammal mammal = new Dogs();
            // mammal.Bark();                   // 오류 / 부모클래스에는 Bark() 가 없음 / 아예 안 되는 거는 아님

            // 짓게 하기
            if (mammal is Dogs)
            {
                //Dogs midDog = (Dogs)mammal;   // 구식 or 값형식
                Dogs midDog = mammal as Dogs;   // 객체 , 참조형식

                midDog.Bark();
            }


            // Dogs dogs = new Mammal();        // 오류 / 부모->자식 변환 불가 ( 자식->부모 는 변환O )
            Dogs dogs2 = new Dogs();
            Cats cats2 = new Cats();
            Elephants el2 = new Elephants();


            ZooKepper kepper = new ZooKepper();
            kepper.Wash(dogs2);
            kepper.Wash(cats2);
            kepper.Wash(el2);

            #endregion
        }
    }
}
