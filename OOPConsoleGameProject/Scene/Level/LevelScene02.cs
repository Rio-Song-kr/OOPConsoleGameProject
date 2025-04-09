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

        //# 편지 추가
        Item letter = GameManager.ItemPools.GetItem("Letter");
        letter.SetPosition(new Vector2(1, 4));
        GameObjects.Add(letter);
    }

    public override void OnEnter()
    {
        GameManager.Map.SetMapData(MapData);
        GameManager.GamePlayer.SetPosition(new Vector2(1, 1));
    }
}