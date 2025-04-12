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
//~ 2. Scene 구성
//~    2-1. 상호작용 가능한 요소(아이템, 던전 입구, 문 등)
//~         a. 우선적으로 맵 이동을 위한 Object를 먼저 생성
//~         b. 던전에서 사용할 Rock, Goal 구현
//~         c. 플레이어가 획득할 수 있는 Navigation, Letter, Key, MusicBox 구현
//~             ㄴ 열쇠
//~             ㄴ Letter
//~             ㄴ MusicBox
//~             ㄴ Navigation
//~    2-2. StartScene 클래스
//~    2-3. EndScene 클래스
//~    2-4. Scene 클래스
//~         1) Level 클래스
//~         2) Dungeon 클래스
//~    2-5. 시작화면 - Level 씬 사이 중간 씬
//~ 3. UI 구성
//~    3-1. UIManager
//~ 4. Player
//~ 5. 입력
//~    5-1. 모든 입력은 InputManager가 관리
//~    5-2. 각 Scene의 Input은 InputManager의 결과를 체크
//~    5-3. Player 등은 InputManager의 event를 구독
//~    5-4. PressAnyKey 추가
//~ 6. Inventory
//~    6-1. 아이템 추가(최대 3개)
//~    6-2. UI 출력(UIManager를 통해 출력)
//~ 7. Test를 위한 Render와 Update
//~    7-1. 맵에서 플레이어가 이동(기존 소코반 방식)
//~ 8. 추가사항
//~    8-1. SceneManager 추가

//! 응용
//~ 2. Scene 구성
//~    2-1. Scene 클래스
//~         1) 세부 LevelScene
//~            (1) LevelScene_xx 클래스
//~         2) 세부 Dungeon 클래스
//~            (1) DungeonScene_xx 클래스
//~            (2) Map과 Object의 위치는 수동 지정
//~            (3) 소코반
//~ 3. Player
//~    3-1. Interaction
//~ 4. Inventory
//~    4-1. 아이템 선택(정보 보기)
//~         1) 열쇠 - 정보출력
//~         2) 편지 - 힌트 출력
//~         3) 뮤직박스 - 음 재생
//todo 시간 부족으로 해당 기능은 제출 후 주말에 구현
//# 5. GameObject
//~    5-1. 상자
//#         1) 편지 또는 뮤직박스의 힌트로 문제를 풀면 열쇠를 획득할 수 있음
//#            ㄴ 편지와 상호작용하는 상자, 뮤직박스와 상호작용하는 상자가 필요함
//#            ㄴ 정답을 입력해야 하기에 상호작용이 가능한 UI를 구현해야 함
//~    5-2. 돌
//~         1) 던전의 소코반에서 사용하는 돌
//~    5-3. Goal
//~         1) 던전의 소코반에서 돌이 올라갈 자리
//~         2) 모든 자리에 돌이 올라가면 열쇠를 얻을 수 있으며, 이전 맵으로 이동
//~ 6. Item
//~    6-1. 열쇠
//~         1) 단순한 열쇠에 대한 정보 출력
//~    6-2. 편지
//~         1) 상자를 열기 위한 힌트 제공
//# 7. Place
//#    7-1. 던전
//#         1) 열쇠를 얻기 위해 던전 맵으로 이동
//~    7-2. 문
//~         1) 열쇠를 가지고 있는 상태에서만 겹쳐서 탈출이 가능함
//~ 8. Render
//~    8-1. 플레이어는 중심에 고정되고, 이동 시 맵이 이동됨

//! 도전
//~ 2. Scene 구성
//~    2-1. Scene 클래스
//~         (1) Map 자동 생성(미로 생성 알고리즘)
//~ 3. Player
//~    3-1. 플레이어가 지나간 길을 별도 표시(되돌아가면 지워짐)
//~ 4. Log
//~    4-1. 아이템 획득, 인벤토리 열기(정보보기), 열쇠 획득 여부 등의 정보 출력
//~          (1) 아이템 획득
//~          (2) 인벤토리 열기(정보보기)
//~          (3) 열쇠 획득 여부
//~    4-2. UI 출력(UIManager를 통해 출력)
//~ 5. Item
//~    5-1. 뮤직박스
//~         1) 상자를 열기 위한 힌트(음) 제공
//~    5-2. 내비게이션
//~         1) 아이템 사용 시 플레이어의 시작 위치부터 현재 플레이어의 현재 위치 전까지 지나온 길을 표시함
//~    5-3. Key 또는 던전 입구 Random하게 배치될 수 있도록 변경(벽이 아닐 때 배치)
//~ 6. Render
//~    6-1. 레벨에 따라 표시되는 시야 가변
//~         1) e.g. Level1 - 5x5
//~         2) e.g. Level2 - 4x4
//~         3) e.g. Level3 - 3x3