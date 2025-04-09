namespace OOPConsoleGameProject;

public abstract class Item : GameObject, IUsable, ISelectable
{
    private string _name;
    public string Name { get => _name; protected set => _name = value; }
    private List<string> _description;
    public List<string> Description { get => _description; protected set => _description = value; }

    public Item(ConsoleColor color, char symbol, Vector2 position) : base(color, symbol, position, true) { }

    //todo 추후 UIManager 생성 후 수정
    public string GetInfo() => $"{_name},{_description}";

    public override bool TryInteract(GameObject gameObject)
    {
        if (gameObject is not Player)
            return false;

        GameManager.Inventory.Add(this);
        return true;
    }

    public abstract void Use();
    public abstract void Select();
}