namespace OOPConsoleGameProject;

public class LevelScene05 : Level
{
    public LevelScene05()
    {
        MapTile = Maze.GenerateByBacktracking(1, 1, GameManager.Instance.MazeSize[SceneName.Level05]);
        GameManager.Map.SetMapData(MapTile);

        //# 문 추가
        GameObjects = new List<GameObject>();
        Vector2 position = new Vector2(
            GameManager.Instance.MazeSize[SceneName.Level05].X - 2,
            GameManager.Instance.MazeSize[SceneName.Level05].Y - 2
        );
        GameObjects.Add(new DoorPlace(SceneName.Level06, position));
        ObjectsPosition.Add(position);
    }

    public override void OnEnter()
    {
        GameManager.Map.SetMapData(MapTile);
        GameManager.UI.ClearMapArea();

        GameManager.Inventory.RemoveAll();

        GameManager.GamePlayer.SetPosition(new Vector2(1, 1));
        Area = GameManager.Instance.Area[SceneName.Level05];

        //# 레벨5은 열쇠 획득 -> 탈출
        //# 열쇠 추가
        Item key = GameManager.ObjectPools.GetItem("Key");
        Vector2 position = Util.RandomCoordinates(SceneName.Level05, GameObjects);
        key.SetPosition(new Vector2(position.X, position.Y));
        GameObjects.Add(key);
        ObjectsPosition.Add(key.Position);

        //# 내비게이션 추가
        Item navigation = GameManager.ObjectPools.GetItem("Navigation");
        position = Util.RandomCoordinates(SceneName.Level05, GameObjects);
        navigation.SetPosition(new Vector2(position.X, position.Y));
        GameObjects.Add(navigation);
        ObjectsPosition.Add(navigation.Position);
    }
}