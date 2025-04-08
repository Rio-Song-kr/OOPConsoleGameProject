namespace OOPConsoleGameProject;

public class SceneManager
{
    private static SceneManager _instance;
    private Dictionary<SceneName, Scene> _scenes;

    private SceneName _previousScene;
    public SceneName PreviousScene { get => _previousScene; }
    private Scene _currentScene;

    public Scene CurrentScene { get => _currentScene; }

    private SceneManager() { _scenes = new Dictionary<SceneName, Scene>(); }

    public static SceneManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new SceneManager();
        }

        return _instance;
    }

    public void Add(SceneName sceneName, Scene scene) { _scenes.Add(sceneName, scene); }

    public void Move(SceneName sceneName)
    {
        if (_scenes.ContainsKey(sceneName))
        {
            Console.Clear();
            if (_currentScene != null)
            {
                _previousScene = PreviousScene;
                _currentScene.OnExit();
            }

            _currentScene = _scenes[sceneName];
            _currentScene.OnEnter();

            if (_currentScene.IsFirstLoad) _currentScene.IsFirstLoad = false;
        }
    }
}