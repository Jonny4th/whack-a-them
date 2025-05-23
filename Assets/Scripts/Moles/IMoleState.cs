public interface IMoleState
{
    void Enter(Mole mole);
    void Exit(Mole mole);
    void Update(Mole mole);
    void HandleInteract(Mole mole);
}
