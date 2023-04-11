using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs23_collection
{

    class CustomEnumerator : IEnumerable        // foreach를 쓸 수 있는 객체로 만들래
    {
        int[] list = { 1, 3, 5, 7, 9 };

        public IEnumerator GetEnumerator()
        {
            yield return list[0];       // 메소드를 빠져나가지 않고 값만 돌려줌
            yield return list[1];       // return과 달리 보내주고 멈춰 있음
            yield return list[2];
            yield return list[3];
            yield break;
            //yield return list[4];

        }
    }

    class MyArrayList : IEnumerator, IEnumerable
    {
        int[] arry;     // 배열값 집어넣는 곳
        int position = -1;

        public MyArrayList()
        {
            arry = new int[3];     // 기본 크기 3으로 초기화
        }

        // 인덱서 프로퍼티
        public int this[int index]
        {
            get { return arry[index]; }
            set 
            {
                if (index >= arry.Length)
                {
                    Array.Resize<int>(ref arry, index + 1);

                    Console.WriteLine("MyArrayList Resize : {0}", arry.Length); // 개발완료 후 주석처리
                }
                arry[index] = value;    
            }
        }


        #region < IEnumarable 인터페이스 구현 >
        public IEnumerator GetEnumerator()
        {
            for (var i = 0; i < arry.Length; i++)
            {
                yield return arry[i];
            }
        }

        #endregion


        #region < IEnumarator 인터페이스 구현 >
        public object Current
        {
            get
            {
                return arry[position];
            }
        }
        

        public bool MoveNext()
        {
            if (position == arry.Length - 1)
            {
                Reset();
                return false;
            }

            position++;
            return (position < arry.Length);
        }

        public void Reset()
        {
            position = -1;
        }
        #endregion
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var obj = new CustomEnumerator();

            foreach (var item in obj)
            {
                Console.WriteLine(item);
            }

            // indexer 프로퍼티를 만들었기 때문에 가능
            var myArrayList = new MyArrayList();
            for (var i = 0; i <= 5 ; i++)
            {
                myArrayList[i] = i;         
            }

            // IEnumerable 인터페이스를 구현했기 때문에 가능
            foreach (var item in myArrayList)   
            {
                Console.WriteLine(item);
            }
        }
    }
}
