namespace OOPConsoleGameProject;

public class LevelScene01 : Level
{
    // private DungeonPlace _dungeon;

    public LevelScene01()
    {
        MapTile = Maze.GenerateByBacktracking(1, 1, GameManager.Instance.MazeSize[SceneName.Level01]);
        GameManager.Map.SetMapData(MapTile);

        //# 문 추가
        GameObjects = new List<GameObject>();
        GameObjects.Add(
            new DoorPlace(SceneName.Level02,
                new Vector2(
                    GameManager.Instance.MazeSize[SceneName.Level01].X - 2,
                    GameManager.Instance.MazeSize[SceneName.Level01].Y - 2)));
    }

    public override void OnEnter()
    {
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
        }
        GameManager.Map.SetMapData(MapTile);
        GameManager.UI.ClearMapArea();

        GameManager.GamePlayer.SetPosition(new Vector2(1, 1));
        Area = GameManager.Instance.Area[SceneName.Level01];

        //# 열쇠 추가
        Vector2 position = Util.RandomCoordinates(SceneName.Level01, GameObjects);
        Item key = GameManager.ObjectPools.GetItem("Key");
        key.SetPosition(new Vector2(position.X, position.Y));
        GameObjects.Add(key);

        //# 편지 추가
        Item letter = GameManager.ObjectPools.GetItem("Letter");
        position = Util.RandomCoordinates(SceneName.Level01, GameObjects);
        letter.SetPosition(new Vector2(position.X, position.Y));
        GameObjects.Add(letter);

        //# 뮤직박스 추가 - Interact 테스트용
        Item musicBox = GameManager.ObjectPools.GetItem("Music Box");
        position = Util.RandomCoordinates(SceneName.Level01, GameObjects);
        musicBox.SetPosition(new Vector2(position.X, position.Y));
        GameObjects.Add(musicBox);

        //# 내비게이션 추가
        Item navigation = GameManager.ObjectPools.GetItem("Navigation");
        position = Util.RandomCoordinates(SceneName.Level01, GameObjects);
        navigation.SetPosition(new Vector2(position.X, position.Y));
        GameObjects.Add(navigation);
    }
}