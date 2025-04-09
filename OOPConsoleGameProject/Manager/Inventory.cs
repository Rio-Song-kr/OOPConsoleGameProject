namespace OOPConsoleGameProject;

public class Inventory
{
    private static Inventory _instance;
    private List<Item> _items;
    private readonly int _size = 3;

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
        //todo UIManager가 추가되면 UIManager를 이용해서 출력해야 함
        Console.ResetColor();
        Console.SetCursorPosition(0, 6);
        Util.PrintConsole($"{item.Name}이 인벤토리에 추가되었습니다.                      ");
    }

    public void Remove(Item item) { _items.Remove(item); }

    public void RemoveAll() { _items = new List<Item>(); }

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
        //todo UIManager가 추가되면 UIManager를 이용해서 출력해야 함
        Util.PrintConsole($"인벤토리가 꽉 찼습니다.                   ", ConsoleColor.Red);
    }

    public bool IsExist(Item item) => _items.Contains(item);
}