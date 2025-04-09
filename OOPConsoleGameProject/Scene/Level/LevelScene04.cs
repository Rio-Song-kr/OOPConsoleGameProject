namespace OOPConsoleGameProject;

public class LevelScene04 : Level
{
    private DungeonPlace _dungeon;

    public LevelScene04()
    {
        MapTile = Maze.GenerateByBacktracking(1, 1, new Vector2(63, 33));

        GameObjects = new List<GameObject>();
        GameObjects.Add(new DoorPlace(SceneName.End, new Vector2(6, 1)));

        //# 편지 추가
        Item letter = GameManager.ObjectPools.GetItem("Letter");
        letter.SetPosition(new Vector2(1, 4));
        GameObjects.Add(letter);

        //# Letter Chest 추가
        FieldObject letterChest = GameManager.ObjectPools.GetFieldObject("Letter Chest", 0);
        letterChest.SetPosition(new Vector2(3, 2));
        GameObjects.Add(letterChest);
    }

    public override void OnEnter()
    {
        GameManager.Map.SetMapData(MapTile);
        if (GameManager.Scene.PreviousScene != SceneName.Dungeon01)
        {
            GameManager.Inventory.RemoveAll();
            GameManager.UI.ClearMapArea();
            GameManager.GamePlayer.SetPosition(new Vector2(1, 1));
        }
        else
        {
            GameManager.GamePlayer.SetPosition(new Vector2(5, 4));
            GameObjects.Remove(_dungeon);
        }
    }
}