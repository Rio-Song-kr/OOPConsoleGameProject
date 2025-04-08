namespace OOPConsoleGameProject;

class Program
{
    static void Main(string[] args)
    {
        GameManager gameManager = new GameManager();
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
//#    6-1. 아이템 추가(최대 3개)
//#    6-2. UI 출력(UIManager를 통해 출력)
//# 7. Test를 위한 Render와 Update
//~    7-1. 맵에서 플레이어가 이동(기존 소코반 방식)
//~ 8. 추가사항
//~    8-1. SceneManager 추가