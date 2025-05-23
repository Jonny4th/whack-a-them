using UnityEngine;

public class BeingHitState : IMoleState
{
    public MoleState State => MoleState.Hit;

    private const float m_HitAnimationTime = 0.5f; //Cooldown time in seconds.
    private float m_HitTimer = 0.0f;
    public void Enter(Mole mole)
    {
        Debug.Log("hit");
        mole.SetHitVisual();
        m_HitTimer = 0.0f;
    }

    public void Exit(Mole mole) { }

    public void HandleInteract(Mole mole) { }

    public void Update(Mole mole)
    {
        m_HitTimer += Time.deltaTime;
        if(m_HitTimer >= m_HitAnimationTime)
        {
            mole.SetState(new InactiveState());
        }
    }
}
