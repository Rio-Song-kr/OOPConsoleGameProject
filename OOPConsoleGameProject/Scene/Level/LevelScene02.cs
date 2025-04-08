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
    }

    public override void OnEnter() { GameManager.Map.SetMapData(MapData); }
}