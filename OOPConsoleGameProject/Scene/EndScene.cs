namespace OOPConsoleGameProject;

public class EndScene : Scene
{
    public override void Render()
    {
        //todo 추후 End 화면에 맞게 수정 및 UIManager로 렌더링은 위임
        Util.PrintConsole("Congratulation! You escaped!");
        Util.PrintConsole("Press any key to Exit!");
    }

    public override void Input() { GameManager.Input.PressAnyKey(); }

    public override void Update() { }

    public override void Result() { GameManager.Instance.GameOver(); }
}