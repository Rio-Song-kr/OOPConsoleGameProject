namespace OOPConsoleGameProject;

public class ItemManager
{
    private static ItemManager _instance;
    private Dictionary<string, Item> _itemPools;
    private ItemManager() { _itemPools = new Dictionary<string, Item>(); }

    public static ItemManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new ItemManager();
        }
        return _instance;
    }

    public void AddItem(Item item) { _itemPools[item.Name] = item; }
    public void RemoveItem(Item item) { _itemPools.Remove(item.Name); }
    public Item GetItem(string name)
    {
        if (_itemPools.ContainsKey(name))
        {
            return _itemPools[name];
        }
        return null;
    }
}