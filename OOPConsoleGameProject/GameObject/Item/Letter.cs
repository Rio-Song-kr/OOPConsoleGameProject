namespace OOPConsoleGameProject;

public class Letter : Item
{
    public Letter(
        string name,
        string[] descriptions,
        ConsoleColor color,
        Vector2 position)
        : base(color, '▤', position)
    {
        Name = name;
        Description = new List<string>();

        foreach (string description in descriptions)
        {
            Description.Add(description);
        }
    }
    public override void Use() { }
}