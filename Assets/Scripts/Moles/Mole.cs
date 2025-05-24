using UnityEngine;
using UnityEngine.Events;

public enum MoleState
{
    Inactive,
    Active,
    Hit,
    Cooldown,
}

public abstract class Mole : MonoBehaviour
{
    public virtual MoleState CurrentState => _currentState.State;
    public UnityEvent OnMoleHitEvent;
    protected IMoleState _currentState;

    protected virtual void Update()
    {
        _currentState.Update(this);
    }

    public virtual void SetState(MoleState stateEnum)
    {

        _currentState?.Exit(this);
        _currentState = GetConcreteState(stateEnum);
        _currentState.Enter(this);
    }

    public abstract void SetActiveVisual();
    public abstract void SetHitVisual();
    public abstract void SetInactiveVisual();
    protected abstract IMoleState GetConcreteState(MoleState stateEnum);
}
