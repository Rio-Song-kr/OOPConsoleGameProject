namespace OOPConsoleGameProject;

public class Level : Scene
{
    protected char[,] Map;
    protected string[] MapData;
    // protected List<GameObject> GameObjects;

    public Level()
    {
        MapData = new string[]
        {
            "########",
            "#   #  #",
            "#   #  #",
            "### #  #",
            "#      #",
            "########"
        };
    }

    public override void Render()
    {
        //todo 추후 Leve 화면에 맞게 수정 및 UIManager로 렌더링은 위임
        for (int y = 0; y < MapData.GetLength(0); y++)
        {
            for (int x = 0; x < MapData[0].Length; x++)
            {
                Console.Write(MapData[y][x]);
            }

            Console.WriteLine();
        }
    }

    public override void Input() { Console.ReadKey(true); }

    public override void Update() { }

    public override void Result() { }

    private void PrintMap() { }
}