namespace OOPConsoleGameProject;

public class StartScene : Scene
{
    public override void Render()
    {
        //todo UIManager가 추가되면 UIManager를 이용해서 출력해야 함
        Util.PrintConsole("Welcome to Escape Game!");
        Util.PrintConsole("Press any key to start!");
    }

    public override void Input() { GameManager.Input.PressAnyKey(); }

    public override void Update() { }

    public override void Result() { GameManager.Scene.Move(SceneName.Level01); }
}