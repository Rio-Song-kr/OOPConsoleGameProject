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
                //# 인벤토리에서 아이템 선택
                //# 만약 해당 자리가 비어있으면, currentIndex를 -1로 변경
                //# 별도로 실행은 되지 않음
                OnSelect(input - ConsoleKey.D1);
                break;
            case ConsoleKey.U:
                //# 사용이 가능한 아이템이 열려있는 상태에서 U를 누르면 아이템 사용
                OnUse();
                break;
            case ConsoleKey.Escape:
                //# 아이템 선택 취소 시 currentIndex를 -1로 변경
                OnSelect(-1);
                break;
        }

        return input;
    }

    public void PressAnyKey() { Console.ReadKey(true); }
}