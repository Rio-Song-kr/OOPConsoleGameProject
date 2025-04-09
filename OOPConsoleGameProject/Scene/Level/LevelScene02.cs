namespace OOPConsoleGameProject;

public class LevelScene02 : Level
{
    private DungeonPlace _dungeon;

    public LevelScene02()
    {
        MapTile = Maze.GenerateByBacktracking(1, 1, new Vector2(63, 33));

        GameObjects = new List<GameObject>();
        GameObjects.Add(new DoorPlace(SceneName.Level03, new Vector2(6, 1)));

        //# 던전 추가
        _dungeon = new DungeonPlace(SceneName.Dungeon01, new Vector2(6, 4));
        GameObjects.Add(_dungeon);
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