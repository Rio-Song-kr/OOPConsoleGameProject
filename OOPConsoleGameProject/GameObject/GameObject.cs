namespace OOPConsoleGameProject;

public abstract class GameObject : IInteractable
{
    public ConsoleColor Color;
    public char Symbol;
    private Vector2 _position;
    public Vector2 Position { get => _position; protected set => _position = value; }

    public GameObject(ConsoleColor color, char symbol, Vector2 position)
    {
        Color = color;
        Symbol = symbol;
        Position = position;
    }

    //todo UIManager가 추가되면 UIManager를 이용해서 출력해야 함
    public void Print()
    {
        Console.SetCursorPosition(Position.X, Position.Y);
        Console.ForegroundColor = Color;
        Console.Write(Symbol);
        Console.ResetColor();
    }

    public abstract void Interact(GameObject gameObject);
}