namespace OOPConsoleGameProject;

public class Player
{
    static Player _instance;

    public ConsoleColor Color;
    public char Symbol;
    private Vector2 _position;
    public Vector2 Position { get => _position; }

    public static Player GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Player(new Vector2(1, 1));
        }

        return _instance;
    }

    private Player(Vector2 position)
    {
        Color = ConsoleColor.Magenta;
        Symbol = 'P';
        _position = position;
    }

    public void SetPosition(Vector2 position) { _position = position; }

    public void Move(Vector2 direction)
    {
        Vector2 targetPosition = _position + direction;

        if (IsMovable(targetPosition)) _position = targetPosition;
    }

    private bool IsMovable(Vector2 position)
    {
        if (GameManager.Map.MapTile[position.Y, position.X] == TileType.Wall) return false;

        return true;
    }

    //todo UI 매니저와 연결해야 할 수도 있음
    public void Print()
    {
        Console.SetCursorPosition(Position.X, Position.Y);
        Console.ForegroundColor = Color;
        Console.Write(Symbol);
        Console.ResetColor();
    }
}