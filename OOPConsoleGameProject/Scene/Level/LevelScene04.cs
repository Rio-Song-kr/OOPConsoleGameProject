namespace OOPConsoleGameProject;

public class LevelScene04 : Level
{
    private DungeonPlace _dungeon;

    public LevelScene04()
    {
        MapTile = Maze.GenerateByBacktracking(1, 1, GameManager.Instance.MazeSize[SceneName.Level04]);
        GameManager.Map.SetMapData(MapTile);

        //# 문 추가
        GameObjects = new List<GameObject>();
        Vector2 position = new Vector2(
            GameManager.Instance.MazeSize[SceneName.Level04].X - 2,
            GameManager.Instance.MazeSize[SceneName.Level04].Y - 2
        );
        GameObjects.Add(new DoorPlace(SceneName.Level05, position));
        ObjectsPosition.Add(position);
    }

    public override void OnEnter()
    {
        GameManager.Map.SetMapData(MapTile);
        GameManager.UI.ClearMapArea();
        Vector2 position;

        if (GameManager.Scene.PreviousScene != SceneName.Dungeon02)
        {
            GameManager.Inventory.RemoveAll();
            GameManager.GamePlayer.SetPosition(new Vector2(1, 1));

            //# 레벨2는 던전 -> 열쇠 획득 -> 탈출
            //# 던전 추가
            position = Util.RandomCoordinates(SceneName.Level04, GameObjects);
            _dungeon = new DungeonPlace(SceneName.Dungeon02, new Vector2(position.X, position.Y));
            GameObjects.Add(_dungeon);
            ObjectsPosition.Add(_dungeon.Position);

            //# 내비게이션 추가
            Item navigation = GameManager.ObjectPools.GetItem("Navigation");
            position = Util.RandomCoordinates(SceneName.Level05, GameObjects);
            navigation.SetPosition(new Vector2(position.X, position.Y));
            GameObjects.Add(navigation);
            ObjectsPosition.Add(navigation.Position);
        }
        else
        {
            GameManager.GamePlayer.SetPosition(new Vector2(_dungeon.Position.X, _dungeon.Position.Y));
            GameObjects.Remove(_dungeon);
            ObjectsPosition.Remove(_dungeon.Position);
        }
        Area = GameManager.Instance.Area[SceneName.Level04];
    }
}