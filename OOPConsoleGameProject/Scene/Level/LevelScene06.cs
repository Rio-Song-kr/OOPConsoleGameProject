namespace OOPConsoleGameProject;

public class LevelScene06 : Level
{
    public LevelScene06()
    {
        MapTile = Maze.GenerateByBacktracking(1, 1, GameManager.Instance.MazeSize[SceneName.Level06]);
        GameManager.Map.SetMapData(MapTile);

        //# 문 추가
        GameObjects = new List<GameObject>();
        Vector2 position = new Vector2(
            GameManager.Instance.MazeSize[SceneName.Level06].X - 2,
            GameManager.Instance.MazeSize[SceneName.Level06].Y - 2
        );
        GameObjects.Add(new DoorPlace(SceneName.Level07, position));
        ObjectsPosition.Add(position);
    }

    public override void OnEnter()
    {
        GameManager.Map.SetMapData(MapTile);
        GameManager.UI.ClearMapArea();

        GameManager.Inventory.RemoveAll();

        GameManager.GamePlayer.SetPosition(new Vector2(1, 1));
        Area = GameManager.Instance.Area[SceneName.Level06];

        //# 레벨6은 편지 힌트에 대한 문제를 풀어서 상자로부터 열쇠 획득 -> 탈출
        //# 편지 추가
        Item letter = GameManager.ObjectPools.GetItem("Letter");
        Vector2 position = Util.RandomCoordinates(SceneName.Level06, GameObjects);
        letter.SetPosition(new Vector2(position.X, position.Y));
        GameObjects.Add(letter);
        ObjectsPosition.Add(letter.Position);

        //# 내비게이션 추가
        Item navigation = GameManager.ObjectPools.GetItem("Navigation");
        position = Util.RandomCoordinates(SceneName.Level06, GameObjects);
        navigation.SetPosition(new Vector2(position.X, position.Y));
        GameObjects.Add(navigation);
        ObjectsPosition.Add(navigation.Position);
    }
}