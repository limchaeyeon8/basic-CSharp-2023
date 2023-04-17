﻿using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using wf13_bookrentalshop.Helpers;

namespace wf13_bookrentalshop
{
    public partial class FrmBooks : Form
    {

        bool isNew = false;     // false(UPDATE) / true(INSERT)


        #region < 생성자 >
        public FrmBooks()
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

            // FK 제약조건으로 지울 수 없는 데이터인지 먼저 확인
            using (MySqlConnection conn = new MySqlConnection(Commons.ConnStr))
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                string strChkQuery = "SELECT COUNT(*) FROM bookstbl WHERE Division = @Division";
                MySqlCommand chkCmd = new MySqlCommand(strChkQuery, conn);
                MySqlParameter prmDivision = new MySqlParameter("@Division", TxtBookIdx.Text);
                chkCmd.Parameters.Add(prmDivision);

                var result = chkCmd.ExecuteScalar();

                if (result.ToString() != "0")
                {
                    MessageBox.Show("이미 사용중인 코드입니다.", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }


            // 삭제여부를 물을 때 아니오를 누르면 삭제진행 취소
            if (MessageBox.Show(this, "삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;


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
                TxtBookIdx.Text = selData.Cells[0].Value.ToString();        // objct(안에 ToString 듦), 숫자 ---> 문자
                TxtAuthor.Text = selData.Cells[1].Value.ToString();
                TxtBookIdx.ReadOnly = true;       // PK 바뀌면 안 됨

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


            if (string.IsNullOrEmpty(TxtBookIdx.Text))
            {
                /*MessageBox.Show("장르코드를 입력하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // 메서드 탈출*/

                result = false;
                errorMsg += "※장르코드를 입력하세요.\r\n";
            }
            if (string.IsNullOrEmpty(TxtAuthor.Text))
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
                    var selQuery = @"SELECT b.bookIdx
                                          , b.Author
                                          , b.Names
                                          , d.Names AS DivNames
                                          , b.ReleaseDate
                                          , b.ISBN
                                          , b.Price
                                       FROM bookstbl AS b
                                      INNER JOIN divtbl AS d
                                         ON b.Division = d.Division
                                      ORDER BY b.bookIdx ASC";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(selQuery, conn);    // 통째로 - Adapter
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "bookstbl");     // bookstbl DataSet 접근가능

                    DgvResult.DataSource = ds.Tables[0];
                    /*DgvResult.DataSource = ds;
                    DgvResult.DataMember = "divtbl";*/

                    DgvResult.Columns[0].HeaderText = "도서번호";
                    DgvResult.Columns[1].HeaderText = "저자명";
                    DgvResult.Columns[2].HeaderText = "책제목";
                    DgvResult.Columns[3].HeaderText = "장르";         // 장르코드 -> 장르명
                    DgvResult.Columns[4].HeaderText = "출판일자";
                    DgvResult.Columns[5].HeaderText = "ISBN";
                    DgvResult.Columns[6].HeaderText = "가격";


                    DgvResult.Columns[0].Width = 90;
                    DgvResult.Columns[1].Width = 130;
                    DgvResult.Columns[2].Width = 250;
                    DgvResult.Columns[3].Width = 120;         // 장르코드 -> 장르명
                    DgvResult.Columns[4].Width = 150;
                    DgvResult.Columns[5].Visible = false;     // ISBN 안 보이게     
                    DgvResult.Columns[6].Width = 90;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"비정상적 오류 : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            TxtBookIdx.Text = TxtAuthor.Text = string.Empty;
            TxtBookIdx.ReadOnly = false;        // 신규일 땐 입력 가능
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
                    MySqlParameter prmDiv = new MySqlParameter("@Division", TxtBookIdx.Text);
                    MySqlParameter prmNames = new MySqlParameter("@Names", TxtAuthor.Text);

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
                    MySqlParameter prmDiv = new MySqlParameter("@Division", TxtBookIdx.Text);

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
