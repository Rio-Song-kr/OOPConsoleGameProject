namespace OOPConsoleGameProject;

public class Level : Scene
{
    protected string[] MapData;
    protected List<GameObject> GameObjects;

    public override void Render()
    {
        GameManager.Map.Print();
        foreach (var gameObject in GameObjects)
        {
            gameObject.Print();
        }

        GameManager.GamePlayer.Print();
    }

    public override void Input() { GameManager.Input.GetKey(); }

    public override void Update()
    {
        foreach (var gameObject in GameObjects)
        {
            if (GameManager.GamePlayer.Position == gameObject.Position)
            {
                gameObject.Interact(GameManager.GamePlayer);
                if (gameObject.IsCollectable)
                    GameObjects.Remove(gameObject);
                break;
            }
        }
    }

    public override void Result() { }
}