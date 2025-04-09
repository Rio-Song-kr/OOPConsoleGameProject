namespace OOPConsoleGameProject;

public class Inventory
{
    private static Inventory _instance;
    private List<Item> _items;
    private readonly int _size = 3;
    public event Action<Item, int> OnAdd;
    public event Action<int> OnRemove;

    private Inventory() { _items = new List<Item>(); }
    private int currentItemIndex = -1;

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
        int index = _items.IndexOf(item);
        OnAdd(item, index);
        GameManager.Log.Log($"{item.Name}이/가 인벤토리에 추가되었습니다.", ConsoleColor.DarkGreen);
    }

    public void Remove(Item item) { _items.Remove(item); }

    public void RemoveAll()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            OnRemove(i);
        }
        _items = new List<Item>();
        GameManager.Log.Log("인벤토리가 초기화되었습니다.", ConsoleColor.DarkMagenta);
    }

    public void SelectAt(int index)
    {
        if (index < 0 || index >= _size || index >= _items.Count)
        {
            currentItemIndex = -1;
            return;
        }

        currentItemIndex = index;

        if (_items[currentItemIndex] is ISelectable selectableItem)
        {
            //todo Select 시 아이템 정보가 출력되게 변경
            selectableItem.Select();
        }
    }

    public void UseAt()
    {
        if (currentItemIndex == -1) return;

        if (_items[currentItemIndex] is IUsable usableItem)
        {
            usableItem.Use();
        }
    }

    public void IsFull()
    {
        Console.SetCursorPosition(0, 6);
        GameManager.Log.Log("인벤토리가 꽉 찼습니다.", ConsoleColor.Red);
    }

    public bool IsExist(Item item) => _items.Contains(item);
}