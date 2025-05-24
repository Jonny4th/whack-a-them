using UnityEngine;

public class CooldownState : IMoleState
{
    public MoleState State => MoleState.Cooldown;

    private const float m_CooldownTime = 1.0f; //Cooldown time in seconds.
    private float m_CooldownTimer = 0.0f;

    public void Enter(Mole mole)
    {
        m_CooldownTimer = 0.0f;
        mole.SetInactiveVisual(); //for testing purpose, you can replace this with an animation or visual effect
    }

    public void Exit(Mole mole)
    {
    }

    public void HandleInteract(Mole mole) { }

    public void Update(Mole mole)
    {
        m_CooldownTimer += Time.deltaTime;

        if(m_CooldownTimer >= m_CooldownTime)
        {
            mole.SetState(MoleState.Inactive);
        }
    }
}

