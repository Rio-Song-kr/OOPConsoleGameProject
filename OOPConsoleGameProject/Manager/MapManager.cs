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
        _mapSize = new Vector2(tileType.GetLength(1), tileType.GetLength(0));
        _mapTile = tileType;
    }

    public void Print() { _print.PrintMap(_mapTile, _mapSize); }
    public void ClearMap() { _print.ClearMapArea(); }
}