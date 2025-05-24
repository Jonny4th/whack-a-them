using UnityEngine;
using UnityEngine.EventSystems;

public class AnimatedMole : Mole, IPointerDownHandler
{
    [SerializeField]
    private GameObject m_MoleVisual;

    [SerializeField]
    private Collider2D m_Collider;

    private readonly IMoleState InactiveState = new InactiveState();
    private readonly IMoleState ActiveState = new ActiveState();
    private readonly IMoleState HitState = new BeingHitState();
    private readonly IMoleState CooldownState = new CooldownState();

    private void Awake()
    {
        _currentState = new InactiveState();
        _currentState.Enter(this);
    }

    public override void SetActiveVisual()
    {
        Activate();
    }

    public override void SetInactiveVisual()
    {
        Inactivate();
    }

    public override void SetHitVisual()
    {
        //testing purpose, you can replace this with an animation or visual effect
        Inactivate();
    }

    private void Activate()
    {
        m_MoleVisual.SetActive(true);
        m_Collider.enabled = true;
    }

    private void Inactivate()
    {
        m_MoleVisual.SetActive(false);
        m_Collider.enabled = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _currentState.HandleInteract(this);
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
