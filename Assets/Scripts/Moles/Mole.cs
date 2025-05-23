using UnityEngine;

public abstract class Mole : MonoBehaviour
{
    public abstract void SetActiveVisual();
    public abstract void SetHitVisual();
    public abstract void SetInactiveVisual();
    public abstract void SetState(IMoleState stateBase);
}
