namespace OOPConsoleGameProject;

public static class Util
{
    public static void PrintConsole(string message, ConsoleColor textColor = ConsoleColor.White, int delay = 0,
        ConsoleColor backgroundColor = ConsoleColor.Black)
    {
        Console.BackgroundColor = backgroundColor;
        Console.ForegroundColor = textColor;
        Console.WriteLine(message);
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
        Console.WriteLine();
    }

    public static void Sleep(int delay) { Thread.Sleep(delay); }
}