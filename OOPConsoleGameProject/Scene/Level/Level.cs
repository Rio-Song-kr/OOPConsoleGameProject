using System.Diagnostics;

namespace OOPConsoleGameProject;

public class Level : Scene
{
    public override void Input() { GameManager.Input.GetKey(); }

    public override void Update()
    {
        foreach (var gameObject in GameObjects)
        {
            if (GameManager.GamePlayer.Position == gameObject.Position)
            {
                gameObject.TryInteract(GameManager.GamePlayer);

                if (gameObject is Item item)
                {
                    if (item == null || !GameManager.Inventory.IsExist(item))
                    {
                        GameManager.Inventory.IsFull();
                        continue;
                    }
                    ObjectsPosition.Remove(gameObject.Position);
                    GameObjects.Remove(gameObject);
                    break;
                }

                if (gameObject is Chest chest)
                {
                    ConsoleKey input = ConsoleKey.None;
                    bool isPassed = false;
                    GameManager.ObjectPools.IsChestOpened = true;

                    while (input != ConsoleKey.Q && !isPassed)
                    {
                        input = GameManager.Input.GetKey();

                        switch (input)
                        {
                            case ConsoleKey.UpArrow:
                            case ConsoleKey.DownArrow:
                            case ConsoleKey.LeftArrow:
                            case ConsoleKey.RightArrow:
                                chest.ChangePosition(input);
                                break;
                            case ConsoleKey.Enter:
                                chest.ChangePassword();
                                break;
                            case ConsoleKey.Spacebar:
                                isPassed = chest.CheckPassword();
                                if (isPassed)
                                    GameManager.Inventory.Add(GameManager.ObjectPools.GetItem("Key"));
                                GameObjects.Remove(gameObject);
                                GameManager.Map.ClearMap();
                                GameManager.ObjectPools.IsChestOpened = false;
                                return;
                        }
                        GameManager.Map.ClearMap();
                        GameManager.ObjectPools.IsChestOpened = false;
                        //todo 문제점 : 만약 힌트를 얻기 전에 상자를 만난다면, 더 이상 진행할 수 없음
                        //todo 임시로 Peek처리를 했지만, TryInteract(); 토글식으로 확인을 해야할 듯
                        //todo 겹치면 off하여 더 이상 실행 X -> 벗어나면 ON하여 다시 겹쳤을 때 실행
                        GameManager.GamePlayer.SetPosition(GameManager.GamePlayer.PassedRoad.Peek());
                    }
                }
            }
        }
    }

    public override void Result() { }
}