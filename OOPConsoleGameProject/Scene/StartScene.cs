namespace OOPConsoleGameProject;

public class StartScene : Scene
{
    public override void Render()
    {
        //todo 추후 Start 화면에 맞게 수정 및 UIManager로 렌더링은 위임
        Util.PrintConsole("Welcome to Escape Game!");
        Util.PrintConsole("Press any key to start!");
    }

    public override void Input() { GameManager.Input.PressAnyKey(); }

    public override void Update() { }

    public override void Result() { GameManager.Scene.Move(SceneName.Level01); }
}