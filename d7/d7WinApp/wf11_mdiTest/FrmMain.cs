using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf11_mdiTest
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        [Obsolete("OldMethod는 다음 버전에서 폐기됩니다. NewMethod를 이용하세요.")]
        private void OldMethod()
        {
            Console.WriteLine("올드메소드!!");
        }

        private void NewMethod()
        {
            //......
        }

        private void MniForm1_Click(object sender, EventArgs e)
        {
            OldMethod();
            child1 = new FrmChild();
            child1.TopLevel = false;
            this.Controls.Add(child1);
            child1.Show();
        }

        private void MniForm2_Click(object sender, EventArgs e)
        {

        }

        private void MniExit_Click(object sender, EventArgs e)
        {

        }

        private void MniAbout_Click(object sender, EventArgs e)
        {

        }
    }
}
