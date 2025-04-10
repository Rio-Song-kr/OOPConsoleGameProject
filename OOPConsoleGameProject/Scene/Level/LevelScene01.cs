namespace OOPConsoleGameProject;

public class LevelScene01 : Level
{
    public LevelScene01()
    {
        MapTile = Maze.GenerateByBacktracking(1, 1, new Vector2(63, 33));

        //# 문 추가
        GameObjects = new List<GameObject>();
        GameObjects.Add(new DoorPlace(SceneName.Level02, new Vector2(6, 6)));

        //# 열쇠 추가
        Item key = GameManager.ObjectPools.GetItem("Key");
        key.SetPosition(new Vector2(3, 1));
        GameObjects.Add(key);
    }

    public override void OnEnter()
    {
        GameManager.Map.SetMapData(MapTile);
        GameManager.GamePlayer.SetPosition(new Vector2(1, 1));

        if (IsFirstLoad)
        {
            //todo Render 테스트 끝나고 다시 주석 해제
            // GameManager.Scene.PrintText(new string[]
            // {
            //     "아무것도 보이지 않아",
            //     "무슨 일이 일어난 걸까?",
            //     "조용한 공기 속, 희미한 빛 한점만...",
            //     "나를 둘러싼 벽들은 왜 이렇게 낯선걸까?"
            // }, true, 100);
            Util.Sleep(1000);
            GameManager.Map.ClearMap();
        }
    }
}