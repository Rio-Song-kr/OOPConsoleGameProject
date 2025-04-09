namespace OOPConsoleGameProject;

public class StartScene : Scene
{
    public override void Render()
    {
        GameManager.Scene.PrintText(new string[]
        {
            "미로 탈출 게임!",
            "조작키 : ↑, ←, ↓, →",
            "아이템 정보 보기 : 1, 2, 3",
            "아이템 사용 : U",
            "게임을 시작하려면, 아무 키나 누르세요."
        }, false);
    }

    public override void Input() { GameManager.Input.PressAnyKey(); }

    public override void Update() { }

    public override void Result() { GameManager.Scene.Move(SceneName.Level01); }
}