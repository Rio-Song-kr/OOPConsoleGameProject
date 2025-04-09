namespace OOPConsoleGameProject;

public class Player : GameObject
{
    static Player _instance;

    private Player(Vector2 position) : base(ConsoleColor.Magenta, 'P', position, false) { }
    public Vector2 MovedDirection { get; private set; }

    public static Player GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Player(new Vector2(1, 1));
        }

        return _instance;
    }

    public void Move(Vector2 direction)
    {
        Vector2 targetPosition = Position + direction;

        if (IsMovable(targetPosition))
        {
            Position = targetPosition;
            MovedDirection = direction;
        }
    }

    private bool IsMovable(Vector2 position)
    {
        if (GameManager.Map.MapTile[position.Y - Offset.Y, position.X - Offset.X] == TileType.Wall) return false;

        return true;
    }

    public override bool TryInteract(GameObject gameObject) { return false; }
}