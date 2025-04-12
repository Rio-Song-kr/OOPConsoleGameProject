namespace OOPConsoleGameProject;

public class Navigation : Item
{
    public Navigation(
        string name,
        string[] descriptions,
        Vector2 position,
        ConsoleColor color = ConsoleColor.Yellow)
        : base(color, 'ξ', position)
    {
        Name = name;
        Description = new List<string>();

        foreach (string description in descriptions)
        {
            Description.Add(description);
        }
    }

    public override void Use() { GameManager.GamePlayer.UseNavigation(); }
}