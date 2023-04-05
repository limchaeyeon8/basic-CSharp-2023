using System;

namespace cs12_methods
{
    class Calc
    {
        public static int Plus (int a, int b)       // static; 정적; 실행되면 메모리에 올라가서 언제든 접근 가능
        {
            return a + b;
        }

        public int Minus (int a, int b)
        {
            return a - b;
        }
    }

    internal class Program
    {
        /// <summary>
        /// 실행시 메모리에 최초로 올라가야 하기 때문에 static이 되어야 하고
        /// 메서드 이름이 Main이면 실행될 때 알아서 제일 처음에 시작된다.
        /// </summary>
        /// <param name="args"></param>
        
        static void Main(string[] args)             // 엔트리포인트가 static이어야 실행됨 // Main 무조건 static
        {
        #region <static 메소드>
            int result = Calc.Plus (1, 2);
            // static은 최초 실행 때 메모리에 바로 올라가기 때문에 클래스 객체를 만들 필요 없음
            // result = new Calc().Plus(1, 2);
            // static 안 쓰면 new Calc() 사용해 객체 생성 -> 힙에 객체를 올려보내야 함

            // Calc.Minus (1, 2);      // Minus는 static이 아니기 때문에 접근불가 ( 객체 생성해야 접근 가능 )
            result = new Calc().Minus(3, 2);
            Console.WriteLine (result);

            //return 0;    <<<int Main일 때

        #endregion

        #region < Call by reference / Call by value 비교 >

            int x = 10; int y = 3;
            // ref 없으면 Call by value
            Swap(ref x, ref y);  // x, y가 가지고 있는 주소(데이터값x)를 전달하라 Call by reference == pointer
            // Swap이 static이 아니면 오류

            Console.WriteLine ("x = {0}, y = {1}", x, y);

            Console.WriteLine(Getnumb());

        #endregion

        #region < out 매개 변수 >

            int divid = 30;
            int divor = 2;

            /*
            result = Divide(divid, divor);
            Console.WriteLine(result);

            int rem = Reminder(divid, divor);   
            Console.WriteLine (rem);
            */

            int rem = 0;
            Divide(divid, divor, out result, out rem);      // ref든 out이든 결과 차이 없음
            Console.WriteLine("나누기값 {0}, 나머지 {1}", result, rem);

            (result, rem) = Divide(20, 6);
            Console.WriteLine("나누기값 {0}, 나머지 {1}", result, rem);

            #endregion

        #region <가변길이 매개변수>
            Console.WriteLine(Sum(1, 2, 3, 4, 5, 6, 7, 8, 9, 10));
        #endregion

        }



        /*
        static int Divide(int x, int y)
        {
            return x / y;
        }

        static int Reminder(int x, int y)
        {
            return x % y;
        }
        */
        // 85~95줄- 메소드 두 개 만들 걸 하나로 합치기
        static void Divide (int x, int y, out int val, out int rem)
        {
            val = x / y;
            rem = x % y;
        }

        static (int result, int rem) Divide (int x, int y)      // (int result, int rem) <--튜플  // 오버로딩
        {
            return( x / y, x % y);      // c# 7.0부터
        }

        static (float result, int rem) Divide(float x, float y)      // 오버로딩(타입 지정해야 하는 언어들에선 이런 작업을 해줘야 함)
        {
            return (x / y, (int)(x % y));      // c# 7.0부터
        }


        // ----------------
        // Main 메소드와 같은 레벨에 있는 메소드들은 전부 static이 되어야 함((무조건!!!))
        public static void Swap(ref int a, ref int b)
        {
            int temp = 0;
            temp = a;       // temp = 5
            a = b;          // a = 4
            b = temp;       // b = 5
        }


        // ----------------
        static int val = 100;

        public static ref int Getnumb()
        {
            return ref val;     // static 메소드에 접근할 수 있는 변수는 static 밖에 없음
        }


        // ----------------
        public static int Sum(params int[] args)        // Python 가변길이 매개 변수랑 비교
        {
            int sum = 0;    

            foreach (var item in args)
            {
                sum += item;
            }
            return sum;
        }
    }
}
