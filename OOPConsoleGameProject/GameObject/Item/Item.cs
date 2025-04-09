namespace OOPConsoleGameProject;

public abstract class Item : GameObject, IUsable, ISelectable
{
    private string _name;
    public string Name { get => _name; protected set => _name = value; }
    private List<string> _description;
    public List<string> Description { get => _description; protected set => _description = value; }

    public Item(ConsoleColor color, char symbol, Vector2 position) : base(color, symbol, position, true) { }

    public override bool TryInteract(GameObject gameObject)
    {
        if (gameObject is not Player)
            return false;

        GameManager.Inventory.Add(this);
        return true;
    }

    public abstract void Use();

    public void Select()
    {
        GameManager.Log.Log($"{Name} 정보창을 열었습니다", ConsoleColor.Cyan);
        GameManager.Inventory.PrintInfo(this);
    }
}