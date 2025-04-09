namespace OOPConsoleGameProject;

public class StartScene : Scene
{
    public override void Render()
    {
        //todo UIManager가 추가되면 UIManager를 이용해서 출력해야 함
        GameManager.UI.PrintTextAtCenter(new string[]
        {
            "미로 탈출 게임!",
            "게임을 시작하려면, 아무 키나 누르세요"
        }, false);
    }

    public override void Input() { GameManager.Input.PressAnyKey(); }

    public override void Update() { }

    public override void Result() { GameManager.Scene.Move(SceneName.Level01); }
}