namespace OOPConsoleGameProject;

public class LevelScene01 : Level
{
    public LevelScene01()
    {
        MapData = new string[]
        {
            "########",
            "#   #  #",
            "#   #  #",
            "### #  #",
            "#      #",
            "########"
        };

        //# 문 추가
        GameObjects = new List<GameObject>();
        GameObjects.Add(new DoorPlace(SceneName.Level02, new Vector2(5, 1)));

        //# 열쇠 추가
        Item yellowKey = GameManager.ItemPools.GetItem("Key");
        yellowKey.SetPosition(new Vector2(1, 4));
        GameObjects.Add(yellowKey);
    }

    public override void OnEnter()
    {
        GameManager.Map.SetMapData(MapData);
        GameManager.GamePlayer.SetPosition(new Vector2(1, 1));

        if (IsFirstLoad)
        {
            //todo UIManager가 추가되면 UIManager를 이용해서 출력해야 함
            Util.PrintCharacterSequentially("아무것도 보이지 않아", delay: 100);
            Util.PrintCharacterSequentially("무슨 일이 일어난 걸까?", delay: 100);
            Util.PrintCharacterSequentially("조용한 공기 속, 희미한 빛 한점만...", delay: 100);
            Util.PrintCharacterSequentially("나를 둘러싼 벽들은 왜 이렇게 낯선 걸까?", delay: 100);
            Util.Sleep(1000);
            Console.Clear();
            GameManager.Inventory.RemoveAll();
        }
    }
}