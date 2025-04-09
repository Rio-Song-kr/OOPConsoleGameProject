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

    public override void Interact(GameObject gameObject) { }
}