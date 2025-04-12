namespace OOPConsoleGameProject;

public class LevelScene07 : Level
{
    public LevelScene07()
    {
        MapTile = Maze.GenerateByBacktracking(1, 1, GameManager.Instance.MazeSize[SceneName.Level07]);
        GameManager.Map.SetMapData(MapTile);

        //# 문 추가
        GameObjects = new List<GameObject>();
        Vector2 position = new Vector2(
            GameManager.Instance.MazeSize[SceneName.Level07].X - 2,
            GameManager.Instance.MazeSize[SceneName.Level07].Y - 2
        );
        GameObjects.Add(new DoorPlace(SceneName.End, position));
        ObjectsPosition.Add(position);
    }

    public override void OnEnter()
    {
        GameManager.Map.SetMapData(MapTile);
        GameManager.UI.ClearMapArea();

        GameManager.Inventory.RemoveAll();

        GameManager.GamePlayer.SetPosition(new Vector2(1, 1));
        Area = GameManager.Instance.Area[SceneName.Level07];

        //# 레벨7은 뮤직박스 힌트에 대한 문제를 풀어서 상자로부터 열쇠 획득 -> 탈출
        //# 뮤직박스 추가 - Interact 테스트용
        Item musicBox = GameManager.ObjectPools.GetItem("Music Box");
        Vector2 position = Util.RandomCoordinates(SceneName.Level07, GameObjects);
        musicBox.SetPosition(new Vector2(position.X, position.Y));
        GameObjects.Add(musicBox);
        ObjectsPosition.Add(musicBox.Position);

        //# 내비게이션 추가
        Item navigation = GameManager.ObjectPools.GetItem("Navigation");
        position = Util.RandomCoordinates(SceneName.Level07, GameObjects);
        navigation.SetPosition(new Vector2(position.X, position.Y));
        GameObjects.Add(navigation);
        ObjectsPosition.Add(navigation.Position);
    }
}