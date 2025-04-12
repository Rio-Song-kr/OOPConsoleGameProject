namespace OOPConsoleGameProject;

public abstract class Scene
{
    public bool IsFirstLoad = true;
    protected TileType[,] MapTile;
    protected List<GameObject> GameObjects;
    protected RenderArea Area;
    protected IPassedRoadPrint _print = GameManager.UI;
    public List<Vector2> ObjectsPosition { get; protected set; } = new List<Vector2>();

    public virtual void Render()
    {
        if (!GameManager.Inventory.PrintItemInfo)
        {
            GameManager.Map.Print(Area);

            _print.PrintPassedRoad(ObjectsPosition);

            foreach (var gameObject in GameObjects)
            {
                gameObject.Print();
            }

            GameManager.GamePlayer.Print();
        }
    }

    public abstract void Input();
    public abstract void Update();
    public abstract void Result();

    public virtual void OnEnter() { }

    public virtual void OnExit() { }
}