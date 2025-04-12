namespace OOPConsoleGameProject;

//# 던전이 없는 넓은 맵
public class LevelScene02 : Level
{
    private DungeonPlace _dungeon;

    public LevelScene02()
    {
        MapTile = Maze.GenerateByBacktracking(1, 1, GameManager.Instance.MazeSize[SceneName.Level02]);
        GameManager.Map.SetMapData(MapTile);

        //# 문 추가
        GameObjects = new List<GameObject>();
        Vector2 position = new Vector2(
            GameManager.Instance.MazeSize[SceneName.Level02].X - 2,
            GameManager.Instance.MazeSize[SceneName.Level02].Y - 2
        );
        GameObjects.Add(new DoorPlace(SceneName.Level03, position));
        ObjectsPosition.Add(position);
    }

    public override void OnEnter()
    {
        GameManager.Map.SetMapData(MapTile);
        GameManager.UI.ClearMapArea();
        Vector2 position;

        if (GameManager.Scene.PreviousScene != SceneName.Dungeon01)
        {
            GameManager.Inventory.RemoveAll();
            GameManager.GamePlayer.SetPosition(new Vector2(1, 1));

            //# 레벨2는 던전 -> 열쇠 획득 -> 탈출
            //# 던전 추가
            position = Util.RandomCoordinates(SceneName.Level02, GameObjects);
            _dungeon = new DungeonPlace(SceneName.Dungeon01, new Vector2(position.X, position.Y));
            GameObjects.Add(_dungeon);
            ObjectsPosition.Add(_dungeon.Position);
        }
        else
        {
            GameManager.GamePlayer.SetPosition(new Vector2(_dungeon.Position.X, _dungeon.Position.Y));
            GameObjects.Remove(_dungeon);
            ObjectsPosition.Remove(_dungeon.Position);
        }
        Area = GameManager.Instance.Area[SceneName.Level02];
    }
}