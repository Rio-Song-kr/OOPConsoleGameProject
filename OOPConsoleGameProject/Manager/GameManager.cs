using System.Text;

namespace OOPConsoleGameProject;

public sealed class GameManager
{
    private static GameManager s_Instance;
    public static GameManager Instance { get => GetInstance(); }

    private static SceneManager _scene;
    public static SceneManager Scene { get => _scene; }

    private static InputManager _input = InputManager.GetInstance();
    public static InputManager Input { get => _input; }

    private static MapManager _map;
    public static MapManager Map { get => _map; }
    private static Inventory _inventory;
    public static Inventory Inventory { get => _inventory; }

    private static ObjectManager _objectPools = ObjectManager.GetInstance();
    public static ObjectManager ObjectPools { get => _objectPools; }
    private static UIManager _uiManager = UIManager.GetInstance();
    public static UIManager UI { get => _uiManager; }
    private static LogManager _log;
    public static LogManager Log { get => _log; }

    private static Player _player = Player.GetInstance();
    public static Player GamePlayer { get => _player; }

    private bool _isGameOver;

    private Dictionary<SceneName, Vector2> _mazeSize = new Dictionary<SceneName, Vector2>();
    public Dictionary<SceneName, Vector2> MazeSize { get => _mazeSize; }
    private Dictionary<SceneName, RenderArea> _area = new Dictionary<SceneName, RenderArea>();
    public Dictionary<SceneName, RenderArea> Area { get => _area; }

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
        //# 의존성 주입
        _log = LogManager.GetInstance(_uiManager);
        _inventory = Inventory.GetInstance(_uiManager);
        _map = MapManager.GetInstance(_uiManager);
        _scene = SceneManager.GetInstance(_uiManager);

        //# Console 창 커서 안보이게 변경
        Console.CursorVisible = false;

        //# ObjectPooling
        ObjectPooling();

        //# MazeSize 설정
        _mazeSize[SceneName.Level01] = new Vector2(33, 23);
        _mazeSize[SceneName.Level02] = new Vector2(43, 33);
        _mazeSize[SceneName.Level03] = new Vector2(53, 43);
        _mazeSize[SceneName.Level04] = new Vector2(73, 63);
        _mazeSize[SceneName.Level05] = new Vector2(93, 83);
        _mazeSize[SceneName.Level04] = new Vector2(113, 103);
        _mazeSize[SceneName.Level04] = new Vector2(153, 143);

        _mazeSize[SceneName.Dungeon01] = new Vector2(8, 8);
        _mazeSize[SceneName.Dungeon02] = new Vector2(8, 8);

        _area[SceneName.Level01] = RenderArea.Render31x15;
        _area[SceneName.Level02] = RenderArea.Render27x13;
        _area[SceneName.Level03] = RenderArea.Render23x11;
        _area[SceneName.Level04] = RenderArea.Render19x9;
        _area[SceneName.Level05] = RenderArea.Render15x7;
        _area[SceneName.Level06] = RenderArea.Render11x5;
        _area[SceneName.Dungeon01] = RenderArea.Render11x5;
        _area[SceneName.Dungeon02] = RenderArea.Render7x3;

        //# Scene 추가
        _scene.Add(SceneName.Start, new StartScene());
        _scene.Add(SceneName.End, new EndScene());
        _scene.Add(SceneName.Level01, new LevelScene01());
        _scene.Add(SceneName.Level02, new LevelScene02());
        _scene.Add(SceneName.Level03, new LevelScene03());
        _scene.Add(SceneName.Level04, new LevelScene04());
        _scene.Add(SceneName.Level05, new LevelScene04());
        _scene.Add(SceneName.Level06, new LevelScene04());
        _scene.Add(SceneName.Level07, new LevelScene04());
        _scene.Add(SceneName.Dungeon01, new DungeonScene01());
        _scene.Add(SceneName.Dungeon02, new DungeonScene02());

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

    private void ObjectPooling()
    {
        //# Item 생성
        _objectPools.AddItem(
            new Key(
                "Key",
                new string[] { "문을 여는데 사용하는 열쇠이다." },
                new Vector2(-1, -1))
        );
        _objectPools.AddItem(
            new Letter(
                "Letter",
                new string[] { "상자를 열 수 있는 힌트가 적힌 편지이다.", "4 + 5 = ?", "9 - 4 = ?", "2 X 4 = ?", "8 ÷ 4 = ?" },
                new Vector2(-1, -1))
        );
        _objectPools.AddItem(
            new MusicBox(
                "Music Box",
                new string[] { "음악 재생이 가능한 상자이다.", "들려오는 소리와 연관이 있지 않을까?", "♪ ♪ ♪ ♪" },
                new Vector2(-1, -1))
        );
        _objectPools.AddItem(
            new Navigation(
                "Navigation",
                new string[] { "문이 있는 곳까지 안내 해주는 네비게이션이다." },
                new Vector2(-1, -1))
        );

        //# Field Object 생성
        _objectPools.AddFieldObject(
            new Chest(
                "Letter Chest",
                new Vector2(-1, -1),
                new char[] { '9', '5', '8', '2' },
                new char[] { '1', '1', '1', '1' },
                ChestType.LetterChest)
        );
        _objectPools.AddFieldObject(
            new Chest(
                "Music Chest",
                new Vector2(-1, -1),
                new char[] { 'C', 'E', 'G', 'D' },
                new char[] { 'C', 'C', 'C', 'C' },
                ChestType.MusicBoxChest)
        );
        _objectPools.AddFieldObject(new Rock(new Vector2(-1, -1)));
        _objectPools.AddFieldObject(new Rock(new Vector2(-1, -1)));
        _objectPools.AddFieldObject(new Rock(new Vector2(-1, -1)));
        _objectPools.AddFieldObject(new Rock(new Vector2(-1, -1)));
        _objectPools.AddFieldObject(new Goal(new Vector2(-1, -1)));
        _objectPools.AddFieldObject(new Goal(new Vector2(-1, -1)));
        _objectPools.AddFieldObject(new Goal(new Vector2(-1, -1)));
        _objectPools.AddFieldObject(new Goal(new Vector2(-1, -1)));
    }

    public void Run()
    {
        Start();
        UI.RenderUI();

        do
        {
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