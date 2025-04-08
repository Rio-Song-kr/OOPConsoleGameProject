namespace OOPConsoleGameProject;

public abstract class Scene
{
    public bool IsFirstLoad = true;

    public abstract void Render();
    public abstract void Input();
    public abstract void Update();
    public abstract void Result();

    public virtual void OnEnter() { }

    public virtual void OnExit() { }
}