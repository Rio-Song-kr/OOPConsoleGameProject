namespace OOPConsoleGameProject;

public class LevelScene01 : Level
{
    public static string Name;

    public LevelScene01() { Name = "Level01"; }

    public override void OnEnter()
    {
        GameManager.Map.SetMapData(MapData);

        if (IsFirstLoad)
        {
            Util.PrintCharacterSequentially("아무것도 보이지 않아", delay: 100);
            Util.PrintCharacterSequentially("무슨 일이 일어난 걸까?", delay: 100);
            Util.PrintCharacterSequentially("조용한 공기 속, 희미한 빛 한점만...", delay: 100);
            Util.PrintCharacterSequentially("나를 둘러싼 벽들은 왜 이렇게 낯선 걸까?", delay: 100);
            Util.Sleep(2000);
        }
    }
}