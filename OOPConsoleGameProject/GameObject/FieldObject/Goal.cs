namespace OOPConsoleGameProject;

public class Goal : FieldObject
{
    //todo 던전 맵(소코반)에서 사용할 돌이 올라갈 위치
    private static string _name { get; } = "Goal";
    private static int _goalIndex = 0;
    private static char _initSymbol;
    private static ConsoleColor _initColor;

    public Goal(ConsoleColor color, Vector2 position) : base(color, '○', position)
    {
        Name = _name;
        Index = _goalIndex++;
        _initSymbol = Symbol;
        _initColor = Color;
    }

    public override bool TryInteract(GameObject gameObject)
    {
        if (gameObject is Player player)
            return false;

        if (gameObject is Rock)
        {
            //todo Goal의 경우, 돌이 올라오면 심볼(◎)과 색상이 변해야함
            //todo 반대로 돌이 심볼을 벗어나면 다시 이전 심볼(○)과 색상으로 복귀
            Symbol = '◎';
            Color = ConsoleColor.Cyan;
            return true;
        }
        return false;
    }

    public void Init()
    {
        Symbol = _initSymbol;
        Color = _initColor;
    }
}