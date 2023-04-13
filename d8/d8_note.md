#### NOTE8
## System.IO 네임스페이스의 클래스
    - FileInfo, DirectoryInfo 좀 더 씀
    - File, Directory는 구식 방식(기능적인 차이가 많은 건 아님)
- 상대경로
    - . 현재
    - .. 부모
- (+) 메소드(로컬) 안에서 받을 타입 모를 때 - var(자동으로 스트링 배열로 반환)

## 특정 경로의 하위 폴더 / 하위 파일 조회
    - Directory.GetDirectories(); - 지정된 디렉토리에 있는 하위 디렉토리 이름(경로포함) 반환

- 디렉토리 / 파일 생성
    - 경로가 없으면 둘다 생성
    - 경로가 존재하면 파일만 생성

## 스트림(Stream); 데이터가 흐르는 통로
    - 순차 접근 방식 (ex> 네트워크, 데이터 백업 장치)
    - 임의 접근 방식 (ex> 하드 디스크)


- FileStream 클래스가 일반적
- (+) Truncate - 잘 안 씀

- StreamReader()로 파일 연결
- Readline()으로 읽음
- Writeline()으로 출력
- line = reader.ReadLine();  <- 다음 줄 읽음
- 파일 읽으면 무조건 마지막에 Close();
- StreamWriter()로 파일 생성

# 심플 노트패드 만들기
    - Load / Save
    - Load 파일 경로 출력
    - 파일 전체내용 읽어오기
    
    (+) 처음 쓴 속성변경
    - TabStop False
    - ReadOnly True

    - Flush() <- 버퍼의 데이터를 해당 스트림에 전송
    - Multiselect = false; <- 여러파일 선택 안 되도록


# Book Rental Shop 앱
    - Application.Exit();     // 전체 프로그램 종료
    - Environment.Exit(0);    // 가장 완전하게 프로그램 종료

    - KeyPress 이벤트 핸들러 => 엔터키: KeyChar == 13
        - TxtUserId 텍스트박스 -> TxtPW.Focus();      // 패스워드입력위치로 이동
        - BtnLogin_Click(sender, e);          // 버튼클릭 이벤트핸들러 호출


    - Validation check(입력검증) - 내용이 들어있으면 진행, 아니면 막음

    - DB userTbl에서 정보확인 로그인 처리(로그인) 성공
    - DB 처리 (MySQL 라이브러리 가져다 넣기)
        - NuGet 패키지 - MySQL.Data 다운
        - using MySql.Data.MySqlClient;
    - 쿼리문 작성
        - Send to SQL Editor > Select All Statement > 수정해서 가져옴
        - WHERE절 추가
    - @userId, @pswd 파라미터 할당
  
    - 종료확인 메시지
    ```cs
    private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("종료하시렵니까?", "떼껄룩", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                e.Cancel = false;
                Environment.Exit(0);
            }
            else { e.Cancel = true; }
        }
    ```
