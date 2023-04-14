using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wf13_bookrentalshop.Helpers   
{
    // bookrentalshop 밑에 Helpers 밑에 Commons 클래스 생성
    internal class Commons
    {
        // 모든 프로그램상에서 다 사용가능
        // readonly; 한번 만들면 수정불가
        //  DB 연결문자열은 여기서만 수정하면 됨
        public static readonly string ConnStr = "Server=localhost;" + 
                                                "Port=3306;" + 
                                                "Database=bookrentalshop;" + 
                                                "Uid=root;" +
                                                "Pwd=12345";
                                            

    }
}
