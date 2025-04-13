namespace OOPConsoleGameProject;

public class LevelScene01 : Level
{
    public LevelScene01()
    {
        MapTile = Maze.GenerateByBacktracking(1, 1, GameManager.Instance.MazeSize[SceneName.Level01]);
        GameManager.Map.SetMapData(MapTile);

        //# 문 추가
        GameObjects = new List<GameObject>();
        Vector2 position = new Vector2(
            GameManager.Instance.MazeSize[SceneName.Level01].X - 2,
            GameManager.Instance.MazeSize[SceneName.Level01].Y - 2
        );
        GameObjects.Add(new DoorPlace(SceneName.Level02, position));
        ObjectsPosition.Add(position);

        // position = Util.RandomCoordinates(SceneName.Level01, GameObjects);
        FieldObject chest = GameManager.ObjectPools.GetFieldObject("Letter Chest", 0);
        // chest.SetPosition(position);
        chest.SetPosition(new Vector2(1, 3));
        GameObjects.Add(chest);
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

        //# 레벨1은 열쇠 획득 -> 탈출
        //# 열쇠 추가
        Vector2 position = Util.RandomCoordinates(SceneName.Level01, GameObjects);
        Item key = GameManager.ObjectPools.GetItem("Key");
        key.SetPosition(new Vector2(position.X, position.Y));
        GameObjects.Add(key);
        ObjectsPosition.Add(key.Position);

        //# 편지 추가
        Item letter = GameManager.ObjectPools.GetItem("Letter");
        letter.SetPosition(new Vector2(3, 1));
        GameObjects.Add(letter);
        ObjectsPosition.Add(letter.Position);
    }
}