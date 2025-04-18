namespace OOPConsoleGameProject;

public static class Util
{
    public static void PrintConsole(string message, ConsoleColor textColor = ConsoleColor.White, int delay = 0,
        ConsoleColor backgroundColor = ConsoleColor.Black)
    {
        Console.BackgroundColor = backgroundColor;
        Console.ForegroundColor = textColor;
        Console.Write(message);
        Thread.Sleep(delay);
        Console.ResetColor();
    }

    public static void PrintConsole(char character, ConsoleColor textColor = ConsoleColor.White, int delay = 0,
        ConsoleColor backgroundColor = ConsoleColor.Black)
    {
        Console.BackgroundColor = backgroundColor;
        Console.ForegroundColor = textColor;
        Console.Write(character);
        Thread.Sleep(delay);
        Console.ResetColor();
    }

    public static void PrintCharacterSequentially(string message, ConsoleColor textColor = ConsoleColor.White,
        int delay = 0, ConsoleColor backgroundColor = ConsoleColor.Black)
    {
        Console.BackgroundColor = backgroundColor;
        Console.ForegroundColor = textColor;
        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(delay);
        }

        Console.ResetColor();
    }

    public static int GetMessageWidth(string message)
    {
        int width = 0;
        foreach (char c in message)
        {
            if (IsWideChar(c)) width += 2;
            else width += 1;
        }
        return width;
    }

    private static bool IsWideChar(char c) => (c >= 0xAC00 && c <= 0xD7A3);

    public static void Sleep(int delay) { Thread.Sleep(delay); }

    public static Vector2 RandomCoordinates(SceneName sceneName, List<GameObject> gameObjects)
    {
        Random rand = new Random();
        Vector2 position = Vector2.Unit;

        do
        {
            position = new Vector2(
                rand.Next(1, GameManager.Instance.MazeSize[sceneName].X - 1),
                rand.Next(1, GameManager.Instance.MazeSize[sceneName].Y - 1)
            );
        } while (IsWallOrFieldObject(position, gameObjects));
        return position;
    }

    private static bool IsWallOrFieldObject(Vector2 position, List<GameObject> gameObjects)
    {
        if (GameManager.Map.MapTile[position.Y, position.X] == TileType.Wall) return true;

        // Object 체크
        foreach (var gameObject in gameObjects)
        {
            if (position == gameObject.Position) return true;
        }

        return false;
    }
}