using UnityEngine;
using UnityEngine.EventSystems;
using WhackATham.Domain.Moles;
using WhackAThem.GameLogics.States;

namespace WhackATham.GameLogics.Moles
{
    public class PrimitiveMole : Mole, IPointerDownHandler
    {
        [SerializeField]
        private SpriteRenderer m_Visual;

        [SerializeField]
        private Color m_InactiveColor = Color.black;

        [SerializeField]
        private Color m_ActiveColor = Color.yellow;

        [SerializeField]
        private Color m_HitColor = Color.green;

        private readonly IMoleState InactiveState = new InactiveState();
        private readonly IMoleState ActiveState = new ActiveState();
        private readonly IMoleState HitState = new BeingHitState();
        private readonly IMoleState CooldownState = new CooldownState();

        private void Awake()
        {
            _currentState = new InactiveState();
            _currentState.Enter(this);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _currentState.HandleInteract(this);
        }

        public override void SetActiveVisual()
        {
            m_Visual.color = m_ActiveColor;
        }

        public override void SetHitVisual()
        {
            m_Visual.color = m_HitColor;
        }

        public override void SetInactiveVisual()
        {
            m_Visual.color = m_InactiveColor;
        }

        protected override IMoleState GetConcreteState(MoleState stateEnum)
        {
            return stateEnum switch
            {
                MoleState.Inactive => InactiveState,
                MoleState.Active => ActiveState,
                MoleState.Hit => HitState,
                MoleState.Cooldown => CooldownState,
                _ => InactiveState,
            };
        }
    }
}