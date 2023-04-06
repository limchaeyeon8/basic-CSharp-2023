using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs13_class
{

    // 난이도: 파이썬 < 자바스크립트 < c#, 자바,... < c < c++
    class Cat               // private이라도 같은 cs13_class(namespace) 안에 있기 때문에 접근 가능
    {

        #region < 생성자 >
        /// <summary>
        /// 기본 생성자
        /// </summary>
        public Cat() 
        {
            Name = string.Empty;
            Color = string.Empty;
            Age = 0;
        }

        /// <summary>
        /// 사용자 지정 생성자
        /// </summary>
        /// <param name="name"></param>
        /// <param name="color"></param>
        /// <param name="age"></param>
        public Cat(string name, string color = "흰색", sbyte age = 1)
        {
            Name = name;
            Color = color;
            Age = age;
        }

        #endregion

        #region <멤버변수 - 속성>
        public string Name;        // 고양이 이름
        public string Color;       // 색상
        public sbyte Age;          // 나이  sbyte : 0~255
        #endregion

        #region <멤버메소드 - 기능>
        public void Meow()
        {
            Console.WriteLine("{0} - 웨옭", Name);        // this.Name 해도 되지만 this를 안 써도 됨
        }

        public void Run()
        {
            Console.WriteLine("{0} 달린다", Name);
        }
        #endregion
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Cat helloKitty = new Cat(); // 클래스명 객체명 = new + 클래스명() <=== 생성자 / helloKitty라는 이름의 객체를 생성할게!
            helloKitty.Name = "헬로키티";
            helloKitty.Color = "흰색";
            helloKitty.Age = 50;
            // 오브젝트가 기본적으로 가지고 있는 메소드 (Equals, GetType, ToString(숫자->문자), ...)

            helloKitty.Meow();
            helloKitty.Run();

            // 인스턴스 생성하면서 속성들 초기화
            Cat nero = new Cat()
            {
                Name = "검은고양이 네로",
                Color = "검은색",
                Age = 27
            };
            nero.Meow();
            nero.Run();

            Console.WriteLine("{0}의 색상은 {1}, 나이는 {2}세 입니다",
                helloKitty.Name, helloKitty.Color, helloKitty.Age);
            Console.WriteLine("{0}의 색상은 {1}, 나이는 {2}세 입니다",
                nero.Name, nero.Color, nero.Age);

            // 기본 생성자
            Cat nabi = new Cat();
            Console.WriteLine("{0}의 색상은 {1}, 나이는 {2}세 입니다",
                nabi.Name, nabi.Color, nabi.Age);

            Cat norangyee = new Cat("노랑이", "노란색");
            Console.WriteLine("{0}의 색상은 {1}, 나이는 {2}세 입니다",
                norangyee.Name, norangyee.Color, norangyee.Age);
        }
    }
}
