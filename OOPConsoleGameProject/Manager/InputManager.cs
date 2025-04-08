namespace OOPConsoleGameProject;

public class InputManager
{
    public event Action<Vector2> OnMove;

    private static InputManager _instance;
    private InputManager() { }
    //todo event 또는 delegate로 Key 입력에 대해서 전파를 해야 하는가 추가 고민 필요함

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
        }

        return input;
    }
}