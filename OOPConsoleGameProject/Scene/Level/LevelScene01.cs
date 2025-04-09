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
        GameObjects.Add(
            new DoorPlace(SceneName.Level02, new Vector2(5, 1)));

        //# 열쇠 추가
        Item key = GameManager.ObjectPools.GetItem("Key");
        key.SetPosition(new Vector2(1, 4));
        GameObjects.Add(key);
    }

    public override void OnEnter()
    {
        GameManager.Map.SetMapData(MapData);
        GameManager.GamePlayer.SetPosition(new Vector2(1, 1));

        if (IsFirstLoad)
        {
            //todo UIManager가 추가되면 UIManager를 이용해서 출력해야 함
            GameManager.UI.PrintTextAtCenter(new string[]
            {
                "아무것도 보이지 않아",
                "무슨 일이 일어난 걸까?",
                "조용한 공기 속, 희미한 빛 한점만...",
                "나를 둘러싼 벽들은 왜 이렇게 낯선걸까?"
            }, true, 100);
            Util.Sleep(1000);
            GameManager.UI.ClearMapArea();
        }
    }
}