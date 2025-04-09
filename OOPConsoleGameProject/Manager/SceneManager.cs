namespace OOPConsoleGameProject;

public class SceneManager
{
    private static SceneManager _instance;
    private Dictionary<SceneName, Scene> _scenes;
    private ITextPrint _print;

    private SceneName _previousScene;
    public SceneName PreviousScene { get => _previousScene; }
    private Scene _currentScene;
    public Scene CurrentScene { get => _currentScene; }

    private SceneManager(ITextPrint print)
    {
        _scenes = new Dictionary<SceneName, Scene>();
        _print = print;
    }

    public static SceneManager GetInstance(ITextPrint print)
    {
        if (_instance == null)
        {
            _instance = new SceneManager(print);
        }

        return _instance;
    }

    public void Add(SceneName sceneName, Scene scene) { _scenes.Add(sceneName, scene); }

    public void Move(SceneName sceneName)
    {
        if (_scenes.ContainsKey(sceneName))
        {
            if (_currentScene != null)
            {
                _currentScene.OnExit();
            }

            _currentScene = _scenes[sceneName];
            _currentScene.OnEnter();

            if (_currentScene.IsFirstLoad) _currentScene.IsFirstLoad = false;
            _previousScene = sceneName;
        }
    }

    public void PrintText(string[] texts, bool isSequentially, int delay = 0)
    {
        _print.PrintTextAtCenter(texts, isSequentially, delay);
    }
}