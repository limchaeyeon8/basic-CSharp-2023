# basic-CSharp-2023
IoT 개발자 과정 C# 학습 리포지토리

## 1일차
#### [note1](https://github.com/limchaeyeon8/basic-CSharp-2023/blob/main/d1/d1_note.md)

-  C# 기본
    - .NET Framework / .NET 5.0 이후
    - Visual Studio상 C# 구성
    - 기본 문법


## 2일차
#### [note2](https://github.com/limchaeyeon8/basic-CSharp-2023/blob/main/d2/d2_note.md)

- C# 기본
    - 기본 문법 (변수, 메소드, 연산자, 제어)

- Win App
    - WinForms vs WPF 개요
    - WinForms 기초


## 3일차
#### [note3](https://github.com/limchaeyeon8/basic-CSharp-2023/blob/main/d3/d3_note.md)

- C# 기본
    - 클래스

- Win App
    - WinForms 컨트롤
    - 리스트뷰, 데이터그리드 추가학습 요

3일차 윈폼 학습 결과

<img src="https://raw.githubusercontent.com/limchaeyeon8/basic-CSharp-2023/main/d3/d3WinApp/wf03_property/wifm1.png" width="700">
    

## 4일차
#### [note4](https://github.com/limchaeyeon8/basic-CSharp-2023/blob/main/d4/d4_note.md)

- C# 기본
    - 클래스 상속 계속
    - 인터페이스 *
- Win App
    - WinForms 컨트롤 마무리
    - WinForms 예제 실습


## 5일차
#### [note5](https://github.com/limchaeyeon8/basic-CSharp-2023/blob/main/d5/d5_note.md)

- C# 기본
    - 인터페이스 / 추상클래스
    - 프로퍼티
- Win App
    - WinForms 디자인 오류시 해결방법
    - Window 탐색기 만들기

5일차 탐색기 만들기 WIP


## 6일차
#### [note6](https://github.com/limchaeyeon8/basic-CSharp-2023/blob/main/d6/d6_note.md)

- C# 기본
    - 컬렉션
    - 일반화(Generic) 프로그래밍
    - 예외처리

- Win App
    - 탐색기 마무리
        - 추가개발 리스트
            - 컨텍스트 메뉴 (마우스 오른쪽 메뉴)
            - 보호된 운영체제 폴더 숨기기
            - 리스트뷰 폴더 더블클릭 시, 하위폴더 표시
    - DB 핸들링


## 7일차
#### [note7](https://github.com/limchaeyeon8/basic-CSharp-2023/blob/main/d7/d7_note.md)

- C# 기본
    - 대리자 / 이벤트
    - 람다식
    - 애트리뷰트
    - 파일 핸들링
    - 더 공부해야 할 내용 - LINQ, Reflection, Dynamic

- Win App
    - DB 핸들링
    - SDI / MDI


## 8일차 
<!--
#### [note8](https://github.com/limchaeyeon8/basic-CSharp-2023/blob/main/d8/d8_note.md)
-->
- C# 기본
    - 파일 핸들링
    - 스레드 / 테스크
    - 가비지 컬렉션

- Win App
    - 메모장 만들기
    - BookRentalShop DB 사용 WinForms 앱개발


#### NOTE8
- System.IO 네임스페이스의 클래스
    - FileInfo, DirectoryInfo 좀 더 씀
    - File, Directory는 구식 방식(기능적인 차이가 많은 건 아님)
- 상대경로
    - . 현재
    - .. 부모
- (+) 메소드(로컬) 안에서 받을 타입 모를 때 - var(자동으로 스트링 배열로 반환)

- 특정 경로의 하위 폴더 / 하위 파일 조회
    - Directory.GetDirectories(); - 지정된 디렉토리에 있는 하위 디렉토리 이름(경로포함) 반환

- 디렉토리 / 파일 생성
    - 경로가 없으면 둘다 생성
    - 경로가 존재하면 파일만 생성

- 스트림(Stream); 데이터가 흐르는 통로
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

- 심플 노트패드 만들기
    - Load / Save
    - Load 파일 경로 출력
    - 파일 전체내용 읽어오기
    
    (+) 처음 쓴 속성변경
    - TabStop False
    - ReadOnly True

    - Flush() <- 버퍼의 데이터를 해당 스트림에 전송
    - Multiselect = false; <- 여러파일 선택 안 되도록


- Book Rental Shop 앱
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
    '''
    private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("종료하시렵니까?", "떼껄룩", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                e.Cancel = false;
                Environment.Exit(0);
            }
            else { e.Cancel = true; }
    '''