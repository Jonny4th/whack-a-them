using UnityEngine;

public class ActiveState : IMoleState
{
    public MoleState State => MoleState.Active;

    private const float m_ActiveTime = 2.0f; //Active time in seconds.
    private float m_ActiveTimer = 0.0f;

    public void Enter(Mole mole)
    {
        m_ActiveTimer = 0.0f;
        mole.SetActiveVisual();
    }
    public void Exit(Mole mole) { }

    public void HandleInteract(Mole mole)
    {
        mole.OnMoleHitEvent?.Invoke();
        mole.SetState(new BeingHitState());
    }

    public void Update(Mole mole)
    {
        m_ActiveTimer += Time.deltaTime;

        if(m_ActiveTimer >= m_ActiveTime)
        {
            mole.SetState(new InactiveState());
        }
    }
}
