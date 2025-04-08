namespace OOPConsoleGameProject;

public class MapManager
{
    private static MapManager _instance;
    private TileType[,] _mapTileTile;
    public TileType[,] MapTile { get => _mapTileTile; }
    private string[] _mapData;
    public string[] MapData { get => _mapData; }
    private Vector2 _mapSize;

    private MapManager() { }

    public static MapManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new MapManager();
        }

        return _instance;
    }


    public void SetMapData(string[] mapData)
    {
        _mapSize = new Vector2(mapData[0].Length, mapData.GetLength(0));
        _mapData = mapData;
        _mapTileTile = new TileType[_mapSize.Y, _mapSize.X];

        for (int y = 0; y < _mapSize.Y; y++)
        {
            for (int x = 0; x < _mapSize.X; x++)
            {
                if (_mapData[y][x] == '#')
                {
                    _mapTileTile[y, x] = TileType.Wall;
                }
                else if (_mapData[y][x] == ' ')
                {
                    _mapTileTile[y, x] = TileType.Ground;
                }
            }
        }
    }

    public void Print()
    {
        for (int y = 0; y < _mapSize.Y; y++)
        {
            for (int x = 0; x < _mapSize.X; x++)
            {
                Console.Write(_mapData[y][x]);
            }

            Console.WriteLine();
        }
    }
}