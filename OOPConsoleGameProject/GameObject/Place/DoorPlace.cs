namespace OOPConsoleGameProject;

public class DoorPlace : Place
{
    public DoorPlace(SceneName scene, Vector2 position) : base(scene, '◇', position) { }

    public override bool TryInteract(GameObject gameObject)
    {
        if (gameObject is not Player)
            return false;

        if (!GameManager.Inventory.IsExist(GameManager.ObjectPools.GetItem("Key")))
            return false;

        GameManager.Scene.Move(SceneName);
        GameManager.GamePlayer.Init();
        return true;
    }
}