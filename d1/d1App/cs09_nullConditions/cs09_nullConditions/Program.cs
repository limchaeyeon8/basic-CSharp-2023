using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs09_nullConditions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Foo myfoo = null;       // new Foo();
            // myfoo.member = 30;

            /*
            int? bar;
            if (myfoo != null)      // null이면 객체 생성x 상태
            {
                bar = myfoo.member;
            }
            else
            {
                bar = null;
            }
            */

            int? bar = myfoo?.member;   // 위의 아홉줄(주석부분)을 모두 축약시킨 한 줄
        }
    }

    class Foo
    {
        public int member;
    }

}
