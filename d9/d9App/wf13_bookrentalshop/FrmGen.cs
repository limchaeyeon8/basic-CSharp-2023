using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace wf13_bookrentalshop
{
    public partial class FrmGen : Form
    {

        bool isNew = false;     // false(UPDATE) / true(INSERT)


        #region < 생성자 >
        public FrmGen()
        {
            InitializeComponent();
        }

        #endregion

        #region < 이벤트 핸들러 >
        private void FrmGen_Load(object sender, EventArgs e)
                {
                    RefreashData();
                    isNew = true;   // 창 켜자마자 신규!!!!
                }

        #region < 버튼 핸들러 >

                private void BtnNew_Click(object sender, EventArgs e)
                {
                    ClearInputs();
                }


                private void BtnSave_Click(object sender, EventArgs e)
                {
                    if (CheckValidation() != true) return;

                    SaveData();     // 데이터 저장 / 수정

                    RefreashData(); // 데이터 재조회(저장 후 바로 DB 표시)
                    ClearInputs();  // 입력창 클리어

                }


                private void BtnDelete_Click(object sender, EventArgs e)
                {
                    if (isNew == true)     // 신규일 땐 삭제 불가
                    {

                        MessageBox.Show("삭제할 데이터를 선택하세요", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 삭제여부를 물을 때 아니오를 누르면 삭제진행 취소
                    if (MessageBox.Show(this, "삭제하시겠습니까?", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.No) return;


                    // Yes를 누르면 계속 진행   // SaveData() 에 있는 로직 복사 -> 코드 수정해서 사용
                    DeleteData();               // 데이터 삭제처리

                    RefreashData();     // 지우고 나서 재조회
                    ClearInputs();      // 입력창 데이터 지우기

                }

                // 그리드뷰 클릭하면 발생이벤트
                private void DgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
                {
                    if (e.RowIndex > -1)        // 아무것도 선택하지 않으면 -1     //첫번째 선택 인덱스 : 0
                    {
                        var selData = DgvResult.Rows[e.RowIndex];

                        //MessageBox.Show(selData.ToString());    날리기
                        //Debug.WriteLine(selData.ToString());    // Debug로 오픈

                        Debug.WriteLine(selData.Cells[0].Value);
                        Debug.WriteLine(selData.Cells[1].Value);
                        TxtDiv.Text = selData.Cells[0].Value.ToString();        // objct(안에 ToString 듦), 숫자 ---> 문자
                        TxtNames.Text = selData.Cells[1].Value.ToString();
                        TxtDiv.ReadOnly = true;       // PK 바뀌면 안 됨

                        isNew = false;      // 수정
                    }
                }

        #endregion

        #endregion

        #region < 커스텀 메서드 >

        // validation check
        private bool CheckValidation()
        {
            var result = true;
            var errorMsg = string.Empty;


            if (string.IsNullOrEmpty(TxtDiv.Text))
            {
                /*MessageBox.Show("장르코드를 입력하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // 메서드 탈출*/

                result = false;
                errorMsg += "※장르코드를 입력하세요.\r\n";
            }
            if (string.IsNullOrEmpty(TxtNames.Text))
            {
                /*MessageBox.Show("장르명을 입력하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // 메서드 탈출*/

                result = false;
                errorMsg += "※장르명을 입력하세요.\r\n";
            }
            if (result == false)
            {
                MessageBox.Show(errorMsg, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return result;
            }
            else
            {
                return result;
            }
        }

        private void RefreashData()
        {
            // DB divtbl 데이터 조회 -> DgvResult에 뿌림
            try
            {
                //string connectionString = "Server=localhost;Port=3306;Database=bookrentalshop;Uid=root;Pwd=12345";
                using (MySqlConnection conn = new MySqlConnection(Helpers.Commons.ConnStr))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    // 쿼리 작성
                    var selQuery = @"SELECT Division
                                          , Names
                                       FROM divTbl";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(selQuery, conn);    // 통째로 - Adapter
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "divtbl");     // divtbl으로 DataSet 접근가능

                    DgvResult.DataSource = ds.Tables[0];
                    /*DgvResult.DataSource = ds;
                    DgvResult.DataMember = "divtbl";*/

                    DgvResult.Columns[0].HeaderText = "장르코드";
                    DgvResult.Columns[1].HeaderText = "장르명";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"비정상적 오류 : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            TxtDiv.Text = TxtNames.Text = string.Empty;
            TxtDiv.ReadOnly = false;        // 신규일 땐 입력 가능
            isNew = true;   // INSERT - 신규
        }

        // isNew = true INSERT / false UPDATE
        private void SaveData()
        {
            // INSERT부터 시작
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Helpers.Commons.ConnStr))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    // INSERT Query문
                    var query = "";

                    if (isNew)
                    {
                        query = @"INSERT INTO divtbl
	                                      VALUES (@Division, @Names)";
                    }
                    else
                    {
                        query = @"UPDATE divtbl
                                             SET Names = @Names
                                           WHERE Division = @Division";
                    }

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlParameter prmDiv = new MySqlParameter("@Division", TxtDiv.Text);
                    MySqlParameter prmNames = new MySqlParameter("@Names", TxtNames.Text);

                    cmd.Parameters.Add(prmDiv);
                    cmd.Parameters.Add(prmNames);

                    // 입력한 결과 받음
                    var result = cmd.ExecuteNonQuery();     // INSERT, UPDATE, DELETE

                    if (result != 0)
                    {
                        // 저장성공
                        MessageBox.Show("저장완료", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // 저장실패
                        MessageBox.Show("저장실패", "실패", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"비정상적 오류 : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Helpers.Commons.ConnStr))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    // DELETE Query문
                    var query = @"DELETE FROM divtbl
	                                       WHERE Division = @Division";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlParameter prmDiv = new MySqlParameter("@Division", TxtDiv.Text);

                    cmd.Parameters.Add(prmDiv);

                    // 입력한 결과 받음
                    var result = cmd.ExecuteNonQuery();     // INSERT, UPDATE, DELETE

                    if (result != 0)
                    {
                        // 삭제성공
                        MessageBox.Show("삭제완료", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // 삭제실패
                        MessageBox.Show("삭제실패", "실패", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"비정상적 오류 : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion



    }
}
