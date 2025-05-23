using UnityEngine;
using UnityEngine.Events;

public enum MoleState
{
    Inactive,
    Active,
    Hit
}

public abstract class Mole : MonoBehaviour
{
    public abstract MoleState CurrentState { get; }
    public UnityEvent OnMoleHitEvent;
    public abstract void SetActiveVisual();
    public abstract void SetHitVisual();
    public abstract void SetInactiveVisual();
    public abstract void SetState(IMoleState stateBase);
}
