namespace OOPConsoleGameProject;

public sealed class GameManager
{
    private static GameManager s_Instance;
    public static GameManager Instance { get => GetInstance(); }

    private static SceneManager _scene = SceneManager.GetInstance();
    public static SceneManager Scene { get => _scene; }

    private static InputManager _input = InputManager.GetInstance();
    public static InputManager Input { get => _input; }

    private static MapManager _map = MapManager.GetInstance();
    public static MapManager Map { get => _map; }
    private static Inventory _inventory = Inventory.GetInstance();
    public static Inventory Inventory { get => _inventory; }

    private static ObjectManager _objectPools = ObjectManager.GetInstance();
    public static ObjectManager ObjectPools { get => _objectPools; }

    private static Player _player = Player.GetInstance();
    public static Player GamePlayer { get => _player; }

    private bool _isGameOver;

    private static GameManager GetInstance()
    {
        if (s_Instance == null)
        {
            s_Instance = new GameManager();
        }
        return s_Instance;
    }

    private void Start()
    {
        //# Console 창 커서 안보이게 변경
        Console.CursorVisible = false;

        //! Object Pooling
        //# Item 생성
        _objectPools.AddItem(
            new Key(
                "Key",
                new string[] { "문을 여는데 사용하는 열쇠이다." },
                ConsoleColor.Yellow,
                new Vector2(-1, -1))
        );
        _objectPools.AddItem(
            new Letter(
                "Letter",
                new string[] { "상자를 열 수 있는 힌트가 적힌 편지이다.", "4 + 5 = ?", "9 - 4 = ?", "2 X 4 = ?", "8 ÷ 4 = ?" },
                ConsoleColor.Yellow,
                new Vector2(-1, -1))
        );
        _objectPools.AddItem(
            new MusicBox(
                "Music Box",
                new string[] { "음악 재생이 가능한 상자이자.", "들려오는 소리와 연관이 있지 않을까?", "♪ ♪ ♪ ♪" },
                ConsoleColor.Yellow,
                new Vector2(-1, -1))
        );
        _objectPools.AddItem(
            new Navigation(
                "Navigation",
                new string[] { "문이 있는 곳까지 안내 해주는 네비게이션." },
                ConsoleColor.Yellow,
                new Vector2(-1, -1))
        );

        //# Field Object 생성
        _objectPools.AddFieldObject(new Chest(ConsoleColor.Blue, new Vector2(-1, -1)));
        _objectPools.AddFieldObject(new Rock(ConsoleColor.White, new Vector2(-1, -1)));
        _objectPools.AddFieldObject(new Rock(ConsoleColor.White, new Vector2(-1, -1)));
        _objectPools.AddFieldObject(new Rock(ConsoleColor.White, new Vector2(-1, -1)));
        _objectPools.AddFieldObject(new Rock(ConsoleColor.White, new Vector2(-1, -1)));
        _objectPools.AddFieldObject(new Goal(ConsoleColor.DarkGreen, new Vector2(-1, -1)));
        _objectPools.AddFieldObject(new Goal(ConsoleColor.DarkGreen, new Vector2(-1, -1)));
        _objectPools.AddFieldObject(new Goal(ConsoleColor.DarkGreen, new Vector2(-1, -1)));
        _objectPools.AddFieldObject(new Goal(ConsoleColor.DarkGreen, new Vector2(-1, -1)));

        //# Scene 추가
        _scene.Add(SceneName.Start, new StartScene());
        _scene.Add(SceneName.End, new EndScene());
        _scene.Add(SceneName.Level01, new LevelScene01());
        _scene.Add(SceneName.Level02, new LevelScene02());
        _scene.Add(SceneName.Level03, new LevelScene03());

        //# 현재 Scene 설정
        _scene.Move(SceneName.Start);

        //# InputManager의 OnMove에 Player Move 연결
        _input.OnMove -= _player.Move;
        _input.OnMove += _player.Move;

        //# InputManager의 OnUse에 Inventory UseAt 연결
        _input.OnSelect -= _inventory.SelectAt;
        _input.OnSelect += _inventory.SelectAt;

        _input.OnUse -= _inventory.UseAt;
        _input.OnUse += _inventory.UseAt;
    }

    public void Run()
    {
        Start();
        do
        {
            Console.SetCursorPosition(0, 0);
            _scene.CurrentScene.Render();
            _scene.CurrentScene.Input();
            _scene.CurrentScene.Update();
            _scene.CurrentScene.Result();
        } while (!_isGameOver);

        End();
    }

    private void End() { }

    public void GameOver() { _isGameOver = true; }
}