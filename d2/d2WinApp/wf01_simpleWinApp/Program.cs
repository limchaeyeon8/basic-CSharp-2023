﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wf01_simpleWinApp
{
    class Program : System.Windows.Forms.Form       // From클래스 상속
    {
        static void Main(string[] args)
        {
            Console.WriteLine("First WinApp");
            System.Windows.Forms.Application.Run(new Program());
        }
    }
}
