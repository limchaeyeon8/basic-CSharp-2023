using System;

namespace cs06_var
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = 400000;
            Console.WriteLine("[type] : {0}, [value] : {1}", a.GetType(), a);

            var b = 3.141592;       // f 여부 따라서 double / float 변경
            Console.WriteLine("[type] : {0}, [value] : {1}", b.GetType(), b);

            var c = "Basic C#";
            Console.WriteLine("[type] : {0}, [value] : {1}", c.GetType(), c);

        }
    }
}
