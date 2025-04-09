namespace OOPConsoleGameProject;

public interface IMapPrint
{
    public void PrintMap(TileType[,] mapTile, Vector2 mapSize);
    public void ClearMapArea();
}