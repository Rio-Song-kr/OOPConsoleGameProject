namespace OOPConsoleGameProject;

public class Level : Scene
{
    protected string[] MapData;
    // protected List<GameObject> GameObjects;

    public override void Render()
    {
        //todo 추후 Leve 화면에 맞게 수정 및 UIManager로 렌더링은 위임
        GameManager.Map.Print();
        GameManager.GamePlayer.Print();
    }


    public override void Input() { GameManager.Input.GetKey(); }

    public override void Update() { }

    public override void Result() { }
}