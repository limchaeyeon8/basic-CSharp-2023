using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace cs27_delegateChain
{
    #region < 대리자 생성 >
    delegate void ThereIsAFire (string locatin);    // 불났을 때 대리해주는 대리자

    delegate int Calc (int a, int b);               // 대리자를 이용

    delegate string Concatenate(string[] args);
    #endregion

    #region < class Sample 람다식 프로퍼티 >

    class Sample
    {
        private int valueA;         // 멤버변수 - 외부 접근 불가하게 하기 위해 만드는 것

        /*public int ValueA         // 프로퍼티
        {
            *//*get { return valueA; }
            set { valueA = value; }*//*

            // 람다식
            get => valueA;
            set => valueA = value;

        }*/

        public int ValueA 
        {
            get => valueA;          // get은 람다식
            set
            {
                valueA = value;     // set은 일반식으로 혼용가능
            }
        }

    }

    #endregion

    internal class Program
    {
        #region < 이벤트 핸들러 >
        /*static void Call119(string locatin)
        {
            Console.WriteLine("▶Alart! {0} 화재 발생", locatin);
        }

        static void ShoutOut(string locatin)
        {
            Console.WriteLine("{0}에서 화재가 발생했습니다", locatin);

        }

        static void Escape(string locatin)
        {
            Console.WriteLine("{0}에서 신속히 대피하십시오", locatin);

        }*/

        #endregion

        #region < 메소드 >
        static string ProcConcate(string[] args)
        {
            string result = string.Empty;       // == "";
            foreach (string s in args)
            {
                result += s + "/";
            }

            return result;
        }

        #endregion

        static void Main(string[] args)
        {
            #region < 대리자 체인 >
            /*var loc = "구역 EMY-0220";
            Call119(loc);
            ShoutOut(loc);
            Escape(loc);

            // 불이 날 수도 있으니까 미리 >준비<
            var otherloc = "경찰서";
            ThereIsAFire fire = new ThereIsAFire(Call119);
            
            fire += new ThereIsAFire(ShoutOut); // 대리자에서 메소드를 추가 (체인 연결)
            fire += new ThereIsAFire(Escape);

            fire(otherloc);

            // 체인 빼기
            fire -= new ThereIsAFire(ShoutOut); // 대리자에서 메소드를 삭제

            fire("터널");

            //----
            #region < 익명함수 >

            Calc plus = delegate (int a, int b)
            {
                return a + b;
            };

            Console.WriteLine(plus(6, 7));

            Calc minus = (a, b) => { return a - b; };       // 람다식

            Console.WriteLine(minus(66, 47));
*/
            #endregion

            Concatenate concat = new Concatenate(ProcConcate);
            var result = concat(args);

            Console.WriteLine(result);

            #region < 람다식으로 >
            Console.WriteLine("↓ 람다식으로");
            Concatenate concat2 = (arr) =>
            {
                string res = string.Empty;       // == "";
                foreach (string s in args)
                {
                    res += s + "/";
                }

                return res;
            };
            Console.WriteLine(concat2(args));
            #endregion
        }
    }
}
