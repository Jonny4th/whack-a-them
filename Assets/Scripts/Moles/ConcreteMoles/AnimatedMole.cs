using UnityEngine;
using UnityEngine.EventSystems;

public class AnimatedMole : Mole, IPointerDownHandler
{
    [SerializeField]
    private GameObject m_MoleVisual;

    [SerializeField]
    private Collider2D m_Collider;

    [SerializeField]
    private Animator m_MoleAnimator;

    [SerializeField]
    private MoleAnimationEventHandler m_MoleAnimationEventHandler;

    [SerializeField]
    private string m_HitTriggerName = "HitTrigger";

    [SerializeField]
    private string m_HideTriggerName = "HideTrigger";

    private readonly IMoleState InactiveState = new InactiveState();
    private readonly IMoleState ActiveState = new ActiveState();
    private readonly IMoleState HitState = new BeingHitState();
    private readonly IMoleState CooldownState = new CooldownState();

    private void Awake()
    {
        _currentState = new InactiveState();
        _currentState.Enter(this);
    }

    private void OnEnable()
    {
        m_MoleAnimationEventHandler.OnRetracted.AddListener(HandleMoleRetracted);
    }

    private void OnDisable()
    {
        m_MoleAnimationEventHandler.OnRetracted.RemoveListener(HandleMoleRetracted);
    }

    public override void SetActiveVisual()
    {
        Activate();
    }

    public override void SetInactiveVisual()
    {
        m_MoleAnimator.SetTrigger(m_HideTriggerName);
    }

    public override void SetHitVisual()
    {
        m_MoleAnimator.SetTrigger(m_HitTriggerName);
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

    private void HandleMoleRetracted()
    {
        Inactivate();
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
