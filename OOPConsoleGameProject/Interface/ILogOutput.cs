namespace OOPConsoleGameProject;

public interface ILogOutput
{
    void Log(List<string> messages, List<ConsoleColor> colors);
}