namespace OOPConsoleGameProject;

public class UIManager : ILogOutput
{
    private static UIManager _instance;
    private RectanglePosition _mapPosition;
    private RectanglePosition _inventoryPosition;
    private RectanglePosition _logPosition;
    private Vector2 _mapStartOffset;
    public Vector2 MapStartOffset { get => _mapStartOffset; }
    private Vector2 _itemOffset;
    private Vector2 _logOffset;

    private UIManager()
    {
        _mapPosition = new RectanglePosition()
        {
            StartPosition = new Vector2(0, 0),
            EndPosition = new Vector2(65, 18)
        };
        _inventoryPosition = new RectanglePosition()
        {
            StartPosition = new Vector2(66, 0),
            EndPosition = new Vector2(73, 18)
        };
        _logPosition = new RectanglePosition()
        {
            StartPosition = new Vector2(0, 19),
            EndPosition = new Vector2(73, 25)
        };
        _itemOffset = new Vector2(
            (_inventoryPosition.StartPosition.X + _inventoryPosition.EndPosition.X) / 2 - 1,
            13
        );
        _mapStartOffset = new Vector2(
            _mapPosition.StartPosition.X + 1,
            _mapPosition.StartPosition.Y + 1
        );
        _logOffset = new Vector2(
            _logPosition.StartPosition.X + 1,
            _logPosition.StartPosition.Y + 2
        );

        Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
    }

    public static UIManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new UIManager();
        }

        return _instance;
    }

    public void RenderUI()
    {
        PrintOutline(_mapPosition);
        PrintOutline(_inventoryPosition);
        PrintOutline(_logPosition);
        PrintInventoryText();
    }

    private void PrintOutline(RectanglePosition position)
    {
        Console.SetCursorPosition(position.StartPosition.X, position.StartPosition.Y);

        Console.Write('┏');
        for (int i = position.StartPosition.X + 1; i < position.EndPosition.X - 1; i++)
        {
            Console.Write("━");
        }
        Console.Write('┓');

        Console.WriteLine();
        for (int i = position.StartPosition.Y + 1; i < position.EndPosition.Y; i++)
        {
            Console.SetCursorPosition(position.StartPosition.X, i);
            Console.Write("┃");
            for (int j = position.StartPosition.X + 1; j < position.EndPosition.X - 1; j++)
            {
                Console.Write(' ');
            }
            Console.WriteLine("┃");
        }

        Console.SetCursorPosition(position.StartPosition.X, position.EndPosition.Y);
        Console.Write('┗');
        for (int i = position.StartPosition.X + 1; i < position.EndPosition.X - 1; i++)
        {
            Console.Write("━");
        }
        Console.Write('┛');
        Console.WriteLine();
    }
    private void PrintInventoryText()
    {
        Vector2 startPosition =
            new Vector2(
                (_inventoryPosition.StartPosition.X + _inventoryPosition.EndPosition.X) / 2,
                2
            );
        string text = "INVENTORY";

        for (int i = 0; i < text.Length; i++)
        {
            Console.SetCursorPosition(startPosition.X, startPosition.Y + i);
            Console.Write(text[i]);
        }
        for (int i = 0; i < 3; i++)
        {
            Console.SetCursorPosition(startPosition.X - 1, startPosition.Y + i + text.Length + 2);
            Console.Write($"_ {i + 1}");
        }
    }

    //# 인벤토리에 아이템이 추가되면 출력
    public void PrintItem(Item item, int index)
    {
        Console.SetCursorPosition(_itemOffset.X, _itemOffset.Y + index);
        Console.Write(item.Symbol);
    }

    //# 인벤토리에서 아이템이 제거되면(또는 특정 아이템이 사용되면) 출력
    public void PrintEmptyItem(int index)
    {
        Console.SetCursorPosition(_itemOffset.X, _itemOffset.Y + index);
        Console.Write('_');
    }

    public void PrintTextAtCenter(string[] texts, bool isSequentially, int delay = 0)
    {
        ClearMapArea();
        int textCounts = texts.Length;
        int intervalY = (_mapPosition.EndPosition.Y - _mapPosition.StartPosition.Y - textCounts) / (textCounts + 1) + 1;
        int yPosition = _mapPosition.StartPosition.Y + intervalY;

        for (int i = 0; i < textCounts; i++)
        {
            int length = Util.GetMessageWidth(texts[i]);
            int intervalX = (_mapPosition.EndPosition.X - _mapPosition.StartPosition.X - length) / 2;

            Console.SetCursorPosition(intervalX, yPosition);

            if (isSequentially) Util.PrintCharacterSequentially(texts[i], delay: delay);
            else Util.PrintConsole((texts[i]));

            yPosition += intervalY + 1;
        }
    }

    public void PrintMap(string[] map, Vector2 mapSize)
    {
        int xPosition = _mapPosition.StartPosition.X + _mapStartOffset.X;
        int yPosition = _mapPosition.StartPosition.Y + _mapStartOffset.Y;

        for (int y = 0; y < mapSize.Y; y++)
        {
            if (y >= _mapPosition.EndPosition.Y - 1)
                break;
            Console.SetCursorPosition(xPosition, yPosition + y);
            for (int x = 0; x < mapSize.X; x++)
            {
                if (x >= _mapPosition.EndPosition.X - 1)
                    break;
                Console.Write(map[y][x]);
            }
        }
    }

    public void ClearMapArea()
    {
        int startXPosition = _mapPosition.StartPosition.X + _mapStartOffset.X;
        for (int y = _mapPosition.StartPosition.Y + _mapStartOffset.Y; y < _mapPosition.EndPosition.Y; y++)
        {
            Console.SetCursorPosition(startXPosition, y);
            for (int x = startXPosition; x < _mapPosition.EndPosition.X - 1; x++)
            {
                Console.Write(' ');
            }
        }
    }

    public void Log(List<string> messages, List<ConsoleColor> color)
    {
        for (int i = 0; i < messages.Count; i++)
        {
            int length = _logPosition.EndPosition.X - 1 - _logOffset.X - Util.GetMessageWidth(messages[i]);
            Console.SetCursorPosition(_logOffset.X, _logOffset.Y + i);
            string message = $"{messages[i]}{new string(' ', Math.Max(0, length))}";
            Util.PrintConsole(message, textColor: color[i]);
        }
    }
}