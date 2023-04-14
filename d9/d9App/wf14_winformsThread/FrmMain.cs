using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace wf14_winformsThread
{
    public partial class FrmMain : Form
    {
        int number = 0;
        int percentage = 0;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Worker.WorkerSupportsCancellation = true;   // 서포트 캔슬할 거냐
            Worker.WorkerReportsProgress = true;        // 진행사항 보여줄 거냐
        }

        #region < BackgoundWorker 이벤트 핸들러 >

        // 백그라운드로 일 진행 == Tread.Start()
        private void Worker_DoWork(object sender, DoWorkEventArgs e)        // 보내주는쪽(sender)==자기자신
        {
            BackgroundWorker worker = sender as BackgroundWorker;           //  인자값으로 BackgroundWorker 생성(얕은복사 - Worker랑 주소참조)

            e.Result = Fibonacci((int)e.Argument, worker, e);           // 피보나치 계산 메서드 만들기
        }

        private long Fibonacci(int arg, BackgroundWorker worker, DoWorkEventArgs e)    // object -> long 변경
        {
            // 파라미터 argsms 0~91사이 / 91보다 크면 long 오버플로우 발생
            // validation 검증
            if (arg < 0 || arg > 91)
            {
                throw new Exception("오류 0~91 사이 입력");       
            }
            long result = 0;

            if (worker.CancellationPending == true)
            {
                e.Cancel = true;
            }
            else
            {
                if (arg < 2)
                {
                    result = 1;
                }
                else
                {
                    // arg만 계산에 필요한 매개변수 / worker, e는 중간에 취소할 때 필요한 Backworker 복사본
                    result = Fibonacci(arg - 1, worker, e) + Fibonacci(arg-2, worker, e);
                }

                // 진행사항 프로그래스바에 표시
                int percentComplete = (int)(arg / number * 100);
                if (percentComplete > percentage)
                {
                    percentage = percentComplete;
                    worker.ReportProgress(percentComplete); // ProgressChanged 이벤트 발생
                }
            }
            return result;
        }

        // 백그라운드 스레드 테스크 종료한 뒤 처리
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                LblResult.Text = "취소됨";
            }
            else
            {
                LblResult.Text = e.Result.ToString();
            }

            TxtNumb.Text = 0.ToString();
            BtnStart.Enabled = true;
            BtnCancel.Enabled = false;
        }

        // 백그라운드 스레드 진행 중 일어나는 일을 프로그래스바에 값 할당하여 표시
        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            PgbCalculate.Value = e.ProgressPercentage;      // 진행사항 표시
        }

        #endregion

        #region < 버튼 >

        private void BtnStart_Click(object sender, EventArgs e)
        {
            // Button button = sender as Button;    // sender 연습 - 버튼 복사 가능
            BtnStart.Enabled = false;       // 시작버튼은 종료시까지 누르지 못함
            BtnCancel.Enabled = true;

            number = int.Parse(TxtNumb.Text);

            percentage = 0;
            PgbCalculate.Value = percentage;
            Worker.RunWorkerAsync(number);  // Async; 비동기로 진행
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Worker.CancelAsync();       // 비동기로 취소시키라고 요청 / 비동기여서 언제 취소될지 모름(사용자가 원하는 시간에 취소요청 전달 안 될 수도)
            BtnCancel.Enabled = false;
            BtnStart.Enabled = true;
        }

        #endregion
    }
}
