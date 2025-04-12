namespace OOPConsoleGameProject;

public class LevelScene03 : Level
{
    // private DungeonPlace _dungeon;

    public LevelScene03()
    {
        MapTile = Maze.GenerateByBacktracking(1, 1, GameManager.Instance.MazeSize[SceneName.Level03]);
        GameManager.Map.SetMapData(MapTile);

        //# 문 추가
        GameObjects = new List<GameObject>();
        GameObjects.Add(
            new DoorPlace(SceneName.Level04,
                new Vector2(
                    GameManager.Instance.MazeSize[SceneName.Level03].X - 2,
                    GameManager.Instance.MazeSize[SceneName.Level03].Y - 2)));
    }

    public override void OnEnter()
    {
        GameManager.Map.SetMapData(MapTile);
        GameManager.UI.ClearMapArea();

        GameManager.Inventory.RemoveAll();

        GameManager.GamePlayer.SetPosition(new Vector2(1, 1));
        Area = GameManager.Instance.Area[SceneName.Level03];

        //# 열쇠 추가
        Item key = GameManager.ObjectPools.GetItem("Key");
        Vector2 position = Util.RandomCoordinates(SceneName.Level03, GameObjects);
        key.SetPosition(new Vector2(position.X, position.Y));
        GameObjects.Add(key);

        //# 편지 추가
        Item letter = GameManager.ObjectPools.GetItem("Letter");
        position = Util.RandomCoordinates(SceneName.Level01, GameObjects);
        letter.SetPosition(new Vector2(position.X, position.Y));
        GameObjects.Add(letter);

        //# 뮤직박스 추가 - Interact 테스트용
        Item musicBox = GameManager.ObjectPools.GetItem("Music Box");
        position = Util.RandomCoordinates(SceneName.Level01, GameObjects);
        musicBox.SetPosition(new Vector2(position.X, position.Y));
        GameObjects.Add(musicBox);

        //# 내비게이션 추가
        Item navigation = GameManager.ObjectPools.GetItem("Navigation");
        position = Util.RandomCoordinates(SceneName.Level01, GameObjects);
        navigation.SetPosition(new Vector2(position.X, position.Y));
        GameObjects.Add(navigation);
    }
}