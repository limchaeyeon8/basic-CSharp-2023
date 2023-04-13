using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf13_bookrentalshop
{
    public partial class FrmMain : Form
    {
        #region < 생성자 >



        #endregion

        #region < 이벤트 핸들러 >

        private void FrmMain_Load(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();
            frm.ShowDialog();
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
            FrmGen frm = new FrmGen();
            frm.TopLevel = false;
            this.Controls.Add(frm);
            frm.Show();
        }

        private void MniBookMng_Click(object sender, EventArgs e)
        {

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
    }
}
