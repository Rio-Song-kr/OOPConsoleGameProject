namespace OOPConsoleGameProject;

public static class Maze
{
    public static readonly char Wall = '▒';
    private static TileType[,] _mapTile;
    private static bool[,] _visitedMapTile;
    private static Vector2 _mapSize;
    public static Vector2 MapSize { get => _mapSize; }

    static Maze() { }

    public static TileType[,] GenerateBySideWinder(Vector2 size)
    {
        size.X += size.X % 2 == 0 ? 1 : 0;
        size.Y += size.Y % 2 == 0 ? 1 : 0;

        _mapSize = size;
        _mapTile = new TileType[size.Y, size.X];

        //# 길막기
        for (int y = 0; y < _mapSize.Y; y++)
        {
            for (int x = 0; x < _mapSize.X; x++)
            {
                if (x % 2 == 0 || y % 2 == 0)
                    _mapTile[y, x] = TileType.Wall;
                else
                    _mapTile[y, x] = TileType.Ground;
            }
        }

        //# 길뚫기
        Random rand = new Random();
        for (int y = 0; y < _mapSize.Y; y++)
        {
            //# 우측 길 개수 측정
            int count = 1;
            for (int x = 0; x < _mapSize.X; x++)
            {
                if (x % 2 == 0 || y % 2 == 0)
                    continue;

                if (x == _mapSize.X - 2 && y == _mapSize.Y - 2)

                    //# 가장 아래쪽은 일자로 뚫음
                    if (y == _mapSize.Y - 2)
                    {
                        _mapTile[y, x + 1] = TileType.Ground;
                        continue;
                    }

                //# 가장 오른쪽은 일자로 뚫음
                if (x == _mapSize.X - 2)
                {
                    _mapTile[y + 1, x] = TileType.Ground;
                    continue;
                }

                if (rand.Next(0, 2) == 0)
                {
                    _mapTile[y, x + 1] = TileType.Ground;
                    count++;
                }
                else
                {
                    int randomIndex = rand.Next(0, count);
                    _mapTile[y + 1, x - randomIndex * 2] = TileType.Ground;
                    count = 1;
                }
            }
        }
        return _mapTile;
    }
    public static TileType[,] GenerateByBacktracking(int xPos, int yPos, Vector2 size)
    {
        size.X += size.X % 2 == 0 ? 1 : 0;
        size.Y += size.Y % 2 == 0 ? 1 : 0;

        _mapSize = size;
        _mapTile = new TileType[size.Y, size.X];
        _visitedMapTile = new bool[_mapSize.Y, _mapSize.X];

        InitializeMapTile();
        GenerateBacktrackingMaze(xPos, yPos);
        return _mapTile;
    }

    private static void GenerateBacktrackingMaze(int xPos, int yPos)
    {
        //# 시작 위치 설정
        _visitedMapTile[yPos, xPos] = true;
        _mapTile[yPos, xPos] = TileType.Ground;

        List<(int dx, int dy)> directions = new List<(int dx, int dy)>
        {
            (0, -2),
            (0, 2),
            (-2, 0),
            (2, 0)
        };

        RandomDirection(directions);

        foreach (var (dx, dy) in directions)
        {
            int nx = xPos + dx;
            int ny = yPos + dy;

            if (IsInBounds(nx, ny) && !_visitedMapTile[ny, nx])
            {
                _mapTile[yPos + dy / 2, xPos + dx / 2] = TileType.Ground;
                GenerateBacktrackingMaze(nx, ny);
            }
        }
    }

    private static void InitializeMapTile()
    {
        //# 모두 벽으로 채움
        for (int y = 0; y < _mapSize.Y; y++)
        {
            for (int x = 0; x < _mapSize.X; x++)
            {
                _mapTile[y, x] = TileType.Wall;
            }
        }
    }
    private static bool IsInBounds(int xPos, int yPos)
        => xPos > 0 && xPos < _mapSize.X - 1 && yPos > 0 && yPos < _mapSize.Y - 1;
    private static void RandomDirection(List<(int dx, int dy)> directions)
    {
        Random rand = new Random();
        for (int i = directions.Count - 1; i > 0; i--)
        {
            int j = rand.Next(i + 1);
            (directions[i], directions[j]) = (directions[j], directions[i]);
        }
    }
}