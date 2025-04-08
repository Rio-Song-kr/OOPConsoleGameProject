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

    //todo UI 매니저와 연결해야 할 수도 있음
    public void Print()
    {
        Console.SetCursorPosition(Position.X, Position.Y);
        Console.ForegroundColor = Color;
        Console.Write(Symbol);
        Console.ResetColor();
    }

    public abstract void Interact(GameObject gameObject);
}