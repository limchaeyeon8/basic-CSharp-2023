using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
            LoadCboData();      // 콤보박스에 들어갈 데이터 로드

            // 출판 일자 수정 (요일 제거)
            DtpReleaseDate.Format = DateTimePickerFormat.Custom;
            DtpReleaseDate.CustomFormat = "yyy-MM-dd";
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

                string strChkQuery = "SELECT COUNT(*) FROM bookstbl WHERE bookIdx = @bookIdx";
                MySqlCommand chkCmd = new MySqlCommand(strChkQuery, conn);
                MySqlParameter prmBookIdx = new MySqlParameter("@bookIdx", TxtBookIdx.Text);
                chkCmd.Parameters.Add(prmBookIdx);

                var result = chkCmd.ExecuteScalar();

                if (result.ToString() != "0")
                {
                    MessageBox.Show("이미 대여중인 책입니다.", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                TxtNames.Text = selData.Cells[2].Value.ToString();
                CboDIviNames.SelectedValue = selData.Cells[3].Value;    // B001 == B001
                DtpReleaseDate.Value = (DateTime)selData.Cells[4].Value;    // as는 null을 허용할 때만 사용가능
                TxtISBN.Text = selData.Cells[5].Value.ToString();
                Price.Text = selData.Cells[6].Value.ToString();

                // 속성에서 바꿈-지우기 //TxtBookIdx.ReadOnly = true;       // PK 바뀌면 안 됨

                isNew = false;      // 수정
            }
        }


        private void DgvResult_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DgvResult.ClearSelection();     // 최초에 첫 번째 열 첫 번째 셸 선택되어있는 것 해제
        }



        #endregion

        #endregion

        #region < 커스텀 메서드 >

        // validation check
        private bool CheckValidation()
        {
            var result = true;
            var errorMsg = string.Empty;


            if (string.IsNullOrEmpty(TxtAuthor.Text))
            {
                /*MessageBox.Show("장르코드를 입력하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // 메서드 탈출*/

                result = false;
                errorMsg += "※저자명을 입력하세요.\r\n";
            }
            if (CboDIviNames.SelectedIndex < 0)
            {
                /*MessageBox.Show("장르명을 입력하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // 메서드 탈출*/

                result = false;
                errorMsg += "※장르를 입력하세요.\r\n";
            }
            if (string.IsNullOrEmpty(TxtNames.Text))
            {
                result = false;
                errorMsg += "※책제목을 입력하세요.\r\n";
            }
            if (DtpReleaseDate.Value == null)
            {
                result = false;
                errorMsg += "※출판일자를 입력하세요.\r\n";
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

                    #region < 데이터그리드뷰 컬럼 헤더 제목 >

                    DgvResult.Columns[0].HeaderText = "도서번호";
                    DgvResult.Columns[1].HeaderText = "저자명";
                    DgvResult.Columns[2].HeaderText = "책제목";
                    DgvResult.Columns[3].HeaderText = "장르";         // 장르코드 -> 장르명
                    DgvResult.Columns[4].HeaderText = "출판일자";
                    DgvResult.Columns[5].HeaderText = "ISBN";
                    DgvResult.Columns[6].HeaderText = "가격";
                    #endregion

                    #region < 컬럼 넓이 / 보이기 여부 >

                    DgvResult.Columns[0].Width = 90;
                    DgvResult.Columns[1].Width = 130;
                    DgvResult.Columns[2].Width = 250;
                    DgvResult.Columns[3].Width = 120;         // 장르코드 -> 장르명
                    DgvResult.Columns[4].Width = 150;
                    DgvResult.Columns[5].Visible = false;     // ISBN 안 보이게     
                    DgvResult.Columns[6].Width = 90;
                    #endregion

                    #region < 컬럼 정렬 >

                    DgvResult.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    DgvResult.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    DgvResult.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


                    #endregion
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
            //TxtBookIdx.ReadOnly = false;        // 신규일 땐 입력 가능
            
            // 신규버튼 - 초기화
            TxtNames.Text = TxtISBN.Text = string.Empty;
            DtpReleaseDate.Value = DateTime.Now;        // 오늘날짜로 초기화
            Price.Value = 0;
            TxtBookIdx.Focus();

            TxtAuthor.Focus();      // 번호는 입력 안 함

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
                        query = @"INSERT INTO bookstbl
                                     ( Author
                                     , Division
                                     , Names
                                     , ReleaseDate
                                     , ISBN
                                     , Price)

                                VALUES
                                     ( @Author
                                     , @Division
                                     , @Names
                                     , @ReleaseDate
                                     , @ISBN
                                     , @Price)";
                    }
                    else
                    {
                        query = @"UPDATE bookstbl
                                     SET Author = @Author
	                                   , Division = @Division
                                       , Names = @Names
                                       , ReleaseDate = @ReleaseDate
                                       , ISBN = @ISBN
                                       , Price = @Price
                                   WHERE bookIdx = @bookIdx";
                    }

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    // 파라미터 6개 추가
                    MySqlParameter prmAuthor = new MySqlParameter("@Author", TxtAuthor.Text);
                    MySqlParameter prmNames = new MySqlParameter("@Names", TxtNames.Text);
                    MySqlParameter prmDivision = new MySqlParameter("@Division", CboDIviNames.SelectedValue.ToString());
                    MySqlParameter prmReleaseDate = new MySqlParameter("@ReleaseDate", DtpReleaseDate.Value);
                    MySqlParameter prmISBN = new MySqlParameter("@ISBN", TxtISBN.Text);
                    MySqlParameter prmPrice = new MySqlParameter("@Price", Price.Value);

                    cmd.Parameters.Add(prmAuthor);
                    cmd.Parameters.Add(prmNames);
                    cmd.Parameters.Add(prmDivision);
                    cmd.Parameters.Add(prmReleaseDate);
                    cmd.Parameters.Add(prmISBN);
                    cmd.Parameters.Add(prmPrice);

                    if (isNew == false) // update할 때 bookIdx 파라미터 꼬!!!!!추가!!!
                    {
                        MySqlParameter prmBookIdx = new MySqlParameter("@bookIdx", TxtBookIdx.Text);
                        cmd.Parameters.Add(prmBookIdx);
                    }

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
                    var query = @"DELETE FROM bookstbl
	                                       WHERE bookstbl = @bookstbl";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlParameter prmBookstbl = new MySqlParameter("@bookstbl", TxtBookIdx.Text);

                    cmd.Parameters.Add(prmBookstbl);

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

        // 콤보박스에 들어갈 데이터 로드
        private void LoadCboData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Commons.ConnStr))
                {
                    if (conn.State == ConnectionState.Closed) { conn.Open(); }
                    var query = "SELECT Division, Names FROM divtbl";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    var temp = new Dictionary<string, string>();
                    while (reader.Read())
                    {
                        temp.Add(reader[0].ToString(), reader[1].ToString());      // (Key)B001, (Value)공포.스릴러
                    }

                    // 콤보박스에 할당
                    CboDIviNames.DataSource = new BindingSource(temp, null);        // divtbl은 null
                    CboDIviNames.DisplayMember = "Value";
                    CboDIviNames.ValueMember = "Key";
                    CboDIviNames.SelectedIndex = -1;

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
