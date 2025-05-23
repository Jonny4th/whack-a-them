public abstract class MoleStateBase
{
    public abstract void Enter(IMole mole);
    public abstract void Exit(IMole mole);
    public abstract void Update(IMole mole);
    public abstract void HandleInteract(IMole mole);
}
