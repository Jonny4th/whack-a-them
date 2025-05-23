public class InactiveState : MoleStateBase
{
    public override void Enter(IMole mole)
    {
        mole.SetInactiveVisual();
    }

    public override void Exit(IMole mole) { }

    public override void HandleInteract(IMole mole) { }

    public override void Update(IMole mole) { }
}
