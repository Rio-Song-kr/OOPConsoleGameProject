namespace OOPConsoleGameProject;

public class Inventory
{
    //todo 현재 인벤토리에서 제거하면서 Inventory에 표시되는 아이템을 앞으로 당겨야할 듯
    //todo 아니면 배열과 queue이용? - queue비어있는 index를 저장 -> 아이템이 추가횔 때 queue꺼내서 사용
    //todo 아이템을 사용할 때, queue 목록과 비교하여, 일치하면 아무것도 하지 않음, 그게 아니면 배열로 접근해서 사용
    private IItemPrint _ui;

    private static Inventory _instance;
    private Item[] _items;
    private readonly int _size = 3;
    private Queue<int> _emptyQueue;

    private int _currentItemIndex = -1;
    public bool PrintItemInfo = false;

    private Inventory(IItemPrint ui)
    {
        _items = new Item[_size];
        _ui = ui;
        _emptyQueue = new Queue<int>();
        for (int i = 0; i < _size; i++)
            _emptyQueue.Enqueue(i);
    }

    public static Inventory GetInstance(IItemPrint ui)
    {
        if (_instance == null)
        {
            _instance = new Inventory(ui);
        }
        return _instance;
    }

    public void Add(Item item)
    {
        if (_emptyQueue.Count == 0) return;
        int index = _emptyQueue.Dequeue();
        _items[index] = item;
        _ui.PrintItem(item, index);
        GameManager.Log.Log($"{item.Name}이/가 인벤토리에 추가되었습니다.", ConsoleColor.DarkGreen);
    }

    public void Remove(Item item)
    {
        for (int i = 0; i < _size; i++)
        {
            if (_items[i] == item)
            {
                _ui.PrintEmptyItem(i);
                _emptyQueue.Enqueue(i);
                _items[i] = null;
            }
        }
    }

    public void RemoveAll()
    {
        _emptyQueue.Clear();
        for (int i = 0; i < _size; i++)
        {
            _ui.PrintEmptyItem(i);
            _emptyQueue.Enqueue(i);
            _items[i] = null;
        }
        GameManager.Log.Log("인벤토리가 초기화되었습니다.", ConsoleColor.DarkMagenta);
    }

    public void SelectAt(int index)
    {
        if (index < 0 || index >= _size)
        {
            _currentItemIndex = -1;
            return;
        }

        if (_items[index] == null) return;

        _currentItemIndex = index;

        if (_items[_currentItemIndex] is ISelectable selectableItem)
        {
            selectableItem.Select();
        }
    }

    public void UseAt()
    {
        if (_currentItemIndex == -1) return;
        if (_items[_currentItemIndex] == null) return;
        if (_items[_currentItemIndex] is not IUsable usableItem) return;
        if (_items[_currentItemIndex] is not Navigation) return;

        usableItem.Use();
        _ui.PrintEmptyItem(_currentItemIndex);
        _items[_currentItemIndex] = null;
        _emptyQueue.Enqueue(_currentItemIndex);
    }

    public void IsFull()
    {
        Console.SetCursorPosition(0, 6);
        GameManager.Log.Log("인벤토리가 꽉 찼습니다.", ConsoleColor.Red);
    }

    public bool IsExist(Item item)
    {
        foreach (var i in _items)
        {
            if (i == item) return true;
        }
        return false;
    }

    public void PrintInfo(Item item)
    {
        PrintItemInfo = true;
        _ui.PrintItemInfo(item);
    }

    public string GetSelectedItem() => _items[_currentItemIndex].Name;
}