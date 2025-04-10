using System.Reflection.Metadata.Ecma335;

namespace OOPConsoleGameProject;

public class UIManager : ILogPrint, IItemPrint, IMapPrint, ITextPrint, IGameObjectPrint
{
    private static UIManager _instance;
    private RectanglePosition _mapPosition;
    private RectanglePosition _inventoryPosition;
    private RectanglePosition _logPosition;
    private Vector2 _mapStartOffset;
    public Vector2 MapStartOffset { get => _mapStartOffset; }
    private Vector2 _itemOffset;
    private Vector2 _logOffset;
    private Vector2 _mapCenter;
    private RenderArea _renderArea;
    private Vector2 _moveOffset;
    private int MapXOffset = 10;
    // private Vector2 _playerCoordinate;

    private UIManager()
    {
        _mapPosition = new RectanglePosition()
        {
            StartPosition = new Vector2(0, 0),
            EndPosition = new Vector2(65, 19)
        };
        _mapStartOffset = new Vector2(
            _mapPosition.StartPosition.X + 1,
            _mapPosition.StartPosition.Y + 1
        );
        _mapCenter = new Vector2(
            (_mapPosition.EndPosition.X - _mapPosition.StartPosition.X) / 2,
            (_mapPosition.EndPosition.Y - _mapPosition.StartPosition.Y) / 2
        );
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
        _logOffset = new Vector2(
            _logPosition.StartPosition.X + 2,
            _logPosition.StartPosition.Y + 2
        );
        _moveOffset = new Vector2(0, 0);

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

    private void CalculatePosition(string[] texts, out int textCounts, out int intervalY, out int yPosition)
    {
        textCounts = texts.Length;
        intervalY = (_mapPosition.EndPosition.Y - _mapPosition.StartPosition.Y - textCounts + 1) / (textCounts + 1);


        yPosition = _mapPosition.StartPosition.Y + intervalY + 1 +
                    (intervalY == 1 ? 1 : textCounts == 3 ? -1 : 0);
    }

    //! ITextPrint
    public void PrintTextAtCenter(string[] texts, bool isSequentially, int delay = 0)
    {
        ClearMapArea();
        CalculatePosition(texts, out int textCounts, out int intervalY, out int yPosition);


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

    //todo 추후 다른 작업 완료 후 구현
    /*
    public void PrintChest(char[] message, Vector2 position)
    {
        char[,] arrows = new char[,]
        {
            { '○', '○', '○', '○' },
            { ' ', ' ', ' ', ' ' },
            { '○', '○', '○', '○' }
        };

        for (int i = 0; i < message.Length; i++)
        {
            arrows[1, i] = message[i];
        }

        char selected = '●';

        if (position.Y == 0 || position.Y == 1) arrows[position.Y, position.X] = selected;

        string[] descriptions = new string[4];
        descriptions[3] = "E  n  t  e  r";

        int rowCount = arrows.GetLength(0);
        int columnCount = arrows.GetLength(1);

        for (int i = 0; i < rowCount; i++)
        {
            char[] rowChars = new char[columnCount * 4];
            for (int j = 0; j < columnCount; j++)
            {
                rowChars[j * 4] = arrows[i, j];
                if (j != columnCount - 1)
                {
                    rowChars[j * 4 + 1] = ' ';
                    rowChars[j * 4 + 2] = ' ';
                    rowChars[j * 4 + 3] = ' ';
                }
            }
            descriptions[i] = new string(rowChars);
        }

        PrintChestText(descriptions, position);
    }

    private void PrintChestText(string[] texts, Vector2 position)
    {
        ClearMapArea();
        CalculatePosition(texts, out int textCounts, out int intervalY, out int yPosition);

        for (int i = 0; i < textCounts; i++)
        {
            int length = Util.GetMessageWidth(texts[i]);
            int intervalX = (_mapPosition.EndPosition.X - _mapPosition.StartPosition.X - length) / 2;

            Console.SetCursorPosition(intervalX, yPosition);

            if (position.Y == 3 && i == 3)
            {
                Util.PrintConsole(texts[i], backgroundColor: ConsoleColor.Gray, textColor: ConsoleColor.Black);
            }
            else Util.PrintConsole(texts[i]);

            yPosition += intervalY + 1;
        }

        // (0,0) (1,0) (2,0) (3,0)
        //   △     △     △     △
        //         message
        // (0,1) (1,1) (2,1) (3,1)
        //   ▽     ▽     ▽     ▽
        // (x,2)
        //      E N T E R
    }
    */

    //! IMapPrint
    public void PrintMap(TileType[,] mapTile, Vector2 mapSize)
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

                if (mapTile[y, x] == TileType.Wall) Console.Write(Maze.Wall);
                else Console.Write(' ');
            }
        }
    }

    public void PrintLimitedSightMap(TileType[,] mapTile, Vector2 mapSize, RenderArea renderArea)
    {
        _renderArea = renderArea;
        (int renderXSize, int renderYSize) = _renderArea switch
        {
            RenderArea.Render7x3 => (7, 3),
            RenderArea.Render11x5 => (11, 5),
            RenderArea.Render15x7 => (15, 7),
            RenderArea.Render19x9 => (19, 9),
            RenderArea.Render23x11 => (23, 11),
            RenderArea.Render27x13 => (27, 13),
            RenderArea.Render31x15 => (31, 15),
        };
        MapXOffset = renderXSize / 2;

        int xPosition = _mapCenter.X;
        int yPosition = _mapCenter.Y;

        int halfXRenderSize = renderXSize / 2;
        int halfYRenderSize = renderYSize / 2;
        for (int y = -halfYRenderSize - 1; y <= halfYRenderSize + 1; y++)
        {
            //# MapXOffset는 현재 중앙 출력이 아닌 것으로 보여져 offset 값으로 추가함
            Console.SetCursorPosition(xPosition - renderXSize + MapXOffset, yPosition + y);
            for (int x = -halfXRenderSize - 1; x <= halfXRenderSize + 1; x++)
            {
                int xPos = x + GameManager.GamePlayer.Position.X;
                int yPos = y + GameManager.GamePlayer.Position.Y;
                if (xPos < 0 || yPos < 0 || xPos >= mapTile.GetLength(1) || yPos >= mapTile.GetLength(0))
                {
                    Util.PrintConsole(' ', backgroundColor: ConsoleColor.DarkGray, textColor: ConsoleColor.DarkGreen);
                    continue;
                }
                if (x == -halfXRenderSize - 1 || x == halfXRenderSize + 1 ||
                    y == -halfYRenderSize - 1 || y == halfYRenderSize + 1)
                {
                    Util.PrintConsole(' ', backgroundColor: ConsoleColor.DarkGray, textColor: ConsoleColor.DarkGreen);
                    continue;
                }

                if (mapTile[yPos, xPos] == TileType.Wall)
                    Util.PrintConsole(Maze.Wall, backgroundColor: ConsoleColor.White, textColor: ConsoleColor.DarkRed);
                else
                    Util.PrintConsole(' ', backgroundColor: ConsoleColor.Black, textColor: ConsoleColor.DarkBlue);
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

    //! IGameObjectPrint
    public void PrintObject(GameObject gameObject)
    {
        (int renderXSize, int renderYSize) = _renderArea switch
        {
            RenderArea.Render7x3 => (7, 3),
            RenderArea.Render11x5 => (11, 5),
            RenderArea.Render15x7 => (15, 7),
            RenderArea.Render19x9 => (19, 9),
            RenderArea.Render23x11 => (23, 11),
            RenderArea.Render27x13 => (27, 13),
            RenderArea.Render31x15 => (31, 15),
        };

        //# 나누기 오차 보정으로 + 1
        int halfXRenderSize = renderXSize / 2 + 1;
        int halfYRenderSize = renderYSize / 2;

        if (gameObject is Player)
        {
            //# Player는 Center에 고정
            //# MapXOffset는 현재 중앙 출력이 아닌 것으로 보여져 offset 값으로 추가함
            Console.SetCursorPosition(_mapCenter.X - halfXRenderSize + 1 + MapXOffset, _mapCenter.Y);
        }
        else
        {
            _moveOffset = GameManager.GamePlayer.Position - Vector2.Unit;

            int xPos = gameObject.Position.X + _mapCenter.X - halfXRenderSize - _moveOffset.X;
            int yPos = gameObject.Position.Y + _mapCenter.Y - 1 - _moveOffset.Y;


            if (xPos < 0 || xPos >= _mapPosition.EndPosition.X || yPos < 0 || yPos > _mapPosition.EndPosition.Y)
                return;

            Vector2 playerPosition = new Vector2(_mapCenter.X - halfXRenderSize + 1, _mapCenter.Y);

            if (xPos < playerPosition.X - halfXRenderSize + 1 ||
                xPos > playerPosition.X + halfXRenderSize - 1 ||
                yPos < playerPosition.Y - halfYRenderSize + 1 ||
                yPos > playerPosition.Y + halfYRenderSize - 1)
                return;

            //# MapXOffset는 현재 중앙 출력이 아닌 것으로 보여져 offset 값으로 추가함
            Console.SetCursorPosition(xPos + MapXOffset, yPos);
        }
        Console.ForegroundColor = gameObject.Color;
        Console.Write(gameObject.Symbol);
        Console.ResetColor();
    }
}