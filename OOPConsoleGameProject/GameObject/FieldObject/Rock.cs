namespace OOPConsoleGameProject;

public class Rock : FieldObject
{
    //todo 던전 맵(소코반)에서 사용할 돌이 올라갈 돌
    private static string _name { get; } = "Rock";
    private static int _rockIndex = 0;

    public Rock(ConsoleColor color, Vector2 position) : base(color, 'Φ', position)
    {
        Name = _name;
        Index = _rockIndex++;
    }

    public override bool TryInteract(GameObject gameObject)
    {
        //todo FieldObject는 Player 뿐만 아니라 Rock <-> Goal상호작용을 함
        if (gameObject is not Player player)
            return false;

        //todo 돌과 플레이어가 부딪힐 경우 상호작용 추가
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
        if (GameManager.Map.MapTile[position.Y - Offset.Y, position.X - Offset.Y] == TileType.Wall) return false;

        return true;
    }
}