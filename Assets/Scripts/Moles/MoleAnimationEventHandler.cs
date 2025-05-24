using UnityEngine;
using UnityEngine.Events;

public class MoleAnimationEventHandler : MonoBehaviour
{
    public UnityEvent OnRetracted;

    public void OnRetractDone()
    {
        OnRetracted?.Invoke();
    }
}
