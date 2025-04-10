namespace OOPConsoleGameProject;

public class DungeonScene01 : Dungeon
{
    public DungeonScene01()
    {
        MapTile = Maze.GenerateByBacktracking(1, 1, new Vector2(33, 33));

        //# Rock 추가 - 테스트용
        FieldObject rock0 = GameManager.ObjectPools.GetFieldObject("Rock", 0);
        rock0.SetPosition(new Vector2(4, 4));
        GameObjects.Add(rock0);

        FieldObject rock1 = GameManager.ObjectPools.GetFieldObject("Rock", 1);
        rock1.SetPosition(new Vector2(3, 2));
        GameObjects.Add(rock1);

        //# Goal 추가 - 테스트용
        FieldObject goal0 = GameManager.ObjectPools.GetFieldObject("Goal", 0);
        goal0.SetPosition(new Vector2(5, 4));
        GameObjects.Add(goal0);

        FieldObject goal1 = GameManager.ObjectPools.GetFieldObject("Goal", 1);
        goal1.SetPosition(new Vector2(3, 1));
        GameObjects.Add(goal1);

        Goals.Add(goal0 as Goal);
        Goals.Add(goal1 as Goal);
    }

    public override void OnEnter()
    {
        GameManager.Map.SetMapData(MapTile);
        GameManager.GamePlayer.SetPosition(new Vector2(1, 1));
    }

    public override void OnExit() { }
}