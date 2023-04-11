﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs25_exception
{



    internal class Program
    {


        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3 };

            try
            {
                for (var i = 0; i < 5; i++)
                {
                    Console.WriteLine(array[i]);
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // ---- 예외가 발생하더라도 무조건 처리해야 되는 로직
                // file 객체 close
                // db연결 close
                // 네트워크 소켓 close

                Console.WriteLine("계속 가요");
            }
            try
            {
                DivideTest(array[2], array[0]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("프로그램 종료!!!");

           /* try
            {
                Console.WriteLine("Test TEST test");
                throw new Exception("커스텀 예외");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }*/
        }

        private static void DivideTest(int v1, int v2)
        {
            try
            {
                Console.WriteLine(v1 / v2);
            }
            catch// (Exception)
            {
                // 현재 메소드에 예외처리하지 않고 메소드를 호출한 곳에서 예외처리 한다
                throw new Exception("DivideTest 메소드에서 예외가 발생!");
            }
        }
    }
}
