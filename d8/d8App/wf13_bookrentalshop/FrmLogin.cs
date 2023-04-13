using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace wf13_bookrentalshop
{
    public partial class FrmLogin : Form
    {
        private bool isLogined = false; // 로그인 성공했는지 물어보는 전체변수

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            isLogined = LoginProcess(); // 로그인 성공해야만 true가 됨 / false면 안 넘어감

            if (isLogined) this.Close();
 
        }

        /// <summary>
        /// DB userTbl에서 정보확인 로그인 처리
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private bool LoginProcess()
        {
            // Validation check(입력검증) - 내용이 들어있으면 진행, 아니면 막음
            if (string.IsNullOrEmpty(TxtUserId.Text))
            {
                MessageBox.Show("사용자 아이디를 입력하세요", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(TxtPW.Text))
            {
                MessageBox.Show("패스워드를 입력하세요", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string strUserId = "";      // 받아온 결과를 넣을 것
            string strPswd = "";

            try
            {
                string connectionString = "Server=localhost;Port=3306;Database=bookrentalshop;Uid=root;Pwd=12345";

                #region < DB 처리 > - MySQL 라이브러리 가져다 넣기

                /*MySqlConnection conn = new MySqlConnection("");
                conn.Open();
                conn.Close();*/

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // 쿼리문 작성
                    // Send to SQL Editor > Select All Statement > 수정해서 가져옴
                    // WHERE절 사용
                    #region < < DB 쿼리를 위한 구성 > >

                    string selQuery = @"SELECT userId
                                             , pswd
                                          FROM usertbl
                                         WHERE userId = @userId 
                                           AND pswd = @pswd";
                    MySqlCommand selCmd = new MySqlCommand(selQuery, conn);

                    // @userId, @pswd 파라미터 할당
                    MySqlParameter prmUserId = new MySqlParameter("@userId", TxtUserId.Text);
                    MySqlParameter prmPswd = new MySqlParameter("@pswd", TxtPW.Text);
                    selCmd.Parameters.Add(prmUserId);
                    selCmd.Parameters.Add(prmPswd);

                    //conn.Close(); 안 써도 닫힘

                    #endregion

                    MySqlDataReader reader = selCmd.ExecuteReader();        // 실행한 다음에 userId, pswd
                    
                    if (reader.Read())
                    {
                        strUserId = reader["userId"] != null ? reader["userId"].ToString() : "-";  // 널이 아니면 ToString
                        strPswd = reader["pswd"] != null ? reader["pswd"].ToString() : "-";
                    }
                    else
                    {
                        MessageBox.Show($"로그인 정보가 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    
                }

                // MessageBox.Show($"ID {strUserId} | PW {strPswd}\n-로그인 성공-");
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show($"비정상적 오류 : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }



        #region < KeyPress 이동 핸들러 >
        private void TxtUserId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)    // 엔터키
            {
                TxtPW.Focus();      // 패스워드입력위치로 이동
            }
        }

        private void TxtPW_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)    // 엔터키
            {
                BtnLogin_Click(sender, e);          // 버튼클릭 이벤트핸들러 호출
            }
        }
        #endregion

        #region < 창 종료 >

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            Environment.Exit(0);    // 가장 완벽하게 프로그램 종료
        }

        // * 예외해결: 이게 없으면 X버튼이나 Alt+F4 했을 때 메인폼 나타남
        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isLogined != true)  // 로그인 안 되었을 때 창을 닫으면 프로그램 모두 종료
            {
            Environment.Exit(0);    // 가장 완벽하게 프로그램 종료

            }
        }

        #endregion
    }
}
