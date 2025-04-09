namespace OOPConsoleGameProject;

class Program
{
    static void Main(string[] args)
    {
        GameManager gameManager = GameManager.Instance;
        gameManager.Run();
    }
}

//! 기본
//~ 1. GameManager
//~    1-1. Scene 전환
//~    1-2. Render, Input, Update, Result를 실행
//todo 상세한 Scene의 구성(텍스트, 오브젝트 배치 등)은 기본 기능 설계 후 수정
//# 2. Scene 구성
//#    2-1. 상호작용 가능한 요소(아이템, 던전 입구, 문 등)
//~         a. 우선적으로 맵 이동을 위한 Object를 먼저 생성
//#         b. 던전에서 사용할 Rock, Goal 구현
//#         c. 플레이어가 획득할 수 있는 Navigation, Letter, Key, MusicBox 구현
//~             ㄴ 열쇠
//~             ㄴ Letter
//#             ㄴ MusicBox
//#             ㄴ Navigation
//~    2-2. StartScene 클래스
//~    2-3. EndScene 클래스
//~    2-4. Scene 클래스
//~         1) Level 클래스
//#         2) Dungeon 클래스
//#    2-5. 시작화면 - Level 씬 사이 중간 씬
//# 3. UI 구성
//#    3-1. UIManager
//~ 4. Player
//# 5. 입력
//~    5-1. 모든 입력은 InputManager가 관리
//#    5-2. 각 Scene의 Input은 InputManager의 결과를 체크
//~    5-3. Player 등은 InputManager의 event를 구독
//~    5-4. PressAnyKey 추가
//# 6. Inventory
//~    6-1. 아이템 추가(최대 3개)
//#    6-2. UI 출력(UIManager를 통해 출력)
//# 7. Test를 위한 Render와 Update
//~    7-1. 맵에서 플레이어가 이동(기존 소코반 방식)
//~ 8. 추가사항
//~    8-1. SceneManager 추가

//! 응용
//# 2. Scene 구성
//#    2-1. Scene 클래스
//~         1) 세부 LevelScene
//~            (1) LevelScene_xx 클래스
//#         2) 세부 Dungeon 클래스
//#            (1) DungeonScene_xx 클래스
//#            (2) Map과 Object의 위치는 수동 지정
//#            (3) 소코반
//# 3. Player
//#    3-1. Interaction
//# 4. Inventory
//#    4-1. 아이템 선택(정보 보기)
//#         1) 열쇠 - 정보출력
//#         2) 편지 - 힌트 출력
//#         3) 뮤직박스 - 음 재생
//#    4-2. 아이템 사용
//#         1) 네비게이션
//# 5. GameObject
//#    5-1. 상자
//#         1) 편지 또는 뮤직박스의 힌트로 문제를 풀면 열쇠를 획득할 수 있음
//#    5-2. 돌
//#         1) 던전의 소코반에서 사용하는 돌
//#    5-3. Goal
//#         1) 던전의 소코반에서 돌이 올라갈 자리
//#         2) 모든 자리에 돌이 올라가면 열쇠를 얻을 수 있으며, 이전 맵으로 이동
//# 6. Item
//~    6-1. 열쇠
//#         1) 단순한 열쇠에 대한 정보 출력
//#    6-2. 편지
//#         1) 상자를 열기 위한 힌트 제공
//# 7. Place
//~    7-1. 던전
//#         1) 열쇠를 얻기 위해 던전 맵으로 이동
//~    7-2. 문
//~         1) 열쇠를 가지고 있는 상태에서만 겹쳐서 탈출이 가능함
//# 8. Render
//#    8-1. 플레이어는 중심에 고정되고, 이동 시 맵이 이동됨

//! 도전
//# 2. Scene 구성
//#    2-1. Scene 클래스
//#         (1) Map 자동 생성(미로 생성 알고리즘)
//# 3. Player
//#    3-1. 플레이어가 지나간 길을 별도 표시(되돌아가면 지워짐)
//# 4. Log
//#    4-1. 아이템 획득, 인벤토리 열기(정보보기), 힌트 사용, 열쇠 획득 여부 등의 정보 출력
//#    4-2. UI 출력(UIManager를 통해 출력)
//#    4-3. a가 발생할 때 호출될 수 있도록 함(싱글톤 또는 static으로 선언)
//# 5. Item
//#    5-1. 뮤직박스
//#         1) 상자를 열기 위한 힌트(음) 제공
//#    5-2. 네비게이션
//#         1) 아이템 사용 시 현재 플레이어의 위치로부터 출구(문)의 길을 안내(길찾기 알고리즘)
//# 6. Render
//#    6-1. 레벨에 따라 표시되는 시야 가변
//#         1) Level1 - 5x5
//#         2) Level2 - 4x4
//#         3) Level3 - 3x3