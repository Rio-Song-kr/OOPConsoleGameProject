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
    }

    public override void OnEnter()
    {
        GameManager.Map.SetMapData(MapData);
        GameManager.GamePlayer.SetPosition(new Vector2(1, 1));
    }
}