namespace OOPConsoleGameProject;

public abstract class FieldObject : GameObject
{
    private string _name;
    public string Name { get => _name; protected set => _name = value; }
    private int _index;
    public int Index { get => _index; protected set => _index = value; }

    public FieldObject(ConsoleColor color, char symbol, Vector2 position) : base(color, symbol, position, false) { }

    //todo 추후 UIManager 생성 후 수정
    public string GetInfo() => $"{_index}";
}