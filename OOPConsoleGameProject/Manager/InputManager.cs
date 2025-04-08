namespace OOPConsoleGameProject;

public class InputManager
{
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

    public ConsoleKey GetKey() { return Console.ReadKey(true).Key; }
}