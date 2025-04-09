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
                bool isSuccess = gameObject.TryInteract(GameManager.GamePlayer);
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

                //todo Dungeon 추가시 Dugeon으로 이동되어야 할 내용 - 현재는 테스트용
                //todo 지금은 TryInteract에 전달되는 것들이 Player만임
                //todo 즉, Object와 Object 간의 상호상용이 안됨
                //todo 현재 플레이어에 대한 처리만 있음
                //todo 그런데 Object와 Object 간의 Interact도 구현해야 함
                //todo 현재 상태에서는 돌 <-> Goal 모두 여기서 체크가 되고 있음
                if (gameObject is Rock rock)
                {
                    if (isSuccess)
                    {
                        break;
                    }

                    //# 이동하기 이전 위치로 다시 이동
                    Vector2 direction = GameManager.GamePlayer.MovedDirection;
                    direction.X *= -1;
                    direction.Y *= -1;
                    GameManager.GamePlayer.Move(direction);
                }
            }
        }
    }

    public override void Result() { }
}