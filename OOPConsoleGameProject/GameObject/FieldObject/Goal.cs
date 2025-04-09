namespace OOPConsoleGameProject;

public class Goal : FieldObject
{
    private static string _name { get; } = "Goal";
    private static int _goalIndex = 0;
    private static char _initSymbol;
    private static ConsoleColor _initColor;

    public Goal(Vector2 position, ConsoleColor color = ConsoleColor.DarkGreen) : base(color, '○', position)
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