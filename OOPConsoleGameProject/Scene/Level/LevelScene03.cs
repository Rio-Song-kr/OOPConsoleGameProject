namespace OOPConsoleGameProject;

public class LevelScene03 : Level
{
    public LevelScene03()
    {
        MapData = new string[]
        {
            "########",
            "#   #  #",
            "## ##  #",
            "#  ##  #",
            "#      #",
            "########"
        };

        GameObjects = new List<GameObject>();
        GameObjects.Add(new DoorPlace(SceneName.End, new Vector2(5, 1)));

        //# 뮤직박스 추가
        Item musicBox = GameManager.ObjectPools.GetItem("Music Box");
        musicBox.SetPosition(new Vector2(1, 4));
        GameObjects.Add(musicBox);

        //# 내비게이션 추가
        Item navigation = GameManager.ObjectPools.GetItem("Navigation");
        navigation.SetPosition(new Vector2(3, 4));
        GameObjects.Add(navigation);
    }

    public override void OnEnter()
    {
        GameManager.Map.SetMapData(MapData);
        // if (GameManager.Scene.PreviousScene != SceneName.Dungeon02)
        // {
        GameManager.Inventory.RemoveAll();
        GameManager.GamePlayer.SetPosition(new Vector2(1, 1));
        // }
        // else
        // {
        //     GameManager.GamePlayer.SetPosition(new Vector2(5, 4));
        // }
    }
}