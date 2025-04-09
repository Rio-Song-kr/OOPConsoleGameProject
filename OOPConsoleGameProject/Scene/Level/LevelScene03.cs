namespace OOPConsoleGameProject;

public class LevelScene03 : Level
{
    public LevelScene03()
    {
        MapTile = Maze.GenerateByBacktracking(1, 1, new Vector2(63, 33));

        GameObjects = new List<GameObject>();
        GameObjects.Add(new DoorPlace(SceneName.Level04, new Vector2(5, 1)));

        /*
        //# 뮤직박스 추가
        Item musicBox = GameManager.ObjectPools.GetItem("Music Box");
        musicBox.SetPosition(new Vector2(1, 4));
        GameObjects.Add(musicBox);

        //# 내비게이션 추가
        Item navigation = GameManager.ObjectPools.GetItem("Navigation");
        navigation.SetPosition(new Vector2(3, 4));
        GameObjects.Add(navigation);
    */
    }

    public override void OnEnter()
    {
        GameManager.Map.SetMapData(MapTile);
        // if (GameManager.Scene.PreviousScene != SceneName.Dungeon02)
        // {
        GameManager.Inventory.RemoveAll();
        GameManager.UI.ClearMapArea();
        GameManager.GamePlayer.SetPosition(new Vector2(1, 1));

        //# 열쇠 추가
        Item key = GameManager.ObjectPools.GetItem("Key");
        key.SetPosition(new Vector2(6, 4));
        GameObjects.Add(key);
        // }
        // else
        // {
        //     GameManager.GamePlayer.SetPosition(new Vector2(5, 4));
        // }
    }
}