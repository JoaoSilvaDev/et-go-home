using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private UnityEvent onFinishCounter;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(time);
        onFinishCounter.Invoke();
    }
}
