namespace OOPConsoleGameProject;

public interface ILogPrint
{
    void Log(Queue<string> messages, Queue<ConsoleColor> colors);
}