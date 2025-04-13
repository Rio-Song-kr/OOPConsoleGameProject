namespace OOPConsoleGameProject;

public class Chest : FieldObject
{
    private static int _chestIndex = 0;
    private char[] _password;
    private char[] _inputPassword;
    private Vector2 _selectedPos = new Vector2(0, 0);
    private ChestType _chestType;

    public Chest(
        string name,
        Vector2 position,
        char[] password,
        char[] inputPassword,
        ChestType chestType,
        ConsoleColor color = ConsoleColor.Blue)
        : base(color, '▣', position)
    {
        Name = name;
        Index = _chestIndex++;
        _password = password;
        _inputPassword = inputPassword;
        _chestType = chestType;
    }

    public override bool TryInteract(GameObject gameObject)
    {
        if (gameObject is not Player player)
            return false;

        Print();

        return true;
    }

    private void Print()
    {
        if (_chestType == ChestType.LetterChest)
            GameManager.UI.PrintChest($"{new string(_inputPassword)}", _selectedPos);
        else
            GameManager.UI.PrintChest($"{_inputPassword}", _selectedPos);
    }

    public void ChangePassword()
    {
        switch (_chestType)
        {
            case ChestType.LetterChest:
                ChangeLetterChestPassword();
                break;
            case ChestType.MusicBoxChest:
                ChangeMusicBoxChestPassword();
                break;
        }
    }

    private void ChangeLetterChestPassword()
    {
        int password = Int32.Parse(_inputPassword);
        int xPos = _selectedPos.X;
        int number = _inputPassword[xPos] - '0' + (_selectedPos.Y == 0 ? 1 : -1);

        if (number > 9) number = 0;
        else if (number < 0) number = 9;

        _inputPassword[xPos] = (char)(number + '0');

        GameManager.UI.PrintChest($"{new string(_inputPassword)}", _selectedPos);
    }

    private void ChangeMusicBoxChestPassword()
    {
        //todo MusicBox에 대한 처리가 필요함
        GameManager.UI.PrintChest($"{_inputPassword}", _selectedPos);
    }

    public void ChangePosition(ConsoleKey input)
    {
        switch (input)
        {
            case ConsoleKey.UpArrow:
                _selectedPos += Vector2.Up;
                break;
            case ConsoleKey.DownArrow:
                _selectedPos += Vector2.Down;
                break;
            case ConsoleKey.LeftArrow:
                _selectedPos += Vector2.Left;
                break;
            case ConsoleKey.RightArrow:
                _selectedPos += Vector2.Right;
                break;
        }

        if (_selectedPos.X < 0) _selectedPos.X = 3;
        else if (_selectedPos.X > 3) _selectedPos.X = 0;
        else if (_selectedPos.Y < 0) _selectedPos.Y = 1;
        else if (_selectedPos.Y > 1) _selectedPos.Y = 0;

        Print();
    }

    public bool CheckPassword()
    {
        switch (_chestType)
        {
            case ChestType.LetterChest:
                string inputPassword = new string(_inputPassword);
                string password = new string(_password);
                return inputPassword.Equals(password);
            case ChestType.MusicBoxChest:
                break;
        }
        return false;
    }
}