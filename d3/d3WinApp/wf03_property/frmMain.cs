using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace wf03_property
{
    public partial class frmMain : Form     // 생성자 / 상속
    {

        Random rnd = new Random();        // ----- 트리뷰 파트

        public frmMain()
        {
            InitializeComponent();
            // 생성자에는 되도록 설정부분을 넣지마세요
            // Form_Load() 이벤트 핸들러에 작성할 것
        }

        #region < 컨트롤 학습 >

        private void frmMain_Load(object sender, EventArgs e)
        {
            GbxMain.Text = "컨트롤 학습";
            var fonts = FontFamily.Families.ToList();   // 내 OS에 있는 폰트 이름 가져오기
            foreach (var font in fonts)
            {
                CboFontFamily.Items.Add(font.Name);
            }

            // 글자크기 최소값 / 최대값 지정
            NudFontSize.Minimum = 5;
            NudFontSize.Maximum = 40;

            // 텍스트박스 초기화
            TxtResult.Text = "Hello, Winforms!!";

        }

        //
        private void ChangeFontStyle()
        {
            if (CboFontFamily.SelectedIndex < 0)
            {
                CboFontFamily.SelectedIndex = 257;  // 나눔고딕을 디폴트로 지정
            }

            FontStyle style = FontStyle.Regular;    // 기본

            if (ChkBold.Checked == true)
            {
                style |= FontStyle.Bold;            // Bit연산 or
            }

            if (ChkItalic.Checked == true)
            {
                style |= FontStyle.Italic;          // Bit연산 or
            }

            decimal fontSize = NudFontSize.Value;
            TxtResult.Font = new Font((string)CboFontFamily.SelectedItem, (float)fontSize, style);
        }

        // 라디오버튼 추가 이벤트
        #region << 라디오버튼 추가 이벤트 >>

        void ChangeIndent()
        {
            if (RdoNormal.Checked)
            {
                TxtResult.Text = TxtResult.Text.Trim();
            }
            else if (RdoIndent.Checked)
            {
                TxtResult.Text = "      " + TxtResult.Text;
            }
        }
        #endregion


        private void CboFontFamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeFontStyle();
        }

        private void ChkBold_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFontStyle();
        }

        private void ChkItalic_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFontStyle();
        }

        private void NudFontSize_ValueChanged(object sender, EventArgs e)
        {
            ChangeFontStyle();
        }

        #endregion

        #region < 트랙바 / 진행바 >
        private void TrbDummy_Scroll(object sender, EventArgs e)
        {
            PgbDummy.Value = TrbDummy.Value;
        }

        #endregion

        #region < 모달 / 모달리스 / 메시지창 >
        private void BtnModal_Click(object sender, EventArgs e)
        {
            Form frm = new Form()
            {
                Text = "Modal Form",
                Width = 300,
                Height = 200,
                Left = 10,
                Top = 20,
                BackColor = Color.AliceBlue,
                StartPosition = FormStartPosition.CenterParent,

            };
            frm.ShowDialog();       // 새로운 자식창 띄우기
        }
        private void BtnModaless_Click(object sender, EventArgs e)
        {
            Form frm = new Form()
            {
                Text = "Modaless Form",
                Width = 400,
                Height = 300,
                StartPosition = FormStartPosition.CenterScreen, // Modaless는 FormStartPosition.CenterParent 안 먹힘
                BackColor = Color.LavenderBlush,
            };
            frm.Show();         // 모달리스 방식으로 자식창 띄움
        }

        // 기본적으로 MessageBox는 모달
        private void BtnMessageBox_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(TxtResult.Text);        // 기본
            //MessageBox.Show(TxtResult.Text, caption: "메시지창");       // 캡션
            //MessageBox.Show(TxtResult.Text, "메시지창", MessageBoxButtons.YesNo);   // 버튼 추가(+ 캡션)
            //MessageBox.Show(TxtResult.Text, "메시지창", 
            //    MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Question);       // 아이콘 추가
            //__________여기까지는 알고 있어야 함

            MessageBox.Show(TxtResult.Text, "메시지창", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);       // 기본(디폴트) 버튼 지정
            //MessageBox.Show(TxtResult.Text, "메시지창", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
            //    MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);     // 글자 오른쪽 정렬
        }

        #endregion

        #region < 트리뷰 >

        private void BtnAddRoot_Click(object sender, EventArgs e)
        {
            TrvDummy.Nodes.Add(rnd.Next(50).ToString());     // 스트링에 int 못 넣음 => ToString
            TreeToList();


        }

        private void BtnAddChild_Click(object sender, EventArgs e)
        {
            if (TrvDummy.SelectedNode != null)
            {
                TrvDummy.SelectedNode.Nodes.Add(rnd.Next(50, 100).ToString());
                TrvDummy.SelectedNode.Expand();         // 트리노드 하위 것들을 펼쳐주기 / 반대는 .collapse
                TreeToList();

            }
        }
        #endregion

        #region < 리스트뷰 >

        void TreeToList()
        {
            LsvDummy.Items.Clear();         // 리스트뷰, 트리뷰 모든 아이템을 제거 - 초기화 메소드

            foreach (TreeNode item in TrvDummy.Nodes)
            {
                TreeToList(item);           // 파라미터를 받는 새로운 메소드임
            }
        }

        private void TreeToList(TreeNode item)
        {
            LsvDummy.Items.Add(new ListViewItem(new []{ item.Text, item.FullPath.ToString() }));

            foreach (TreeNode node in item.Nodes)
            {
                TreeToList(node);           // 재귀호출
            }
        }

        #endregion

        #region < 라디오버튼 >   

        private void RdoNormal_CheckedChanged(object sender, EventArgs e)
        {
            ChangeIndent();
        }

        private void RdoIndent_CheckedChanged(object sender, EventArgs e)
        {
            ChangeIndent();
        }

        #endregion

        #region < 픽쳐박스 >
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (PcbDummy.SizeMode == PictureBoxSizeMode.Zoom)
            {
                PcbDummy.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                PcbDummy.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PcbDummy.Image = Bitmap.FromFile("cat.png");
        }

        #endregion



    }
}