namespace OOPConsoleGameProject;

public class InputManager
{
    public event Action<Vector2> OnMove;
    public event Action<int> OnUse;
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
                OnUse(input - ConsoleKey.D1);
                break;
        }

        return input;
    }

    public void PressAnyKey() { Console.ReadKey(true); }
}