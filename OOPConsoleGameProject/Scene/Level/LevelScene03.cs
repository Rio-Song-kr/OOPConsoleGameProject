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
    }

    public override void OnEnter() { GameManager.Map.SetMapData(MapData); }
}