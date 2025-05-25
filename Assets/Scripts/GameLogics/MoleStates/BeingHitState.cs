using UnityEngine;
using WhackATham.Domain.Moles;

namespace WhackAThem.GameLogics.States
{
    public class BeingHitState : IMoleState
    {
        public MoleState State => MoleState.Hit;

        private const float m_HitAnimationTime = 0.5f; //Cooldown time in seconds.
        private float m_HitAnimationTimer = 0.0f;

        public void Enter(Mole mole)
        {
            mole.SetHitVisual();
            m_HitAnimationTimer = 0.0f;
        }

        public void Exit(Mole mole) { }

        public void HandleInteract(Mole mole) { }

        public void Update(Mole mole)
        {
            m_HitAnimationTimer += Time.deltaTime;

            if(m_HitAnimationTimer >= m_HitAnimationTime)
            {
                mole.SetState(MoleState.Cooldown);
            }
        }
    }
}