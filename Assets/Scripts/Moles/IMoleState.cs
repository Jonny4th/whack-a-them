namespace WhackATham.Domain.Moles
{
    public interface IMoleState
    {
        MoleState State { get; }
        void Enter(Mole mole);
        void Exit(Mole mole);
        void Update(Mole mole);
        void HandleInteract(Mole mole);
    }
}