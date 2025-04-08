namespace OOPConsoleGameProject;

public abstract class Place : GameObject
{
    private string _scene;

    public Place(string scene, char symbol, Vector2 position) : base(ConsoleColor.Yellow, symbol, position)
    {
        _scene = _scene;
    }
}