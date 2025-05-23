public class InactiveState : IMoleState
{
    public void Enter(Mole mole)
    {
        mole.SetInactiveVisual();
    }

    public void Exit(Mole mole) { }

    public void HandleInteract(Mole mole) { }

    public void Update(Mole mole) { }
}
