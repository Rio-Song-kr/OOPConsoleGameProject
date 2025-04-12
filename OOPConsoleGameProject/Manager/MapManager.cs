namespace OOPConsoleGameProject;

public class MapManager
{
    private static MapManager _instance;

    public readonly static char WallSign = '#';
    public readonly static char GroundSign = ' ';

    private TileType[,] _mapTile;
    public TileType[,] MapTile { get => _mapTile; }

    private Vector2 _mapSize;
    private IMapPrint _print;

    private MapManager(IMapPrint print) { _print = print; }

    public static MapManager GetInstance(IMapPrint print)
    {
        if (_instance == null)
        {
            _instance = new MapManager(print);
        }

        return _instance;
    }

    public void SetMapData(TileType[,] tileType)
    {
        _mapTile = tileType;
        _mapSize = new Vector2(tileType.GetLength(1), tileType.GetLength(0));
    }

    public void Print(RenderArea renderArea = RenderArea.Render31x15)
    {
        _print.PrintLimitedSightMap(_mapTile, _mapSize, renderArea);
    }

    public void ClearMap() { _print.ClearMapArea(); }
}