namespace OOPConsoleGameProject;

public class Rock : FieldObject
{
    private static string _name { get; } = "Rock";
    private static int _rockIndex = 0;

    public Rock(Vector2 position, ConsoleColor color = ConsoleColor.White) : base(color, 'Φ', position)
    {
        Name = _name;
        Index = _rockIndex++;
    }

    public override bool TryInteract(GameObject gameObject)
    {
        if (gameObject is not Player player)
            return false;

        if (Move(player.MovedDirection))
            return true;
        return false;
    }

    public bool Move(Vector2 direction)
    {
        Vector2 targetPosition = Position + direction;

        if (!IsMovable(targetPosition))
            return false;

        Position = targetPosition;
        return true;
    }

    private bool IsMovable(Vector2 position)
    {
        if (GameManager.Map.MapTile[position.Y - MapOffset.Y, position.X - MapOffset.Y] == TileType.Wall) return false;

        return true;
    }
}