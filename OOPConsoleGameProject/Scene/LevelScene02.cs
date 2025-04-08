namespace OOPConsoleGameProject;

public class LevelScene02 : Level
{
    public static string Name;

    public LevelScene02()
    {
        Name = "Level02";
        MapData = new string[]
        {
            "########",
            "#   ## #",
            "#   #  #",
            "# ### ##",
            "#      #",
            "########"
        };
    }

    public override void OnEnter() { GameManager.Map.SetMapData(MapData); }
}