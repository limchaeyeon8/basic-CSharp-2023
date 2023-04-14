#### NOTE9

## 프로세스 스레드

### 프로세스; 실행 파일이 실행되어 메모리에 적재된 인스턴스
    - 하나 이상의 스레드로 구성
    - 하위 프로세스(추가프로세스) 있는 경우도 있음

### 스레드; 운영체게가 CPU 시간을 할당하는 기본 단위
    - 여러가지를 동시에

#### 멀티 스레드 
    - IPC 통한 프로세스 간의 데이터 교환 (IPC Request / IPC Response)
    - 변수를 이용한 스레드 간의 데이터 교환

    - 장점
        - 사용자 대화형 프로그램에서 응답성 높일 수
        - 경제성 => 메모리, 자원 할당하는 비용 절감
        - 멀티 프로세스 방식에 비해 멀티 스레드 방식이 자원 공유가 쉬움

    - 단점
        - 구현하기 까다롭고 테스트가 쉽지 않음
        - 과다한 사용은 성능 저하 야기 => 작업간 전환 (Contaext Switching)
        - 자식 스레드의 문제가 생기면 전체 프로세스에 영향을 끼침

- 스레드 상태변환
    - Start 
    - Aborted
    - Suspended

# Background Worker Test - WinForms

- 도구상자 > 구성요소 > BackgroundWorker
    - 스레드를 직접 만들지 않아도 됨
    - 도구상자 안 써도 코드에서 입력해서 사용은 가능

- 이벤트 생성 
    - DoWork             - 백그라운드로 일 진행 / Thread.Start()
    - ProgressChanged    - 백그라운드 스레드 테스크 종료한 뒤 처리
    - RunWorkerCompleted - 백그라운드 스레드 진행 중 일어나는 일을 프로그래스바에 값 할당하여 표시

### BackgroundWorker

- (+)
    - 컨트롤 잠그기 - 디자인 도구 추가만 가능, 안 움직임
    - Text Align - 숫자는 Right 권장


## Task / Task<TResult>
- 멀티 코어 시대 고성능 소프트웨어 개발
    - 병렬 처리 기법 / "비동기" 처리 기법
- MS의 대응
    - .NET 프레임워크 4.0
    - System, Threading.tasks 네임스페이스
    - -> Task, Task<TResult>, Parrallel 클래스

    - 병렬처리하는 Parallel 병렬컴퓨팅 클래스; 빠르지만 틀어지면 문제,,
    - 동시에 4개정도까지의 프로세스들 동시에 빠르게 처리 가능
    - 일반적일 땐  foreach 사용하고 빠르게 끝낼 땐 Parallel

## 동기 코드 / 비동기 코드
- 동기 코드   : 메소드 호출 후 시행이 종료 (반환)돼야 다음 메소드 호출
- 비동기 코드 : 메소드 호출 후 종료를 기다리지 않고 다음 코드 실행

## async 한정자 / Await 연산자
- 메서드,로직들 비동기식으로 Await
- 비동기 메소드 안에 항상 Await 있어야 함
- await 연산자가 없이 비동기로 실행하는 경우는 거의 없음
- 비동기로 할 때는 async, await O / async가 있으면 await 꼭 있어야 함
- 동기로 할 때는 async, await X

### async; 메소드나 테스크 수식하기만 함녀 비동기 코드 생성 / 메소드, 이벤트 처리기, 테스크, 람다식, ... 수식
- void; 실행하고 잊어버릴 작업 담고 있는 메소드           |    async void
- Task, Task<Tresult>; 작업 완료될 때까지 기다리는 메소드 |    async Task, Task<TResult>


## 가비지컬렉터
- ? 프로그래머가 쉽게 저지르는 실수 - 해제한 메모리 액세스
- 메모리 관리의 실수를 줄이기 위한 C#의 해결책
    - 자동 메모리 관리 기능 => 가비지 컬렉션 ( 쓰레기 수거 ) - 가비지 컬렉터가 담당
- 가비지 컬렉터 = 소프트웨어
    - 컴퓨팅 자원을 사용
    - 최소한의 자운 사용 추구
    → 가비지 컬렉터의 동작 메커니즘 이해 필요
    → 그에 따른 코딩 가이드 라인 수립

- 주의
    - 가비지 컬렉션 매커니즘의 이해를 바탕으로 적절한 작전 수립
    - 객체를 너무 많이 할당하지 X
        - 관리되고 있는 힙의 각 세대에 메모리 포화 초래 -> 빈번한 컬렉션 호출 -> X
    - 너무 큰 객체 할당 X
        - 대형 객체 힙 : LOH / 소형 객체 힙 : SOH
        - 대형 객체 핑은 할당 시의 성능과 메모리 공간 효율 ↓
        - LOH는 2세대 힙으로 간주 -> 전 세대에 가비지 컬렉션 촉발 -> 일시적 중지
    - 너무 복잡한 참조 관계는 만들지 X
        - 참조 관계가 많은 객체는 가비지 컬렉션 후에 살아남았을 때 문제
        - 객체의 각 필드 간 참조 관계 모두 조사 / 참조하는 메모리 주소 모두 수정
        - 가비지 컬렉션을 회피하기 위해 오버헤드가 큰 쓰기 장벽 생성 문제
    - 루트 많이 만들지 X
        - 루트 목록이 작을 수록 컬렉터 검사 횟수 ↓ => 가비지 컬렉션 더 빨리 끝냄

# Book Rental Shop
- (+) readonly; 한 번 만들면 수정 불가
- MySql 연결 프로그래밍 
    - 기존 방법
```cs
string connectionString = "Server=localhost;Port=3306;Database=bookrentalshop;Uid=root;Pwd=12345";
MySqlConnection conn = new MySqlConnection("");
conn.Open();
conn.Close();
```
    - wf13_bookrentalshop > 폴더 Helpers 생성 > Commons 클래스 생성
    - 프로그생상에서 전체 사용 가능
    - readonly; 한번 만들면 수정불가
    - DB 연결문자열은 여기서만 수정하면 됨
```cs
    namespace wf13_bookrentalshop.Helpers   
{
    internal class Commons
    {
        public static readonly string ConnStr = "Server=localhost;" + 
                                                "Port=3306;" + 
                                                "Database=bookrentalshop;" + 
                                                "Uid=root;" +
                                                "Pwd=12345";
    }
}
```
```cs
using (MySqlConnection conn = new MySqlConnection(Helpers.Commons.ConnStr))
{
    if (conn.State == ConnectionState.Closed) conn.Open();
    // Query 작성~~~
}
```
    - RefreashData(), SaveData(), DeleteData() 에서 사용