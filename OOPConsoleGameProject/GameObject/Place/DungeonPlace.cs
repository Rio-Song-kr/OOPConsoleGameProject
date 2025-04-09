namespace OOPConsoleGameProject;

public class DungeonPlace : Place
{
    public DungeonPlace(SceneName scene, char symbol, Vector2 position) : base(scene, symbol, position) { }

    public override bool TryInteract(GameObject gameObject)
    {
        if (gameObject is not Player)
            return false;

        GameManager.Scene.Move(SceneName);
        return true;
    }
}