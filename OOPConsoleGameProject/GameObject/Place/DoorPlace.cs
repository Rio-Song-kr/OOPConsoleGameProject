namespace OOPConsoleGameProject;

public class DoorPlace : Place
{
    public DoorPlace(SceneName scene, Vector2 position) : base(scene, '◇', position) { }

    public override void Interact(GameObject gameObject)
    {
        if (gameObject is Player)
        {
            //todo 플레이어가 접촉했으면서, 인벤토리에 열쇠가 있다면 다음 맵으로 이동
            //todo 테스트를 위해 키 없이 다음 맵으로 이동
            if (GameManager.Inventory.IsExist(GameManager.ObjectPools.GetItem("Key")))
                GameManager.Scene.Move(SceneName);
        }
    }
}