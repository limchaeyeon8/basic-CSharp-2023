using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wf13_bookrentalshop.Helpers;

namespace wf13_bookrentalshop
{
    public partial class FrmMain : Form
    {
        #region < 각 화면 폼 >
        FrmGen frmGen = null;       // 책 장르 관리 객체변수
        FrmBooks frmBooks = null;   // 책 정보 관리

        #endregion

        #region < 생성자 >



        #endregion

        #region < 이벤트 핸들러 >

        private void FrmMain_Load(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();

            // 상태바
            LblUserId.Text = Commons.LoginId;
            LblLoginDatetime.Text = "/" + DateTime.Now.ToString();
        }


        public FrmMain()
        {
            InitializeComponent();
        }


        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();     // 전체 프로그램 종료!
        }

        private void MniGenMng_Click(object sender, EventArgs e)
        {
            /*FrmGen frm = new FrmGen();
            frm.TopLevel = false;
            this.Controls.Add(frm);
            frm.Show();*/

            frmGen = ShowActiveForm(frmGen, typeof(FrmGen)) as FrmGen;
        }

        #region <임시 Collapse>
        private void MniBookMng_Click(object sender, EventArgs e)
        {
            frmBooks = ShowActiveForm(frmBooks, typeof(FrmBooks)) as FrmBooks;
        }

        private void MniMembMng_Click(object sender, EventArgs e)
        {

        }

        private void MniRentMng_Click(object sender, EventArgs e)
        {

        }

        private void MniAbout_Click(object sender, EventArgs e)
        {

        }

        #endregion


        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("종료하시렵니까?", "떼껄룩", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                e.Cancel = false;
                Environment.Exit(0);
            }
            else { e.Cancel = true; }
        }

        #endregion

        #region <  >


        private Form ShowActiveForm(Form form, Type type)
        {
            if (form == null)               // 한 번도 자식창을 안 열었으면
            {
                form = (Form)Activator.CreateInstance(type);    // 만들어주기  // *리플랙션으로 타입에 맞는 창을 새로 생성
                form.MdiParent = this;                          // FrmMain이 부모라는 의미
                form.WindowState = FormWindowState.Normal;
                form.Show();
            }
            else
            {
                if (form.IsDisposed)        // 컨트롤삭제됐는가(한 번 닫힘?)
                {
                    form = (Form)Activator.CreateInstance(type);    // 만들어주기  // *리플랙션으로 타입에 맞는 창을 새로 생성
                    form.MdiParent = this;                          // FrmMain이 부모라는 의미
                    form.WindowState = FormWindowState.Normal;
                    form.Show();
                }
                else                        // 창이 열려있으면
                {
                    form.Activate();                                // 화면이 있으면 그 화면을 활성화
                }
            }
            return form;
        }


        #endregion

    }
}
