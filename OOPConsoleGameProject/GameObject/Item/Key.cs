namespace OOPConsoleGameProject;

public class Key : Item
{
    public Key(string name, string[] descriptions, ConsoleColor color, Vector2 position) : base(color, '♀', position)
    {
        Name = name;
        Description = new List<string>();

        foreach (string description in descriptions)
        {
            Description.Add(description);
        }
    }

    public override void Use()
    {
        //todo Item 사용 관련 처리가 필요함
    }
}