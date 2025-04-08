namespace OOPConsoleGameProject;

public class LevelScene03 : Level
{
    public static string Name;

    public LevelScene03()
    {
        Name = "Level03";
        MapData = new string[]
        {
            "########",
            "#   #  #",
            "## ##  #",
            "#  ##  #",
            "#      #",
            "########"
        };
    }

    public override void OnEnter() { GameManager.Map.SetMapData(MapData); }
}