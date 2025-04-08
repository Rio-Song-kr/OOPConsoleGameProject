namespace OOPConsoleGameProject;

public class EndScene : Scene
{
    public static SceneName Name;

    public EndScene()
    {
        Name = SceneName.End;
    }

    public override void Render()
    {
        Console.WriteLine("***********************");
        Console.WriteLine("****** End Scene ******");
        Console.WriteLine("***********************");
    }

    public override void Input()
    {
        Console.ReadKey(true);
    }

    public override void Update()
    {
    }

    public override void Result()
    {
        GameManager.Scene.Move(SceneName.Start);
    }
}