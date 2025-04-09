namespace OOPConsoleGameProject;

public class UIManager : ILogPrint, IItemPrint, IMapPrint, ITextPrint
{
    private static UIManager _instance;
    private RectanglePosition _mapPosition;
    private RectanglePosition _inventoryPosition;
    private RectanglePosition _logPosition;
    private Vector2 _mapStartOffset;
    public Vector2 MapStartOffset { get => _mapStartOffset; }
    private Vector2 _itemOffset;
    private Vector2 _logOffset;
    // private Vector2 _playerCoordinate;

    private UIManager()
    {
        _mapPosition = new RectanglePosition()
        {
            StartPosition = new Vector2(0, 0),
            EndPosition = new Vector2(65, 19)
        };
        _inventoryPosition = new RectanglePosition()
        {
            StartPosition = new Vector2(66, 0),
            EndPosition = new Vector2(73, 19)
        };
        _logPosition = new RectanglePosition()
        {
            StartPosition = new Vector2(0, 20),
            EndPosition = new Vector2(73, 26)
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
            _logPosition.StartPosition.X + 2,
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
        PrintLogText();
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

    private void PrintLogText()
    {
        Console.SetCursorPosition(_logOffset.X, _logOffset.Y - 1);
        Console.Write("LOG");
    }

    //! ITextPrint
    public void PrintTextAtCenter(string[] texts, bool isSequentially, int delay = 0)
    {
        ClearMapArea();
        int textCounts = texts.Length;
        int intervalY =
            (_mapPosition.EndPosition.Y - _mapPosition.StartPosition.Y - textCounts + 1) / (textCounts + 1);


        int yPosition = _mapPosition.StartPosition.Y + intervalY + 1 +
                        (intervalY == 1 ? 1 : textCounts == 3 ? -1 : 0);


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

    //! IMapPrint
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

    //! ILogPrint
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

    //! IItemPrint
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

    public void PrintItemInfo(Item item)
    {
        string[] descriptions = new string[item.Description.Count + 2];
        descriptions[0] = new string($"----------     {item.Name}     ----------");

        for (int i = 0; i < item.Description.Count; i++)
        {
            descriptions[i + 1] = item.Description[i];
        }
        descriptions[item.Description.Count + 1] = "맵으로 이동하려면 아무 키나 누르세요.";

        ClearMapArea();
        PrintTextAtCenter(descriptions, false);
    }
}