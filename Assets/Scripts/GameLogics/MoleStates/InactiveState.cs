using WhackATham.Domain.Moles;

namespace WhackAThem.GameLogics.States
{
    public class InactiveState : IMoleState
    {
        public MoleState State => MoleState.Inactive;

        public void Enter(Mole mole)
        {
            mole.SetInactiveVisual();
        }

        public void Exit(Mole mole) { }

        public void HandleInteract(Mole mole) { }

        public void Update(Mole mole) { }
    }
}