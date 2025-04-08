namespace OOPConsoleGameProject;

public class Player : GameObject
{
    static Player _instance;

    private Player(Vector2 position) : base(ConsoleColor.Magenta, 'P', position, false) { }

    public static Player GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Player(new Vector2(1, 1));
        }

        return _instance;
    }

    public void SetPosition(Vector2 position) { Position = position; }

    public void Move(Vector2 direction)
    {
        Vector2 targetPosition = Position + direction;

        if (IsMovable(targetPosition)) Position = targetPosition;
    }

    private bool IsMovable(Vector2 position)
    {
        if (GameManager.Map.MapTile[position.Y, position.X] == TileType.Wall) return false;

        return true;
    }

    //todo UIManager가 추가되면 UIManager를 이용해서 출력해야 함
    public override void Interact(GameObject gameObject) { }
}