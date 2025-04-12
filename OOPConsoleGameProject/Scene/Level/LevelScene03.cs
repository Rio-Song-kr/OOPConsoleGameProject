namespace OOPConsoleGameProject;

public class LevelScene03 : Level
{
    public LevelScene03()
    {
        MapTile = Maze.GenerateByBacktracking(1, 1, GameManager.Instance.MazeSize[SceneName.Level03]);
        GameManager.Map.SetMapData(MapTile);

        //# 문 추가
        GameObjects = new List<GameObject>();
        Vector2 position = new Vector2(
            GameManager.Instance.MazeSize[SceneName.Level03].X - 2,
            GameManager.Instance.MazeSize[SceneName.Level03].Y - 2
        );
        GameObjects.Add(new DoorPlace(SceneName.Level04, position));
        ObjectsPosition.Add(position);
    }

    public override void OnEnter()
    {
        GameManager.Map.SetMapData(MapTile);
        GameManager.UI.ClearMapArea();

        GameManager.Inventory.RemoveAll();

        GameManager.GamePlayer.SetPosition(new Vector2(1, 1));
        Area = GameManager.Instance.Area[SceneName.Level03];

        //# 레벨3은 열쇠 획득 -> 탈출
        //# 열쇠 추가
        Item key = GameManager.ObjectPools.GetItem("Key");
        Vector2 position = Util.RandomCoordinates(SceneName.Level03, GameObjects);
        key.SetPosition(new Vector2(position.X, position.Y));
        GameObjects.Add(key);
        ObjectsPosition.Add(key.Position);
    }
}