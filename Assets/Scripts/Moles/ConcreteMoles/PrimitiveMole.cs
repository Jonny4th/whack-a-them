using UnityEngine;
using UnityEngine.EventSystems;

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
}
