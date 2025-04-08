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
        //todo UIManager가 추가되면 UIManager를 이용해서 출력해야 함
        Console.SetCursorPosition(0, 6);
        Util.PrintConsole($"{item.Name}이 인벤토리에 추가되었습니다.", delay: 200);
    }

    public void Remove(Item item) { _items.Remove(item); }

    public void UseAt(int index)
    {
        if (index < 0 || index >= _size || index >= _items.Count) return;

        if (_items[index] is IUsable)
        {
            _items[index].Use();
        }
    }

    public bool IsExist(Item item) => _items.Contains(item);
}