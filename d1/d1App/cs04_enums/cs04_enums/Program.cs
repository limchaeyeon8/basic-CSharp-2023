using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs04_enums
{
    internal class Program
    {

        enum HomeTown       // enum - 같은 특성을 가진 것을 열거
        {
            SEOUL = 1,
            DAEJEON = 2,
            DAEGU = 3,
            BUSAN = 4,
            JEJU = 5        // 숫자 커스터마이징 가능
        };


        static void Main(string[] args)
        {
            HomeTown myHomeTown;
            myHomeTown = HomeTown.BUSAN;

            if (myHomeTown == HomeTown.SEOUL)
            {
                Console.WriteLine("서울 출신이시군요!");
            }
            else if (myHomeTown == HomeTown.DAEJEON)
            {
                Console.WriteLine("충청도예유~");
            }
            else if (myHomeTown == HomeTown.DAEGU)
            {
                Console.WriteLine("대구여~");
            }
            else if (myHomeTown == HomeTown.BUSAN)
            {
                Console.WriteLine("마 밥 뭇나");
            }
            else if (myHomeTown == HomeTown.JEJU)
            {
                Console.WriteLine("우리집에 귤 있어");
            }
        }
    }
}
