namespace OOPConsoleGameProject;

public class StartScene : Scene
{
    public static SceneName Name;

    public StartScene()
    {
        Name = SceneName.Start;
    }

    public override void Render()
    {
        Console.WriteLine("***********************");
        Console.WriteLine("***** Start Scene *****");
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
        GameManager.Scene.Move(SceneName.End);
    }
}