namespace OOPConsoleGameProject;

public class LevelScene02 : Level
{
    public LevelScene02()
    {
        MapData = new string[]
        {
            "########",
            "#   ## #",
            "#   #  #",
            "# ### ##",
            "#      #",
            "########"
        };

        GameObjects = new List<GameObject>();
        GameObjects.Add(new DoorPlace(SceneName.Level03, new Vector2(6, 1)));
    }

    public override void OnEnter()
    {
        GameManager.Map.SetMapData(MapData);
        GameManager.GamePlayer.SetPosition(new Vector2(1, 1));
    }
}