namespace OOPConsoleGameProject;

public class DungeonScene01 : Dungeon
{
    public DungeonScene01()
    {
        MapData = new string[]
        {
            "########",
            "#      #",
            "#      #",
            "#      #",
            "#      #",
            "########"
        };

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
        GameManager.Map.SetMapData(MapData);
        GameManager.GamePlayer.SetPosition(new Vector2(1, 1));
    }

    public override void OnExit() {  }
}