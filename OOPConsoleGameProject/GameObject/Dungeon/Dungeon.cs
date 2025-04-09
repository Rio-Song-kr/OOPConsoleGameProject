namespace OOPConsoleGameProject;

public class Dungeon : Scene
{
    protected string[] MapData;
    protected List<GameObject> GameObjects;
    protected List<Goal> Goals;

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

                if (gameObject is Rock rock)
                {
                    if (!isSuccess)
                    {
                        //# 이동하기 이전 위치로 다시 이동
                        Vector2 direction = GameManager.GamePlayer.MovedDirection;
                        direction.X *= -1;
                        direction.Y *= -1;
                        GameManager.GamePlayer.Move(direction);
                        continue;
                    }

                    //# 돌이 움직일 때만 체크 - goal 위에 돌이 올라와 있는가 아닌가
                    foreach (var goal in Goals)
                    {
                        if (rock.Position == goal.Position)
                        {
                            goal.TryInteract(rock);
                            break;
                        }
                        else
                        {
                            goal.Init();
                        }
                    }
                }
            }
        }
    }
    public override void Result() { }
}