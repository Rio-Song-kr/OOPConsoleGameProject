namespace OOPConsoleGameProject;

public abstract class GameObject : IInteractable
{
    public ConsoleColor Color;
    public char Symbol;
    private Vector2 _position;
    public Vector2 Position { get => _position; protected set => _position = value; }
    public bool IsCollectable { get; }

    public GameObject(ConsoleColor color, char symbol, Vector2 position, bool collectable)
    {
        Color = color;
        Symbol = symbol;
        Position = position;
        IsCollectable = collectable;
    }

    //todo UIManager가 추가되면 UIManager를 이용해서 출력해야 함
    public void Print()
    {
        if (Position.X < 0 || Position.Y < 0) return;
        Console.SetCursorPosition(Position.X, Position.Y);
        Console.ForegroundColor = Color;
        Console.Write(Symbol);
        Console.ResetColor();
    }

    public void SetPosition(Vector2 position) { _position = position; }

    public abstract void Interact(GameObject gameObject);
}