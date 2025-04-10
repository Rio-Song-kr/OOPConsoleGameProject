namespace OOPConsoleGameProject;

public interface IMapPrint
{
    public void PrintMap(TileType[,] mapTile, Vector2 mapSize);
    public void PrintLimitedSightMap(TileType[,] mapTile, Vector2 mapSize, RenderArea renderArea);
    public void ClearMapArea();
}