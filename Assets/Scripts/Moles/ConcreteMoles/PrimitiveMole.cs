using UnityEngine;
using UnityEngine.EventSystems;

public class PrimitiveMole : MonoBehaviour, IMole, IPointerDownHandler
{
    [SerializeField]
    private SpriteRenderer m_Visual;

    [SerializeField]
    private Color m_InactiveColor = Color.black;

    [SerializeField]
    private Color m_ActiveColor = Color.yellow;

    [SerializeField]
    private Color m_HitColor = Color.green;

    private MoleStateBase m_CurrentState;

    private void Awake()
    {
        m_CurrentState = new InactiveState();
        m_CurrentState.Enter(this);
    }

    private void Update()
    {
        m_CurrentState.Update(this);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        m_CurrentState.HandleInteract(this);
    }

    public void SetState(MoleStateBase stateBase)
    {
        m_CurrentState?.Exit(this);
        m_CurrentState = stateBase;
        m_CurrentState.Enter(this);
    }

    public void SetActiveVisual()
    {
        m_Visual.color = m_ActiveColor;
    }

    public void SetHitVisual()
    {
        m_Visual.color = m_HitColor;
    }

    public void SetInactiveVisual()
    {
        m_Visual.color = m_InactiveColor;
    }
}
