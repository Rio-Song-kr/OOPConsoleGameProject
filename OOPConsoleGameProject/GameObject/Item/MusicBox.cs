namespace OOPConsoleGameProject;

public class MusicBox : Item
{
    public MusicBox(
        string name,
        string[] descriptions,
        ConsoleColor color,
        Vector2 position)
        : base(color, '♩', position)
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