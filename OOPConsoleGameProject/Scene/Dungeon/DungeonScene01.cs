namespace OOPConsoleGameProject;

public class DungeonScene01 : Dungeon
{
    public DungeonScene01()
    {
        char[,] map = new char[,]
        {
            { '#', '#', '#', '#', '#', '#', '#', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#' },
        };
        MapTile = new TileType[map.GetLength(0), map.GetLength(1)];
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (map[y, x] == '#') MapTile[y, x] = TileType.Wall;
                else MapTile[y, x] = TileType.Ground;
            }
        }

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
        GameManager.UI.ClearMapArea();
        GameManager.Map.SetMapData(MapTile);
        GameManager.GamePlayer.SetPosition(new Vector2(1, 1));
        Area = GameManager.Instance.Area[SceneName.Dungeon01];
    }

    public override void OnExit()
    {
        foreach (var gameObject in GameObjects)
        {
            gameObject.SetPosition(new Vector2(-1, -1));
        }
    }
}