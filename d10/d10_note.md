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

### 프로젝트 복제 [FrmBooks.cs]
- 복붙 -> F2; 이름변경
- 세 군데 직접 변경
    - FrmBooks.cs - 파셜 클래스명 / 생성자 퍼블릭
    - FrmBooks.Designer.cs - 파셜 클래스명
- 다시 빌드 (NuGet 참조 다시 설치하지 않아도 됨)

- private void RefreashData()
    - 쿼리 변경 ( bookstbl; Select All Statement에서 추출 )
    - bookstbl 데이터셋 접근 - adapter.Fill(ds, "bookstbl");  <--  복제해온 adapter.Fill(ds, "divstbl"); 에서 변경
    - 

#### 추가한 도구
- ComboBox       - 장르 선택
- DateTimePicker - 출간일자 지정
- NumericUpdown  - 가격 입력

