namespace OOPConsoleGameProject;

//# 던전이 없는 넓은 맵
public class LevelScene02 : Level
{
    // private DungeonPlace _dungeon;

    public LevelScene02()
    {
        MapTile = Maze.GenerateByBacktracking(1, 1, GameManager.Instance.MazeSize[SceneName.Level02]);
        GameManager.Map.SetMapData(MapTile);

        //# 문 추가
        GameObjects = new List<GameObject>();
        GameObjects.Add(
            new DoorPlace(SceneName.Level03,
                new Vector2(
                    GameManager.Instance.MazeSize[SceneName.Level02].X - 2,
                    GameManager.Instance.MazeSize[SceneName.Level02].Y - 2)));
    }

    public override void OnEnter()
    {
        GameManager.Map.SetMapData(MapTile);
        GameManager.UI.ClearMapArea();

        GameManager.Inventory.RemoveAll();

        GameManager.GamePlayer.SetPosition(new Vector2(1, 1));
        Area = GameManager.Instance.Area[SceneName.Level02];

        //# 열쇠 추가
        Vector2 position = Util.RandomCoordinates(SceneName.Level02, GameObjects);
        Item key = GameManager.ObjectPools.GetItem("Key");
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

    //todo 던전은 추후 적용
    // public override void OnEnter()
    // {
    //     if (GameManager.Scene.PreviousScene != SceneName.Dungeon01)
    //     {
    //         GameManager.Inventory.RemoveAll();
    //         GameManager.GamePlayer.SetPosition(new Vector2(1, 1));
    //
    //         //# 던전 추가
    //         Vector2 position = Util.RandomCoordinates(SceneName.Level02, GameObjects);
    //         _dungeon = new DungeonPlace(SceneName.Dungeon01, new Vector2(position.X, position.Y));
    //         GameObjects.Add(_dungeon);
    //     }
    //     else
    //     {
    //         //todo 생성된 던전 위치에서 되돌아올 Player의 위치를 저장해서 불러와야 함
    //         GameManager.GamePlayer.SetPosition(new Vector2(_dungeon.Position.X, _dungeon.Position.Y));
    //         GameObjects.Remove(_dungeon);
    //     }
    //     Area = GameManager.Instance.Area[SceneName.Level02];
    //     GameManager.UI.ClearMapArea();
    //     GameManager.Map.SetMapData(MapTile);
    // }
}