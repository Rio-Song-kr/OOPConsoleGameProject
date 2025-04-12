namespace OOPConsoleGameProject;

public class Player : GameObject
{
    static Player _instance;

    public Vector2 MovedDirection { get; private set; }
    private Stack<Vector2> _passedRoad;
    public Stack<Vector2> PassedRoad { get => _passedRoad; private set => _passedRoad = value; }

    private Player(Vector2 position) : base(ConsoleColor.Magenta, 'P', position, false)
    {
        MovedDirection = new Vector2(0, 0);
        _passedRoad = new Stack<Vector2>();
        PassedRoad = new Stack<Vector2>();
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
            if (_passedRoad.Count != 0 && targetPosition == _passedRoad.Peek()) _passedRoad.Pop();
            else _passedRoad.Push(Position);
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

    public void Init()
    {
        _passedRoad = new Stack<Vector2>();
        MovedDirection = new Vector2(1, 1);
    }

    public override bool TryInteract(GameObject gameObject) { return false; }
}