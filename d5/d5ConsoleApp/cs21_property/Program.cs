using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace cs21_property
{

    #region < 보일러 클래스 예제 >

    class Boiler
    {
        public int temp;   // 안 적으면 기본은 private // 멤버변수

        #region < get; / set; >
        public int Temp     // [ 프로퍼티(속성) ]
        {
            get { return temp; }
            set
            {
                if (value <= 10 || value >= 70)
                {
                    temp = 10;      // 제일 낮은 온도로 변경 설정
                }
                else
                {
                    temp = value;
                }
            }
        }
        #endregion

        // 위의 get; / set; 과 비교      -------  아래의 Get 메소드와 Set 메소드는 Java에서만 사용, C#은 거의 안 씀
        #region < 옛날 방식 - Get, Set 메소드 >
        public void SetTemp(int temp)
        {
            if (temp <= 10 || temp >= 70)
            {
                //Console.WriteLine("수온설정값이 정상값을 벗어났습니다\n10~70도 사이로 지정해주세요");
                //return;

                this.temp = 10;
            }

            this.temp = temp;   
        }

        public int GetTemp() { return this.temp;}
        #endregion
    }

    #endregion


    #region < 인터페이스 >

    interface IProduct
    {
        string ProductName { get; set; }

        void Produce();
    }

    class MyProduct : IProduct
    {
        private string productName;

        public string ProductName
        {
            get { return productName; }
            set{ productName = value; }
        }

        public void Produce() 
        {
            Console.WriteLine("{0}을(를) 생산합니다.", ProductName);   // 프로퍼티
        }
    }

    #endregion


    internal class Program
    {
        static void Main(string[] args)
        {
            Boiler kitturami = new Boiler();
            //kitturami.temp =60;       // private이면 접근이 안 돼서 클래스에서 퍼블릭으로 변경

            //-----데이터 오염 => get/set 사용
            //kitturami.temp = 300000;        // 보일러 물수온이 30만도??
            //kitturami.temp = -120;          // ????

            //-----------------------
            kitturami.SetTemp(50);

            Console .WriteLine(kitturami.GetTemp());        // 예전 방식


            Boiler navien = new Boiler();
            navien.Temp = 5000;
            Console.WriteLine(navien.GetTemp());

        }
    }
}
