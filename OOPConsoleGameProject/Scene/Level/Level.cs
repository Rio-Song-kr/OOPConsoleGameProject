namespace OOPConsoleGameProject;

public class Level : Scene
{
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
                    ObjectsPosition.Remove(gameObject.Position);
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