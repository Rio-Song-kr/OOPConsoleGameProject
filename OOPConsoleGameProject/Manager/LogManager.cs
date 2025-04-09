namespace OOPConsoleGameProject;

public class LogManager
{
    private static LogManager _instance;
    private ILogOutput _log;
    private const int MaxLogSize = 4;
    private List<string> _logMessages;
    private List<ConsoleColor> _colors;

    //# 의존성 역전 구현
    private LogManager(ILogOutput log)
    {
        _logMessages = new List<string>();
        _colors = new List<ConsoleColor>();
        _log = log;
    }

    public static LogManager GetInstance(ILogOutput log)
    {
        if (_instance == null)
        {
            _instance = new LogManager(log);
        }
        return _instance;
    }

    public void Log(string message, ConsoleColor color = ConsoleColor.White)
    {
        //todo list에 넣어야함
        //todo Max에 도달하면 앞에서부터 제거
        if (_logMessages.Count >= MaxLogSize)
        {
            _logMessages.RemoveAt(0);
            _colors.RemoveAt(0);
        }
        _logMessages.Add(message);
        _colors.Add(color);
        PrintLog();
    }

    public void PrintLog() { _log.Log(_logMessages, _colors); }
}