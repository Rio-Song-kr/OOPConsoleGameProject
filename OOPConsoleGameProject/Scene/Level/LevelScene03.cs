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
        Item musicBox = GameManager.ItemPools.GetItem("Music Box");
        musicBox.SetPosition(new Vector2(1, 4));
        GameObjects.Add(musicBox);
    }

    public override void OnEnter()
    {
        GameManager.Map.SetMapData(MapData);
        GameManager.GamePlayer.SetPosition(new Vector2(1, 1));
    }
}