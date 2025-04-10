namespace OOPConsoleGameProject;

public abstract class GameObject : IInteractable
{
    public ConsoleColor Color;
    public char Symbol;
    private Vector2 _position;
    public Vector2 Position { get => _position; protected set => _position = value; }
    public bool IsCollectable { get; }
    protected static Vector2 MapOffset = GameManager.UI.MapStartOffset;
    private IGameObjectPrint _print = GameManager.UI;

    public GameObject(ConsoleColor color, char symbol, Vector2 position, bool collectable)
    {
        Color = color;
        Symbol = symbol;

        //# 중앙 출력이 아닐 시
        // Position = position + MapOffset;
        Position = position;
        IsCollectable = collectable;
    }

    public void Print()
    {
        if (Position.X < MapOffset.X || Position.Y < MapOffset.Y) return;
        _print.PrintObject(this);
    }

    //# 중앙 출력이 아닐 시
    // public void SetPosition(Vector2 position) { _position = position + MapOffset; }
    public void SetPosition(Vector2 position) { _position = position; }

    public abstract bool TryInteract(GameObject gameObject);
}