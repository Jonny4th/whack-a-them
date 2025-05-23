using UnityEngine;

public class ActiveState : MoleStateBase
{
    private const float m_ActiveTime = 2.0f; //Active time in seconds.
    private float m_ActiveTimer = 0.0f;

    public override void Enter(IMole mole)
    {
        m_ActiveTimer = 0.0f;
        mole.SetActiveVisual();
    }
    public override void Exit(IMole mole) { }

    public override void HandleInteract(IMole mole)
    {
        mole.SetHitVisual();
    }

    public override void Update(IMole mole)
    {
        m_ActiveTimer += Time.deltaTime;

        if(m_ActiveTimer >= m_ActiveTime)
        {
            mole.SetState(new InactiveState());
        }
    }
}
