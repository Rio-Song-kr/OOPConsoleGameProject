namespace OOPConsoleGameProject;

public class Key : Item
{
    public Key(
        string name,
        string[] descriptions,
        Vector2 position,
        ConsoleColor color = ConsoleColor.Yellow)
        : base(color, '♀', position)
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