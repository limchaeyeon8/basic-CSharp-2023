using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs24_generic
{
    #region <일반화 클래스>*****
    class MyArray<T> where T : class // where T : class 사용할 타입은 무조건 클래스타입이어야 한다
    {
        T[] array;
    }
    #endregion



    internal class Program
    {
        #region < 일반화 메소드 >
        // 하나로 퉁치자!! 일반화

        static void CopyArray<T>(T[] source, T[] target)
        {
            for (var i = 0; i < source.Length; i++)
            {
                target[i] = source[i];
            }
        }

        /*
        static void CopyArray(long[] source, long[] target)
        {
            for (var i = 0; i < source.Length; i++)
            {
                target[i] = source[i];
            }
        }
        static void CopyArray(long[] source, long[] target)
        {
            for (var i = 0; i < source.Length; i++)
            {
                target[i] = source[i];
            }
        }

        // ......
        */
        #endregion



        static void Main(string[] args)
        {
            #region < 일반화 시키기 >
            int[] source = {2, 4, 6, 8, 10};
            int[] target = new int[source.Length];

            CopyArray(source, target);
            foreach (var item in target)
            {
                Console.WriteLine(item);
            }

            long[] source2 = { 2100000, 2300000, 3300000, 5600000, 7800000 };
            long[] target2 = new long[source2.Length];

            CopyArray(source2, target2);

            float[] source3 = { 3.14f, 3.15f, 3.16f, 3.17f, 3.19f };
            float[] target3 = new float[source3.Length];

            CopyArray(source3, target3);
            #endregion

            #region < 일반화 컬렉션 >

            List<int> list = new List<int>();
            for (var i = 10; i > 0; i--)
            {
                list.Add(i);
            }

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            list.RemoveAt(3);       // 7 삭제

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            list.Sort();

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            // 아래와 같은 일반화 컬렉션을 자주 볼 수 있음
            List<MyArray<string>> myStringArray = new List<MyArray<string>>();

            // 일반화 Stack
            Stack<float> stFloats = new Stack<float>();
            stFloats.Push(3.15f);
            stFloats.Push(4.28f);
            stFloats.Push(7.24f);

            while (stFloats.Count > 0)
            {
                Console.WriteLine(stFloats.Pop());     // 
            }

            // 일반화 Queue
            Queue<string> qStrings = new Queue<string>();
            qStrings.Enqueue("I love you");
            qStrings.Enqueue("and");
            qStrings.Enqueue("I miss you");

            while (stFloats.Count > 0)
            {
                Console.WriteLine(qStrings.Dequeue());     // 
            }

            // 일반화 Dictionary
            Dictionary<string, int> dicNumbs = new Dictionary<string, int>();
            dicNumbs["하나"] = 1;
            dicNumbs["둘"] = 2;
            dicNumbs["셋"] = 3;
            dicNumbs["넷"] = 4;

            Console.WriteLine(dicNumbs["셋"])


            #endregion
        }
    }
}
