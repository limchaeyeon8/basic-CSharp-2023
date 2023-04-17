#### NOTE10


- 로그인 사용자 아이디 저장 변수  -  프로그램 전체에서 이 데이터를 공유
```cs
public static string LoginId = string.Empty;
```

[FrmGen - FK 제약조건으로 지울 수 없는 데이터인지 먼저 확인]
- namespace 참조
```cs
using wf13_bookrentalshop.Helpers;
```
- ExecuteScalar() - 쿼리에 컬럼 하나
    - (+)쿼리에 컬럼 여러개면 ExcuteReader()
```cs
    using (MySqlConnection conn = new MySqlConnection(Commons.ConnStr))     // Helpers.Commons.ConnStr 에서 Helpers 생략가능
    {
        if (conn.State == ConnectionState.Closed) conn.Open();

        string strChkQuery = "SELECT COUNT (*) FROM bookstbl WHERE Division = @Division";
        MySqlCommand chkCmd = new MySqlCommand(strChkQuery, conn);
        MySqlParameter prmDivision = new MySqlParameter("@Division", TxtDiv.Text);
        chkCmd.Parameters.Add(prmDivision);

        var result = chkCmd.ExecuteScalar();

        if (result.ToString() != "0")
        {
            MessageBox.Show("이미 사용중인 코드입니다.", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
    }
```
