using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs29_fileHandling
{

    internal class Program
    {
        

        static void Main(string[] args)
        {
            // 특정 경로의 하위폴더 / 하위 파일 조회
            #region < 현재 디렉토리 정보 > 
            // Directory == Folder

            //string CurDir = ".";       // 현재 디렉토리(상대경로)
            //string CurDir = "..";       // 부모 디렉토리(상대경로)
            //string CurDir = "C:\\Dev";       // 절대경로
            string CurDir = @"C:\Temp";       // 절대경로 / @리터럴은 여러줄 문자열도 가능

            Console.WriteLine("---현재 디렉토리 정보---");

            var dirs = Directory.GetDirectories(CurDir); // 메소드(로컬) 안에서 받을 타입 모를 때 - var

            foreach (var dir in dirs)
            {
                var dirInfo = new DirectoryInfo(dir);

                Console.WriteLine(dirInfo.Name);
                Console.WriteLine(" [{0}] ", dirInfo.Attributes);
            }

            #endregion

            #region < 현재 디렉토리 파일 정보 >

            Console.WriteLine("---현재 디렉토리 파일 정보---");

            var files = Directory.GetFiles(CurDir);
            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                Console.WriteLine(fileInfo.Name);
                Console.WriteLine(" [{0}] ", fileInfo.Attributes);
            }

            #endregion

            #region < 디렉토리 생성 >

            string path = @"C:\Temp\CSharp_Bank";   // 생성할 폴더
            string sfile = "Test.log";              // 생성할 파일

            if (Directory.Exists(path))
            {
                Console.WriteLine("경로가 존재하여 파일을 생성합니다.");
                File.Create(path + @"\" + sfile); // C:\Temp\Csharp_Bank\Test.log
            }
            else
            {
                Console.WriteLine("해당 경로 '{0}' 이(가) 없습니다.", path);
                Console.WriteLine($"해당 경로 '{path}' 이(가) 없습니다. 생성합니다"); // 위와 동일
                Directory.CreateDirectory(path);

                Console.WriteLine("경로를 생성하여 파일을 생성합니다.");
                File.Create(path + @"\" + sfile); // C:\Temp\Csharp_Bank\Test.log

            }


            #endregion
        }
    }
}

