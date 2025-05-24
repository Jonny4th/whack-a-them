using UnityEngine;
using UnityEngine.Events;

public class MoleAnimationEventHandler : MonoBehaviour
{
    public UnityEvent OnRetracted;

    public void OnRetractDone()
    {
        Debug.Log("Mole has retracted.");
        OnRetracted?.Invoke();
    }
}
