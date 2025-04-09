namespace OOPConsoleGameProject;

public class EndScene : Scene
{
    private bool _isCalledRender = false;
    public override void Render()
    {
        GameManager.Scene.PrintText(new string[]
        {
            "축하합니다 !",
            "탈출에 성공하였습니다!",
            "게임을 종료하려면, 아무 키나 누르세요."
        }, false);

        _isCalledRender = true;
    }

    public override void Input() { GameManager.Input.PressAnyKey(); }

    public override void Update() { }

    public override void Result()
    {
        if (_isCalledRender)
            GameManager.Instance.GameOver();
    }

    public override void OnEnter() { IsFirstLoad = true; }
}