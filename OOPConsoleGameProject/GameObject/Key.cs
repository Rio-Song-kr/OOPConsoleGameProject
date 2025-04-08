namespace OOPConsoleGameProject;

public class Key : Item
{
    public Key(string name, string description, ConsoleColor color, Vector2 position) : base(color, '♀', position)
    {
        Name = name;
        Description = description;
    }

    public override void Use()
    {
        //todo Item 사용 관련 처리가 필요함
    }
}