namespace OOPConsoleGameProject;

public abstract class Place : GameObject
{
    private SceneName _scene;
    public SceneName SceneName { get => _scene; }

    public Place(SceneName scene, char symbol, Vector2 position) : base(ConsoleColor.Cyan, symbol, position, false)
    {
        _scene = scene;
    }
}