using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs28_event
{
    #region < 1. 대리자(delegate) 선언 >

    delegate void EventHandler(string message);

    #endregion

    #region < 2. 선언한 대리자 인스턴스를 event 한정자로 수식 (대리자를 사용한 이벤트 준비) >
    class CustomNotifier
    {
        public event EventHandler SomethingChanged;

        public void DoSomething (int number)
        {
            int temp = number % 10;

            if (temp != 0 && temp % 3 == 0)
            {
                #region < 3. 특별한 이벤트가 발생할 상황에서 이벤트를 수행 >

                SomethingChanged(string.Format("{0} : odd", number));

                #endregion
            }
        }
    }

    #endregion

    internal class Program
    {
        #region < 4. 클래스 인스턴스 생성 후 객체의 이벤트에 이벤트 핸들러 등록 (이벤트가 대신 호출할 메소드) >
        static void CustomHandler(string message)
        {
            Console.WriteLine(message);
        }

        #endregion

        static void Main(string[] args)
        {

            #region < 5. 이벤트 발생 => 이벤트 핸들러 호출 >

            CustomNotifier notifier = new CustomNotifier();
            notifier.SomethingChanged += new EventHandler(CustomHandler);   // SomethingChanged가 일어나면 '+=' 체인 EventHandler가 실행되는데 CustomHandler가 대신 해줄거야 

            for (int i = 0; i <= 30; i++)
            {
                notifier.DoSomething(i);
            }

            #endregion

        }
    }
}
