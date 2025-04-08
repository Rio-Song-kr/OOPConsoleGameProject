namespace OOPConsoleGameProject;

public abstract class Item : GameObject, IUsable
{
    private string _name;
    public string Name { get => _name; protected set => _name = value; }
    private string _description;
    public string Description { get => _description; protected set => _description = value; }

    public Item(ConsoleColor color, char symbol, Vector2 position) : base(color, symbol, position, true) { }
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