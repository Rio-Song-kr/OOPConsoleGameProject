namespace OOPConsoleGameProject;

public class Player : GameObject
{
    static Player _instance;
    public Vector2 MovedDirection { get; private set; }

    private Player(Vector2 position) : base(ConsoleColor.Magenta, 'P', position, false)
    {
        MovedDirection = new Vector2(0, 0);
    }

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
        // if (GameManager.Map.MapTile[position.Y - MapOffset.Y, position.X - MapOffset.X] == TileType.Wall) return false;
        if (GameManager.Map.MapTile[position.Y, position.X] == TileType.Wall) return false;

        return true;
    }

    public override bool TryInteract(GameObject gameObject) { return false; }
}