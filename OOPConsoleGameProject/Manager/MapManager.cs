namespace OOPConsoleGameProject;

public class MapManager
{
    private static MapManager _instance;
    private TileType[,] _mapTileTile;
    public TileType[,] MapTile { get => _mapTileTile; }
    private string[] _mapData;
    public string[] MapData { get => _mapData; }
    private Vector2 _mapSize;
    public readonly static char WallSign = '#';
    public readonly static char GroundSign = ' ';

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
                if (_mapData[y][x] == WallSign)
                {
                    _mapTileTile[y, x] = TileType.Wall;
                }
                else if (_mapData[y][x] == GroundSign)
                {
                    _mapTileTile[y, x] = TileType.Ground;
                }
            }
        }
    }

    //todo UIManager가 추가되면 UIManager를 이용해서 출력해야 함
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