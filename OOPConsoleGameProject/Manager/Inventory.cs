namespace OOPConsoleGameProject;

public class Inventory
{
    private static Inventory _instance;
    private List<Item> _items;
    private readonly int _size = 3;

    private Inventory() { _items = new List<Item>(); }

    public static Inventory GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Inventory();
        }
        return _instance;
    }

    public void Add(Item item)
    {
        if (_items.Count == _size) return;
        _items.Add(item);
    }

    public void Remove(Item item) { _items.Remove(item); }

    public void UseAt(int index)
    {
        if (index < 0 || index >= _size) return;

        if (_items[index] is IUsable)
        {
            _items[index].Use();
        }
    }
}