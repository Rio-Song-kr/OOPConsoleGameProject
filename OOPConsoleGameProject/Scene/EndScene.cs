namespace OOPConsoleGameProject;

public class EndScene : Scene
{
    public override void Render()
    {
        //todo UIManager가 추가되면 UIManager를 이용해서 출력해야 함
        Util.PrintConsole("Congratulation! You escaped!");
        Util.PrintConsole("Press any key to Exit!");
    }

    public override void Input() { GameManager.Input.PressAnyKey(); }

    public override void Update() { }

    public override void Result()
    {
        if (IsFirstLoad)
        {
            GameManager.Instance.GameOver();
            IsFirstLoad = false;
        }
    }
}