namespace OOPConsoleGameProject;

public abstract class Item : GameObject, IUsable
{
    private string _name;
    public string Name { get => _name; protected set => _name = value; }
    private List<string> _description;
    public List<string> Description { get => _description; protected set => _description = value; }

    public Item(ConsoleColor color, char symbol, Vector2 position) : base(color, symbol, position, true) { }

    //todo 추후 UIManager 생성 후 수정
    public string GetInfo() => $"{_name},{_description}";

    public override void Interact(GameObject gameObject)
    {
        if (gameObject is Player)
        {
            GameManager.Inventory.Add(this);
        }
    }

    public abstract void Use();
}