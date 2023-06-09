﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs10_operator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 비트 연산자 '<<' == '*2' // '>>' == '/2'  
            int firstval = 15;  // 15 = 0x1111(이진수)
            int secondval = firstval << 1;  // shift ==> 0x11110 = 16+8+4+2 = 30
            Console.WriteLine(secondval);


    // 실무에서는 많이 안 씀
        // AND 연산
            // 1111 & 1101 => 1101      15 & 13 => 13
            firstval = 15;
            secondval = 13;
            Console.WriteLine(firstval & secondval);

        // OR 연산
            // 1010 | 0101 => 1111      15 | 13 => 15
            firstval = 10;
            secondval = 5;
            Console.WriteLine(firstval | secondval);
            Console.WriteLine(firstval ^ secondval);    // XOR

            Console.WriteLine(~secondval);      // 보수
    //________________________

            // Null 병합 연산자
            int? checkval = null;
            Console.WriteLine(checkval == null? 0 : checkval);  // 3항연산자
            Console.WriteLine(checkval ?? 0);   // null 병합연산자는 3항연산자를 더 축소시킴

            checkval = 25;
            Console.WriteLine(checkval == null ? 0 : checkval);
            Console.WriteLine(checkval ?? 0);

            checkval = 25;
            Console.WriteLine(checkval.HasValue ? checkval.Value : 0);
            Console.WriteLine(checkval ?? 0);
        }
    }
}
