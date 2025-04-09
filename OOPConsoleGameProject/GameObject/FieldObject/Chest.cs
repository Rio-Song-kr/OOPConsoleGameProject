namespace OOPConsoleGameProject;

public class Chest : FieldObject
{
    private static int _chestIndex = 0;

    public Chest(string name, Vector2 position, ConsoleColor color = ConsoleColor.Blue) : base(color, '▣', position)
    {
        Name = name;
        Index = _chestIndex++;
    }

    public override bool TryInteract(GameObject gameObject)
    {
        if (gameObject is not Player player)
            return false;

        //todo Vector2 값은 추후 InputManager의 입력과 연동이 되어야 함
        //todo 문제를 맞추면 인벤토리에 있는 힌트 제거 및 키 추가
        //todo 돌과 플레이어가 부딪힐 경우 상호작용 추가
        // GameManager.UI.PrintChest(new char[] { '1', '1', '1', '1' }, new Vector2(3, 0));

        return true;
    }
}