#### NOTE6

- using System.Collections;
- 컬렉션 초기화 방법
    - 1. 배열 통한 초기화
        - ArrayList, Queue, Stack
    - 2. 직접 컬렉션 초기자로 초기화(배열 도움X)
        - ArrayList, Hashtable
        - 컬렉션 초기자 - IEnumerable과 Add()를 구현한 컬렉션만 지원
    - 3. 딕셔너리 초기자를 이용한 초기화
        - Hashtable

- foreach가 가능한 객체 생성
    - foreach는 IEnumerable과 IEnumerator를 상속하는 형식만 지원

- IEnumerable의 유일한 메소드 : GetEnumerator()
    - 구현 시 yield return문 필요
    - IEnumerator 형식의 객체 반환

    - yield 특징
        - 메소드를 빠져나가지 않고 값만 돌려줌
        - return과 달리 보내주고 멈춰 있음

- IEnumerator 인터페이스의 메소드 및 프로퍼티 목록
    - boolean MoveNext(): 다음 요소로 이동 / true, false 반환
    - void Reset(): 컬렉션의 첫 번째 위치의 "앞"으로 이동 / 첫 번째 위치가 0번이라면 -1번으로 이동 / <-MoveNext() 호출 뒤 이동됨
    - object Current { get; }: 컬렉션의 현재 요소 반환

- 일반화; 특수한 개념으로부터 공통된 개념을 찾아 묶는 것
- 일반화 프로그래밍; 일반화의 대상 => 데이터 형식
    - 오버로딩 없이 모든 형식을 지원하는 프로그래밍 패러다임
- 일반화 메소드; 데이터 형식을 일반화한 메소드
- 일반화 클래스; 데이터 형식을 일반화한 클래스
    - 선언형식: class 클래스명 <형식 매개변수>

    - 클래스 일반화 단계
        - 데이터 형식은 다르나 기능은 같은 클래스
        - 형식 매개 변수를 이용해 일반화 클래스로 개선
        - 객체 생성시 입력 받은 형식으로 치환

- 형식 매개 변수 제약시키기; 특정조건을 갖춘 형식에만 대응하는 형식 매개변수로 제한
    - 형식 제약 문법 (형식) - [where 형식매개변수 : 제약조건]
                                                    ((T는,,))
        - where T : struct                      - 값 형식
        - where T : class                       - 참조 형식
        - where T : new()                       - 반드시 매개 변수가 없는 생성자가 있어야 함
        - where T : 기반_클래스_이름            - 명시한 기반 클래스의 파생 클래스여야 함
        - where T : 인터페이스_이름             - 명시한 인터페이스를 반드시 구현해야 함 / 인터페이스이름에는 여러 개의 인터페이스를 명시 가능
        - where T : U                           - 또 다른 형식 매개변수 U로부터 상속받은 클래스여야 함

- 일반화 컬렉션; [object 형식에 기반 => 태생적 성능 문제 내포]하는 컬렉션을 일반화 컬렉션으로 해결
    - 컴파일 시 컬렉션에서 사용할 형식 결정
    - 잘못된 형식의 객체를 담게 될 위험 회피
-  System.Collections.Generic 네임스페이스
    - List<T>   비일반화 클래스 ArrayList와 동일한 기능&사용법
        - 차이점: 인스턴스 생성시 형식매개변수 필요 / 형식매개변수로 입력한 형식 외에는 입력 허용X
    - Queue<T>  비일반화 클래스 Queue와 동일한 기능
        - 사용법 상의 차이점: 형식매개변수 요구
    - Stack<T>  비일반화 클래스 Stack과 동일한 기능
        - 사용법 상의 차이점: 형식매개변수 요구
    - Dictionary<TKey, TValue> Hashtable의 일반화 버전
        - 사용법 상의 차이점: 2개의 형식매개변수 요구 / TKey는 Key, TValue는 Valu를 위한 형식
    - (+) 일반화 List<T> 제일 많이 사용 -> 일반화 Dictionary<T> 그 다음으로 많이 사용

- foreach 사용 가능한 일반화 클래스
    - IEnumerable과 IEnumerator 상속 구현 => 성능 저하
        - 일반화 클래스를 foreach에 사용 할 경우
        -> IEnumerable<T>, IEnumerator<T> 구현


DB연동
- SSMS SQL Server
- Data Grid View 컨트롤
- 데이터 소스 구성 마법사에서 SQL 서버로부터 (혹은 다른 데이터 소스 사용) 테이블에 대한 DataSet 생성