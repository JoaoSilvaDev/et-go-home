using UnityEngine;
using UnityEngine.Events;

public class Placeable : MonoBehaviour
{
    [SerializeField] private UnityEvent onStartMoving;
    [SerializeField] private UnityEvent onPlace;

    public void SetMoving()
    {
        onStartMoving.Invoke();
    }

    public void Place()
    {
        onPlace.Invoke();
    }
}
