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

        //# 문 추가
        GameObjects = new List<GameObject>();
        GameObjects.Add(new DoorPlace(SceneName.Level02, new Vector2(5, 1)));

        //# Rock 추가 - 테스트용
        FieldObject rock0 = GameManager.ObjectPools.GetFieldObject("Rock", 0);
        rock0.SetPosition(new Vector2(4, 4));
        GameObjects.Add(rock0);

        //# Goal 추가 - 테스트용
        FieldObject goal0 = GameManager.ObjectPools.GetFieldObject("Goal", 0);
        goal0.SetPosition(new Vector2(5, 4));
        GameObjects.Add(goal0);

        Goals = new List<Goal>();
        Goals.Add(goal0 as Goal);
    }

    public override void OnEnter()
    {
        GameManager.Map.SetMapData(MapData);
        GameManager.GamePlayer.SetPosition(new Vector2(1, 1));
    }
}