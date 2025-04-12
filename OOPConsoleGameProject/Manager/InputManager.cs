namespace OOPConsoleGameProject;

public class InputManager
{
    public event Action<Vector2> OnMove;
    public event Action OnUse;
    public event Action<int> OnSelect;
    private static InputManager _instance;
    private InputManager() { }

    public static InputManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new InputManager();
        }

        return _instance;
    }

    public ConsoleKey GetKey()
    {
        ConsoleKey input = Console.ReadKey(true).Key;

        if (GameManager.Inventory.PrintItemInfo)
        {
            if (input == ConsoleKey.U)
            {
                GameManager.Log.Log($"{GameManager.Inventory.GetSelectedItem()}을/를 사용합니다.", ConsoleColor.Yellow);
                OnUse();
            }
            OnSelect(-1);
            GameManager.Map.ClearMap();
            GameManager.Inventory.PrintItemInfo = false;
            GameManager.Log.Log("아이템 정보창을 닫았습니다", ConsoleColor.Cyan);
            return input;
        }

        switch (input)
        {
            case ConsoleKey.UpArrow:
                OnMove(Vector2.Up);
                break;
            case ConsoleKey.DownArrow:
                OnMove(Vector2.Down);
                break;
            case ConsoleKey.LeftArrow:
                OnMove(Vector2.Left);
                break;
            case ConsoleKey.RightArrow:
                OnMove(Vector2.Right);
                break;
            case ConsoleKey.D1:
            case ConsoleKey.D2:
            case ConsoleKey.D3:
                OnSelect(input - ConsoleKey.D1);
                break;
        }
        Util.Sleep(10);

        return input;
    }

    public void PressAnyKey() { Console.ReadKey(true); }
}