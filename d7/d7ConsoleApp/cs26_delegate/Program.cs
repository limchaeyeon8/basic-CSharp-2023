using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace cs26_delegate
{
    #region < 대리자 사용하겠다는 선언 >

    // Plus 메소드를 반환해주는 int / Calc를 대신해주는 delegate
    delegate int CalcDelegate(int a, int b);

    // a, b 중 뭐가 큰지작은지 비교 대리자
    delegate int Compare (int a, int b);        

    #endregion

    #region < 대리자 기본 >
    class Calc
    {
        public int Plus(int a, int b)
        {
            return a + b;
        }

        public static int Minus (int a, int b) 
        { 
            return a - b;
        }
    }
    #endregion
    internal class Program
    {
        // 오름차순 비교
        static int AscendCompare(int a, int b) // 대리자에서 쓸 메소드 생성
        {
            if (a > b) return 1;
            else if (a == b) return 0;
            else return -1;
        }

        // 내림차순 비교
        static int DescendCompare(int a, int b)
        {
            if (a < b) return 1;
            else if (a == b) return 0;
            else return -1;
        }

        //오름차순 내림차순 정렬이 하나의 메소드에서 실행
        static void BubbleSort(int[] DataSet, Compare comparer)
        {
            int i = 0, j = 0, temp = 0;

            for (i = 0; i < DataSet.Length - 1 ; i++)
            {
                for (j = 0; j < DataSet.Length - (i + 1) ; j++)
                {
                    // 오름차순
                    if (comparer ( DataSet[j], DataSet[j+1] ) > 0)     // 대리자 사용 O
                    {
                        temp = DataSet[j + 1];
                        DataSet[j + 1] = DataSet[j];
                        DataSet[j] = temp;      // Swap
                    }
                    /*if (DataSet[j] > DataSet[j + 1])                 // 대리자 사용 X
                    {
                        temp = DataSet[j + 1];
                        DataSet[j + 1] = DataSet[j];
                        DataSet[j] = temp;      // Swap
                    }*/
                }
            }
        }
        /*
        #region (+) 
        static void BubbleSort2(int[] DataSet, bool isAscend)
        {
            int i = 0, j = 0, temp = 0;

            for (i = 0; i < DataSet.Length - 1; i++)
            {
                for (j = 0; j < DataSet.Length - (i + 1); j++)
                {
        
                    if (isAscend == true)
                    {
                        if (comparer(DataSet[j], DataSet[j + 1]) > 0)     // 대리자 사용 X
                        {
                            temp = DataSet[j + 1];
                            DataSet[j + 1] = DataSet[j];
                            DataSet[j] = temp;
                        }
                    }
                    
                    else
                    {

                    }
                }
            }
        }
        #endregion
        */

        static void Main(string[] args)
        {
            #region < 대리자 기본 예 >
            // 일반적으로 클래스 사용 방식 - 직접 호출
            Calc normalCalc = new Calc();
            int x = 10, y = 15;
            int res = normalCalc.Plus(x, y);
            Console.WriteLine(res);

            Console.WriteLine(normalCalc.Plus(x, y));
            
            res = Calc.Minus(x, y);

            #region < 대리자 사용하는 방식 > - 대리자 대신 실행

            x = 30; y = 20;

            Calc delCalc = new Calc();
            CalcDelegate Callback;

            Callback = new CalcDelegate(delCalc.Plus);
            int res2 = Callback(x, y);  // <= Calc.Plus() 대신 호출((Calc 클래스가 가진 Plus 메소드))
            Console.WriteLine(res2);    // 50

            Callback = new CalcDelegate(Calc.Minus);
            res2 = Callback(x, y);
            Console.WriteLine(res2);    // 10

            #endregion

            #endregion

            #region <  >

            int[] origin = { 4, 7, 8, 2, 9, 1 };

            Console.WriteLine("\n오름차순 버블정렬>>>");
            BubbleSort(origin, new Compare(AscendCompare));     // 정렬

            foreach (int item in origin)
            {
                Console.Write("{0} ", item);
            }


            Console.WriteLine("\n내림차순 버블정렬>>>");
            BubbleSort(origin, new Compare(DescendCompare));     // 정렬

            foreach (int item in origin)
            {
                Console.Write("{0} ", item);
            }

            #endregion

        }
    }
}
