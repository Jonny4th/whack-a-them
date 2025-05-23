using UnityEngine;

public class BeingHitState : MoleStateBase
{
    private const float m_HitAnimationTime = 0.5f; //Cooldown time in seconds.
    private float m_HitTimer = 0.0f;
    public override void Enter(IMole mole)
    {
        Debug.Log("hit");

        m_HitTimer = 0.0f;
        mole.SetHitVisual();
    }

    public override void Exit(IMole mole) { }

    public override void HandleInteract(IMole mole) { }

    public override void Update(IMole mole)
    {
        m_HitTimer += Time.deltaTime;
        if(m_HitTimer >= m_HitAnimationTime)
        {
            mole.SetState(new InactiveState());
        }
    }
}
