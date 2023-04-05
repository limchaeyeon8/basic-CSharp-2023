using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace cs03_object
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Object 형식
            // int == System.Int32
            // long == System.Int64
            // Int32 idata = 1024;         // int idata = 1024;
            long idata = 1024;
            Console.WriteLine(idata);
            Console.WriteLine(idata.GetType());

            object iobj = (object)idata;    // 박싱; 데이터 타입의 값을 object로 담아라
            Console.WriteLine(iobj);
            Console.WriteLine(iobj.GetType());

            long udata = (long)iobj;        // 언박싱; object를 원래 데이터타입으로 바꿔라
            Console.WriteLine(udata);
            Console.WriteLine(udata.GetType());

            //------------------------

            double ddata = 3.141592;
            object pobj = (object)ddata;
            double pdata = (double)pobj;

            Console.WriteLine(pobj);
            Console.WriteLine(pobj.GetType());
            Console.WriteLine(pdata);
            Console.WriteLine(pdata.GetType());

            //------------------------

            short sdata = 32000;
            int indata = sdata;
            Console.WriteLine(indata);

            long lndata = long.MaxValue;
            Console.WriteLine(lndata);
            indata = (int)lndata;      // 결과 '-1' <= 오버플로우
            Console.WriteLine(indata);

            // float 과 double 간의 형변환
            float fval = 3.141592f;     // float형은 마지막에 f를 써줘야 한다
            Console.WriteLine("fval=" + fval);

            double dval = (double)fval;
            Console.WriteLine("dval= " + dval);

            Console.WriteLine(fval == dval);
            Console.WriteLine(dval == 3.141592);

            // ★★★★★ 정말중요!! 실무에서
            int numival = 1024;
            string strival = numival.ToString();
            Console.WriteLine(strival);
            Console.WriteLine(numival);
            // Console.WriteLine(numival == strival); 
            Console.WriteLine(strival.GetType());


            double numbval = 3.14159265358979323846264338327950288;
            string strbval = numbval.ToString();
            Console.WriteLine(strbval);

            // 문자열을 숫자로
            // 문자열 내에 숫자가 아닌 특수문자나 정수인데 소숫점이 있거나
            string originstr = "34567890";                  // "3million은 예외 발생"
            int convval = Convert.ToInt32(originstr);       // int.Parse()와 동일
            Console.WriteLine(convval);
            originstr = "1.2345";
            float convfloat = float.Parse(originstr);
            Console.WriteLine(convfloat);

            // ㄴ 예외발생하지 않도록 형변환하는 방법
            originstr = "123.0f";
            float ffval;
            // TryParse는 예외가 발생하면 값은 0으로 대체 / 예외 없으면 원래 값으로
            float.TryParse(originstr, out ffval);           // 예외발생하지 않게 숫자 변환
            Console.Write(ffval);

            //------------------------
            // 상수
            const double pi = 3.14159265358979;
            Console.WriteLine(pi);
            //pi. 4.56;     // constant(상수) 는 바꿀 수 없음



        }
    }
}
