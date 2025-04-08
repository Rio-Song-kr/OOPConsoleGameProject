namespace OOPConsoleGameProject;

public class GameManager
{
    private static GameManager s_Instance;

    public static GameManager Instance
    {
        get
        {
            Init();
            return s_Instance;
        }
    }

    private bool _isGameOver;
    private static SceneManager _scene = SceneManager.GetInstance();
    public static SceneManager Scene { get => _scene; }
    private static InputManager _input = InputManager.GetInstance();
    public static InputManager Input { get => _input; }

    //# 싱글톤
    public static void Init()
    {
        if (s_Instance == null)
        {
            s_Instance = new GameManager();
        }
    }

    private void Start()
    {
        //# Console 창 커서 안보이게 변경
        Console.CursorVisible = false;

        //# Scene 추가
        _scene.Add(SceneName.Start, new StartScene());
        _scene.Add(SceneName.End, new EndScene());
        _scene.Add(SceneName.Level01, new LevelScene01());

        //# 현재 Scene 설정
        _scene.Move(StartScene.Name);
    }

    public void Run()
    {
        Start();
        do
        {
            Console.Clear();
            _scene.CurrentScene.Render();
            _scene.CurrentScene.Input();
            _scene.CurrentScene.Update();
            _scene.CurrentScene.Result();
        } while (!_isGameOver);

        End();
    }

    private void End() { }
}