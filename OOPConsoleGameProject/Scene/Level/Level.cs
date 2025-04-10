namespace OOPConsoleGameProject;

public class Level : Scene
{
    protected TileType[,] MapTile;
    protected List<GameObject> GameObjects;

    public override void Render()
    {
        if (!GameManager.Inventory.PrintItemInfo)
        {
            // GameManager.Map.Print();
            GameManager.Map.Print(RenderArea.Render9x5);
            foreach (var gameObject in GameObjects)
            {
                gameObject.Print();
            }

            GameManager.GamePlayer.Print();
        }
    }

    public override void Input() { GameManager.Input.GetKey(); }

    public override void Update()
    {
        foreach (var gameObject in GameObjects)
        {
            if (GameManager.GamePlayer.Position == gameObject.Position)
            {
                gameObject.TryInteract(GameManager.GamePlayer);

                if (gameObject is Item item)
                {
                    if (item == null || !GameManager.Inventory.IsExist(item))
                    {
                        GameManager.Inventory.IsFull();
                        continue;
                    }
                    GameObjects.Remove(gameObject);
                    break;
                }
                else if (gameObject is Chest chest)
                {
                    //todo Chest의 문제를 해결했을 때에 대한 처리 추가
                }
            }
        }
    }

    public override void Result() { }
}