using UnityEngine;

public class BeingHitState : IMoleState
{
    private const float m_HitAnimationTime = 0.5f; //Cooldown time in seconds.
    private float m_HitTimer = 0.0f;
    public void Enter(Mole mole)
    {
        Debug.Log("hit");

        m_HitTimer = 0.0f;
        mole.SetHitVisual();
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
