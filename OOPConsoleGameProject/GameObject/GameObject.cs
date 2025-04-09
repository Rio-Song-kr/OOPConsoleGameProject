namespace OOPConsoleGameProject;

public abstract class GameObject : IInteractable
{
    public ConsoleColor Color;
    public char Symbol;
    private Vector2 _position;
    public Vector2 Position { get => _position; protected set => _position = value; }
    public bool IsCollectable { get; }
    protected static Vector2 Offset = GameManager.UI.MapStartOffset;

    public GameObject(ConsoleColor color, char symbol, Vector2 position, bool collectable)
    {
        Color = color;
        Symbol = symbol;
        Position = position + Offset;
        IsCollectable = collectable;
    }

    //todo UIManager가 추가되면 UIManager를 이용해서 출력해야 함
    public void Print()
    {
        if (Position.X < Offset.X || Position.Y < Offset.Y) return;
        Console.SetCursorPosition(Position.X, Position.Y);
        Console.ForegroundColor = Color;
        Console.Write(Symbol);
        Console.ResetColor();
    }

    public void SetPosition(Vector2 position) { _position = position + Offset; }

    public abstract bool TryInteract(GameObject gameObject);
}