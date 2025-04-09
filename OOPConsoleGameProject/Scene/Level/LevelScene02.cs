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
        Item letter = GameManager.ObjectPools.GetItem("Letter");
        letter.SetPosition(new Vector2(1, 4));
        GameObjects.Add(letter);

        //# 던전 추가
        GameObjects.Add(new DungeonPlace(SceneName.Dungeon01, new Vector2(6, 4)));
    }

    public override void OnEnter()
    {
        GameManager.Map.SetMapData(MapData);
        if (GameManager.Scene.PreviousScene != SceneName.Dungeon01)
        {
            GameManager.Inventory.RemoveAll();
            GameManager.UI.ClearMapArea();
            GameManager.GamePlayer.SetPosition(new Vector2(1, 1));
        }
        else
        {
            GameManager.GamePlayer.SetPosition(new Vector2(5, 4));
        }
    }
}