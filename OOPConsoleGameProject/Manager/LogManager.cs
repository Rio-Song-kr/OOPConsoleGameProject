namespace OOPConsoleGameProject;

public class LogManager
{
    private static LogManager _instance;
    private ILogPrint _log;
    private const int MaxLogSize = 4;
    private Queue<string> _logMessages;
    private Queue<ConsoleColor> _colors;

    //# 의존성 역전 구현
    private LogManager(ILogPrint log)
    {
        _logMessages = new Queue<string>();
        _colors = new Queue<ConsoleColor>();
        _log = log;
    }

    public static LogManager GetInstance(ILogPrint log)
    {
        if (_instance == null)
        {
            _instance = new LogManager(log);
        }
        return _instance;
    }

    public void Log(string message, ConsoleColor color = ConsoleColor.White)
    {
        if (_logMessages.Count >= MaxLogSize)
        {
            _logMessages.Dequeue();
            _colors.Dequeue();
        }
        _logMessages.Enqueue(message);
        _colors.Enqueue(color);
        PrintLog();
    }

    private void PrintLog() { _log.Log(_logMessages, _colors); }
}