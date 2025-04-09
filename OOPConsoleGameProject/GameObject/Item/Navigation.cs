namespace OOPConsoleGameProject;

public class Navigation : Item
{
    public Navigation(
        string name,
        string[] descriptions,
        ConsoleColor color,
        Vector2 position)
        : base(color, 'ξ', position)
    {
        Name = name;
        Description = new List<string>();

        foreach (string description in descriptions)
        {
            Description.Add(description);
        }
    }

    public override void Use() { }
    public override void Select() { }
}