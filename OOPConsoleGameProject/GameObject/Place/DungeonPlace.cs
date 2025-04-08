namespace OOPConsoleGameProject;

public class DungeonPlace : Place
{
    public DungeonPlace(SceneName scene, char symbol, Vector2 position) : base(scene, symbol, position) { }

    public override void Interact(GameObject gameObject)
    {
        if (gameObject is Player)
        {
            //todo 플레이어와 겹쳤을 때 Level에 맞는 던전으로 이동
            GameManager.Scene.Move(SceneName);
        }
    }
}