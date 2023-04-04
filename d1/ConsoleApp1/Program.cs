using System;

// 네임스페이스 ConsoleApp1
namespace ConsoleApp1
{
    /// <summary> xml 주석 (문서화 자동화 가능)
    /// 프로그램 클래스
    /// </summary>
    internal class Program      // 프로그램파일명과 클래스명을 같게 쓰는 걸 권장
    {
        /// <summary>
        /// * 메인 엔트리 포인트
        /// </summary>
        /// <param name="args">콘솔 매개변수</param>
        static void Main(string[] args)     // static; 정적함수(메소드) // string 배열에 arguments(여러개 값 저장)
        {
            Console.WriteLine("Hello C#!!");
        }
    }
}
