namespace OOPConsoleGameProject;

public class Dungeon : Scene
{
    protected TileType[,] MapTile;
    protected List<GameObject> GameObjects;
    protected List<Goal> Goals;
    protected RenderArea Area;

    public Dungeon()
    {
        GameObjects = new List<GameObject>();
        Goals = new List<Goal>();
    }

    public override void Render()
    {
        GameManager.Map.Print(Area);
        foreach (var gameObject in GameObjects)
        {
            gameObject.Print();
        }

        GameManager.GamePlayer.Print();
    }

    public override void Input() { GameManager.Input.GetKey(); }
    public override void Update()
    {
        int checkGoalCount = 0;

        foreach (var gameObject in GameObjects)
        {
            if (GameManager.GamePlayer.Position == gameObject.Position)
            {
                bool isSuccess = gameObject.TryInteract(GameManager.GamePlayer);

                if (gameObject is Rock rock)
                {
                    if (!isSuccess) MovePlayer();
                    else
                    {
                        CheckGoalSign(rock);
                    }
                }
            }

            if (gameObject is Rock)
            {
                foreach (var goal in Goals)
                {
                    if (gameObject.Position == goal.Position)
                    {
                        checkGoalCount++;
                        break;
                    }
                }
            }
        }

        if (checkGoalCount == Goals.Count)
        {
            GameManager.Inventory.Add(GameManager.ObjectPools.GetItem("Key"));
        }
    }

    private void MovePlayer()
    {
        //# 이동하기 이전 위치로 다시 이동
        Vector2 direction = GameManager.GamePlayer.MovedDirection;
        direction.X *= -1;
        direction.Y *= -1;
        GameManager.GamePlayer.Move(direction);
    }

    private void CheckGoalSign(Rock rock)
    {
        //# 돌이 움직일 때만 체크 - goal 위에 돌이 올라와 있는가 아닌가
        foreach (var goal in Goals)
        {
            if (rock.Position == goal.Position)
            {
                goal.TryInteract(rock);
                break;
            }
            goal.Init();
        }
    }

    public override void Result()
    {
        if (GameManager.Inventory.IsExist(GameManager.ObjectPools.GetItem("Key")))
        {
            GameManager.Scene.Move(SceneName.Level02);
        }
    }
}