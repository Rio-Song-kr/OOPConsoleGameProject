namespace OOPConsoleGameProject;

public class Chest : FieldObject
{
    private static string _name { get; } = "Chest";
    private static int _chestIndex = 0;

    public Chest(ConsoleColor color, Vector2 position) : base(color, '▣', position)
    {
        //todo 상자는 문제를 출력(별도의 화면 필요)
        //todo 문제를 맞추면 인벤토리에 있는 힌트 제거 및 키 추가
        //todo 힌트 - 상자의 매칭 시스템이 필요함(ID 확인 등)
        Name = _name;
        Index = _chestIndex++;
    }

    public override bool TryInteract(GameObject gameObject)
    {
        //todo FieldObject는 Player 뿐만 아니라 Rock <-> Goal상호작용을 함
        if (gameObject is not Player player)
            return false;

        //todo 돌과 플레이어가 부딪힐 경우 상호작용 추가
        return true;
    }
}